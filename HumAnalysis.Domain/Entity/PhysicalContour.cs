using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Entity
{
    public class PhysicalContour
    {
        public byte Id { get; set; }
        public byte Muladhara { get; set; }
        public byte Svadhisthana { get; set; }
        public string ContourType { get; set; }
    }
}
