using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riichi_mahjong
{
    enum Wind
    { east, south, west, north }
    class Player
    {
        const int DEFAULT_SCORE = 25000;
        const int RIICHI_COST = 1000;
        private const int TILES_IN_HAND = 13;

        public Hand Hand { get; }
        public List<Tile> Discard { get; }
        public int Score { get; private set; }
        public bool IsDealer { get; private set; }
        public Wind SeatWind { get; private set; }
        public Player(Wind seatWind)
        {
            Hand = new Hand();
            Discard = new List<Tile>();
            Score = DEFAULT_SCORE;
            SeatWind = seatWind;
            if (seatWind == Wind.east) { IsDealer = true; }
        }

        public Tile CallRiichi(int index)
        {
            if (Score > RIICHI_COST)
            {
                Score -= 1000;
                return DropTile(index);
            }
            else throw new Exception("Not enough points to call a riichi");
        }
        public virtual Tile DropTile(int index)
        {
            Tile droppedTile = Hand.DropTile(index);
            Discard.Add(droppedTile);
            return droppedTile;
        }
        public void PickTile(Wall wall)
        {
            Hand.PutTile(wall.GetTileFromWall());
        }
        public void NextWind()
        {
            SeatWind += (int)SeatWind < 3 ? 1 : -3;
            IsDealer = SeatWind == Wind.east;
        }
        public void AddScore(int score)
        {
            Score += score;
        }
        public void FillHand(Wall wall)
        {
            for(int i=0;i<TILES_IN_HAND;i++)
            {
                PickTile(wall);
            }
        }
        public void SortHand()
        {
            Hand.SortHand();
        }
    }

    class Bot : Player
    {
        public Bot(Wind seatWind) : base(seatWind) { }

        public override Tile DropTile(int index)
        {
            return base.DropTile(0);
        }
    }
}
