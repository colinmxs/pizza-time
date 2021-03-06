﻿using System;
using System.Collections.Generic;

namespace PizzaTime.Core.Conversations
{
    public interface IThingToSayCategory
    {
        Category Name { get; }
        IEnumerable<Category> ResponseCategories { get; }
    }

    public enum Category
    {
        NameRequest,
        NameResponse,
        AddressRequest,
        AddressResponse,
        GenericAffirmative,
        GenericNegative,
        HoldRequest,
        OrderRequest,
        OrderResponse,
        PhoneGreeting,
        PhoneGreetingResponse,
        PhoneNumberRequest,
        PhoneNumberResponse,
        PhoneFarwell,
        PhoneFarwellResponse
    }

    public class ThingToSayCategory : IThingToSayCategory, IEquatable<ThingToSayCategory>
    {
        public static readonly IThingToSayCategory NameRequest = new ThingToSayCategory(Category.NameRequest, Category.NameResponse);
        public static readonly IThingToSayCategory NameResponse = new ThingToSayCategory(Category.NameResponse, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory AddressRequest = new ThingToSayCategory(Category.AddressRequest, Category.AddressResponse);
        public static readonly IThingToSayCategory AddressResponse = new ThingToSayCategory(Category.AddressResponse, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory GenericAffirmative = new ThingToSayCategory(Category.GenericAffirmative, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory GenericNegative = new ThingToSayCategory(Category.GenericNegative, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory HoldRequest = new ThingToSayCategory(Category.HoldRequest, Category.GenericNegative, Category.GenericAffirmative);
        public static readonly IThingToSayCategory OrderRequest = new ThingToSayCategory(Category.OrderRequest, Category.OrderResponse);
        public static readonly IThingToSayCategory OrderResponse = new ThingToSayCategory(Category.OrderResponse, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory PhoneGreeting = new ThingToSayCategory(Category.PhoneGreeting, Category.PhoneGreetingResponse);
        public static readonly IThingToSayCategory PhoneGreetingResponse = new ThingToSayCategory(Category.PhoneGreetingResponse, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory PhoneNumberRequest = new ThingToSayCategory(Category.PhoneNumberRequest, Category.PhoneNumberResponse);
        public static readonly IThingToSayCategory PhoneNumberResponse = new ThingToSayCategory(Category.PhoneNumberResponse, Category.AddressRequest, Category.NameRequest, Category.OrderRequest, Category.PhoneNumberRequest, Category.HoldRequest, Category.PhoneFarwell);
        public static readonly IThingToSayCategory PhoneFarewell = new ThingToSayCategory(Category.PhoneFarwell, Category.PhoneFarwellResponse);
        public static readonly IThingToSayCategory PhoneFarewellResponse = new ThingToSayCategory(Category.PhoneFarwellResponse);

        public Category Name { get; }
        public IEnumerable<Category> ResponseCategories { get; }

        private ThingToSayCategory(Category category, params Category[] responseCategories)
        {
            Name = category;
            ResponseCategories = responseCategories;
        }

        public bool Equals(ThingToSayCategory other)
        {
            if (other == null) return false;
            return Name == other.Name;
        }

        public override bool Equals(object other)
        {
            if (other is ThingToSayCategory)
                return Equals((ThingToSayCategory)other);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
