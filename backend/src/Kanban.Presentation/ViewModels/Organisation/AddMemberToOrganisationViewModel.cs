using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class AddMemberToOrganisationViewModel
    {
        public int OrganisationId { get; set; }

        [Display(Name = "Organisation name")]
        public string OrganisationName { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }

    public class AddMemberToOrganisationViewModelValidator : AbstractValidator<AddMemberToOrganisationViewModel>
    {
        public AddMemberToOrganisationViewModelValidator()
        {
            IntegrateRules();
        }

        private void IntegrateRules()
        {
            #region OrganisationId

            RuleFor(model => model.OrganisationId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull();

            #endregion

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
                .WithMessage("Fullname max length can be  25");

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
