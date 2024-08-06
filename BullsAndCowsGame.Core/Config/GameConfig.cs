using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BullsAndCowsGame.Core.Config
{
    public class GameConfig
    {
        public string riddleType { get; set; }
        public int riddleLength { get; set; }
    }

    public static class ConfigLoader
    {
        public static GameConfig LoadConfig(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameConfig>(jsonString);
        }
    }
}
