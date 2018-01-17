using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AutoTestExecution
    {
        public int Sno { get; set; }
        public string ScriptName { get; set; }
        public string IsExecute { get; set; }
        public DateTime? ExecutionDate { get; set; }
    }
}
