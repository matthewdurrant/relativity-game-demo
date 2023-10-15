using RelativityDemo.Traders;
using System.Numerics;

namespace RelativityDemo.Locations
{
    public record Star2D : ILocation
    {
        public float X => Vector2.X;
        public float Y => Vector2.Y;

        public string Name { get; set; }
        private Vector2 Vector2 { get; set; }
        public DateTime CoordinateTime { get; private set; }
        public List<Trader> Traders { get; set; }

        public Star2D(string name, float x, float y)
        {
            Name = name;
            Vector2 = new(x, y);
        }

        public float DistanceTo(ILocation destination)
        {
            var destinationVector = new Vector2(destination.X, destination.Y);
            return Vector2.Distance(Vector2, destinationVector);
        }

        public void Update(DateTime currentCoordinateTime)
        {
            CoordinateTime = currentCoordinateTime;
            RefreshTraders(currentCoordinateTime);
        }

        private void RefreshTraders(DateTime currentDate)
        {
            if (Traders is null || !Traders.Any())
            {
                //Create a number of new traders.
                //TODO Trader count could be based on economy.
                Traders = new List<Trader>()
                {
                    new Trader(currentDate)
                };
            }
            else
            {
                //Update the existing traders,
                //kill 'em if they're too old
                foreach (Trader trader in Traders)
                {
                    trader.Refresh(currentDate);
                }
            }
        }
    }
}
