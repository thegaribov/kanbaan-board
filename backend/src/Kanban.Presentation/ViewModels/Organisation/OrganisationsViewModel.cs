using System.Collections.Generic;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class OrganisationsViewModel
    {
        public OrganisationsViewModel()
        {
            Organisations = new();
        }

        public List<OrganisationViewModel> Organisations { get; set; }
    }
}
