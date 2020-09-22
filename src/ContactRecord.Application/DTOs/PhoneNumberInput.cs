using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactRecord.Application.DTOs
{
    public class PhoneNumberInput
    {
        [Required]
        public string PersonalNumber { get; set; }
        [Required]
        public string WorkNumber { get; set; }
    }
}
