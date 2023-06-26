using lab_work_31;

class Task
{
    public string name { get; set; }
    public string description { get; set; }
    public DateTime finishedDate { get; set; }
    public DateTime createdDate { get; set; }
    public Priority priority { get; set; }
    private State _state;
    public string State { get => _state.GetType().Name.ToString(); }
    public List<Task> tasks = new List<Task>();

    public Task(string name, string description, DateTime finishedDate, DateTime createdDate, Priority priority, string state)
    {
        this.name = name;
        this.description = description;
        this.finishedDate = finishedDate;
        this.createdDate = createdDate;
        this.priority = priority;

        switch (state)
        {
            case ("InNewState"):
                this._state = new InNewState();
                this.TransitionTo(new InNewState());
                break;

            case ("InProgressState"):
                this._state = new InProgressState();
                this.TransitionTo(new InProgressState());
                break;

            case ("InDoneState"):
                this._state = new InDoneState();
                this.TransitionTo(new InDoneState());
                break;
        }

    }

    public void TransitionTo(State state)
    {
        this._state = state;
        this._state.SetStatus(this);
    }

    public List<Task> DeleteTask(int index, List<Task> taskList, JsonData jsonData)
    {
        this._state.DeleteTask(index, taskList, jsonData);
        return this.tasks;
    }

    public void ChangeDescription(string newDescription)
    {
        this._state.ChangeDescription(newDescription);
    }

    public void ChangeStatus(int status)
    {
        this._state.ChangeStatus(status);
    }
}

public enum Priority
{
    низкий,
    средний,
    высокий
}