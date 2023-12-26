using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riichi_mahjong
{
    class Hand
    {
        public List<Tile> Tiles { get; }
        public Hand()
        {
            Tiles = new List<Tile>();
        }
        public void PutTile(Tile tile)
        {
            Tiles.Add(tile);
        }
        public Tile DropTile(int index)
        {
            Tile tile = Tiles[index];
            Tiles.RemoveAt(index);
            return tile;
        }
        public void SortHand()
        {
            Tiles.Sort();
        }
    }
}
