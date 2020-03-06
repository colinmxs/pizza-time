﻿using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTimeAwsCdkCognito
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new PizzaTimeAwsCdkCognitoStack(app, "PizzaTimeAwsCdkCognitoStack");
            app.Synth();
        }
    }
}
