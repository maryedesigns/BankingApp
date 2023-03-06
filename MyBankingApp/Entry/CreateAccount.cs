using BankApp.App;

namespace BankApp.Entity
{
    public class CreateAccount
    {
        public string? UserName { get; set; }
        
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Age { get; set; }
        
        public string? Phone { get; set; }

        public decimal Balance { get; set; }

        public List<Transactions>? Transaction { get; set; }

        public CreateAccount(string username, string password, string email, string age, string phone, decimal balance)
        {
            UserName = username;
            Password = password;
            Email = email;
            Age = age;
            Phone = phone;
            Balance = balance;
            Transaction = new List<Transactions>();
        }

        public static void Signup()
        {
            Console.Clear();
            Console.WriteLine("*****************Registering a new User******************\n");

            string username;
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            while (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username field is required. Please enter your username again.");
                username = Console.ReadLine();
            }

            string password;
            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password field is required. Please enter your password again.");
                password = Console.ReadLine();
            }

            string email;
            Console.Write("Enter your email: ");
            email = Console.ReadLine();

            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email field is required. Please enter your email again.");
                email = Console.ReadLine();
            }

            string age;
            Console.Write("Enter your age: ");
            age = Console.ReadLine();

            while (string.IsNullOrEmpty(age))
            {
                Console.WriteLine("age field is required. Please enter your age again.");
                age = Console.ReadLine();
            }

            string phone;
            Console.Write("Enter your phone: ");
            phone = Console.ReadLine();

            while (string.IsNullOrEmpty(phone))
            {
                Console.WriteLine("phone field is required. Please enter your phone again.");
                phone = Console.ReadLine();
            }

            decimal balance = 100000;

            List<Transactions> transaction = new List<Transactions>();

            var user = new CreateAccount(username,password,email,age,phone,balance);

            string filename = @"C:\Users\erhie\Desktop\Bank\MyBankingApp\" + $"{user.UserName}.txt";

            if (File.Exists(filename))
            {
                Console.WriteLine("Username already exists!");
            }

            else
            {
                SaveUserToFile(user);

                Console.WriteLine($"Congratulations {username}! Your account has been created with username: {username}.");
                Console.WriteLine("Press Enter to Continue");
            }

            
        }

        public static void SaveUserToFile(CreateAccount user)
        {
            string filePath = $@"C:\Users\erhie\Desktop\Bank\MyBankingApp\{user.UserName}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Username: {user.UserName}");
                writer.WriteLine($"Password: {user.Password}");
                writer.WriteLine($"Email: {user.Email}");
                writer.WriteLine($"Age: {user.Age}");
                writer.WriteLine($"Phone: {user.Phone}");
                writer.WriteLine($"Balance: {user.Balance}");
                writer.WriteLine("Transaction Summary:");


            }
        }

        public static void Login()
        {
            Console.Clear();

            Console.WriteLine("*****************Login into Account********************\n");
            
            string username;
            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            while (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Username field is required. Please enter your username again.");
                username = Console.ReadLine();
            }

            string password;
            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password field is required. Please enter your password again.");
                password = Console.ReadLine();
            }

            string file = $"{username}";
            CreateAccount user = LoadCustomerFromFile(file);
            var name = user.UserName.Split(' ')[1];
            var userPassword = user.Password.Split(' ')[1];

            if (name == username && userPassword == password)
            {
                Console.Clear();
                Console.WriteLine($"Login Successful. Welcome {user.UserName}\n");
                bool isLoggedIn = true;

                while (isLoggedIn)
                {
                    
                    Console.WriteLine("1.  Account Balance                    ");
                    Console.WriteLine("2.  Cash Deposit                       ");
                    Console.WriteLine("3.  Withdrawal                         ");
                    Console.WriteLine("4.  Transcations                       ");
                    Console.WriteLine("5.  Exit                               ");
                    Console.WriteLine("\nPlease select an option:");

                    string choice = Console.ReadLine();
                 
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Bank.Balance();
                            break;

                        case "2":
                            Console.Clear();
                            Bank.Deposit(username);
                            break;

                        case "3":
                            Console.Clear();
                            Bank.Withdrawal(username);
                            break;

                        case "4":
                            Console.Clear();
                            Bank.DisplayTransactionHistory();
                            break;

                        case "5":
                            Console.Clear();
                            isLoggedIn = false;
                            Logout();
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }

                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");

            }
        }

        public static CreateAccount LoadCustomerFromFile(string name)
        {
            string fileName = @"C:\Users\erhie\Desktop\Bank\MyBankingApp\" + $"{name}.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            string[] lines = File.ReadAllLines(fileName);

            if (lines.Length < 5)
            {
                Console.WriteLine("File has incorrect format.");
                throw new FormatException("File has incorrect format.");
            }

            string username = lines[0];
            string hashedPassword = lines[1];
            string email = lines[2];
            string age = lines[3];
            string phone = lines[4];
            decimal balance = decimal.Parse(lines[5].Substring(9));
            
            CreateAccount user = new CreateAccount(username, hashedPassword, email, age, phone, balance);

            return user;
        }

        public static void SaveCustomersToFile(List<CreateAccount> createAccounts)
        {
            string fileName = "user.txt";
            string filePath = @"C:\Users\erhie\Desktop\Bank\MyBankingApp\" + fileName;

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (CreateAccount account in createAccounts)
                {
                    writer.WriteLine($"{ account.UserName},{account.Password},{account.Email},{account.Age},{account.Balance}");
                }
            }
        }

        public static void Logout()
        {
            Console.WriteLine("Thank You for banking with us..");
            Environment.Exit(0);
        }

    }
}
