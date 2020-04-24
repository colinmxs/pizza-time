namespace PizzaTime.Core.v2.PointOfSaleMachine.Responses
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