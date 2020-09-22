using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Core.ValueObjects
{
    public class PhoneNumber
    {
        public string PersonalNumber { get; private set; }
        public string WorkNumber { get; private set; }

        // Required for EntityFramework
        public PhoneNumber() { }

        public PhoneNumber(string personalNumber, string workNumber)
        {
            PersonalNumber = Guard.Against.NullOrWhiteSpace(personalNumber, nameof(personalNumber));
            WorkNumber = Guard.Against.NullOrWhiteSpace(workNumber, nameof(workNumber));
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var valueObject = (PhoneNumber)obj;

            return PersonalNumber == valueObject.PersonalNumber
                && WorkNumber == valueObject.WorkNumber;
        }

        public static bool operator == (PhoneNumber firstPhoneNumber, PhoneNumber secondPhoneNumber) =>
            firstPhoneNumber.Equals(secondPhoneNumber);

        public static bool operator != (PhoneNumber firstPhoneNumber, PhoneNumber secondPhoneNumber) =>
            !firstPhoneNumber.Equals(secondPhoneNumber);
    }
}
