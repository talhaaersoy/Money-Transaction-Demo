using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Response
{
    public class ResponseModel : IResponse
    {
        public int ReferenceNumber { get; set; }
        public bool IsError { get; set; }

        public ResponseModel(int referenceNumber,bool isError)
        {
            ReferenceNumber = referenceNumber;
            IsError = isError;
        }
        public ResponseModel(bool isError)
        {
            IsError = isError;
        }
    }
}
