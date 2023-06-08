using System;
using hw_25;

public class Program
{
    static void Main(string[] args)
    {
        // Task 1
        int[] intArr = { 1, 7, 3, 4, 2, 1, 5};
        string[] stringArr = { "bha", "aab", "ac", "aac", "brb" };

        General<int> intArray = new General<int>();
        int[] intArrSort = intArray.SortArray(intArr);
        int[] intReverse = intArray.ReverseArray(intArr);

        General<string> stringArray = new General<string>();
        string[] strSort = stringArray.SortArray(stringArr);
        string[] strReverse = stringArray.ReverseArray(stringArr);

        

        // Task 2
        Bank<Account> bank1 = new Bank<Account>();

        DepositAccount depAcc  = new DepositAccount{ id = 1, ownerName = "Sasuke", sum = 5000, currency = "USD"};
        TransitAccount tranAcc = new TransitAccount{ id = 2, ownerName = "Naruto", sum = 6000, currency = "EUR"};
        ClosedAccount  clAcc   = new ClosedAccount { id = 3, ownerName = "Kimchi", sum = 4000, currency = "KZT"};

        bank1.AllAccountInfo(depAcc);
        bank1.AllAccountInfo(tranAcc);
        bank1.AllAccountInfo(clAcc);
    }
}
