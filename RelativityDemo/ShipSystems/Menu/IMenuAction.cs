using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.ShipSystems.Menu
{
    public interface IMenuAction
    {
        string Name { get; }
        void Run(Ship ship);
    }
}
