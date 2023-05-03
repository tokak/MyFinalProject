using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingCorncerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            //ProductValidator productValidator = new ProductValidator();
            var result = validator.Validate(context);
            if (!result.IsValid)//sonuc geçerli değilse hata verir
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
