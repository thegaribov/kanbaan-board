using FluentValidation;
using Kanban.Core.Enums.Ticket;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kanban.Presentation.ViewModels.Ticket
{
    public class TicketCreateViewModel
    {
        public int OrganisationId { get; set; }

        [Display(Name = "Related organisation name")]
        public string OrganisationName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Deadline")]
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public TicketStatus Status { get; set; }
    }

    public class TicketCreateViewModelValidator : AbstractValidator<TicketCreateViewModel>
    {
        public TicketCreateViewModelValidator()
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

            #region Title

            RuleFor(model => model.Title)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Title can't be empty")

                .NotNull()
                .WithMessage("Title can't be empty")

                .MinimumLength(3)
                .WithMessage("Title min length can be 3")

                .MaximumLength(25)
                .WithMessage("Title max length can be 25");

            #endregion

            #region Description

            RuleFor(model => model.Description)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Description can't be empty")

                .NotNull()
                .WithMessage("Description can't be empty")

                .MinimumLength(3)
                .WithMessage("Description min length can be 3")

                .MaximumLength(40)
                .WithMessage("Description max length can be 40");

            #endregion

            #region Deadline

            RuleFor(model => model.Deadline)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Deadline can't be empty")

                .NotNull()
                .WithMessage("Deadline can't be empty")

                .Must(deadline => deadline > DateTime.Now)
                .WithMessage("Deadline must be greater than current date");

            #endregion

            #region Status

            RuleFor(model => model.Status)
                .Cascade(CascadeMode.Stop)

                .NotEmpty()
                .WithMessage("Status can't be empty")

                .NotNull()
                .WithMessage("Status can't be empty");

            #endregion
        }
    }
}
