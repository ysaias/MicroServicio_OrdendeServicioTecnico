using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.PhoneNumber.Rule;

namespace Tienda.SharedKernel.ValueObjects.PhoneNumber
{
    public class PhoneNumberValue : ValueObject, IComparable<PhoneNumberValue>
    {
        public string Value { get; private set; }

        public PhoneNumberValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new PhoneNumberRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PhoneNumberValue value) => value.Value;

        public static implicit operator PhoneNumberValue(string value) => new PhoneNumberValue(value);

        #endregion

        public int CompareTo([AllowNull] PhoneNumberValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
