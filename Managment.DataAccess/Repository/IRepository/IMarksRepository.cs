using Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.DataAccess.Repository.IRepository
{
    public interface IMarksRepository : IRepository<MarksDetail>
    {
        void Update(MarksDetail obj);

    }
}
