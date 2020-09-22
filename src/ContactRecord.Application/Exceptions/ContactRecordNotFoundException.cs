using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Application.Exceptions
{
    public class ContactRecordNotFoundException: Exception
    {
        public ContactRecordNotFoundException()
        {
        }

        public ContactRecordNotFoundException(string message)
            : base(message)
        {
        }

        public ContactRecordNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
