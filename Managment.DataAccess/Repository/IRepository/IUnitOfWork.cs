using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.DataAccess.Repository.IRepository
{
    public interface  IUnitOfWork
    {
        IStudentRepository Student{ get; }
        ITeacherRepository Teacher { get; }
       IMarksRepository MarksDetails { get; }
        void Save();
    }
}
