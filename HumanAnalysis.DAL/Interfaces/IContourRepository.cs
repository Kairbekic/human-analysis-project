using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAnalysis.DAL.Interfaces
{
    public interface IContourRepository<T>
    {
        IQueryable<T> GetAllContour();
    }
}
