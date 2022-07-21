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
    public class GroupRepository : IRepository<Group>
    {
        private static int Id;
        public Group Create(Group entity)
        {
            Id++;
            entity.Id = Id;
            Dbcontext.Groups.Add(entity);
            return entity;
        }

        public void Delete(Group entity)
        {
            Dbcontext.Groups.Remove(entity);
        }

        public Group Get(Predicate<Group> filter = null)
        {
            if (filter==null)
            {
                return Dbcontext.Groups[0];
            }
            else
            {
                return Dbcontext.Groups.Find(filter);
            }
        }

        public List<Group> GetAll(Predicate<Group> filter = null)
        {
            if (filter==null)
            {
                return Dbcontext.Groups;

            }
            else
            {
                return Dbcontext.Groups.FindAll(filter);
            }
        }

        public void Update(Group entity)
        {
            var group = Dbcontext.Groups.Find(g => g.Id == entity.Id);
            if (group!=null)
            {
                group.Name = entity.Name;
                group.MaxSize = entity.MaxSize;
                
            }
        }
    }
}
