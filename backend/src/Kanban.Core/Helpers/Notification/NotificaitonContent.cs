using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Helpers.Notification
{
    public class NotificationContent
    {
        public string EmailSubject { get; set; } = String.Empty;
        public string EmailText { get; set; } = String.Empty;
    }

}
