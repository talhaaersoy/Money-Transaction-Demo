using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models.Response
{
    public interface IResponse
    {
        bool IsError { get; set; }
        string Message { get; set; }
        int ReferenceNumber { get; set; }
    }
}
