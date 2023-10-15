using Oasis1;
using RelativityDemo.Locations;
using RelativityDemo.ShipSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelativityDemo
{
    /// <summary>
    /// The flight computer keeps track of the ship's location in space.
    /// It plans jumps, including distance, time dilation and fuel consumption.
    /// It also holds a model of space, including locations and coordinate time.
    /// </summary>
    public class FlightComputer
    {
        [JsonIgnore]
        public Space2D Space { get; set; }
        [JsonIgnore]
        public Ship Ship { get; set; }
        bool firstBoot = true;

        [JsonIgnore]
        public ILocation CurrentLocation { get; set; }
        public FlightComputer()
        {

        }

        public FlightComputer(Space2D space, Ship ship, ILocation loc)
        {
            Space = space;
            Ship = ship;
            CurrentLocation = loc;
            Description = "MAXR-POLYX FLIGHT COMPUTER SYSTEM v14.75";
        }

        public string Description { get; set; }

        public JumpPlan PlanJump()
        {
            Ship.Terminal.WriteLine();
            if (firstBoot)
            {
                Ship.Terminal.WriteBlue(Description);
                Ship.Terminal.WriteBlue("© 2009 Maxr-Polyx Astrosystems, San Francisco, Calif. All rights reserved.");
                firstBoot = false;
            }
            Thread.Sleep(500);
            Ship.Terminal.WriteLine();
            ILocation destination = GetDestination();
            float d = CurrentLocation.DistanceTo(destination);
            float v = GetVelocity(d);

            JumpPlan plan = new(destination, v, d, CurrentLocation.CoordinateTime, Ship.ShipClock);
            return plan;
        }

        ILocation GetDestination()
        {
            Ship.Terminal.WriteLine("Where are you going today?");
            List<ILocation> list = Space.Locations.ToList();
            //Remove the current location
            list = list.Where(x => x.Name != CurrentLocation.Name).ToList();

            int options = 0;
            foreach (ILocation star in list)
            {
                options++;
                Ship.Terminal.WriteLine($"{options}: {star.Name} ({star.DistanceTo(CurrentLocation)} ly)");
            }

            int option = Ship.Terminal.GetInt();
            return list[option - 1];
        }

        float GetVelocity(float distance)
        {
            Ship.Terminal.WriteLine($"How fast do you want to go? (Your ship reports its maximum speed as {Ship.MaxSpeed}.)");
            (double minV, double maxV) recommendedVelocity = TimeDilationCalculator.GetRecommendedMinMaxVelocity(distance);
            Ship.Terminal.WriteLine($"Recommended velocity is between {Math.Round(recommendedVelocity.minV,6)}c and {Math.Round(recommendedVelocity.maxV,6)}.");
            float v = Ship.Terminal.GetFloat();

            if (v <= 0)
            {
                Ship.Terminal.WriteLine($"Please enter a speed higher than 0.");
                return GetVelocity(distance);
            }

            if (v > Ship.MaxSpeed)
            {
                Ship.Terminal.WriteLine($"Sorry. Your ship reports its maximum speed as {Ship.MaxSpeed}c.");
                return GetVelocity(distance);
            }

            return v;
        }

        internal bool Jump(JumpPlan plan)
        {
            IShipTerminal Terminal = Ship.Terminal;

            if (Ship.Fuel < plan.RequiredFuel)
            {
                Terminal.WriteError("Cannot perform jump: Insufficient fuel.");
                Terminal.WriteLine($"The jump requires {plan.RequiredFuel} and you have {Ship.Fuel}");
                Terminal.WriteLine($"Please try replanning your journey with a shorter or slower trip.");
                return false;
            }

            Terminal.WriteLine("Jumping...");
            JumpDrive.Jump(plan, Ship);
            Terminal.WriteLine();
            Terminal.WriteLine("Jump complete.");
            Terminal.WriteSuccess($"Welcome to {CurrentLocation.Name}.");
            Terminal.WriteLine($"The system time is {CurrentLocation.CoordinateTime}.");
            Terminal.WriteLine($"Ship time is {Ship.ShipClock}.");
            return true;
        }
    }
}
