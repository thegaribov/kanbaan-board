using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Helpers.ActionResultMessage
{
    public class ActionResultMessage
    {
        public ActionResultMessageType ActionResultMessageType { get; set; }
        public string Content { get; set; }
    }

    public enum ActionResultMessageType
    {
        Success,
        Error
    }

    public enum ActionType
    {
        Create,
        Update,
        Delete
    }
}
