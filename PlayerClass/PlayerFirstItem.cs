using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace Sprint0.PlayerClass
{
    public class PlayerFirstItem : IPlayerState
    {
        private Player player;
        private int currentFrame;
        private int TOTAL_FRAMES = 90;
        private static Dictionary<ItemType, Rectangle> dict = new Dictionary<ItemType, Rectangle>
        {
            {ItemType.Rupee, new Rectangle(2894,2444,134,298) },
            {ItemType.Key,new Rectangle(2894,2444,134,298)}, //TODO: replace with key texture
            {ItemType.Bomb,new Rectangle(2268,2449,134,294)},
            {ItemType.Boomerang,new Rectangle(1109,2483,131,266) },
            {ItemType.Arrow,new Rectangle(1682,2449,134,294)},
            {ItemType.Heart,new Rectangle(2429,2473,134,294)}, //TODO: replace with actual heart texture
            {ItemType.HeartCountainer,new Rectangle(2429,2473,134,294)},
            {ItemType.Compass,new Rectangle(2579,2482,134,294)},
            {ItemType.Fairy,new Rectangle(1462,2452,134,294)},
            {ItemType.Map,new Rectangle(927,2451,131,293)},
            {ItemType.Clock,new Rectangle(1301,2452,133,294)}
        };

        public PlayerFirstItem(Player instance, ItemType heldItem)
        {
            player = instance;
            currentFrame = 1;
            player.SourceRectangle = dict[heldItem];
        }

        public enum ItemType
        {
            Rupee,
            Key,
            Bomb,
            Boomerang,
            Bow,
            Clock,
            Arrow,
            Heart,
            HeartCountainer,
            Compass,
            Fairy,
            Map,
        }

        public void ChangeDirection(Player.Directions dir)
        {
            return;
        }

        public void Update()
        {

            //make texture the triforce, play the music, then set some boolean for the state change
            if (currentFrame > TOTAL_FRAMES)
            {
                player.State = new PlayerDownIdle(player);

            }
            player.DrawOffset = new Vector2(0, 0);
            player.CollisionOffsetX = new Vector2(0, 0);
            player.CollisionOffsetY = new Vector2(0, 0);
            currentFrame++;
        }

        public void DamageLink(Player.Directions dir)
        {
            return;
        }

        public void Attack()
        {
            return;
        }

        

        

    }
}