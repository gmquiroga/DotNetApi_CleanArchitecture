using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactRecord.Application.DTOs
{
    public class CreateContactRecordInput
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string ProfileImagePath { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public PhoneNumberInput PhoneNumber { get; set; }
        [Required]
        public AddressInput Address { get; set; }
    }
}
