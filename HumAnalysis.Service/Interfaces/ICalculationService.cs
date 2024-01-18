using HumAnalysis.Domain.Entity;
using HumAnalysis.Domain.Response;
using HumAnalysis.Domain.ViewModels.ContourYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Service.Interfaces
{
    public interface ICalculationService
    {
        Task<FullResponse> GetAnalysis(ContourYearViewModel data);
    }
}
