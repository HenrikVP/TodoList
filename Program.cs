class Program
{
    //int   string  bool    DateTime    DateTime
    //id,   what    done    createDate  Deadline

    static string[] toDoList;
    static int id;

    static void Main(string[] args)
    {
        toDoList = new string[0];
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("(1) Show Todo List\n(2) Add Todo Item");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    for (int i = 0; i < toDoList.Length; i++)
                        ShowTodo(toDoList[i]);
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    string todo = CreateTodo(); //TODO add to array
                    string[] tmpArr = new string[toDoList.Length + 1];
                    for (int i = 0; i < toDoList.Length; i++)
                        tmpArr[i] = toDoList[i];
                    tmpArr[toDoList.Length] = todo;
                    toDoList = tmpArr;
                    break;
                default:
                    break;
            }
        }
    }

    static void ShowTodo(string todo)
    {
        //string item = $"10|Do the dishes|false|{dt}|{dtDone}";
        string[] si = todo.Split('|');
        int id = int.Parse(si[0]);
        string chore = si[1];
        bool done = bool.Parse(si[2]);
        string create = si[3];
        string deadline = si[4];
        Console.WriteLine($"Id: {id}\nWhat to do: {chore}\nIs it done?{done}\nCreated: {create}\nDeadline: {deadline}");
    }

    static string CreateTodo()
    {
        string todo = id + "|";
        Console.WriteLine("What to do?");
        todo += Console.ReadLine();
        todo += "|false|" + DateTime.Now.ToString("HH:mm dd/MM") + "|";
        Console.WriteLine("When to do it? (hh:mm)");
        string[] dtsplit = Console.ReadLine().Split(':');
        DateTime s = DateTime.Today + new TimeSpan(int.Parse(dtsplit[0]), int.Parse(dtsplit[1]), 0);
        todo += s.ToString("HH:mm dd/MM");
        id++;

        ShowTodo(todo);
        return todo;
    }
}