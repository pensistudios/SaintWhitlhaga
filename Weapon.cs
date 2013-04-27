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
    class Weapon : Entity
    {
        public Vector2 offset_r;
        public Vector2 offset_l;
        
        public Weapon(int x, int y, int xx, int yy)
        {
            offset_r = new Vector2(x, y);
            offset_l = new Vector2(xx, yy);
        }

        public Vector2 getPosition(bool left)
        {
            if (left)
                return (pos + offset_l);
            else
                return (pos + offset_r);
        }

        
    }
}
