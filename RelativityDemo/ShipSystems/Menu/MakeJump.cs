using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    public class MakeJump : IMenuAction
    {
        public string Name => "Plan a system jump";

        public void Run(Ship ship)
        {
            IShipTerminal Terminal = ship.Terminal;
            JumpPlan plan = ship.FlightComputer.PlanJump();
            plan.PrintPlanSummary(Terminal, ship.Pilot);
            Terminal.WriteLine("Would you like to initiate the jump? Y/N");
            string input = Console.ReadLine();

            if (input.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
            {
                bool jumpSuccess = ship.FlightComputer.Jump(plan);
                if (jumpSuccess)
                {
                    ship.Pilot.PrintLifeFunctions(Terminal);
                }
            }

            Terminal.WriteLine("Returning to main menu.");
        }
    }
}
