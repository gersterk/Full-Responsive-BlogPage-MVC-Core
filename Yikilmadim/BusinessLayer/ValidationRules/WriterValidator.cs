using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("A Writer should have a name to shine");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("I need your email. Do not worry, it's just a procedure");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("A password, please!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Your name should not be shorter than two chars");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Your name should not be longer than 50 chars if you are not Hubert Blaine Wolfeschlegelsteinhausenbergerdorff");

        }
    }
}
