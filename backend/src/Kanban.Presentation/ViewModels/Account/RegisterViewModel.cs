using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Presentation.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Organisation")]
        public string Organisation { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        
    }

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            IntegrateRules();
        }

        private void IntegrateRules()
        {
            #region Fullname

            RuleFor(model => model.FullName)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Fullname can't be empty")

                .NotNull()
                .WithMessage("Fullname can't be empty")

                .MinimumLength(3)
                .WithMessage("Fullname min length can be 3")

                .MaximumLength(25)
                .WithMessage("Fullname max length can be 25");

            #endregion

            #region Organisation

            RuleFor(model => model.Organisation)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Organisation can't be empty")

                .NotNull()
                .WithMessage("Organisation can't be empty")

                .MinimumLength(3)
                .WithMessage("Organisation min length can be 3")

                .MaximumLength(35)
                .WithMessage("Organisation max length can be 35");

            #endregion

            #region PhoneNumber

            RuleFor(model => model.PhoneNumber)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Phone number can't be empty")

                .NotNull()
                .WithMessage("Phone number can't be empty");

            #endregion

            #region Address

            RuleFor(model => model.Address)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Address can't be empty")

                .NotNull()
                .WithMessage("Address can't be empty")

                .MinimumLength(3)
                .WithMessage("Address min length can be 3")

                .MaximumLength(40)
                .WithMessage("Address max length can be 40");

            #endregion

            #region Email

            RuleFor(model => model.Email)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Email can't be empty")

                .NotNull()
                .WithMessage("Email can't be empty")

                .EmailAddress()
                .WithMessage("Email is not in correct format");


            #endregion

            #region Password

            RuleFor(model => model.Password)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Password can't be empty")

                .NotNull()
                .WithMessage("Password can't be empty");

            #endregion

            #region ConfirmPassword

            RuleFor(model => model.ConfirmPassword)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Confirm password can't be empty")

                .NotNull()
                .WithMessage("Confirm password can't be empty")

                .Equal(model => model.Password)
                .WithMessage("Passwords don't match");

            #endregion
        }
    }
}
