﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.StateClass
{
    public class GameInventoryState : AState
    {
        private const int WIDTH = 1024;
        private const int HEIGHT = 960;
        private const int MAX_HEART_COUNT = 5;
        private Game1 _game;
        private ContentManager _content;
        private Texture2D screen;
        private LinkInventory _inventory;

        private Rectangle heartSourceRect;
        private Rectangle halfHeartSourceRect;
        private Rectangle emptyHeartSourceRect;
        private Rectangle timesSymbolSourceRect;
        private Rectangle mapSourceRect;
        private Rectangle mapDesignSourceRect;
        private Rectangle compassSourceRect;

        private Rectangle currentHeartNeeded;
        private Rectangle rupeeNumberDestRect;
        private Rectangle bombNumberDestRect;
        private Rectangle keyNumberDestRect;
        private Rectangle levelNumberDestRect;
        private Rectangle slotA;
        private Rectangle slotB;
        private Rectangle mapDestRect;
        private Rectangle mapDesignDestRect;
        private Rectangle compassDestRect;

        const int heartWidth = 64;
        const int heartHeight = 73;
        const int spaceBetweenHearts = 8;

        const int numberWidth = 33;
        const int numberHeight = 37;
        const int spaceBetweenNumbers = 5;

        const int mapWidth = 39;
        const int mapAndCompassHeight = 83;
        const int compassWidth = 74;
        const int mapDesignHeightAndWidth = 275;

        const int slotWidth = 40;
        const int slotHeight = 75;

        const int heartAndNumberYSourceLocation = 1142;
        const int timesSymbolYSourceLocation = 1178;
        const int compassAndMapYSourceLocation = 1059;
        const int mapDesignYSourceLocation = 1215;

        const int numberXSourceLocation = 208;
        const int mapXSourceLocation = 403;
        const int compassXSourceLocation = 457;

        const int heartXDestLocation = 706;
        const int slotA_XDestLocation = 605;
        const int slotB_XDestLocation = 509;
        const int numberXDestLocation = 384;
        const int mapAndCompassXDestLocation = 160;
        const int mapDesignXDestLocation = 500;
        const int levelNumberXDestLocation = 135;

        const int heartYDestLocation = 854;
        const int slotsYDestLocation = 819;
        const int rupeeYDestLocation = 781;
        const int keyYDestLocation = 854;
        const int bombYDestLocation = 890;
        const int mapYDestLocation = 420;
        const int compassYDestLocation = 590;
        const int mapDesignYDestLocation = 370;
        const int levelNumberYDestLocation = 707;

        //private KeyboardController kController;
        //private MouseController mController;


        public GameInventoryState(Game1 game, ContentManager content, LinkInventory inventory) : base(game, content)
        {
            _game = game;
            _content = content;
            _inventory = inventory;

            heartSourceRect = new Rectangle((heartWidth * 2) + (spaceBetweenHearts * 2), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            halfHeartSourceRect = new Rectangle((heartWidth * 1) + (spaceBetweenHearts * 1), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            emptyHeartSourceRect = new Rectangle((heartWidth * 0) + (spaceBetweenHearts * 0), heartAndNumberYSourceLocation, heartWidth, heartHeight);
            timesSymbolSourceRect = new Rectangle(numberXSourceLocation, timesSymbolYSourceLocation, numberWidth, numberHeight);
            mapSourceRect = new Rectangle(mapXSourceLocation, compassAndMapYSourceLocation, mapWidth, mapAndCompassHeight);
            mapDesignSourceRect = new Rectangle(0,mapDesignYSourceLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassSourceRect = new Rectangle(compassXSourceLocation, compassAndMapYSourceLocation, compassWidth, mapAndCompassHeight);

            rupeeNumberDestRect = new Rectangle(numberXDestLocation, rupeeYDestLocation, numberWidth, numberHeight);
            bombNumberDestRect = new Rectangle(numberXDestLocation, bombYDestLocation, numberWidth, numberHeight);
            keyNumberDestRect = new Rectangle(numberXDestLocation, keyYDestLocation, numberWidth, numberHeight);
            levelNumberDestRect = new Rectangle(levelNumberXDestLocation, levelNumberYDestLocation, numberWidth, numberHeight);
            slotA = new Rectangle(slotA_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            slotB = new Rectangle(slotB_XDestLocation, slotsYDestLocation, slotWidth, slotHeight);
            mapDestRect = new Rectangle(mapAndCompassXDestLocation, mapYDestLocation, mapWidth, mapAndCompassHeight);
            mapDesignDestRect = new Rectangle(mapDesignXDestLocation, mapDesignYDestLocation, mapDesignHeightAndWidth, mapDesignHeightAndWidth);
            compassDestRect = new Rectangle(mapAndCompassXDestLocation, compassYDestLocation, compassWidth, mapAndCompassHeight);

    }
        public override void loadContent()
        {
            screen = _content.Load<Texture2D>("Inventory");
            isInventory = true;
        }

        public override void update(GameTime gameTime)
        {
            _game.MouseController.handleInput();
            _game.KeyboardController.handleInput();

        }

        public override void Draw(GameTime gameTime)
        {
            _inventory.Update();
            Rectangle screenDestRect = new Rectangle(0, 0, WIDTH, HEIGHT);
            Rectangle screenSrcRect = new Rectangle(0, 0, WIDTH, HEIGHT);

            _game.SpriteBatch.Begin();

            _game.SpriteBatch.Draw(
                     screen,
                     screenDestRect,
                     screenSrcRect,
                    Color.White,
                    0f,
                    new Vector2(0, 0),
                    SpriteEffects.None,
                    0f
                    );
            _game.SpriteBatch.Draw(screen, rupeeNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, bombNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, keyNumberDestRect, timesSymbolSourceRect, Color.White);
            _game.SpriteBatch.Draw(screen, levelNumberDestRect, new Rectangle(numberXSourceLocation + (_inventory.LevelNumber * numberWidth) + (_inventory.LevelNumber * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);


            int remainingNumberSpaces = 2;
            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount / 10) * numberWidth) + ((_inventory.RupeeCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), rupeeYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.RupeeCount % 10) * numberWidth) + (_inventory.RupeeCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount / 10) * numberWidth) + ((_inventory.KeyCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), keyYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.KeyCount % 10) * numberWidth) + (_inventory.KeyCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            for (int i = 1; i <= remainingNumberSpaces; i++)
            {
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + numberWidth, bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount / 10) * numberWidth) + ((_inventory.BombCount / 10) * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
                _game.SpriteBatch.Draw(screen, new Rectangle(numberXDestLocation + (numberWidth * remainingNumberSpaces), bombYDestLocation, numberWidth, numberHeight), new Rectangle(numberXSourceLocation + ((_inventory.BombCount % 10) * numberWidth) + (_inventory.BombCount * spaceBetweenNumbers), heartAndNumberYSourceLocation, numberWidth, numberHeight), Color.White);
            }

            int remainingHalfHearts = _inventory.HeartCount;
            for (int i = 0; i < MAX_HEART_COUNT; i++)
            {
                if (i < _inventory.HeartContainerCount)
                {
                    if (remainingHalfHearts >= 2)
                    {
                        currentHeartNeeded = heartSourceRect;
                        remainingHalfHearts -= 2;
                    }
                    else if (remainingHalfHearts == 1)
                    {
                        currentHeartNeeded = halfHeartSourceRect;
                        remainingHalfHearts -= 1;
                    }
                    else
                    {
                        currentHeartNeeded = emptyHeartSourceRect;
                    }
                    _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), currentHeartNeeded, Color.White);
                }
                else
                {
                    _game.SpriteBatch.Draw(screen, new Rectangle(heartXDestLocation + (heartWidth * i), heartYDestLocation, heartWidth, heartHeight), new Rectangle(heartWidth, 0, heartWidth, heartHeight), Color.Black);
                }
            }

            if(_inventory.Compass == true)
            {
                _game.SpriteBatch.Draw(screen,compassDestRect, compassSourceRect, Color.White);

            }

            if (_inventory.Map == true)
            {
                _game.SpriteBatch.Draw(screen, mapDestRect, mapSourceRect, Color.White);
                _game.SpriteBatch.Draw(screen, mapDesignDestRect, mapDesignSourceRect, Color.White);
            }

            _game.SpriteBatch.End();
        }
    }
}
