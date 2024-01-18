using HumAnalysis.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using HumAnalysis.Service.Implementations;
using HumAnalysis.Domain.ViewModels.ContourYear;

namespace HumAnalysis.WebAPI.Controllers
{
    public class CalculationController : Controller
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }


        [HttpGet("calculate")]
        public async Task<IActionResult> Calculation(ContourYearViewModel birthDate)
        {
            var response = await _calculationService.GetAnalysis(birthDate);

            return Json(response);
        }
    }
}
