using lab_work_31;
using Newtonsoft.Json;

public class StartProgramm
{
    public void Start()
    {
        JsonData jsonData = new JsonData();
        List<Task> task_list = new List<Task>();
        task_list = jsonData.GetProducts();

        while (true)
        {
            if (task_list.Count == 0)
            {
                Console.WriteLine("Задачи еще не созданы. Вы можете создать свою первую задачу");
                AddNewTask(jsonData, task_list);
            }
            else
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("\t1. Отобразить все задачи");
                Console.WriteLine("\t2. Добавить новую задачу");
                Console.WriteLine("\t3. Выход");
                Console.Write("Ваш ответ: ");
                int userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("\nСписок задач:");
                        DisplayTasks(task_list, jsonData);
                        break;
                    case 2:
                        task_list = AddNewTask(jsonData, task_list);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    static void DisplayTasks(List<Task> displayTasks, JsonData jsonData)
    {
        int index = 1;
        foreach (Task task in displayTasks)
        {
            Console.WriteLine($"\t{index}. {task.name};");
            index++;
        }

        ChooseTask(displayTasks, jsonData);
    }

    static void ChooseTask(List<Task> task_list, JsonData jsonData)
    {
        Console.Write("\nВыберите задачу: ");
        int userChoiceIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        Task userChoiceTask = task_list[userChoiceIndex];

        Console.WriteLine(@$"Подробная информация:
        Имя задачи: {userChoiceTask.name};
        Описание задачи: {userChoiceTask.description}; 
        Дата создания задачи: {userChoiceTask.createdDate};
        Дата завершения задачи: {userChoiceTask.finishedDate};
        Приоритет задачи: {userChoiceTask.priority}
        Статус задачи: {userChoiceTask.State}");

        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("\t1. Изменить описание задачи");
        Console.WriteLine("\t2. Изменить статус задачи");
        Console.WriteLine("\t3. Удалить задачу");
        Console.WriteLine("\t4. Выход");
        Console.Write("Ваш ответ: ");

        int userChoiceAction = Convert.ToInt32(Console.ReadLine());

        switch (userChoiceAction)
        {
            case 1:
                task_list = ChangeTaskDescription(jsonData, userChoiceTask, task_list);
                break;
            case 2:
                task_list = ChangeTaskStatus(jsonData, userChoiceTask, task_list);
                break;
            case 3:
                task_list = DeleteTask(jsonData, userChoiceTask, task_list, userChoiceIndex);
                break;
            case 4:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Такого пункта не существует. Выберите один из предложенных!");
                break;
        }

    }

    static List<Task> AddNewTask(JsonData jsonData, List<Task> task_list)
    {
        Console.Write("Введите имя задачи: ");
        string taskName = Console.ReadLine();

        Console.Write("Введите описание задачи: ");
        string taskDescription = Console.ReadLine();

        Console.Write("Введите дату завершения задачи: ");
        DateTime finishedDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Выберите приоритет задачи: \n\t1. Низкий \n\t2. Средний \n\t3. Высокий");
        Console.Write("Ваш ответ: ");
        int priority = Convert.ToInt32(Console.ReadLine());

        Task task;
        switch(priority)
        {
            case(1): 
                task = new Task(taskName, taskDescription, finishedDate, DateTime.Now, Priority.низкий, "InNewState");
                task_list.Add(task);
                break;
            case(2):
                task = new Task(taskName, taskDescription, finishedDate, DateTime.Now, Priority.средний, "InNewState");
                task_list.Add(task);
                break;
            case(3):
                task = new Task(taskName, taskDescription, finishedDate, DateTime.Now, Priority.высокий, "InNewState");
                task_list.Add(task);
                break;
        }

        task_list = task_list.OrderByDescending(t => t.priority).ToList();

        jsonData.SerializeTasks(task_list);
        task_list = jsonData.GetProducts();

        return task_list;
    }

    static List<Task> ChangeTaskDescription(JsonData jsonData, Task userChoiceTask, List<Task> tasks)
    {
        Console.Write("Введите новое описание: ");
        string newDescription = Console.ReadLine();
        userChoiceTask.ChangeDescription(newDescription);
        tasks = tasks.OrderByDescending(t => t.priority).ToList();
        jsonData.SerializeTasks(tasks);
        tasks = jsonData.GetProducts();

        return tasks;
    }

    static List<Task> DeleteTask(JsonData jsonData, Task chosenTask, List<Task> taskList, int userChoice)
    {
        taskList = chosenTask.DeleteTask(userChoice, taskList, jsonData);
        jsonData.SerializeTasks(taskList);
        taskList = jsonData.GetProducts();

        return taskList;
    }

    static List<Task> ChangeTaskStatus(JsonData jsonData, Task chosenTask, List<Task> taskList)
    {
        Console.WriteLine("Выбиретие статус задачи:\n\t1. Новая; \n\t2. В работе; \n\t3. Сделано");
        Console.Write("Ваш ответ: ");
        int userChoiceStatus = Convert.ToInt32(Console.ReadLine());

        chosenTask.ChangeStatus(userChoiceStatus);

        jsonData.SerializeTasks(taskList);
        taskList = jsonData.GetProducts();

        return taskList;
    }
}