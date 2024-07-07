using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1.FolderClasses
{
    internal partial class PersonClass
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public double Vision { get; set; }
        public List<string> HabitsAndIll { get; set; }
        public List<TestResult> Results { get; set; } = new List<TestResult>();
    }
}
