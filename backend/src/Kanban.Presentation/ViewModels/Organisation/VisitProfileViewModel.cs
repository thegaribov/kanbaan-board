using Kanban.Core.Entities;
using Kanban.Core.Enums.Organisation;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class VisitProfileViewModel
    {
        public User User { get; set; }
        public Kanban.Core.Entities.Organisation Organisation { get; set; }
        public OrganisationRole Role { get; set; }
    }
}
