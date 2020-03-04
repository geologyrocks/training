
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    // --------------------------------------------------------------------
    // Define a class to hold contextual information about events
    // --------------------------------------------------------------------
    public class CardEventArgs : EventArgs
    {
        // Private fields.
        private string mNumber, mSuit;

        // Constructor, to initialize private fields.
        public CardEventArgs(string number, string suit)
        {
            mNumber = number;
            mSuit = suit;
        }

        // Properties, to get the values held in the private fields.
        public string Number
        {
            get { return mNumber; }
        }

        public string Suit
        {
            get { return mSuit; }
        }
    }


    // --------------------------------------------------------------------
    // Define a delegate type for all events from CardDealer.
    // This is the standard pattern for all events in .NET 
    // --------------------------------------------------------------------
    public delegate void CardEventHandler(object src, CardEventArgs e);


    // --------------------------------------------------------------------
    // Define the "card dealer" class
    // --------------------------------------------------------------------
    public class CardDealer
    {
        // Card numbers.
        private static string[] NUMBERS =
        {
            "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
        };

        // Card suits.
        private static string[] SUITS =
        {
            "Clubs", "Diamonds", "Hearts", "Spades"
        };

        // Define events, using our delegate type to denote the signatures.
        public event CardEventHandler AcePicked;
        public event CardEventHandler PicturecardPicked;
        public event CardEventHandler DiamondPicked;

        // Or alternatively, using EventHandler<T>:
        // public event EventHandler<CardEventArgs> AcePicked;
        // public event EventHandler<CardEventArgs> PicturecardPicked;
        // public event EventHandler<CardEventArgs> DiamondPicked;

        // Pick a card, any card...
        public void Deal(out string number, out string suit)
        {
            Random rg = new Random();
            number = NUMBERS[rg.Next(0, 13)];
            suit = SUITS[rg.Next(0, 4)];

            if (number == "A")
            {
                if (AcePicked != null)
                    AcePicked(this, new CardEventArgs(number, suit));
            }
            else if (number == "J" || number == "Q" || number == "K")
            {
                if (PicturecardPicked != null)
                    PicturecardPicked(this, new CardEventArgs(number, suit));
            }
            if (suit == "Diamonds")
            {
                if (DiamondPicked != null)
                    DiamondPicked(this, new CardEventArgs(number, suit));
            }
        }
    }
}
