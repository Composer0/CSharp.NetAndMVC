using System;

public class CardHolder
{
    string CardNumber;
    int Pin;
    string FirstName;
    string LastName;
    double Balance;


    //Curious to see learn how to switch from what is written below to this. Because this looks like it should do the same thing.
    //public string CardNumber { get; set; }
    //public int Pin { get; set; }
    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public double Balance { get; set; }

    public CardHolder(string CardNumber, int Pin, string FirstName, string LastName, double Balance) //Constructor
    {
        this.CardNumber = CardNumber; //Objects.... We constructed objects to be used.
        this.Pin = Pin;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Balance = Balance;
    }

    public string GetNumber()
    {
        return CardNumber;
    }

    public int GetPin()
    {
        return Pin;
    }

    public string GetFirstName()
    {
        return FirstName;
    }
    public string GetLastName()
    {
        return LastName;
    }
    public double GetBalance()
    {
        return Balance;
    }

    public void SetNumber(string NewCardNumber) //remember in a set string, things like NewCardNumber are values that are never seen elsewhere.
    {
        CardNumber = NewCardNumber;
    }

    public void SetPin(int NewPin)
    {
        Pin = NewPin;
    }

    public void SetFirstName(string NewFirstname)
    {
        FirstName = NewFirstname;
    }

    public void SetLastName(string NewLastName)
    {
        LastName = NewLastName;
    }

    public void SetBalance(double NewBalance)
    {
        Balance = NewBalance;
    }


    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(CardHolder CurrentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double Deposit = Double.Parse(Console.ReadLine()); //5:45
            CurrentUser.SetBalance(CurrentUser.GetBalance() + Deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + CurrentUser.GetBalance());
        }

        void Withdraw(CardHolder CurrentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double Withdraw = Double.Parse(Console.ReadLine());
            //Check if the user has enough money
            if(CurrentUser.GetBalance() < Withdraw)
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                CurrentUser.SetBalance(CurrentUser.GetBalance() - Withdraw);
                Console.WriteLine("Thank you for your business! Enjoy your $" + Withdraw + "!");
            }
        }

        void Balance(CardHolder CurrentUser)
        {
            Console.WriteLine("Current balance: " + CurrentUser.GetBalance());
        }

        List<CardHolder> cardHolders = new List<CardHolder>(); //type is drawing upon a list.
        cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new CardHolder("1234772818527395", 4274, "Hero", "Dragon", 321.13));
        cardHolders.Add(new CardHolder("5678772818527395", 2232, "Mark", "Cuban", 851.84));
        cardHolders.Add(new CardHolder("9008772818527395", 9876, "Alan", "Aldo", 54.21));
        cardHolders.Add(new CardHolder("2876772818527395", 3214, "Leroy", "Jenkins", 2.15));

        //Prompt User
        Console.WriteLine("Welcome to OrionATM");
        Console.WriteLine("Please insert your debit card: ");
        string DebitCardNumber = "";
        CardHolder CurrentUser;

        while (true)
        {
            try
            {
                DebitCardNumber = Console.ReadLine();
                //Check against our database
                CurrentUser = cardHolders.FirstOrDefault(a => a.CardNumber == DebitCardNumber);
                if(CurrentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int UserPin = 0;
        while (true)
        {
            try
            {
                UserPin = int.Parse(Console.ReadLine()); //int.Parse has to be used because you can not set a string set to int. Parse must occur.
                //Check against our database
                if (CurrentUser.GetPin() == UserPin) { break; }
                else { Console.WriteLine("Incorrect Pin. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + CurrentUser.GetFirstName() + " " + CurrentUser.GetLastName() + ".");
        int Option = 0;
        do
        {
            PrintOptions();
            try
            {
                Option = int.Parse(Console.ReadLine());
            }
            catch
            {
                //Nothing should be here for this try/catch method.
            }
                if(Option == 1) { Deposit(CurrentUser); }
                else if(Option == 2) { Withdraw(CurrentUser); }
                else if(Option == 3) { Balance(CurrentUser); }
                else if(Option == 4) { break; }
                else { Option = 0; }
        }
        while (Option != 4);
        Console.WriteLine("Thank you! Have a great day!");
    }
}
