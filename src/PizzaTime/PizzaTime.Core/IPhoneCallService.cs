using Amazon.S3;
using PizzaTime.Core.Phones;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public interface IPhoneCallService
    {
        IPhoneCall GetCall();
    }

    public class PhoneCallService : IPhoneCallService
    {
        private readonly IAmazonS3 _s3Client;

        public PhoneCallService(IAmazonS3 s3Client) 
        {
            _s3Client = s3Client;
        }

        public IPhoneCall GetCall()
        {
            return null;
        }
    }
}