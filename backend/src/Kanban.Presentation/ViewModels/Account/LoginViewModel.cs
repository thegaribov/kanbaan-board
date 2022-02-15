using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Presentation.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name ="Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            IntegrateRules();
        }

        private void IntegrateRules()
        {
            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Email can't be empty")
                .NotNull()
                .WithMessage("Email can't be empty");

            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Password can't be empty")
                .NotNull()
                .WithMessage("Password can't be empty");

            #endregion
        }
    }
}
