namespace PizzaTime.Core.PointOfSaleMachinev2.Responses
{
    public class SignInResponse
    {
        public bool Success { get; }

        public SignInResponse(bool success)
        {
            Success = success;
        }
    }
}