using HumAnalysis.Domain.Entity;
using HumanAnalysis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Repositories
{
    public class ContourYearRepository : IContourRepository<YearContour>
    {
        private readonly ApplicationDbContext _db;

        public ContourYearRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<YearContour> GetAllContour()
        {
            return _db.YearContours;
        }
    }
}
