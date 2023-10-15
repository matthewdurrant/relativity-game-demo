using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo.SaveData
{
    internal interface ISaveDataManager
    {
        bool Save(Ship ship);
        GameState Load();
    }
}
