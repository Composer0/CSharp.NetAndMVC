using System;
using System.Security.Cryptography.X509Certificates;

public class CardHolder
{
    string CardNumber;
    int Pin;
    string FirstName;
    string LastName;
    double Balance;

    string Funny;
    string Sad;
    string Adventure;
    string Dark;
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

        this.Funny = "Funny Story";
        this.Sad = "Sad Story";
        this.Adventure = "Adventure Story";
        this.Dark = "Dark Story";

}

    public string GetFunny()
    {
        return Funny;
    }

    public string GetSad()
    {
        return Sad;
    }

    public string GetAdventure()
    {
        return Adventure;
    }

    public string GetDark()
    {
        return Dark;
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
            Console.WriteLine("4. Story?");
            Console.WriteLine("5. Exit");
        }

        void PrintStory()
        {
            Console.WriteLine("1. A Funny Story");
            Console.WriteLine("2. A Sad Story");
            Console.WriteLine("3. An Adventure Story");
            Console.WriteLine("4. A Dark Story");
            Console.WriteLine("5. Exit");
        }
        void PrintDarkPaths()
        {
            Console.WriteLine("1. The Hero");
            Console.WriteLine("2. The Victim");
            Console.WriteLine("3. The Aggressor");
            Console.WriteLine("4. The Bystander");
            Console.WriteLine("5. Exit");
        }
        void PrintChoice()
        {
            Console.WriteLine("1. Back the ATM Menu?");
            Console.WriteLine("2. One more story?");
            Console.WriteLine("3. Exit");
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

        void Funny(CardHolder CurrentUser)
        {
            Console.WriteLine("Welcome to the joke. A story without an ending.");
        }
        void Sad(CardHolder CurrentUser)
        {
            Console.WriteLine("Welcome to our sad story. A story without an ending.");
        }
        void Adventure(CardHolder CurrentUser)
        {
            Console.WriteLine("Off we go, to sights unseen and unwritten.");
            Console.WriteLine("Until now that is... but first what is your part in our story?");
        }
        void Dark(CardHolder CurrentUser)
        {
            Console.WriteLine("End it now.");
            Console.WriteLine("Until now that is... but first what is your part in our story?");
            int DarkOption = 0;
            do
            {
                PrintDarkPaths();
                try
                {
                    DarkOption = int.Parse(Console.ReadLine());
                }
                catch { }
                if (DarkOption == 1) { Hero(CurrentUser); }
                else if (DarkOption == 2) { Victim(CurrentUser); }
                else if (DarkOption == 3) { Aggressor(CurrentUser); }
                else if (DarkOption == 4) { Bystander(CurrentUser); }
                else if (DarkOption == 5) { break; }
                else { DarkOption = 0; }
            }
            while (DarkOption != 5);
            Console.WriteLine("Thank you! Have a great day!");
        }


        void Story(CardHolder CurrentUser)
        {
            Console.WriteLine("You wanted me to tell you a story?");
            Console.WriteLine("I can tell you a story instead.");
            Console.WriteLine("But first...");
            Console.WriteLine("What type of story?");
            int StoryOption = 0;
            do
            {
                PrintStory();
                    try
                    {
                        StoryOption = int.Parse(Console.ReadLine());
                    }
                    catch { }
                    if (StoryOption == 1) { Funny(CurrentUser); }
                    else if (StoryOption == 2) { Sad(CurrentUser); }
                    else if (StoryOption == 3) { Adventure(CurrentUser); }
                    else if (StoryOption == 4) { Dark(CurrentUser); }
                    else if (StoryOption == 5) { break; }
                    else { StoryOption = 0; }
            }
            while (StoryOption != 5);
            Console.WriteLine("Thank you! Have a great day!");
        }



        void Hero(CardHolder CurrentUser)
        {
            Console.WriteLine("You see a crime being committed. You're instincts tell you to intervene. Be proud!");
            Console.WriteLine("It's time to return to why you are here.");
            Console.WriteLine("<<<<Story Ends for now...>>>>");
            Console.WriteLine("");
            int ChoiceOption = 0;
            do
            {
                PrintChoice();
                try
                {
                    ChoiceOption = int.Parse(Console.ReadLine());
                }
                catch { }
                if (ChoiceOption == 1) { PrintOptions(); }
                else if(ChoiceOption == 2) { PrintStory(); }
                else if(ChoiceOption == 3) { break; }
                else { ChoiceOption = 0; }
            }
            while (ChoiceOption != 3);
            Console.WriteLine("Thank you! Have a great day!");
            
        }
        void Victim(CardHolder CurrentUser)
        {
            Console.WriteLine("You are being attacked. It was never supposed to happen like this.");
            Console.WriteLine("It's time to return to why you are here.");
            Console.WriteLine("<<<<Story Ends for now...>>>>");
            Console.WriteLine("");
            
        }
        void Aggressor(CardHolder CurrentUser)
        {
            Console.WriteLine("Confronted with a sense of joy, you rediscovered that this would be your only sense of release.");
            Console.WriteLine("It's time to return to why you are here.");
            Console.WriteLine("<<<<Story Ends for now...>>>>");
            Console.WriteLine("");
            
        }
        void Bystander(CardHolder CurrentUser)
        {
            Console.WriteLine("You see a crime being committed. You stare. Stare for a while as the conflict began to escalate.");
            Console.WriteLine("It's time to return to why you are here.");
            Console.WriteLine("<<<<Story Ends for now...>>>>");
            Console.WriteLine("");
            


        }

        //void DarkStory(CardHolder CurrentUser)
        //{
        //    Console.WriteLine("You wanted me to tell you a story?");
        //    Console.WriteLine("I can tell you a story instead.");
        //    Console.WriteLine("But first...");
        //    Console.WriteLine("What type of story?");
        //    int DarkOption = 0;
        //    do
        //    {
        //        PrintDarkPaths();
        //        try
        //        {
        //            DarkOption = int.Parse(Console.ReadLine());
        //        }
        //        catch { }
        //        if (DarkOption == 1) { Hero(CurrentUser); }
        //        else if (DarkOption == 2) { Victim(CurrentUser); }
        //        else if (DarkOption == 3) { Aggressor(CurrentUser); }
        //        else if (DarkOption == 4) { Bystander(CurrentUser); }
        //        else if (DarkOption == 5) { break; }
        //        else { DarkOption = 0; }
        //    }
        //    while (DarkOption != 5);
        //    Console.WriteLine("Thank you! Have a great day!");
        //}

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
                else if(Option == 4) { Story(CurrentUser); }
                else if(Option == 5) { break; }
                else { Option = 0; }
        }
        while (Option != 5);
        Console.WriteLine("Thank you! Have a great day!");
    }
}
