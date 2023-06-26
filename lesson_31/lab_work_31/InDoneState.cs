using lab_work_31;

class InDoneState : State
{
    public override void ChangeDescription(string newDescription)
    {
        Console.WriteLine("У выполненной задача не может быть измененно описание!"); 
    }

    public override void ChangeStatus(int status)
    {
        switch(status)
        {
            case(1):
                Console.WriteLine("Выполненная задача не может быть новой!");
                break;
            case(2):
                Console.WriteLine("Выполненная задача не может быть в работе!");
                break;
            case(3):
                Console.WriteLine("У задачи и так установлен статус \"Сделано\"!");
                break; 
        }
    }

    public override void DeleteTask(int index, List<Task> taskList, JsonData jsonData)
    {
        Console.WriteLine("Выполненная задача не может быть удалена!");
    }
}