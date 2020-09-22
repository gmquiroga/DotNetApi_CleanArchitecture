using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Core.ValueObjects
{
    public class Address
    {
        public string State { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }

        // Required for EntityFramework
        public Address() { }

        public Address(string state, string city, string zipCode, string street, int number)
        {
            State = Guard.Against.NullOrWhiteSpace(state, nameof(state));
            City = Guard.Against.NullOrWhiteSpace(city, nameof(city));
            ZipCode = Guard.Against.NullOrWhiteSpace(zipCode, nameof(zipCode));
            Street = Guard.Against.NullOrWhiteSpace(street, nameof(street));
            Number = Guard.Against.NegativeOrZero(number, nameof(number));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var valueObject = (Address)obj;

            return State == valueObject.State 
                && City == valueObject.City 
                && ZipCode == valueObject.ZipCode
                && Street == valueObject.Street
                && Number == valueObject.Number;
        }

        public static bool operator == (Address firstAddress, Address secondAddress) =>
            firstAddress.Equals(secondAddress);

        public static bool operator != (Address firstAddress, Address secondAddress) =>
            !firstAddress.Equals(secondAddress);

    }
}
