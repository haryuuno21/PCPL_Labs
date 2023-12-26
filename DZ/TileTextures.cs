using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Riichi_mahjong
{
    class TileTextures
    {
        public Dictionary<Tile,Texture> Textures { get; private set; }
        public TileTextures(string TexturesFolderName)
        {
            Textures = new Dictionary<Tile,Texture>();
            for(Tile tile = 0;tile < Tile.last; tile++)
            {
                Textures.Add(tile, new Texture(TexturesFolderName + tile + ".png"));
            }
        }

        public Texture GetTileTexture(Tile tile)
        {
            return Textures[tile];
        }
        public Vector2f GetDimensions()
        {
            return new Vector2f(Textures[Tile.m1].Size.X, Textures[Tile.m1].Size.Y);
        }
    }
}
