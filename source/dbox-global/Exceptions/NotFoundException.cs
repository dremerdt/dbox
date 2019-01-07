using System;
using System.Collections.Generic;
using System.Text;

namespace dbox_global.Exceptions
{
    /// <summary>
    /// A not found exception
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message)
            : base(message)
        {

        }

        public NotFoundException(string message, Exception exception)
            : base(message, exception)
        {

        }
    }
}
