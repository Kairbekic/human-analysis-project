using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Entity
{
    public class EmotionalContour
    {
        public byte Id { get; set; }
        public byte Manipura { get; set; }
        public byte Anahata { get; set; }
        public string ContourType { get; set; }
    }
}
