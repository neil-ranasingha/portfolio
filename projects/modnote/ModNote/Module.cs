using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModNote
{
    class Module
    {
        public string Path = "";
        public string ModuleID = "";
        public string ModuleTitle = "";
        public string ModuleSynopsis = "";
        public List<string> ModuleLO;
        public List<string> ModuleAssessments;
        public string[] AssessmentType;
        public DateTime[] AssessmentDate;
    }
}
