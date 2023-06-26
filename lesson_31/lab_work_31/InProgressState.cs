using lab_work_31;

class InProgressState: State
{
    public override void ChangeDescription(string newDescription)
    {
        Console.WriteLine("Нельзя менять описание выполняющеся задачи!");
    }

    public override void ChangeStatus(int status)
    {
        switch(status)
        {
            case(1):
                Console.WriteLine("Выполняющаяся задача не может быть новой!");
                break;
            case(2):
                Console.WriteLine("У задачи и так установлен статус \"В работе\"!");
                break;    
            case(3):
                this._task.TransitionTo(new InDoneState());
                Console.WriteLine("Статус изменен на \"Сделано\"!");
                break;
        }
    }

    public override void DeleteTask(int index, List<Task> taskList, JsonData jsonData)
    {
         Console.WriteLine("Выполняющаяся задача не может быть удалена!");
    }
}