using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ais.Agent.Executor.Service.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string FunctionCall { get; set; }
        public string Status { get; set; }
    }
}
