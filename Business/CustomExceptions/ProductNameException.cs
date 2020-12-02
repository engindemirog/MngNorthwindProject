using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CustomExceptions
{
    public class ProductNameException:Exception
    {
        public ProductNameException(string message) : base(message)
        {

        }
    }
}
