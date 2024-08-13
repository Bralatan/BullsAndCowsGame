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
        public string RiddleType { get; init; }
        public int RiddleLength { get; init; }
        public string ConnectionString { get; init; }
    }
}
