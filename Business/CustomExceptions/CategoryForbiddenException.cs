using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CustomExceptions
{
    public class CategoryForbiddenException:Exception
    {
        public CategoryForbiddenException(string message) : base(message)
        {

        }
    }
}
