using RelativityDemo.Locations;
using RelativityDemo.Traders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems
{
    public class TradeComputer
    {
        public string Description { get; set; }
        public string Copyright { get; set; }

        public TradeComputer()
        {
            Description = "TradeLink Navigator Pro (Enterprise Edition) v20.4";
            Copyright = "Copyright 2017 TradeLink Software, Inc.";
        }

        public void Run(IShipTerminal terminal, Ship ship)
        {
            terminal.WriteBlue(Description);
            terminal.WriteLine(Copyright);
            terminal.WriteLine();
            terminal.WriteLine("Traders in this system:");

            int optionCounter = 0;
            var traders = ship.FlightComputer.CurrentLocation.Traders;
            foreach (Trader trader in traders) { 
                optionCounter++;
                terminal.WriteLine($"{trader.Name} ({optionCounter})");
            }
            int selected = terminal.GetInt();
            Trader selectedTrader = traders[selected - 1];

            terminal.WriteLine("Connecting you to the trader...");
            selectedTrader.Connect(terminal);
        }
    }
}
