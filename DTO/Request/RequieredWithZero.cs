using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.DTO.Request
{
    public class RequieredWithZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is long LongValue && LongValue != 0)
            {
                return true;
            }
            return false;
        }
    }
}
