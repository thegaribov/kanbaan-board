using Kanban.Core.Helpers.ActionResultMessage;
using Kanban.Presentation.ViewModels.ViewComponent;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Presentation.ViewComponents
{
    public class PrettyUserProfileViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string fullName, string size = "sm")
        {
            var model = new PrettyProfileViewModel
            {
                Size = size
            };

            try
            {
                var names = fullName.Split(" ");
                StringBuilder resultName = new StringBuilder();

                foreach (var name in names)
                {
                    resultName.Append(name.ToUpperInvariant()[0]);
                }

                model.FullNameFirstLetter = resultName.ToString();

                return View("PrettyUserProfile", model);
            }
            catch
            {
                model.FullNameFirstLetter = string.Empty;

                return View("PrettyUserProfile", model);
            }
        }
    }
}
