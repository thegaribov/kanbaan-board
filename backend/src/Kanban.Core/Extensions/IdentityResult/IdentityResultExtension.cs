using Kanban.Core.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Extensions.IdentityResult
{
    public static class IdentityResultExtension
    {
        public static void AddToModelState(this Microsoft.AspNetCore.Identity.IdentityResult identityResult, ModelStateDictionary modelStateDictionary)
        {
            var errors = IdentityErrorTranslator.Translate(identityResult);

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Key, string.Join(" ", error.Value));
            }

        }
    }
}
