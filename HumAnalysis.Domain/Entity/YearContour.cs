using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Entity
{
    public class YearContour
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public byte PhysicalParameter { get; set; }
        public byte EmotionalParameter { get; set; }
        public byte IntellectualParameter { get; set; }
    }
}
