using System;
using System.Collections.Generic;

namespace Kanban.Presentation.ViewModels.Organisation
{
    public class OrganisationViewModel
    {
        public OrganisationViewModel()
        {
            Members = new();
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Address { get; set; }
        public List<string> Members { get; set; }
        public bool IsCurrentUserOwner { get; set; }
    }
}
