using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WindowsGame1
{
    class Zombie : Entity
    {
        int health;
        int move_speed;

        Rectangle attackBox;

        Vector2 toPlayer;
        Vector2 randomDir;

        int max_value = 10; // halved: -5 to 5
        float hungerForFlesh = 1.4f;

        public Zombie()
        {
            health = 100;
            move_speed = 5;

            Random rand = new Random();
            toPlayer = new Vector2();
            //randomDir = new Vector2(rand.Next(max_value) - (max_value / 2), rand.Next(max_value) - (max_value / 2));
            randomDir = new Vector2();
        }

        public void Update(Rectangle player_box)
        {
            Vector2 player_pos = new Vector2(player_box.X, player_box.Y);

            Vector2 temp = pos - player_pos;
            float r = temp.LengthSquared();

            float costheta = (Vector2.Dot(temp, Vector2.UnitX));
            float sintheta = (Vector2.Dot(temp, Vector2.UnitY));

            float mag = hungerForFlesh / r;

            float x = mag * costheta;
            float y = mag * sintheta;

            Vector2 hunger = new Vector2(x, y);

            pos += (hunger + randomDir);

        

            


            

            

            


        }


    }
}
