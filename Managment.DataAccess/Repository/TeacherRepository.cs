using Managment.DataAccess.Data;
using Managment.DataAccess.Repository;
using Managment.DataAccess.Repository.IRepository;
using Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Managment.DataAccess.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private ApplicationDbContext _db;

        public TeacherRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Teacher obj)
        {
            _db.Teachers.Update(obj);
        }
    }

}
