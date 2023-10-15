using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.Locations
{
    /// <summary>
    /// Small class to simulate the entire universe in 2 spatial dimensions.
    /// </summary>
    public class Space2D
    {
        //Some initial test data
        //TODO Put this in a config file or something
        public static Star2D Sol => new("Sol", 0, 0);
        public static Star2D AlphaCentauri => new("Alpha Centauri", 4.3441f, 0);
        public static Star2D BarnardsStar => new("Barnard's Star", 2, 5.9629f);

        public static Star2D Wolf359 => new("Wolf 359", 3.8558f, 4);

        public static Star2D Betelgeuse => new("Betelgeuse", 75.2f, 81.9f);

        public List<ILocation> Locations { get; set; }
        public Space2D(DateTime time)
        {
            //Fiat lux
            Locations = new()
            {
                Sol,
                AlphaCentauri,
                BarnardsStar,
                Wolf359,
                Betelgeuse
            };
            UpdateCoordinateTime(time);
        }

        public ILocation GetDefaultLocation()
        {
            //Obviously there is no default location in the universe.
            //But we need to set a starting spacetime.
            ILocation defaultLocation = Space2D.Sol;
            return Locations.Single(s => s.Name == defaultLocation.Name);
        }

        /// <summary>
        /// This feels odd, but I think it makes sense.
        /// In this game the different locations are in the same frame
        /// so the same time passes across the whole universe.
        /// </summary>
        /// <param name="newTime"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateCoordinateTime(DateTime newTime)
        {
            Locations.ForEach(l => l.Update(newTime));
        }
    }
}
