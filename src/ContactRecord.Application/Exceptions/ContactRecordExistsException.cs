using System;
using System.Collections.Generic;
using System.Text;

namespace ContactRecord.Application.Exceptions
{
    public class ContactRecordExistsException: Exception
    {
        public ContactRecordExistsException()
        {
        }

        public ContactRecordExistsException(string message)
            : base(message)
        {
        }

        public ContactRecordExistsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
