using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            CardDealer dealer = new CardDealer();

            Console.Write("Do you want to handle 'Ace' events? ");
            string input = Console.ReadLine();
            if (input[0] == 'Y' || input[0] == 'y')
                dealer.AcePicked += OnAce;

            Console.Write("Do you want to handle 'Picture card' events? ");
            input = Console.ReadLine();
            if (input[0] == 'Y' || input[0] == 'y')
                dealer.PicturecardPicked += OnPicturecard;

            Console.Write("Do you want to handle 'Diamond' events? ");
            input = Console.ReadLine();
            if (input[0] == 'Y' || input[0] == 'y')
                dealer.DiamondPicked += OnDiamond;

            do
            {
                string number, suit;
                dealer.Deal(out number, out suit);

                Console.Write($"You got the {number} of {suit}. Pick again? ");
                input = Console.ReadLine();
                Console.WriteLine();
            }
            while (input[0] == 'Y' || input[0] == 'y');
        }

        // Event handler method for AceEventHandler events.
        private static void OnAce(object source, CardEventArgs e)
        {
            Console.WriteLine($"OnAce handler, {e.Number} of {e.Suit}!!!");
        }

        // Event handler method for PicturecardEventHandler events.
        private static void OnPicturecard(object source, CardEventArgs e)
        {
            Console.WriteLine($"OnPicturecard handler, {e.Number} of {e.Suit}!!!");
        }

        // Event handler method for DiamondEventHandler events.
        private static void OnDiamond(object source, CardEventArgs e)
        {
            Console.WriteLine($"OnDiamond handler, {e.Number} of {e.Suit}!!!");
        }
    }
}
