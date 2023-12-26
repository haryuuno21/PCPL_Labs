using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Riichi_mahjong
{
    interface ITileRandomiser
    {
        public void Reset();
        public Tile GetTile();
        public int Sum();
    }
    class TileRandomiser : ITileRandomiser
    {
        Random rand;
        int[] tiles;
        HashSet<int> exclude;
        public TileRandomiser()
        {
            rand = new Random();
            tiles = new int[(int)Tile.last - 1];
            exclude = new HashSet<int>();
            Reset();
        }
        public void Reset()
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (i != (int)Tile.m5A && i != (int)Tile.p5A && i != (int)Tile.s5A) tiles[i] = 4;
                else tiles[i] = 1;
            }
            exclude.Clear();
        }
        public Tile GetTile()
        {
            var tile = new Tile();
            var range = Enumerable.Range(0, (int)Tile.last - 1).Where(i => !exclude.Contains(i));
            int index = rand.Next(0, (int)Tile.last - 1 - exclude.Count);
            tile = (Tile)range.ElementAt(index);
            if (--tiles[(int)tile] == 0) exclude.Add((int)tile);
            return tile;
        }

        public int Sum()
        {
            return tiles.Sum();
        }
    }

}
