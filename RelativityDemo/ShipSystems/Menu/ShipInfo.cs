using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    public class ShipInfo : IMenuAction
    {
        public string Name => "Ship information";

        public void Run(Ship ship)
        {
            ship.Terminal.WriteLine();
            ship.Terminal.WriteBlue("Ship information");
            ship.Terminal.WriteLine(BIOS.SystemDescription);
            ship.Terminal.WriteLine($"Serial No: {BIOS.SerialNo}");
            ship.Terminal.WriteLine($"Registered name: {ship.Name}");
            ship.Terminal.WriteLine($"Ship class: {ship.Class}");
            ship.Terminal.WriteLine($"Max rated speed (c): {ship.MaxSpeed}");
            ship.Terminal.WriteLine($"Fuel: {ship.Fuel}");
            ship.Terminal.WriteLine($"Ship clock: {ship.ShipClock}");

            //TODO Do a module list
            ship.Terminal.WriteLine($"Flight computer: {ship.FlightComputer.Description}");
            ship.Terminal.WriteLine($"Registered locations in stellar database: {ship.FlightComputer.Space.Locations.Count}");
            ship.Terminal.WriteLine($"Trade computer: {ship.TradeComputer.Description}");

            ship.Terminal.WriteLine("Ship information complete.");
            ship.Terminal.WriteLine();
        }
    }
}
