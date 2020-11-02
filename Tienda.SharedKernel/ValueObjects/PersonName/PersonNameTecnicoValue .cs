
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.PersonName.Rule;

namespace Tienda.SharedKernel.ValueObjects
{
    public class PersonNameTecnicoValue : ValueObject, IComparable<PersonNameTecnicoValue>
    {
        public string Value { get; private set; }

        public PersonNameTecnicoValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new OnlyLettersRule(value));
            CheckRule(new NameLengtRule(value));

            Value = value;
        }


        #region Conversion

        public static implicit operator string(PersonNameTecnicoValue value) => value.Value;

        public static implicit operator PersonNameTecnicoValue(string value) => new PersonNameTecnicoValue(value);

        #endregion

        public int CompareTo([AllowNull] PersonNameTecnicoValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
