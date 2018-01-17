using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AutoTestResults
    {
        public int Sno { get; set; }
        public int? TestId { get; set; }
        public string TestScenario { get; set; }
        public string TestName { get; set; }
        public string Result { get; set; }
        public string ScriptName { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
