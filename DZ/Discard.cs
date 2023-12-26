using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riichi_mahjong
{
    internal class Discard : Drawable
    {
        TileTextures tileTextures;
        public List<Tile> DiscardList { get; private set; }
        public List<Sprite> TileSprites { get; set; }
        public Discard(Player player, TileTextures tileTextures)
        {
            DiscardList = player.Discard;
            TileSprites = new List<Sprite>();
            this.tileTextures = tileTextures;
        }

        public void Update()
        {
            int k = 0;
            TileSprites.Clear();
            foreach (Tile tile in DiscardList)
            {
                Sprite sprite = new Sprite(new Texture(tileTextures.GetTileTexture(tile)));
                int X = (int)(Positions.PlayerDiscardPosition.X + (tileTextures.Textures[Tile.m1].Size.X + 10) * (k % 6));
                int Y = (int)(Positions.PlayerDiscardPosition.Y + (tileTextures.Textures[Tile.m1].Size.Y + 5) * (k / 6));
                sprite.Position = new SFML.System.Vector2f(X, Y);
                TileSprites.Add(sprite);
                k++;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach(Sprite sprite in TileSprites)
            {
                sprite.Draw(target, states);
            }
        }
    }
}
