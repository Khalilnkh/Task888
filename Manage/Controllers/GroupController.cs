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
    public class GroupController
    {

        private GroupRepository _groupRepository;
        public GroupController()
        {
            _groupRepository = new GroupRepository();


        }


        #region CreateGroup
        public void CreateGroup()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Name:");
            string name = Console.ReadLine();
            maxsize: ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Enter Group Maxsize:");
            string size = Console.ReadLine();
            int maxsize;
            bool result = int.TryParse(size, out maxsize);
            if (result)
            {
                Group group = new Group
                {
                    Name = name,
                    MaxSize = maxsize

                };
                var createdGroup = _groupRepository.Create(group);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"{createdGroup.Name} is successfully created with max size {createdGroup.MaxSize}");

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct group maxsize:");
                goto maxsize;
            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteGroup()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "Please, enter group name");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                _groupRepository.Delete(group);
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name: {name} is deleted");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "This group doesnt existed");
            }
        }

        #endregion

        #region UpdateGroup
        public void UpdateGroup()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Magenta, "Please, enter group name");
            string name = Console.ReadLine();

            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            
            if (group != null)
            {
                int oldSize = group.MaxSize;
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkCyan, "Please, enter new group name");
                string newName = Console.ReadLine();
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkCyan, "Please, enter new group max size");
                string size = Console.ReadLine();
                int maxsize;
                bool result = int.TryParse(size, out maxsize);
                if (true)
                {

                    var newGroup = new Group
                    {
                        Name = newName,
                        MaxSize = maxsize,
                        Id = group.Id,
                    };
                    _groupRepository.Update(newGroup);
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{name} Max size:{oldSize}is updated to Name:{newGroup.Name} Maxsize:{newGroup.MaxSize}");
                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct group max siz");
                }

            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please , enter correct group name");
            }

        }


        #endregion

        #region AllGroups

        public void AllGroups()
        {
            var groups = _groupRepository.GetAll();
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.DarkBlue, "All Groups");
            foreach (var group in groups)
            {
                Console.WriteLine($"Name;{group.Name} Maxsize {group.MaxSize}");
            }
        }


        #endregion

        #region GetGroupsByName
        public void GetGroupByName()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Blue, "Please, enter group name");
            string name = Console.ReadLine();
            var group = _groupRepository.Get(g => g.Name.ToLower() == name.ToLower());
            if (group != null)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, $"Name:{group.Name} Maxsize{group.MaxSize}");
            }
            else
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Group nox existed");
            }
        }

        #endregion

        #region Exit

        public void Exit()
        {
            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Thanks for using our accplication");


        }


        #endregion

    }

}
