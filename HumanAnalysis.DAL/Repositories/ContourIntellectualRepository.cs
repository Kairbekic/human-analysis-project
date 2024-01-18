using HumAnalysis.Domain.Entity;
using HumanAnalysis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Repositories
{
    public class ContourIntellectualRepository : IContourRepository<IntellectualContour>
    {
        private readonly ApplicationDbContext _db;

        public ContourIntellectualRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<IntellectualContour> GetAllContour()
        {
            return _db.IntellectualContours;
        }
    }
}
