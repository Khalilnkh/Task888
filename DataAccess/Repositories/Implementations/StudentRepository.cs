using Core.Entities;
using DataAccess.Context;
using DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations
{
    public class StudentRepository:IRepository<Student>
    {
        public Student Create(Student entity)
        {
            Dbcontext.Students.Add(entity);
            return entity;
        }

        public void Delete(Student entity)
        {
            Dbcontext.Students.Remove(entity);
        }

        public Student Get(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return Dbcontext.Students[0];
            }
            else
            {
                return Dbcontext.Students.Find(filter);
            }
        }

        public List<Student> GetAll(Predicate<Student> filter = null)
        {
            if (filter == null)
            {
                return Dbcontext.Students;

            }
            else
            {
                return Dbcontext.Students.FindAll(filter);
            }
        }

        public void Update(Student entity)
        {
            var student = Dbcontext.Students.Find(g => g.Id == entity.Id);
            if (student != null)
            {
                student.Name = entity.Name;
                student.Surname = entity.Surname;

            }
        }

        
    }
}
