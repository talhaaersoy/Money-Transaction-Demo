using Entities.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessRules
{
    public class BusinessRules
    {
        public static IResponse Run(params IResponse[] logics)
        {
            foreach (var logic in logics)
            {
                if (logic.IsError)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
