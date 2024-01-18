using HumAnalysis.Domain.Entity;
using HumanAnalysis.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Repositories
{
    public class ContourEmotionalRepository : IContourRepository<EmotionalContour>
    {
        private readonly ApplicationDbContext _db;

        public ContourEmotionalRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<EmotionalContour> GetAllContour()
        {
            return _db.EmotionalContours;
        }
    }
}
