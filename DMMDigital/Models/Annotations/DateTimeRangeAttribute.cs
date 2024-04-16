using System;
using System.ComponentModel.DataAnnotations;

namespace DMMDigital.Models.Annotations
{
    public class DateTimeRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate = new DateTime(1910, 01, 01);
        private readonly DateTime _maxDate = DateTime.Now;

        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue >= _minDate && dateValue <= _maxDate;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Data deve ser entre {_minDate:dd/MM/yyyy} e {_maxDate:dd/MM/yyyy}.";
        }
    }
}
