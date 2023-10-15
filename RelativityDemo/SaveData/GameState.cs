using RelativityDemo.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.SaveData
{
    public class GameState
    {
        public GameState()
        {
                
        }

        public GameState(Ship ship)
        {
            Ship = ship;
            CurrentLocationName = ship.FlightComputer.CurrentLocation.Name;
            CurrentLocationTime = ship.FlightComputer.CurrentLocation.CoordinateTime;
        }

        public Ship Ship { get; set; }
        public string CurrentLocationName { get; set; }
        public DateTime CurrentLocationTime { get; set; }
    }
}
