﻿using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class PlayerDownIdle : IState 
{
	private Player player;

	public PlayerDownIdle(Player instance)
	{
		player = instance;
	}

	public void ChangeDirection() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up))
		{
			player.State = new PlayerUpMove(player);
		}
		else if (kstate.IsKeyDown(Keys.A)|| kstate.IsKeyDown(Keys.Left))
		{
			player.State = new PlayerLeftMove(player);
		}
		else if (kstate.IsKeyDown(Keys.S)|| kstate.IsKeyDown(Keys.Down))
		{
			player.State = new PlayerDownMove(player);
		}
		else if (kstate.IsKeyDown(Keys.D)|| kstate.IsKeyDown(Keys.Right)) { 
			player.State = new PlayerRightMove(player);
		}
	}

	public void Update() {
		//update the sprite
		player.Draw(new Rectangle(6,94,141,152));

	}

	public void Attack() {
		KeyboardState kstate = Keyboard.GetState();
		if (kstate.IsKeyDown(Keys.N) || kstate.IsKeyDown(Keys.Z))
		{
			player.State = new PlayerDownAttack(player);
		}

	}
}
