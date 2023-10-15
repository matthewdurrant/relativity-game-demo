using RelativityDemo.SaveData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    internal class Sleep : IMenuAction
    {
        public string Name => "Enter sleep mode";

        public void Run(Ship ship)
        {
            ship.Terminal.WriteLine("Entering sleep mode.");
            ship.Terminal.WriteLine("Saving data...");
            JsonSaveDataManager jsonSaveDataManager = new JsonSaveDataManager();
            jsonSaveDataManager.Save(ship);
            ship.Terminal.WriteLine("Saving complete.");
            ship.Terminal.WriteLine("GOODBYE");
            ship.Terminal.Exit();
        }
    }
}
