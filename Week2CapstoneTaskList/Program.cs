using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            string response = "y";
           
            while(response == "y")
            {
                Console.WriteLine("1.  List tasks");
                Console.WriteLine("2.  Add task");
                Console.WriteLine("3.  Delete task");
                Console.WriteLine("4.  Mark task complete");
                Console.WriteLine("5.  Quit");


                Console.WriteLine("Wagan 'Mon!, select something from the menu!: ");


                switch (Console.ReadLine())
                {
                    //Printing all of the list.
                    case "1":
                        foreach (Task task in tasks)
                        {
                            foreach (string member in task.members)
                            {
                                Console.WriteLine(member);
                            }
                            Console.WriteLine(task.date);
                            Console.WriteLine(task.status);
                            Console.WriteLine(task.description);
                        }
                        break;

                    case "2":
                        string newMember = "wagga mon";
                        Task newTask = new Task();
                        while (newMember != "")
                        {
                            Console.WriteLine("Add a member or press enter to move on the menu: ");
                            newMember = Console.ReadLine();
                            newTask.members.Add(newMember);
                        }
                        Console.WriteLine("Please enter date: ");
                        newTask.date = Console.ReadLine();

                        Console.WriteLine("Please enter description: ");
                        newTask.description = Console.ReadLine();

                        tasks.Add(newTask);

                        break;

                    case "3":
                        
                        // we put deleteindex in the index of tasks (whatever they chose)
                        if (tasks.Remove(GetTask(tasks, "What would you like to delete")))
                        {
                            Console.WriteLine("Task removed");
                        }
                        else
                        {
                            Console.WriteLine("That item is not found. You can only delete an actual task.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Which task would you like to mark complete?");
                        int indexMark = int.Parse(Console.ReadLine());
                        indexMark--;

                        tasks[indexMark].status = true;
 
                        break;

                    case "5": response = "n";

                        break;

                    default: break;
                }
                if(response != "y")
                {
                    response = "n";
                }
                else
                {
                    Console.WriteLine("Would you like to continue: (y or n)");
                    response = Console.ReadLine();
                }
                
            }
            
            






        }

        public static Task GetTask(List<Task> list, string message)
        {
            Console.WriteLine(message);
            int deleteIndex = int.Parse(Console.ReadLine());
            // decrement - 1 so that the number is accurate to the array lst
            deleteIndex--;
            return list[deleteIndex];


        }




    }

}
