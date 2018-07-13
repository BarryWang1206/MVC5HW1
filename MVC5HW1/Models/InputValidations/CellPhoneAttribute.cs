using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5HW1.Models.InputValidations
{
    public class CellPhoneAttribute : DataTypeAttribute
    {
        public CellPhoneAttribute() : base(DataType.Text)
        {

        }
    }
}