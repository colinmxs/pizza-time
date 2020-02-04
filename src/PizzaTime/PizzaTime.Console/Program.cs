namespace PizzaTime.Console
{
    using Amazon;
    using Amazon.Polly;
    using PizzaTime.VoiceEngine;
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var awsAccessKeyId = "";
            var secretAccessKey = "";
            var pollyClient = new Amazon.Polly.AmazonPollyClient(awsAccessKeyId, secretAccessKey, new AmazonPollyConfig 
            {
                RegionEndpoint = RegionEndpoint.USWest2
            });
            var app = new App(pollyClient);
            await app.Speak("" +
                "When our dogs see their backpacks, they have a tendency to freak out a little.  After a long winter of casual walks and backyard fetch games, getting into the mountains and exploring is the only thing they want to do !Luckily for us, spring is here and although Idaho has a tendency to throw surprise two-minute snow flurries our way, we are getting our supplies ready and brushing up on our wilderness know - how as we prep for our first backpacking trip of the season.Here are some tips for making sure your camping dog is ready for adventure! There are some awesome sizing charts out there to help find the right size pack for your pup, but most backpacks rely on size and weight ranges to fit dogs correctly.Dog backpacks will generally clasp around the shoulders, chest and waist; you want the pack to fit snuggly but not too tight(if they can’t breathe they probably won’t get very far on the trail) and make sure weight is distributed evenly on both sides.Although dog weight doesn’t fluctuate as much as humans, it’s a good idea to check the way their pack fits every time they wear it.  Things like coat thickness or even just a couple extra pounds of winter weight can drastically change how their pack sits on their body; one time Charlie went about a mile in a pack that was too tight because we forgot that the last time he had worn it he had short hair.  To avoid mishaps like this, it’s best to adhere to the golden rule: Do unto your dogs backpacks as you would do unto your backpack – check the fit before you hit the trail. How much can dogs carry? The word around the internet is that dogs can carry up to 25 % of their own weight, so depending on Fido’s size they should be able to carry their own food and water.Some dogs are able to carry up to 40 % of their own weight(huskies, for example and other working / pack dogs) but for weekend warriors or inexperienced dogs, it’s a good idea to ease them into backpacking with less weight and see how they do.When Theanie went on her first hike with us, we equipped her with an empty pack so she could get used to how it felt; on her very first overnight backpacking trip we kept the weight in her pack to just the canine med kit, their food and water bowls and a couple of gummy snack packs for us.Now that she’s an experienced backpacking pup, she carries all of that stuff, plus her meds, our camp shovel and our Ziploc trash bag. Be aware of your dog’s age, physical ability and any ailments they might have.Theanie is only 5 and in general very fit and active, but she has a bum elbow that acts up when it’s cold or when she has been running or hiking.To keep her healthy enough to hike with us for years to come, I like to keep the weight in her pack to a minimum, even if that means carrying some extra weight in my own pack.");
        }
    }
}
