﻿namespace PizzaTime.Core.PointOfSale.Responses
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