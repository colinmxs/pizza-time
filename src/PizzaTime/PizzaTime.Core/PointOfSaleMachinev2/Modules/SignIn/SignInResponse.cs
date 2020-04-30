namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.SignIn
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
