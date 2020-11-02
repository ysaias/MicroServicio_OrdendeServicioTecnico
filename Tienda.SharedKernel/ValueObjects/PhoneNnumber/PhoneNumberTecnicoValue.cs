using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.PhoneNumber.Rule;

namespace Tienda.SharedKernel.ValueObjects.PhoneNumber
{
    public class PhoneNumberTecnicoValue : ValueObject, IComparable<PhoneNumberTecnicoValue>
    {
        public string Value { get; private set; }

        public PhoneNumberTecnicoValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new PhoneNumberRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PhoneNumberTecnicoValue value) => value.Value;

        public static implicit operator PhoneNumberTecnicoValue(string value) => new PhoneNumberTecnicoValue(value);

        #endregion

        public int CompareTo([AllowNull] PhoneNumberTecnicoValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
