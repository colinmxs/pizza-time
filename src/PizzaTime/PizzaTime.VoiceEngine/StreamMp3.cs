using NAudio.Wave;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaTime.VoiceEngine
{
    public class StreamMp3
    {
        private BufferedWaveProvider bufferedWaveProvider;
        private IWavePlayer waveOut;
        public bool IsReadyToPlay => bufferedWaveProvider != null;

        public async Task StartBuffering(Stream stream)
        {
            //bufferedWaveProvider = null;
            await Task.Run(() => 
            {
                var buffer = new byte[16384 * 4]; // needs to be big enough to hold a decompressed frame

                IMp3FrameDecompressor decompressor = null;
                try
                {
                    using (var responseStream = stream)
                    {
                        var readFullStream = new ReadFullStream(responseStream);

                        do
                        {
                            if (IsBufferNearlyFull)
                                Thread.Sleep(500);
                            else
                            {
                                Mp3Frame frame;
                                try
                                {
                                    frame = Mp3Frame.LoadFromStream(readFullStream);
                                }
                                catch (EndOfStreamException)
                                {
                                    break;
                                }
                                if (frame == null)
                                    break;
                                if (decompressor == null)
                                {
                                    decompressor = CreateFrameDecompressor(frame);
                                    bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                                    bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(20);
                                    bufferedWaveProvider.ReadFully = false;
                                }
                                if (frame != null)
                                {
                                    int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                                    bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                                }
                                //Thread.Sleep(500);
                            }
                        } while (true);
                        decompressor.Dispose();
                    }
                }
                finally
                {
                    if (decompressor != null)
                    {
                        decompressor.Dispose();
                    }
                }
            });            
        }

        public async Task StartPlaying() 
        {
            await Task.Run(() => 
            {
                if (waveOut == null)
                {
                    waveOut = new WaveOutEvent();
                    waveOut.Init(bufferedWaveProvider);
                }
                if (waveOut.PlaybackState != PlaybackState.Playing)
                    waveOut.Play();
                do
                {
                    Thread.Sleep(500);
                }
                while (waveOut.PlaybackState == PlaybackState.Playing);
            });            
        }

        private static IMp3FrameDecompressor CreateFrameDecompressor(Mp3Frame frame)
        {
            WaveFormat waveFormat = new Mp3WaveFormat(frame.SampleRate, frame.ChannelMode == ChannelMode.Mono ? 1 : 2,
                frame.FrameLength, frame.BitRate);
            return new AcmMp3FrameDecompressor(waveFormat);
        }

        private bool IsBufferNearlyFull
        {
            get
            {
                return bufferedWaveProvider != null &&
                       bufferedWaveProvider.BufferLength - bufferedWaveProvider.BufferedBytes
                       < bufferedWaveProvider.WaveFormat.AverageBytesPerSecond / 4;
            }
        }
    }
}
