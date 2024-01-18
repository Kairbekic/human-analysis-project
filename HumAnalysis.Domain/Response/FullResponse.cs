using HumAnalysis.Domain.Entity;
using HumAnalysis.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Response
{
    public class FullResponse
    {
        public InnatePotential InnatePotential { get; set; }
        public Workoff TopLine {  get; set; }
        public Workoff BottomLine { get; set; }
        public int PeriodLength { get; set; }
        public int KarmicNumber { get; set; }
        public string MonthlyNegativeForecast { get; set; }
        public string MonthlyPositiveForecast { get; set; }
        public int EnergyPotentialYear { get; set; }
        public int PositiveDigit { get; set; }
    }
}
