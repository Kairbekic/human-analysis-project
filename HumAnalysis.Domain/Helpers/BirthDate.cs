using HumAnalysis.Domain.ViewModels.ContourYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Domain.Helpers
{
    public class BirthDate
    {
        public BirthDate(string birthDate) 
        {
            string[] birthDateParts = birthDate.Split('.');
            Year = int.Parse(birthDateParts[2]);
            Month = int.Parse(birthDateParts[1]);
            Day = int.Parse(birthDateParts[0]);
        }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
