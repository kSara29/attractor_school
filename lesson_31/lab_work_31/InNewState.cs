using lab_work_31;

class InNewState: State
{
    public override void ChangeDescription(string newDescription)
    {
        this._task.description = newDescription;
        Console.WriteLine("Описание задачи изменено!");
    }

    public override void ChangeStatus(int status)
    {
        switch(status)
        {
            case(1):
                Console.WriteLine("У задачи и так установлен статус \"Новая\"!");
                break;
            case(2):
                this._task.TransitionTo(new InProgressState());
                Console.WriteLine("Статус изменен на \"В работе\"!");
                break;
            case(3):
                Console.WriteLine("Новая задача не может быть сделана!");
                break;
        }
    }

    public override void DeleteTask(int index, List<Task> taskList, JsonData jsonData)
    {
        taskList.RemoveAt(index);
        jsonData.SerializeTasks(taskList);
        taskList = jsonData.GetProducts();
        this._task.tasks = taskList;
    }
}