


using Core.Constant;
using Core.Entities;
using Core.Entities.Helpers;
using DataAccess.Repositories.Implementations;
using Manage.Controllers;

namespace Manage

{
    public class Program
    {
        static void Main()
        {
            GroupController _groupController = new GroupController();
             
            StudentRepository _studentRepository = new StudentRepository();
            GroupRepository groupRepository = new GroupRepository();
            

            ConsoleHelpers.WriteTextWithColor(ConsoleColor.Green, "Welcome");
            Console.WriteLine("-----");

            while (true)
            {
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Groups");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Group by name");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "6 - Create Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "7 - Update Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "8 - Delete Student");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "9 - All Students by Group");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                Console.WriteLine("-----");
                ConsoleHelpers.WriteTextWithColor(ConsoleColor.Gray, "Select Option");
                string number = Console.ReadLine();

                int selectedNumber;
                bool result = int.TryParse(number, out selectedNumber);
                if (result)
                {
                    if (selectedNumber >= 0 && selectedNumber <= 5)
                    {
                        switch (selectedNumber)
                        {
                            case (int)Options.CreateGroup:
                                _groupController.CreateGroup();

                                break;
                            case (int)Options.UpdateGroup:
                                _groupController.UpdateGroup();
                               
                                break;
                            case (int)Options.DeleteGroup:
                                _groupController.DeleteGroup();
                                break;
                            case (int)Options.AllGroups:
                                _groupController.AllGroups();
                                break;
                            case (int)Options.GetGroupByName:
                                _groupController.GetGroupByName();
                                break;
                            case (int)Options.CreatStudent:
                                _groupController.CreateGroup();
                              break;
                            case (int)Options.UpdateStudent:
                                _groupController.UpdateGroup();
                                break;
                            case (int)Options.GetAllStudentsbyGroup:
                                _groupController.GetGroupByName();
                                break;
                            case (int)Options.Exit:
                                _groupController.Exit();
                                return;

                        }

                    }
                    else
                    {
                        ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");

                    }

                }
                else
                {
                    ConsoleHelpers.WriteTextWithColor(ConsoleColor.Red, "Please enter correct number");
                }
            }








        }

    }
}