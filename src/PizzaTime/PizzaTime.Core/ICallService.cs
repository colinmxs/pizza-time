﻿using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public interface ICallService
    {
        Task<Call> GetCall();
    }
}