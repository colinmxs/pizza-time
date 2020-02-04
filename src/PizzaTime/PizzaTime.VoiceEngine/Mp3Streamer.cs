using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaTime.VoiceEngine
{
    public class Mp3Streamer
    {        
        private BufferedWaveProvider bufferedWaveProvider;
        private IWavePlayer waveOut;

        public async Task StreamMp3(Stream stream)
        {            
            var buffer = new byte[16384 * 8]; // needs to be big enough to hold a decompressed frame

            IMp3FrameDecompressor decompressor = null;
            try
            {
                using (var responseStream = stream)
                {
                    var readFullyStream = new ReadFullStream(responseStream);
                    bool killFlag = false;
                    do
                    {
                        if (IsBufferNearlyFull)
                            Thread.Sleep(500);
                        else
                        {
                            Mp3Frame frame;
                            try
                            {
                                frame = Mp3Frame.LoadFromStream(readFullyStream);
                            }
                            catch (EndOfStreamException)
                            {
                                break;
                            }
                            if (frame == null)
                                killFlag = true;
                            if (decompressor == null)
                            {
                                decompressor = CreateFrameDecompressor(frame);
                                bufferedWaveProvider = new BufferedWaveProvider(decompressor.OutputFormat);
                                bufferedWaveProvider.BufferDuration = TimeSpan.FromSeconds(20);
                            }
                            if (frame != null) 
                            {
                                int decompressed = decompressor.DecompressFrame(frame, buffer, 0);
                                bufferedWaveProvider.AddSamples(buffer, 0, decompressed);
                            }                            
                        }

                        if (waveOut == null)
                        {
                            waveOut = new WaveOutEvent();
                            waveOut.Init(bufferedWaveProvider);
                        }
                        if (waveOut.PlaybackState != PlaybackState.Playing)
                            await Play();

                    } while (!killFlag);
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

        private Task Play()
        {   
            waveOut.Play();

            for (int i = 0; i < bufferedWaveProvider.BufferedDuration.TotalMilliseconds;)
            {
                Thread.Sleep(1000);
            }

            return Task.FromResult(true);
        }
    }
}
