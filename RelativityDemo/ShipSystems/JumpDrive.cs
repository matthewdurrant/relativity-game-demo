using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems
{
    public static class JumpDrive
    {

        public static void Jump(JumpPlan plan, Ship ship)
        {
            //Remove fuel
            ship.Fuel -= plan.RequiredFuel;

            // Jump through space
            int time = (int)(plan.Distance * 10f);
            ship.Terminal.Spinner(time);
            ship.FlightComputer.CurrentLocation = plan.Destination;

            //Make sure to update time.
            ship.FlightComputer.Space.UpdateCoordinateTime(plan.CoordinateArrivalTime);

            //And update the shipclock and the player's biological time.
            ship.ShipClock = plan.ProperArrivalTime;
            ship.Pilot.PlayerTime = plan.ProperArrivalTime;
        }
    }
}
