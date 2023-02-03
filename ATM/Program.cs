using System;

public class cardHolder
{
    String cardName;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardName, int pin, string firstName, string lastName, double balance)
    {
        this.cardName = cardName;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum ()
    {
        return cardName;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName ()
    {
        return firstName;
    }

    public string getLastName ()
    {
        return lastName;
    }

    public double getBalance ()
    {
        return balance;
    }

    public void setNum(String newCardName)
    {
        cardName = newCardName;
    }

    public void setPin (int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please chooose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your Bread. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //Checks to see if the user haas enough money to withdraw
            if (currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient balance sorry :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you, you're all set to go!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        //mini database showing the users card numbers
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4569456323476572", 2345, "John", "Cena", 345.92));
        cardHolders.Add(new cardHolder("5649345285892495", 1256, "Brian", "Smith", 567.09));
        cardHolders.Add(new cardHolder("4578390283647578", 0687, "David", "Luu", 235.67));
        cardHolders.Add(new cardHolder("3548382647735376", 4509, "Stephen", "Janky", 134.56));

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card");
        String debitCardnumber = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardnumber = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardName == debitCardnumber);
                if (currentUser != null) { break;  }
                else { Console.WriteLine("Card not recognized. Please try again");  }
            }
            catch { Console.WriteLine("Card not recognized. Please try again");  }
        }

        Console.WriteLine("Pleae enteryour pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.cardName == debitCardnumber);
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Wrong pin. Please try again"); }
            }
            catch { Console.WriteLine("Wrong pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a great day");

    }
}