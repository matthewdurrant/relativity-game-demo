using RelativityDemo.Locations;
using RelativityDemo.SaveData;
using RelativityDemo.ShipSystems;
using RelativityDemo.ShipSystems.Menu;
using RelativityDemo.Traders;
using System.Text.Json.Serialization;

namespace RelativityDemo
{
    public class Ship
    {
        /// <summary>
        /// Allows ship computer system to output to the player.
        /// </summary>
        [JsonIgnore]
        public IShipTerminal Terminal { get; set; }

        public List<Commodity> Cargo { get; set; }


        public void PowerOn(Space2D space, ILocation currentLocation, IShipTerminal terminal)
        {
            FlightComputer = new(space, this, currentLocation);
            TradeComputer = new();
            ShipClock = currentLocation.CoordinateTime;
            Terminal = terminal;
            BIOS.BootSystem(terminal);

            if (Pilot is null)
            {
                Terminal.WriteLine("New pilot detected. Initializing new pilot setup.");
                Terminal.WriteLine();
                Pilot = PilotRegistration.PilotSetup(ShipClock, Terminal);
            }
            Terminal.WriteLine();
            Thread.Sleep(500);
        }

        public void Wake(Space2D space, IShipTerminal terminal, ILocation location)
        {
            Terminal = terminal;
            FlightComputer.Space = space;
            FlightComputer.CurrentLocation = location;
            FlightComputer.Ship = this;
            Terminal.WriteLine("Waking from sleep...");
            Terminal.WriteLine();
        }

        //Ship info
        public string Name { get; set; }
        public float MaxSpeed { get; set; }
        public double FuelCapacity { get; set; }
        public PilotRegistration Pilot { get; set; }

        public DateTime ShipClock { get; set; }

        public double Fuel { get; set; }

        public FlightComputer FlightComputer { get; set; }
        public TradeComputer TradeComputer { get; set; }
        public object Class { get; set; }

        internal void ShipMenu()
        {
            Terminal.WriteLine();
            Terminal.WriteBlue($"{this.Class} - {this.Name}");
            if (this.Fuel < FuelCapacity * 0.25f)
            {
                Terminal.WriteError($"Fuel level: {this.Fuel}");
            }
            else
            {
                Terminal.WriteLine($"Fuel level: {this.Fuel}");
            }
            Terminal.WriteLine();
            Terminal.WriteLine("MAIN MENU");
            Terminal.WriteLine();
            Terminal.WriteLine($"Current location: {FlightComputer.CurrentLocation.Name}");
            Terminal.WriteLine($"Current coordinate time: {FlightComputer.CurrentLocation.CoordinateTime}");
            Terminal.WriteLine();

            List<IMenuAction> menu = new()
            {
                new MakeJump(),
                new Trade(),
                new ShipInfo(),
                new Sleep(),
                new Restart()
            };

            //Save data
            Terminal.WriteLine("Saving system data...");
            JsonSaveDataManager jsonSaveDataManager = new JsonSaveDataManager();
            jsonSaveDataManager.Save(this);

            MenuSelect(menu);

            //Back to the top
            ShipMenu();
        }

        private void MenuSelect(List<IMenuAction> menu)
        {
            Terminal.WriteLine("Select an option:");
            int option = 0;
            foreach (IMenuAction menuAction in menu)
            {
                option++;
                Terminal.WriteLine($"{option}: {menuAction.Name}");
            }

            int selected = Terminal.GetInt();
            if (selected == 0 || selected > menu.Count)
            {
                Terminal.WriteLine("Invalid option.");
                MenuSelect(menu);
            }
            else
            {
                menu[selected-1].Run(this);
            }
        }
    }

    /// <summary>
    /// Some default ships. This ought to end up in a config file.
    /// </summary>
    internal static class Ships
    {
        internal static Ship Defaulto => new Ship { 
            Name = "ICS Defaulto", 
            Class="Light Transport Starship", 
            MaxSpeed = 0.9997f,
            FuelCapacity = 1250 
        };
    }


}
