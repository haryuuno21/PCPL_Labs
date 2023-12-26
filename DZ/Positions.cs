using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Riichi_mahjong
{
    static class Positions
    {
        public static readonly Vector2f HandPosition = new Vector2f(225, 900);
        public static readonly Vector2f PlayerDiscardPosition = new Vector2f(375, 650);
        public static readonly Vector2f LeftBotDiscardPosition = new Vector2f(10, 20);
        public static readonly Vector2f RightBotDiscardPosition = new Vector2f(20, 20);
        public static readonly Vector2f UpBotDiscardPosition = new Vector2f(30, 20);
        public static readonly Vector2f scoreboardPosition = new Vector2f(0, 0);
        public static readonly Vector2f RiichiButtonPosition = new Vector2f(0, 0);
    }
}
