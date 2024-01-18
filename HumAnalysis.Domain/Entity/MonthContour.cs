using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Entity
{
    public class MonthContour
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte NumberDaysInMonth { get; set; }
        public byte PhysicalParameter { get; set; }
        public byte EmotionalParameter { get; set; }
        public byte IntellectualParameter { get; set; }
    }
}
