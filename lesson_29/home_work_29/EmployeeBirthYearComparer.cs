using home_work_29;

public class EmployeeBirthYearComparer<T>: IComparer<T> where T: Employee
{
    public int Compare(T x, T y)
    {
        if(x.birthYear > y.birthYear) 
            return 1;
        if(x.birthYear < y.birthYear) 
            return -1;
        else 
            return 0;
    }
}