using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Application.Exception
{
    public class JewelryStoreValidationException: ApplicationException
    {

        public List<ValidationFailure> ValidationFailures { get; set; }
        public JewelryStoreValidationException(List<ValidationFailure> validationFailures)
            : base("Validation Exception")
        {
            ValidationFailures = validationFailures;
        }
    }
}
