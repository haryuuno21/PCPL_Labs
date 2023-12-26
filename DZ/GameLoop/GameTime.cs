using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riichi_mahjong
{
    class GameTime
    {
        public float TimeScale { get; set; }
        public float DeltaTime
        {
            get { return TimeScale * DeltaTime; }
            set { }
        }
        public float TotalTimeElapsed { get; private set; }
        public void Update(float deltaTime, float totalTimeElapsed)
        {
            DeltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}
