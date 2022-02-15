using FluentValidation;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class OrganisationEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }


    public class OrganisationEditViewModelValidator : AbstractValidator<OrganisationEditViewModel>
    {
        public OrganisationEditViewModelValidator()
        {
            IntegrateRules();
        }

        private void IntegrateRules()
        {

            #region Organisation

            RuleFor(model => model.Name)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Name can't be empty")

                .NotNull()
                .WithMessage("Name can't be empty")

                .MinimumLength(3)
                .WithMessage("Name min length can be 3")

                .MaximumLength(35)
                .WithMessage("Name max length can be 35");

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
        }
    }
}
