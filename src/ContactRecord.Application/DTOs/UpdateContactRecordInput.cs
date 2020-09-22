using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Application.DTOs
{
    public class UpdateContactRecordInput: CreateContactRecordInput
    {
        public int Id { get; set; }

    }
}
