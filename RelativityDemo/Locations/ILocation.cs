using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelativityDemo.Traders;

namespace RelativityDemo.Locations
{
    public interface ILocation
    {
        string Name { get; }
        float X { get; }
        float Y { get; }

        DateTime CoordinateTime { get; }

        void Update(DateTime newCoordinateTime);

        float DistanceTo(ILocation destination);

        List<Trader> Traders { get; set; }
    }
}
