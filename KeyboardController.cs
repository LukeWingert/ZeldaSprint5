using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.LevelClass;
using Sprint0.StateClass;

namespace Sprint0 {

	public class KeyboardController : IController
	{
		Game1 myGame;
		Vector2 center;
		LevelManager levelManager;
		//int count = 0;
		//int enemyCount = 3;


	
		private KeyboardState kstate;
		private KeyboardState previousState;
		private Boolean inventoryOpen = false;

		
		public KeyboardController(Game1 g, Vector2 center)
		{
			myGame = g;
			this.center = center;
			levelManager = LevelManager.Instance;
		}

		private bool HasBeenPressed(Keys key)
		{
			return kstate.IsKeyDown(key) && !previousState.IsKeyDown(key);
		}

		public bool AllMovementKeysUp() {
			bool rval = true;
			Keys[] moveKeys = { Keys.A, Keys.D, Keys.W, Keys.S, Keys.Up, Keys.Down, Keys.Left, Keys.Right };
			foreach (Keys k in moveKeys) {
				if (kstate.IsKeyDown(k))
				{
					rval = false;
				}
			}
			return rval;
		}

		public void handleInput() {
			previousState = kstate;
			kstate = Keyboard.GetState();
			
				/*if (HasBeenPressed(Keys.O))
				{
					enemyCount--;
					if (enemyCount == -1)
					{
						enemyCount = 6;
					}
					else if (enemyCount == 7)
						enemyCount = 2;
					myGame.currentEnemy = myGame.enemyList[enemyCount];






				}

				else if  (HasBeenPressed(Keys.P))
					{

					enemyCount++;
					if (enemyCount == 7)
					{
						enemyCount = 0;
					}
					else if (enemyCount == -1)
						enemyCount = 1;
					myGame.currentEnemy = myGame.enemyList[enemyCount];

				}*/

				//tile controls
				/*if (HasBeenPressed(Keys.T))
				{
					count--;
					if (count == -1)
					{
						count = myGame.TileList.Length - 1;
					}
					myGame.CurrentTile = myGame.TileList[count];

				}
				if (HasBeenPressed(Keys.Y))
				{
					count++;
					if (count == myGame.TileList.Length || count == -1)
					{
						count = 0;
					}
					myGame.CurrentTile = myGame.TileList[count];


				}
				*/
				//item keys
				if (HasBeenPressed(Keys.U)) {
				//myGame.shownItem = myGame.itemFactoryPublic.previousItem();
			}
			else if (HasBeenPressed(Keys.I))
			{
				if (inventoryOpen)
				{
					myGame.ChangeState(0);
					inventoryOpen = false;
				}
				else if (!inventoryOpen)
                {
					myGame.ChangeState(1);
					inventoryOpen = true;
				}
			}

			if (HasBeenPressed(Keys.E))
			{
				//return val of 0, exit the game
				myGame.Exit();
			}
			else if (HasBeenPressed(Keys.R))
			{
				myGame.reset();
			}
			

			if (kstate.IsKeyDown(Keys.W))
			{
				levelManager.Player1.ChangeDirection(Player.Directions.Up);

			}
			else if (kstate.IsKeyDown(Keys.A))
			{
				levelManager.Player1.ChangeDirection(Player.Directions.Left);
			}
			else if (kstate.IsKeyDown(Keys.S))
			{
				levelManager.Player1.ChangeDirection(Player.Directions.Down);
			}
			else if (kstate.IsKeyDown(Keys.D))
			{
				levelManager.Player1.ChangeDirection(Player.Directions.Right);
			}
			
			else if (AllMovementKeysUp()) {
				levelManager.Player1.ChangeDirection(Player.Directions.Idle);
			}

			if (HasBeenPressed(Keys.Z))
			{
				SoundManager.Instance.Play(SoundManager.Sound.SwordSlash);
				levelManager.Player1.Attack();
				
			}

			
			if (kstate.IsKeyDown(Keys.Up))
			{
				levelManager.Player2.ChangeDirection(Player.Directions.Up);
			}
			else if (kstate.IsKeyDown(Keys.Left))
			{
				levelManager.Player2.ChangeDirection(Player.Directions.Left);
			}
			else if (kstate.IsKeyDown(Keys.Down))
			{
				levelManager.Player2.ChangeDirection(Player.Directions.Down);
			}
			else if (kstate.IsKeyDown(Keys.Right))
			{
				levelManager.Player2.ChangeDirection(Player.Directions.Right);
			}
			else if (AllMovementKeysUp())
			{
				levelManager.Player2.ChangeDirection(Player.Directions.Idle);
			}

			if (HasBeenPressed(Keys.N))
			{
				SoundManager.Instance.Play(SoundManager.Sound.SwordSlash);
				levelManager.Player2.Attack();

			}
			


			//player1 projectile controls
			if (HasBeenPressed(Keys.D1))
			{
				levelManager.Player1.UseItem(new ProjectilePlayerFireball(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.DoMagic);
			}
			else if(HasBeenPressed(Keys.D2)) {
				levelManager.Player1.UseItem(new ProjectilePlayerBomb(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.BombDrop);
			}
			else if(HasBeenPressed(Keys.D3)) {
				levelManager.Player1.UseItem(new ProjectilePlayerNormalArrow(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			else if(HasBeenPressed(Keys.D4)) {
				levelManager.Player1.UseItem(new ProjectilePlayerBoomerang(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			else if(HasBeenPressed(Keys.D5)) {
				levelManager.Player1.UseItem(new ProjectilePlayerSpecialArrow(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}		
			else if(HasBeenPressed(Keys.D6)) {
				levelManager.Player1.UseItem(new ProjectilePlayerSpecialBoomerang(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}

			//player2 projectile controls
			if (HasBeenPressed(Keys.D1))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerFireball(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.DoMagic);
			}
			else if (HasBeenPressed(Keys.D2))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerBomb(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.BombDrop);
			}
			else if (HasBeenPressed(Keys.D3))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerNormalArrow(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			else if (HasBeenPressed(Keys.D4))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerBoomerang(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			else if (HasBeenPressed(Keys.D5))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerSpecialArrow(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			else if (HasBeenPressed(Keys.D6))
			{
				levelManager.Player2.UseItem(new ProjectilePlayerSpecialBoomerang(levelManager.ProjectileTexture, myGame.SpriteBatch, Vector2.Zero, Vector2.Zero));
				SoundManager.Instance.Play(SoundManager.Sound.UseArrowBoomerang);
			}
			
		}

		
	}
}