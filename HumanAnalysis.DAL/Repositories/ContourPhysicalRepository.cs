using HumAnalysis.Domain.Entity;
using HumanAnalysis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Repositories
{
    public class ContourPhysicalRepository: IContourRepository<PhysicalContour>
    {
        private readonly ApplicationDbContext _db;

        public ContourPhysicalRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<PhysicalContour> GetAllContour()
        {
            return _db.PhysicalContours;
        }
    }
}
