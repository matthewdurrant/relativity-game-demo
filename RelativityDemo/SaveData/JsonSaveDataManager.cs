using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RelativityDemo.SaveData
{
    public class JsonSaveDataManager : ISaveDataManager
    {
        string path = "C:\\Games\\gamedata.json";
        public bool Save(Ship ship)
        {
            GameState gameState = new GameState(ship);

            string json = JsonSerializer.Serialize(gameState);
            File.WriteAllText(path, json);
            return true;
        }

        public GameState? Load()
        {
            try
            {
                string json = File.ReadAllText(path);
                if (string.IsNullOrEmpty(json)) 
                    return null;
                GameState state = JsonSerializer.Deserialize<GameState>(json);
                return state;
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }


    }
}
