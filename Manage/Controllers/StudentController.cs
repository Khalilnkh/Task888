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
        #endregion

        #region
        public void UpdateStudent()
        {
            GetAllstudentsByGroup();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter student id");
            string id = Console.ReadLine();
            int studentid;
            bool result = int.TryParse(id, out studentid);
            var studentId = _studentRepository.Get(s => s.Id == studentid);
            if (studentid !== null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter new student name");
                string newName = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkMagenta, " Please enter new student surname");
                string newSurname = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please, enter new student age");
                string Age = Console.ReadLine();
                byte newAge;
                result = byte.TryParse(Age, out newAge);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter new group name");
                string newGroupName = Console.ReadLine();
                if (studentId.Group.Name.ToLower() == newGroupName.ToLower())
                {
                    studentId.Surname = newSurname;
                    studentId.age = newAge;
                    studentId.Name = newName;
                    _studentRepository.Update(studentId);

                }
                else
                {
                    studentId.Surname = newSurname;
                    studentId.age = newAge;
                    studentId.Name = newName;
                    var group = _groupRepository.Get(g => g.Name.ToLower() == newGroupName.ToLower());
                    if (group != null)
                    {
                        studentId.Group.CurrentSize--;
                        studentId.Group = group;
                        studentId.Group.CurrentSize++;
                        _studentRepository.Update(studentId);

                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkMagenta, "Please enter correct group name");
                        goto Groupname;
                    }
                }


            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter student id");
            }
        }
        #endregion

        #region
        public void GetAllStudentsByGroup()
        {
            var groups = _groupRepository.GetAll();

        GroupAllList: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "All groups");

            foreach (var group in groups)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, group.Name);

            }
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter group name");
            string groupName = Console.ReadLine();

            var dbGroup = _groupRepository.Get(g => g.Name.ToLower() == groupName.ToLower());
            if (dbGroup != null)
            {
                var groupStudents = _studentRepository.GetAll(s => s.Group.Id == dbGroup.Id);

                if (groupStudents.Count != 0)
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "All students of the group");


                    foreach (var groupStudent in groupStudents)
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{groupStudent.Name} {groupStudent.Surname} {groupStudent.Age}");
                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, $"There is no student in this group - {dbGroup.Name}");
                }


            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Including group doesn't exist");
            }
            goto GroupAllList;
        }
        #endregion



    }
}


