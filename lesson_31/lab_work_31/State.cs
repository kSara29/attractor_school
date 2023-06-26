using lab_work_31;

abstract class State
{
    protected Task _task;

    public void SetStatus(Task task)
    {
        this._task = task;
    }

    public abstract void ChangeStatus(int status);
    public abstract void DeleteTask(int index, List<Task> taskList, JsonData jsonData);
    public abstract void ChangeDescription(string newDescription);
}