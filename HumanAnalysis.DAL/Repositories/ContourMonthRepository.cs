using HumAnalysis.Domain.Entity;
using HumanAnalysis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Repositories
{
    public class ContourMonthRepository : IContourRepository<MonthContour>
    {
        private readonly ApplicationDbContext _db;

        public ContourMonthRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<MonthContour> GetAllContour()
        {
            return _db.MonthContours;
        }
    }


}
