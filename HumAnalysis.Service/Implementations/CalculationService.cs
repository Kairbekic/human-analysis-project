using HumAnalysis.Domain.Entity;
using HumAnalysis.Domain.Helpers;
using HumAnalysis.Domain.Response;
using HumAnalysis.Domain.ViewModels.Account;
using HumAnalysis.Domain.ViewModels.ContourYear;
using HumAnalysis.Service.Interfaces;
using HumanAnalysis.DAL.Interfaces;
using HumanAnalysis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HumAnalysis.Service.Implementations
{
    public class CalculationService: ICalculationService
    {
        private readonly IContourRepository<YearContour> _contourYearRepository;
        private readonly IContourRepository<MonthContour> _contourMonthRepository;
        private readonly IContourRepository<PhysicalContour> _contourPhysicalRepository;
        private readonly IContourRepository<EmotionalContour> _contourEmotionalRepository;
        private readonly IContourRepository<IntellectualContour> _contourIntellectualRepository;
        private readonly ILogger<AccountService> _logger;

        public CalculationService(IContourRepository<YearContour> contourYearRepository, 
                                  IContourRepository<MonthContour> contourMonthRepository, 
                                  IContourRepository<PhysicalContour> contourPhysicalRepository, 
                                  IContourRepository<EmotionalContour> contourEmotionalRepository,
                                  IContourRepository<IntellectualContour> contourIntellectualRepository,
                                  ILogger<AccountService> logger)
        {
            _contourYearRepository = contourYearRepository;
            _contourMonthRepository = contourMonthRepository;
            _contourPhysicalRepository = contourPhysicalRepository;
            _contourEmotionalRepository = contourEmotionalRepository;
            _contourIntellectualRepository = contourIntellectualRepository;
            _logger = logger;
        }

        public async Task<FullResponse> GetAnalysis(ContourYearViewModel birthDate)
        {
            BirthDate birth = new BirthDate(birthDate.Date);
            var karmicNumber = CalculateKarmicNumber(birth);
            var negativeKarmicPeriod = CalculateNegativeKarmicPeriod(birth);
            var topLineLife = TopLineOfLifeCode(birth, negativeKarmicPeriod);
            var monthlyNegativeForecast = CalculateNegativeForecastYear(birthDate, negativeKarmicPeriod);

            async Task<InnatePotential> CalculationInnatePotential(BirthDate birth)
            {
                const int PhysicalContourNumber = 23;
                const int EmocionalContourNumber = 28;
                const int IntellectualContourNumber = 33;

                var contourYear = await _contourYearRepository.GetAllContour().FirstOrDefaultAsync(x => x.Year == birth.Year);

                if (LeapYearHelper.IsLeapYear(birth.Year) && birth.Month == 2)
                    birth.Month = 13;

                var contourMonth = await _contourMonthRepository.GetAllContour().FirstOrDefaultAsync(x => x.Id == birth.Month);

                var remainingDaysInMonth = contourMonth.NumberDaysInMonth - birth.Day;

                var PhysicalContourColumn = (contourYear.PhysicalParameter + contourMonth.PhysicalParameter + remainingDaysInMonth) % PhysicalContourNumber;
                var EmotionalContourColumn = (contourYear.EmotionalParameter + contourMonth.EmotionalParameter + remainingDaysInMonth) % EmocionalContourNumber;
                var IntellectualContourColumn = (contourYear.IntellectualParameter + contourMonth.IntellectualParameter + remainingDaysInMonth) % IntellectualContourNumber;

                var contourPhysical = await _contourPhysicalRepository.GetAllContour().FirstOrDefaultAsync(x => x.Id == (PhysicalContourColumn != 0 ? PhysicalContourColumn : PhysicalContourNumber));
                var contourEmotional = await _contourEmotionalRepository.GetAllContour().FirstOrDefaultAsync(x => x.Id == (EmotionalContourColumn != 0 ? EmotionalContourColumn : EmocionalContourNumber));
                var contourIntellectual = await _contourIntellectualRepository.GetAllContour().FirstOrDefaultAsync(x => x.Id == (IntellectualContourColumn != 0 ? IntellectualContourColumn : IntellectualContourNumber));

                var chakras = new Chakra()
                {
                    Muladhara = contourPhysical.Muladhara,
                    Svadhisthana = contourPhysical.Svadhisthana,
                    Anahata = contourEmotional.Anahata,
                    Manipura = contourEmotional.Manipura,
                    Vishuddha = contourIntellectual.Vishuddha,
                    Ajna = contourIntellectual.Ajna,
                };
                var contourTypes = new ContourType()
                {
                    Physical = contourPhysical.ContourType,
                    Emotional = contourEmotional.ContourType,
                    Intellectual = contourIntellectual.ContourType,
                };

                var potential = new InnatePotential()
                {
                    Chakra = chakras,
                    ContourType = contourTypes,
                };
                return potential;
            }


            Workoff TopLineOfLifeCode(BirthDate birth, double negativeKarmicPeriod)
            {
                var negativeBirthWorkoff = SumDigitsHelper.SumDigits(birth.Day) + SumDigitsHelper.SumDigits(birth.Month);

                if(negativeBirthWorkoff >= 10)
                {
                    negativeBirthWorkoff = SumDigitsHelper.SumDigits(negativeBirthWorkoff);
                }

                var negativeKarmicPeriodsNumber = negativeKarmicPeriod.ToString();
                var negativeKarmicWorkoff = negativeKarmicPeriodsNumber[0].ToString();

                var negative = new Workoff()
                {
                     Birth = negativeBirthWorkoff.ToString(),
                     Karmic = negativeKarmicWorkoff,
                     Periods = negativeKarmicPeriodsNumber.Substring(1),
                };

                return negative;
            }

            Workoff BottomLineOfLifeCode(Workoff workoff, int karmicNumber)
            {
                var birth = SumDigitsHelper.SumDigits(int.Parse(workoff.Birth) + karmicNumber);
                var karmic = SumDigitsHelper.SumDigits(int.Parse(workoff.Karmic) + karmicNumber);

                StringBuilder tempLine = new StringBuilder();

                foreach (char ch in workoff.Periods)
                {
                    tempLine.Append(SumDigitsHelper.SumDigits(ch - '0' + karmicNumber));
                }

                Workoff positive = new Workoff()
                {
                    Birth = birth.ToString(),
                    Karmic = karmic.ToString(),
                    Periods = tempLine.ToString(),
                };

                return positive;
            }

            int CalculateKarmicNumber(BirthDate birth)
            {
                var sumDigitsDay = SumDigitsHelper.SumDigits(birth.Day);
                var sumDigitsMonth = SumDigitsHelper.SumDigits(birth.Month);
                var sumDigitsYear = SumDigitsHelper.SumDigits(birth.Year);
                var sumDigitsAll = SumDigitsHelper.SumDigits(sumDigitsDay + sumDigitsMonth + sumDigitsYear);

                while (sumDigitsAll > 9)
                {
                    sumDigitsAll = SumDigitsHelper.SumDigits(sumDigitsAll);
                }
                return sumDigitsAll;
            }

            int CalculatePeriodLength(Workoff response)
            {
                int count = 0;
                char nine = '9';
                for (int i = 0; i < response.Periods.Length; i++)
                    if (response.Periods[i] != nine)
                    {
                        count++;
                    }
                int periodLength = 60 / count;

                return periodLength;
            }

            double CalculateNegativeKarmicPeriod(BirthDate birth)
            {
                int birthDayAndMonth;

                if (birth.Month < 10)
                    birthDayAndMonth = int.Parse(birth.Day.ToString() + "0" + birth.Month.ToString());
                else
                    birthDayAndMonth = int.Parse(birth.Day.ToString() + birth.Month.ToString());
                var negativeKarmicPeriodsNumber = (birthDayAndMonth * birth.Year);

                return negativeKarmicPeriodsNumber;
            }

            string CalculateNegativeForecastYear(ContourYearViewModel contour, double negativeKarmicPeriod)
            {
                var yearForecast = negativeKarmicPeriod * contour.Year;

                var yearForecastString = yearForecast.ToString();
                if (yearForecastString.Length < 12)
                {
                    string prefix = yearForecastString.Substring(0, 12 - yearForecastString.Length);
                    yearForecastString += prefix;

                    return yearForecastString;
                }
                return yearForecastString;
            }

            string CalculatePositiveForecastYear(string negativeForecast, int karmicNumber)
            {
                StringBuilder tempLine = new StringBuilder();

                foreach (char ch in negativeForecast)
                {
                    tempLine.Append(SumDigitsHelper.SumDigits(ch - '0' + karmicNumber));
                }
                return tempLine.ToString();
            }

            var enetgyPotential = SumDigitsHelper.SumDigits(Convert.ToDouble(monthlyNegativeForecast));
            while (enetgyPotential > 9)
            {
                enetgyPotential = SumDigitsHelper.SumDigits(enetgyPotential);
            }

            var positiveDigit = SumDigitsHelper.SumDigits(enetgyPotential + karmicNumber);
            while (positiveDigit > 9)
            {
                positiveDigit = SumDigitsHelper.SumDigits(positiveDigit);
            }

            var result = new FullResponse()
            {
                InnatePotential = await CalculationInnatePotential(birth),
                TopLine = topLineLife,
                BottomLine = BottomLineOfLifeCode(topLineLife, karmicNumber),
                PeriodLength = CalculatePeriodLength(topLineLife),
                KarmicNumber = karmicNumber,
                MonthlyNegativeForecast = monthlyNegativeForecast,
                MonthlyPositiveForecast = CalculatePositiveForecastYear(monthlyNegativeForecast, karmicNumber),
                EnergyPotentialYear = enetgyPotential,
                PositiveDigit = positiveDigit,
            };

            return result;
        }

    }
}
