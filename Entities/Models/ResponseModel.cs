using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ResponseModel
    {
        public Guid ReferenceNumber { get; set; }
        public bool IsError { get; set; }

        public ResponseModel(Guid referenceNumber,bool isError)
        {
            ReferenceNumber = referenceNumber;
            IsError = isError;
        }
    }
}
