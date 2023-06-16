using A_Tale_of_Guys_and_Cash;


//Vorbereitung der Gewinnwahrscheinlich und der Nutzung von Random
Random random = new Random();
double odds = 0.69;



Console.WriteLine("Hello Player, welcome to our casino. The odds are " + odds + ", today.");
ResetGame();

int[] Players;
void ResetGame()
{
    //Abfrage der Anzahl der Spieler
    int NumberOfPlayers;
    do
    {
        Console.WriteLine("How many Players would like to enter?");
        Console.WriteLine("Currently, we have enough room for up to 8 players.");
        string stringNumberOfPlayers = Console.ReadLine();
        //Überprüfung ob Usereingabe eine Zahl ist
        NumberOfPlayers = int.Parse(stringNumberOfPlayers);
    }
    //Überprüfung des Limits der Spieleranzahl
    while (NumberOfPlayers < 0 || NumberOfPlayers > 8);
    Players = new int[NumberOfPlayers];
    StartGame();
}

void StartGame()
{
    //erstellen eines SpielerArrays, festlegen des Startgeldes
    //Guy wird Index i zugewiesen
    Guy player = new Guy() { Cash = 100, Name = string.Empty };
    Guy[] guyArr = new Guy[Players.Length];
    var p = 1;
    var i = 0;
    do
    {
        //Ábfrage Spielername und Erstellung des Spielers im Array
        Console.WriteLine("How may I address you, Player " + p + "?");
        player = new Guy { Cash = 100, Name = string.Empty };
        player.Name = Console.ReadLine();
        guyArr[i] = player;
        //Index- und Spielernummer wird um 1 erhöht
        i++;
        p++;        
    }
    while (p <= Players.Length);

    var totalCash = 1;
    var x = 0;
    while (totalCash > 0)
        foreach (var guy in guyArr)
        {
            //greift auf die Methode aus Guy.cs zu
            //leere WriteLines für Übersichtlichkeit
            Console.WriteLine();
            guyArr[x].WriteMyInfo();
            Console.WriteLine("How much would you like to bet, " + guyArr[x].Name + "?");
            string howMuch = Console.ReadLine();

            //Überprüfung Userinputs
            if (int.TryParse(howMuch, out int amount))
            {
                //Berechnung des Gewinns
                var Pot = (int)amount * 2;
                //Wenn die eingegebene Menge die Cash Value des Spieler übersteigt
                if (amount > guyArr[x].Cash)
                {
                    Console.WriteLine("Sadly, you don't have enough money, " + guyArr[x].Name + ".");
                }
                else
                {
                    //wenn Cash des Spielers >= des Einsatzes ist, wird der Betrag vom Cash abgezogen
                    guyArr[x].Cash -= amount;
                    if (Pot > 0)
                    {
                        //wenn Random höher als odds ist
                        if (random.NextDouble() > odds)
                        {
                            //wird ReceivedCash aus der Guy.cs genutzt um die Pot Value zur Cash Value hinzuzufügen
                            int winnings = Pot;
                            Console.WriteLine("You win " + winnings);
                            guyArr[x].ReceiveCash(winnings);
                        }
                        else
                        {
                            //ansonsten verliert man :(
                            Console.WriteLine("Awww shucks, you lose :(");
                        }
                    }
                    //falls kein gültiger Betrag eingegeben wurde
                    else
                    {
                        Console.WriteLine("Please enter a valid amount, " + guyArr[x].Name + ".");
                    }
                }
            }
            //erhöht den Index um 1
            x++;
            if (x >= guyArr.Length)
            {
                var index = 0;
                do
                {
                    //setzt totalCash auf 0 zurück und berechnet ihn erneut mit den geupdateten Cash Values der Spieler
                    totalCash = 0;               
                    totalCash += guy.Cash;
                    index++;
                }
                //setzt den Index zurück auf 0 sobald die Anzahl der Spieler überschritten wird
                while (index < Players.Length);
                x = 0;
            }
        }
    //hier wird man hingesendet, sobald kein Spieler mehr Cash hat <3
    Console.WriteLine();
    Console.WriteLine("The house always wins <3");
    ResetGame();
}