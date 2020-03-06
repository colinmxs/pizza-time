using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTime.Aws.Sdk.Cognito
{
    interface ISignIn
    {
        string Username { get; set; }
        string Password { get; set; }

        Task<string> SignIn();
    }
}
