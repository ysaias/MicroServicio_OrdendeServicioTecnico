using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.SharedKernel.Core
{
     public class DateTimeValue : ValueObject
    {
        public DateTime Value { get; private set; }

        public DateTimeValue(DateTime date)
        {
            
            Value = date;
        }

        #region Conversion

        public static implicit operator DateTime(DateTimeValue value)
        {
            return value.Value;
        }

        public static implicit operator DateTimeValue(DateTime value)
        {
            return new DateTimeValue(value);
        }

        #endregion
    }
}
