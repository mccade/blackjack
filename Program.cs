using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    //Card class with value and appearance, for comparing and printing
    public class Card
    {
        public int cardValue { get; set; }
        public string cardAppearance { get; set; }
        public Card(int cValue, string cAppearance)
        {
            cardValue = cValue;
            cardAppearance = cAppearance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //initialize deck and other variables
            List<Card> deckList = new List<Card>()
            {
                new Card(1, "ACEclub"),
                new Card(2, "TWOclub"),
                new Card(3, "THREEclub"),
                new Card(4, "FOURclub"),
                new Card(5, "FIVEclub"),
                new Card(6, "SIXclub"),
                new Card(7, "SEVENclub"),
                new Card(8, "EIGHTclub"),
                new Card(9, "NINEclub"),
                new Card(10, "TENclub"),
                new Card(10, "JACKclub"),
                new Card(10, "QUEENclub"),
                new Card(10, "KINGclub"),
                new Card(1, "ACEspade"),
                new Card(2, "TWOspade"),
                new Card(3, "THREEspade"),
                new Card(4, "FOURspade"),
                new Card(5, "FIVEspade"),
                new Card(6, "SIXspade"),
                new Card(7, "SEVENspade"),
                new Card(8, "EIGHTspade"),
                new Card(9, "NINEspade"),
                new Card(10, "TENspade"),
                new Card(10, "JACKspade"),
                new Card(10, "QUEENspade"),
                new Card(10, "KINGspade"),
                new Card(1, "ACEheart"),
                new Card(2, "TWOheart"),
                new Card(3, "THREEheart"),
                new Card(4, "FOURheart"),
                new Card(5, "FIVEheart"),
                new Card(6, "SIXheart"),
                new Card(7, "SEVENheart"),
                new Card(8, "EIGHTheart"),
                new Card(9, "NINEheart"),
                new Card(10, "TENheart"),
                new Card(10, "JACKheart"),
                new Card(10, "QUEENheart"),
                new Card(10, "KINGheart"),
                new Card(1, "ACEdiamond"),
                new Card(2, "TWOdiamond"),
                new Card(3, "THREEdiamond"),
                new Card(4, "FOURdiamond"),
                new Card(5, "FIVEdiamond"),
                new Card(6, "SIXdiamond"),
                new Card(7, "SEVENdiamond"),
                new Card(8, "EIGHTdiamond"),
                new Card(9, "NINEdiamond"),
                new Card(10, "TENdiamond"),
                new Card(10, "JACKdiamond"),
                new Card(10, "QUEENdiamond"),
                new Card(10, "KINGdiamond")
            };
            List<Card> playerList = new List<Card>();
            List<Card> dealerList = new List<Card>();
            List<Card> discardList = new List<Card>();
            Random rando = new Random();
            int deckRemaining = 51;
            int cardDraw;
            int dealerValue;
            int playerValue;
            string aceInput;
            string input = "";
            Console.Write("Blackjack\n\nPress any key to start.\n");
            Console.ReadKey();
            Console.Clear();

            //draw two cards for player and dealer
            cardDraw = rando.Next(0, deckRemaining);
            deckRemaining--;
            playerList.Add(deckList[cardDraw]);
            deckList.RemoveAt(cardDraw);
            cardDraw = rando.Next(0, deckRemaining);
            deckRemaining--;
            playerList.Add(deckList[cardDraw]);
            deckList.RemoveAt(cardDraw);
            Console.Write("you: " + playerList[0].cardAppearance + "   " + playerList[1].cardAppearance + "\n\n");
            cardDraw = rando.Next(0, deckRemaining);
            deckRemaining--;
            dealerList.Add(deckList[cardDraw]);
            deckList.RemoveAt(cardDraw);
            cardDraw = rando.Next(0, deckRemaining);
            deckRemaining--;
            dealerList.Add(deckList[cardDraw]);
            deckList.RemoveAt(cardDraw);
            Console.Write("dealer: " + dealerList[0].cardAppearance + "   " + dealerList[1].cardAppearance + "\n\n");
            Console.Write("Hit? (h or n or q): ");
            input = Console.ReadLine();
            playerValue = playerList[0].cardValue + playerList[1].cardValue;
            dealerValue = dealerList[0].cardValue + dealerList[1].cardValue;
            if((dealerList[0].cardValue == 1 && dealerList[1].cardValue == 10) || (dealerList[0].cardValue == 10 && dealerList[1].cardValue == 1))
            {
                dealerValue = 21;
            }
            while(input != "q")
            {
                //add discard cards back into deck
                if (deckList.Count() <= 10)
                {
                    for (int k = 0; k < discardList.Count(); k++)
                    {
                        deckList.Add(discardList[k]);
                    }
                    deckRemaining = deckList.Count();
                    discardList.Clear();
                }
                Console.Clear();

                //add card to player's hand
                if (input == "h")
                {
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    playerList.Add(deckList[cardDraw]);
                    playerValue = playerValue + deckList[cardDraw].cardValue;
                    deckList.RemoveAt(cardDraw);
                }
                Console.Write("you: ");
                for (int i = 0; i < playerList.Count(); i++)
                {
                    Console.Write(playerList[i].cardAppearance + "   ");
                }
                Console.Write("\n\n");

                //add cards to dealer's hand until at least a value of 16
                if (dealerValue < 16)
                {
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    dealerList.Add(deckList[cardDraw]);
                    dealerValue = dealerValue + deckList[cardDraw].cardValue;
                    deckList.RemoveAt(cardDraw);
                }
                Console.Write("dealer: ");
                for (int j = 0; j < dealerList.Count(); j++)
                {
                    Console.Write(dealerList[j].cardAppearance + "   ");
                }

                //for when player stays and dealer has at least 16
                if ((input == "n" && dealerValue >= 16))
                {
                    //if player has aces, lets user choose high or low
                    for(int p = 0; p < playerList.Count(); p++)
                    {
                        if(playerList[p].cardValue == 1)
                        {
                            Console.Write("\n\nace high or low:  ");
                            aceInput = Console.ReadLine();
                            if(aceInput == "high")
                            {
                                playerValue += 10;
                            }
                        }
                    }
                    //win and lose comparisons
                    if (((playerValue >= dealerValue) && (playerValue <= 21)) || (playerValue < 22) && (dealerValue > 21))
                    {
                        Console.Write("\n\nyou win\n\n");
                    }
                    else if (((playerValue < dealerValue) && (dealerValue >= 16)) || (playerValue > 21))
                    {
                        Console.Write("\n\nyou lose\n\n");
                    }
                    //discard hands and draw new ones
                    for (int g = 0; g < playerList.Count(); g++)
                    {
                        discardList.Add(playerList[g]);
                    }
                    for (int h = 0; h < dealerList.Count(); h++)
                    {
                        discardList.Add(dealerList[h]);
                    }
                    playerList.Clear();
                    dealerList.Clear();
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    playerList.Add(deckList[cardDraw]);
                    deckList.RemoveAt(cardDraw);
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    playerList.Add(deckList[cardDraw]);
                    deckList.RemoveAt(cardDraw);
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    dealerList.Add(deckList[cardDraw]);
                    deckList.RemoveAt(cardDraw);
                    cardDraw = rando.Next(0, deckRemaining);
                    deckRemaining--;
                    dealerList.Add(deckList[cardDraw]);
                    deckList.RemoveAt(cardDraw);
                    playerValue = playerList[0].cardValue + playerList[1].cardValue;
                    dealerValue = dealerList[0].cardValue + dealerList[1].cardValue;
                    if ((dealerList[0].cardValue == 1 && dealerList[1].cardValue == 10) || (dealerList[0].cardValue == 10 && dealerList[1].cardValue == 1))
                    {
                        dealerValue = 21;
                    }
                    Console.Write("new round (press any key) ");
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("you: " + playerList[0].cardAppearance + "   " + playerList[1].cardAppearance + "\n\n");
                    Console.Write("dealer: " + dealerList[0].cardAppearance + "   " + dealerList[1].cardAppearance);
                }
                Console.Write("\n\n");
                Console.Write("Hit? (h or n or q): ");
                input = Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}
