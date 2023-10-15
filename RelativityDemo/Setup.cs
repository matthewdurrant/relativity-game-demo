using RelativityDemo.Locations;

namespace RelativityDemo
{
    public static class Setup
    {
        /// <summary>
        /// "If you wish to make an apple pie from scratch, you must first invent the universe." - Carl Sagan
        /// </summary>
        /// <returns>The known universe including space and time.</returns>
        public static Space2D SpaceSetup(DateTime coordinateStartTime)
        {
            Space2D space = new Space2D(coordinateStartTime);
            return space;
        }

        public static Ship ShipSetup(Space2D space, IShipTerminal terminal1)
        {
            ILocation globalFrameLocation = space.GetDefaultLocation();

            var Ship = Ships.Defaulto;
            Ship.Fuel = Ship.FuelCapacity;
            Ship.PowerOn(space, globalFrameLocation, terminal1);

            return Ship;
        }
    }
}
