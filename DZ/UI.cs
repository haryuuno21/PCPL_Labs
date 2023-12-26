using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Riichi_mahjong
{
    class UI : Drawable
    {
        public Hand Hand { get; set; }
        TileTextures tileTextures;
        public List<Sprite> TileSprites { get; set; }
        public UI(Player player,TileTextures tileTextures)
        {
            Hand = player.Hand;
            this.tileTextures = tileTextures;
            TileSprites = new List<Sprite>();
        }
        public void Update()
        {
            int k = 0;
            TileSprites.Clear();
            
            foreach (Tile tile in Hand.Tiles)
            {
                Sprite sprite = new Sprite(new Texture(tileTextures.GetTileTexture(tile)));
                sprite.Position = new SFML.System.Vector2f(Positions.HandPosition.X + (tileTextures.Textures[Tile.m1].Size.X+10) * k,
                    Positions.HandPosition.Y);
                TileSprites.Add(sprite);
                k++;
            }
        }
        public int CheckTileClick(MouseButtonEventArgs e)
        {
            int k = 0;
            foreach(Sprite sprite in TileSprites)
            {
                if (sprite.Position.X < e.X && e.X < sprite.Position.X + tileTextures.GetDimensions().X &&
                    sprite.Position.Y < e.Y && e.Y < sprite.Position.Y + tileTextures.GetDimensions().Y) 
                {
                    return k;
                }
                k++;
            }
            return -1;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (Sprite sprite in TileSprites)
            {
                target.Draw(sprite);
            }
        }
    }
}
