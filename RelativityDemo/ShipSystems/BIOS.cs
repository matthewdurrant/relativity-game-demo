using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems
{
    internal static class BIOS
    {
        internal static string SystemDescription => "Falcon Dynamics Space Transportation System";
        internal static string SerialNo => "00087-FALC768";


        internal static void BootSystem(IShipTerminal Terminal)
        {
            Terminal.Clear();
            Terminal.WriteLine("SYSTEM CHECK");
            Thread.Sleep(500);
            Terminal.WriteLine("CPU READY");
            Thread.Sleep(500);
            Terminal.WriteLine("RAM READY. 1076 BYTES IN USE.");
            Terminal.WriteLine();
            Terminal.WriteBlue(SystemDescription);
            Terminal.WriteLine($"Serial no. {SerialNo}");
            Terminal.WriteLine();
            Thread.Sleep(500);
        }
    }
}
