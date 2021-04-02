using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Response
{
    public class ResponseDataModel<T> : ResponseModel
    {
        public T Data { get; set; }
        public ResponseDataModel(T data,int referenceNumber, bool isError) : base(referenceNumber, isError)
        {
            Data = data;
        }
        public ResponseDataModel(T data,bool isError) : base(isError)
        {
            Data = data;
        }
    }
}
