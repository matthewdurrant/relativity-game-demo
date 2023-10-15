using RelativityDemo.Locations;
using RelativityDemo.SaveData;

namespace RelativityDemo.ShipSystems
{
    public class PilotRegistration
    {
        public PilotRegistration()
        {
            
        }
        public static PilotRegistration PilotSetup(DateTime ShipClock, IShipTerminal Terminal)
        {
            Terminal.WriteLine("Welcome, new pilot.");
            Terminal.WriteLine("What is your year of birth?");
            int dobYear = Terminal.GetInt();
            PilotRegistration player = new(dobYear, ShipClock);

            Terminal.WriteLine("Thank you.");
            Terminal.WriteLine($"You are {player.Age} years old.");

            return player;
        }

        public void PrintLifeFunctions(IShipTerminal Terminal)
        {
            Terminal.WriteLine("Analysing pilot biological signs...");
            if (Died)
            {
                Terminal.WriteError("WARNING LIFE FUNCTIONS TERMINATED");
                Terminal.WriteError($"Pilot has died at age {Age}.");
                Terminal.Spinner(500);
                Terminal.Exit();
            }
            else
            {
                Terminal.WriteSuccess("Pilot life functions nominal.");
                Terminal.WriteLine($"You are now {Age} years old.");
            }
        }

        private PilotRegistration(int yearOfBirth, DateTime startTime)
        {
            //No one older than Maria Branyas Morera is allowed to play this game
            if (yearOfBirth < 1907)
                throw new ArgumentException("Pilot is too old!");
            YearOfBirth = yearOfBirth;

            PlayerTime = startTime;
        }

        /// <summary>
        /// This is your personal spacetime, baby, and nobody can take it away from you
        /// </summary>
        public DateTime PlayerTime { get; set; }

        public int YearOfBirth { get; set; }
        public int Age => PlayerTime.Year - YearOfBirth;

        public bool Died
        {
            get
            {
                //TODO Do something random here so player has a x% of dying
                return Age > 100;
            }
        }
    }
}
