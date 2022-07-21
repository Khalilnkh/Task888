using Core.Entities;
using Core.Entities.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class StudentController
    {
        private StudentRepository _studentRepository;
        private GroupRepository _groupRepository;

        public StudentController()
        {

            _studentRepository = new StudentRepository();
      
        
        }

        #region CreateStudent
        public void CreateStudent()
        {
            var groups = _groupRepository.GetAll();
            if (groups.Count != 0)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, Enter student name");
                string name = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please , Enter student surname");
                string surname = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, Enter student age");
                string age = Console.ReadLine();
                byte studentAge;
                bool result = byte.TryParse(age, out studentAge);
                AllGroupsList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Allgroups");
                foreach (var group in groups)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, group.Name);
                }
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, Enter group name");
                string groupName = Console.ReadLine();
                var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
                if (dbGroup != null)
                {
                    if (dbGroup.MaxSize > dbGroup.CurrentSize)
                    {
                        var student = new Student
                        {
                            Name = name,
                            Surname = surname,
                            age = studentAge,
                            Group = dbGroup
                        };
                        dbGroup.CurrentSize++;

                        _studentRepository.Create(student);
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name;{student.Name}, Surname;{student.Surname}, Age:{student.age} Group:{student.Group.Name}");
                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, $"Group is full, max size of group {dbGroup.MaxSize}");
                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Including group doesnt exist");
                }


            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "You have to create group before creating of student");
            }
        }
    }
}
#endregion
