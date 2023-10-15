using RelativityDemo.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    internal class Restart : IMenuAction
    {
        public string Name => "Restart system";

        public void Run(Ship ship)
        {
            ship.Terminal.WriteLine("Restarting system.");
            ship.Terminal.WriteLine("Saving data...");
            JsonSaveDataManager jsonSaveDataManager = new JsonSaveDataManager();
            jsonSaveDataManager.Save(ship);
            ship.Terminal.WriteLine("Saving complete.");
            ship.Terminal.WriteLine("GOODBYE");
            Thread.Sleep(300);
            BIOS.BootSystem(ship.Terminal);
            ship.ShipMenu();
        }
    }
}
