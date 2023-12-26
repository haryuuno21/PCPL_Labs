using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riichi_mahjong
{
    class Wall
    {
        const int MAX_DORA_COUNT = 5;
        const int TILES_IN_DWALL = 14;
        int doraCount;
        Stack<Tile> wall = new Stack<Tile>();
        List<Tile> deadWall = new List<Tile>();
        public event EventHandler? TilesEnded;

        ITileRandomiser randomiser;
        public Wall(ITileRandomiser randomiser)
        {
            this.randomiser = randomiser;
            Reset();
        }

        public void Reset()
        {
            doraCount = 1;
            randomiser.Reset();
            wall.Clear();
            deadWall.Clear();
            while (deadWall.Count < TILES_IN_DWALL && randomiser.Sum() > 0) deadWall.Add(randomiser.GetTile());
            while (randomiser.Sum() > 0) wall.Push(randomiser.GetTile());
        }

        public Tile GetTileFromWall()
        {
            if (TilesLeft() > 0) return wall.Pop();
            else TilesEnded?.Invoke(this, EventArgs.Empty);
            return Tile.m1;
        }

        public bool OpenDora()
        {
            if (doraCount < MAX_DORA_COUNT)
            {
                doraCount++;
                return true;
            }
            return false;
        }

        public List<Tile> GetDoraList()
        {
            List<Tile> doraList = new List<Tile>();
            for (int i = 0; i < doraCount; i++) doraList.Add(deadWall[i]);
            return doraList;
        }

        public List<Tile> GetUraDoraList()
        {
            List<Tile> uraDoraList = new List<Tile>();
            for (int i = 0; i < doraCount; i++) uraDoraList.Add(deadWall[i + TILES_IN_DWALL / 2]);
            return uraDoraList;
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach (Tile tile in wall) { str += tile.ToString() + "\n"; }
            str += "\n";
            foreach (Tile tile in deadWall) { str += tile.ToString() + " "; }
            return str;
        }
        public int TilesLeft() => wall.Count;
    }
}
