using Oasis1;
using RelativityDemo.Locations;
using RelativityDemo.ShipSystems;
using System.Numerics;

namespace RelativityDemo
{
    public class JumpPlan
    {
        public JumpPlan(ILocation destination, float v, float d, DateTime coordinateTime, DateTime properTime)
        {
            Destination = destination;
            Distance = d;
            Velocity = v;
            CoordinateDepartTime = coordinateTime;
            ProperDepartTime = properTime;
        }

        public double RequiredFuel { 
            get 
            {
                //This should be some function of distance and velocity.
                //Faster journey - more fuel required.
                //More distance - more fuel required.
                //Something like ... a 100 ly journey at 0.99c should require 100 * 0.99 = 99 units of fuel.
                double minimumJumpFuel = 1.27318; //random number, the min fuel required to enter hyperspace or something
                return Distance * Velocity + minimumJumpFuel;
            }
        }

        internal ILocation Destination { get; private set; }

        internal float JourneyTimeYears => Distance / Velocity;
        internal float JourneyTimeDays => JourneyTimeYears * 365;

        internal DateTime CoordinateDepartTime { get; private set; }
        internal DateTime CoordinateArrivalTime => CoordinateDepartTime.AddDays(JourneyTimeDays);
        internal TimeSpan CoordinateTimeSpan => CoordinateArrivalTime - CoordinateDepartTime;

        internal DateTime ProperDepartTime { get; private set; }
        internal TimeSpan ProperTimeSpan => TimeDilationCalculator.GetProperTime(CoordinateTimeSpan, Velocity);
        internal DateTime ProperArrivalTime => ProperDepartTime.AddDays(ProperTimeSpan.Days);

        internal float Distance { get; set; }
        internal float Velocity { get; set; }

        /// <summary>
        /// TODO Not sure this is "factor"
        /// </summary>
        internal double Factor => TimeDilationCalculator.CalculateFactorFromVelocity(Velocity, 1);

        internal void PrintPlanSummary(IShipTerminal Terminal, PilotRegistration Pilot)
        {
            Terminal.WriteLine();
            Terminal.WriteLine($"CALCULATING JUMP PARAMETERS");
            Terminal.WriteLine($"DISTANCE (LY): {this.Distance}");
            Terminal.WriteLine($"VELOCITY (C): {this.Velocity}");
            if (this.Velocity > 1)
                Terminal.WriteError("WARNING: FASTER THAN LIGHT TRAVEL DETECTED.");
            Terminal.WriteLine($"LORENTZ FACTOR: {this.Factor}");
            if (this.Factor < 0)
                Terminal.WriteError("WARNING: LORENTZ FACTOR LESS THAN ZERO");

            if (this.ProperTimeSpan.Ticks < 0)
                Terminal.WriteError("WARNING: TIME TRAVEL DETECTED.");


            if (this.ProperArrivalTime < this.ProperDepartTime)
                Terminal.WriteError("WARNING: YOU WILL ARRIVE BEFORE YOU DEPART. CAUSALITY VIOLATION DETECTED.");

            Terminal.WriteLine();
            Terminal.WriteLine($"JUMP CALCULATIONS COMPLETE.");
            Terminal.WriteLine();
            Terminal.WriteLine($"PROJECTED FUEL USAGE: {this.RequiredFuel}");
            if (this.Velocity < 0.5) Terminal.WriteLine("ECO MODE");
            Terminal.WriteLine();

            Terminal.WriteLine($"DESTINATION ARRIVAL:");
            Terminal.WriteLine($"EARTH DATETIME {this.CoordinateArrivalTime}");
            Terminal.WriteLine($"PERSONAL DATETIME {this.ProperArrivalTime}");
            Terminal.WriteLine();

            int bioAge = this.ProperArrivalTime.Year - Pilot.YearOfBirth;
            Terminal.WriteLine($"PERSONAL BIO AGE: {bioAge}");
            Terminal.WriteLine($"EARTH BIO AGE: {this.CoordinateArrivalTime.Year - Pilot.YearOfBirth}");
            if (bioAge > 99)
            {
                Terminal.WriteLine("WARNING! BIO AGE EXCEEDS 100 YEARS");
                Terminal.WriteError("EXTREME RISK OF LIFE FUNCTIONS TERMINATION.");
            }
            Terminal.WriteLine($"Your journey will take approximately {this.CoordinateTimeSpan.PrettyPrintTimeSpan()} on Earth.");
            Terminal.WriteLine($"From your viewpoint, your journey will take approximately {this.ProperTimeSpan.PrettyPrintTimeSpan()}.");
        }
    }
}