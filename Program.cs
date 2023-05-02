using A_Tale_of_Guys_and_Cash;

Random random = new Random();
double odds = 0.69;



Console.WriteLine("Hello Player, welcome to our casino. The odds are " + odds + ", today.");
ResetGame();

int[] Players;
void ResetGame()
{
    int NumberOfPlayers;
    do
    {
        Console.WriteLine("How many Players would like to enter?");
        Console.WriteLine("Currently, we have enough room for up to 8 players.");
        string stringNumberOfPlayers = Console.ReadLine();
        NumberOfPlayers = int.Parse(stringNumberOfPlayers);
    }
    while (NumberOfPlayers < 0 || NumberOfPlayers > 8);
    Players = new int[NumberOfPlayers];
    //Console.WriteLine(Players.Length);
    StartGame();
}

void StartGame()
{
    Guy player = new Guy() { Cash = 100, Name = string.Empty };
    Guy[] guyArr = new Guy[Players.Length];
    var p = 1;
    var i = 0;
    do
    {
        Console.WriteLine("How may I address you, Player " + p + "?");
        player = new Guy { Cash = 100, Name = string.Empty };
        player.Name = Console.ReadLine();
        guyArr[i] = player;
        i++;
        p++;        
    }
    while (p <= Players.Length);

    var totalCash = 1;
    var x = 0;
    while (totalCash > 0)
        foreach (var guy in guyArr)
        {
            guyArr[x].WriteMyInfo();
            Console.WriteLine("How much would you like to bet, " + guyArr[x].Name + "?");
            string howMuch = Console.ReadLine();

            if (int.TryParse(howMuch, out int amount))
            {
                var Pot = (int)amount * 2;
                if (amount > guyArr[x].Cash)
                {
                    Console.WriteLine("Sadly, you don't have enough money, " + guyArr[x].Name + ".");
                }
                else
                {
                    guyArr[x].Cash -= amount;
                    if (Pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = Pot;
                            Console.WriteLine("You win " + winnings);
                            guyArr[x].ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("Awww shucks, you lose :(");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid amount, " + guyArr[x].Name + ".");
                    }
                }
            }
            x++;
            if (x >= guyArr.Length)
            {
                var index = 0;
                do
                {
                    totalCash = 0;
                    int guyCash = amount;
                    totalCash += guyCash;
                    //Console.WriteLine(totalCash);
                    index++;
                }
                while (index < Players.Length);
                x = 0;
            }
        }
    Console.WriteLine("The house always wins <3");
    ResetGame();
}