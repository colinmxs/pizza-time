using PizzaTime.Core.v2.PointOfSaleMachine.Responses;
using System;

namespace PizzaTime.Core.v2.PointOfSaleMachine.Requests
{
    public class SignInRequest : IPointOfSaleRequest<SignInResponse>
    {
        public string Passcode { get; set; }
    }

    public class SignInRequestHandler : IPointOfSaleRequestHandler<SignInRequest, SignInResponse>
    {
        private readonly string _passCode;

        public SignInRequestHandler(string passCode)
        {
            _passCode = passCode;
        }

        public SignInResponse Handle(SignInRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var signedIn = request.Passcode == _passCode;
            return new SignInResponse(signedIn);
        }
    }
}