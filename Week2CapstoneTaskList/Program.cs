using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week2CapstoneTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = DummyData();
            string response = "y";
           
            while(response == "y")
            {
 
                Console.WriteLine("Hi, select something from the menu!: ");


                switch (ReadUserInput())
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
                        string newMember = "Tony";
                        Task newTask = new Task();
                        while (newMember != "")
                        {
                            Console.WriteLine("Add a member or press enter to move on the menu: ");
                            //trim gets rid of all the nonsense whitespace at the front and end.
                            newMember = Console.ReadLine().Trim();
                            newTask.members.Add(newMember);
                        }
                        // check to see if the date is a valid date. 
                        bool valid;
                        string dateToValidate;
                        do
                        {
                            Console.WriteLine("Please enter date: ");
                            dateToValidate = Console.ReadLine();
                            valid = (CheckDate(dateToValidate));
                        }
                        // if the date user entered isnt valid. re run the loop
                        while (valid == false);
                        newTask.date = dateToValidate;

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

                        Task toCompleteTask = GetTask(tasks, "Which task would you like to mark complete?");
                        toCompleteTask.status = true;
 
                        break;

                    case "5": response = "n";
                        Console.WriteLine("\nGood bye!");

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

            int deleteIndex = -1;
            do
            {
                Console.WriteLine(message);
                // it is true if it successfully parsed the input and it stores the result in delete index.
                if (int.TryParse(Console.ReadLine(), out int index))
                {
                    // got rid of my decrement counter because tryparse turns value back to 0 IF it fails.
                    deleteIndex = index - 1;
                    // decrement - 1 so that the number is accurate to the array lst
                }
                else
                {
                    Console.WriteLine($"Please enter a message between 1 and {list.Count}");
                }
            }
            // if the date user entered isnt valid. re run the loop
            while (deleteIndex < 0 || deleteIndex >= list.Count);
 
            return list[deleteIndex];

        }

        public static List<Task> DummyData()
        {
            List<Task> list = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                Task task = new Task();
                for (int j = 0; j < 3; j++)
                {
                    task.members.Add($"Tony{i + 1}{j + 1}");
                }
                task.date = "08/08/2019";
                task.description = $"Project{i + 1}";
                list.Add(task);
            }
            return list;
        }

        public static bool CheckDate(string word)
        {
            if (Regex.IsMatch(word, @"^([0]?[1-9]|[1][0-2])[./-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0-9]{4}|[0-9]{2})$"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Date");
                return false;
            }
            
        }

        public static string ReadUserInput()
        {
            string userInput;
            bool isUserInputValid = false;

            do
            {
                Console.WriteLine("1.  List tasks");
                Console.WriteLine("2.  Add task");
                Console.WriteLine("3.  Delete task");
                Console.WriteLine("4.  Mark task complete");
                Console.WriteLine("5.  Quit");
                userInput = Console.ReadLine();
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                        isUserInputValid = true;
                        break;
                    default:
                        isUserInputValid = false;
                        break;
                }
                if (!isUserInputValid) { Console.WriteLine("That's not valid input. Please input 1-5"); }
            }
            while (!isUserInputValid);

            return userInput;
        }




    }

}
