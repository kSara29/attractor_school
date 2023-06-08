namespace hw_25;

public class Bank<T> where T: Account
{
    public void AllAccountInfo(T account)
    {
        Console.WriteLine($"Account info: \n\tid - {account.id}, \n\towner - {account.ownerName}, \n\tsum - {account.sum}, \n\tcurrency - {account.currency}\n");
    }
}