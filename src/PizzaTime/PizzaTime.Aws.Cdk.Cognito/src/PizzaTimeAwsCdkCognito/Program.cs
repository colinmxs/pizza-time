using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Aws.Cdk.Cognito
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CognitoStack(app, "PizzaTimeCognitoStack");
            app.Synth();
        }
    }
}
