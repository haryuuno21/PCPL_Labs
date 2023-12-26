using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;


namespace Riichi_mahjong
{
    enum GameState
    {
        NewRound,
        PlayerPick,
        PlayerMove,
        BotMove,
        End
    }
    class Game: GameLoop
    {
        public const uint WINDOW_WIDTH = 1000;
        public const uint WINDOW_HEIGHT = 1000;
        public const string TEXTURES_FOLDER_NAME = "Textures/";
        public GameState State {  get; set; }
        public bool IsLastTile { get; set; }
        public Sprite? Background { get; set; }
        public Texture? BackgroundTexture { get; set; }
        public TileTextures? TileTextures { get; set; }
        public Wall Wall { get; set; }
        public Player Player { get; set; }
        public List<Bot> Bots { get; set; }
        public UI? UI { get; set; }
        public Discard? Discard { get; set; }
        public Game() : base(WINDOW_HEIGHT, WINDOW_HEIGHT, "RIICHI MAHJONG", Color.Black)
        {
            Wall = new Wall(new TileRandomiser());
            State = GameState.PlayerPick;
            IsLastTile = false;
            Wall.TilesEnded += TilesEnded;
            Player = new Player(Wind.east);
            Player.FillHand(Wall);
            Player.SortHand();
            Bots = new List<Bot>();
            Window.MouseButtonPressed += PlayerMove;
        }

        private void PlayerMove(object? sender, MouseButtonEventArgs e)
        {
            int index = UI.CheckTileClick(e);
            if (State == GameState.PlayerMove)
            {
                if (index != -1) {
                    Player.DropTile((int)index);
                    Player.SortHand();
                    if (IsLastTile) State = GameState.End;
                    else State = GameState.BotMove;
                }            
            }
        }

        private void TilesEnded(object? sender, EventArgs e)
        {
            IsLastTile = true;
        }

        public override void Draw(GameTime gameTime)
        {
            Window.Draw(Background);
            Window.Draw(UI);
            Window.Draw(Discard);
        }

        public override void Initialize()
        {
            Bots.Add(new Bot(Wind.south));
            Bots[0].FillHand(Wall);
            Bots.Add(new Bot(Wind.west));
            Bots[1].FillHand(Wall);
            Bots.Add(new Bot(Wind.north));
            Bots[2].FillHand(Wall);
        }

        public override void LoadContent()
        {
            BackgroundTexture = new Texture("Textures/bg.png");
            Background = new Sprite(BackgroundTexture, new IntRect(0, 0, (int)WINDOW_WIDTH, (int)WINDOW_HEIGHT));
            TileTextures = new TileTextures(TEXTURES_FOLDER_NAME);
            UI = new UI(Player, TileTextures);
            Discard = new Discard(Player, TileTextures);
        }

        public override void Update(GameTime gameTime)
        {
            switch (State)
            {
                case GameState.PlayerPick:
                    Player.PickTile(Wall);
                    State = GameState.PlayerMove;
                    break;
                case GameState.BotMove:
                    foreach (Bot bot in Bots)
                    {
                        bot.PickTile(Wall);
                        if (IsLastTile)
                        {
                            bot.DropTile(0);
                            State = GameState.End;
                            break;
                        }
                    }
                    if (State != GameState.End) State = GameState.PlayerPick;
                    break;
                case GameState.End:
                    Console.WriteLine("END");
                    break;
            }
            Discard?.Update();
            UI?.Update();
        }
    }
}
