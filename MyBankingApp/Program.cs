// See https://aka.ms/new-console-template for more information
using BankApp.Entity;

while (true)
{
    Console.Clear();
    Console.Title = "Banking App";

    Console.WriteLine("-----------Welcome to Banking App--------------\n");
    Console.WriteLine("1.  Create an Account                  ");
    Console.WriteLine("2.  Login                              ");
    Console.WriteLine("3.  Exit                               ");

    Console.WriteLine("Select an Option: ");
    int options = int.Parse(Console.ReadLine());

    if (options == 1)
    {
        CreateAccount.Signup();
    }

    else if (options == 2)
    {
        CreateAccount.Login();
    }

    else if (options == 3)
    {

        CreateAccount.Logout();
    }
    else
    {        
        Console.WriteLine("Invalid Value Selected. Please select a valid option from 1 - 3");
        Console.WriteLine("Press Enter to Continue");
    }

    Console.ReadLine();

}
