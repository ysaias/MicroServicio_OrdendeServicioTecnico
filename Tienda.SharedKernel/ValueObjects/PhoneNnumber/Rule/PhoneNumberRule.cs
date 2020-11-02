using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda.SharedKernel.Core;

namespace Tienda.SharedKernel.ValueObjects.PhoneNumber.Rule
{
    public class PhoneNumberRule : IBusinessRule
    {
        private readonly string _value;

        public PhoneNumberRule(string value)
        {
            _value = value;
        }

        public string Message => "El formato del número de telefono es incorrecto";

        public bool IsBroken()
        {
            return !Regex.IsMatch(_value, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
        }
    }
}
