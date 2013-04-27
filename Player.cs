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
    class Player : Entity
    {
        Weapon currentWeapon;
        public Vector2 goofyOffset;

        public float bounce_dt;
        
        public bool moving_left;
        public int pmove_speed = 5;

        public int health;

        public Player()
        {
            goofyOffset = new Vector2(0.0f, 2.0f);
            bounce_dt = moving_dt / 2.0f;
            moving_left = false;
        }

        public void switchWeapons(Weapon w)
        {
            currentWeapon = w;
        }

        public Vector2 getPosition(int milli)
        {
            //goofyOffset.Y = (standing) ? 3.0f : 2.0f;
    
            
                if (dt >= (bounce_dt * 1000) && dt < (moving_dt * 1000))
                {
                    return (pos - goofyOffset);
                }
                else
                {
                    return (pos + goofyOffset);
                }
            

        }
    }
}
