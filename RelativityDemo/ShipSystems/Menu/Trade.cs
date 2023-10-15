using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    internal class Trade : IMenuAction
    {
        public string Name => "Open trading menu";

        public void Run(Ship ship)
        {
            ship.TradeComputer.Run(ship.Terminal, ship);
        }
    }
}
