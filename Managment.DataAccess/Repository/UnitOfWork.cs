using Managment.DataAccess.Data;
using Managment.DataAccess.Repository.IRepository;
using Managment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IStudentRepository Student { get; private set; }
        public ITeacherRepository Teacher { get; private set; }
        public IMarksRepository MarksDetails { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Student = new StudentRepository(_db);
            Teacher = new TeacherRepository(_db);
            MarksDetails = new MarksRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
