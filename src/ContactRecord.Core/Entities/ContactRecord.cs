using Ardalis.GuardClauses;
using ContactRecord.Core.SeedWork;
using ContactRecord.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Core.Entities
{
    public class ContactRecord : Entity
    {
        // For simplicity all properties have public setter, instead of private how DDD especified
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImagePath { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }

        public ContactRecord() { }

        public ContactRecord(string name, string company, string profileImagePath, string email, DateTime birthDate, PhoneNumber phoneNumber, Address address)
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Company = Guard.Against.NullOrWhiteSpace(company, nameof(company));
            ProfileImagePath = Guard.Against.NullOrWhiteSpace(profileImagePath, nameof(profileImagePath));
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email));
            BirthDate = Guard.Against.OutOfSQLDateRange(birthDate, nameof(birthDate));
            PhoneNumber = phoneNumber;
            Address = address;
        }

    }
}
