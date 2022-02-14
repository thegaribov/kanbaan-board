using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Core.Entities.Abstracts
{
    public interface ICreatedAt
    {
        public DateTime CreatedAt { get; set; }
    }
}
