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
    class Entity
    {
        public Vector2 pos;
        public Rectangle bound;

        public List<Texture2D> standingFrames;
        public List<Texture2D> movingFrames;

        public int currentFrame_s;
        public int currentFrame_m;

        public bool standing;

        public float dt = 0.0f;
        public float standing_dt;
        public float moving_dt;

        public Entity()
        {
            pos = new Vector2();
            bound = new Rectangle();
            standingFrames = new List<Texture2D>();
            movingFrames = new List<Texture2D>();
            currentFrame_s = 0;
            currentFrame_m = 0;
            standing = true;
            standing_dt = 0.5f;
            moving_dt = 0.5f;
        }

        public void switchFrameList(bool s)
        {
            standing = s;
            
            /*if (movingFrames.Count != standingFrames.Count)
            {
                currentFrame = 0;
            }*/
        }

        public void Load()
        {

        }

        public Texture2D getFrame(int milli)
        {
            dt += milli;

            if (standing)
            {
                if (dt >= (standing_dt * 1000))
                {
                    currentFrame_s++;
                    dt = 0;

                    if (currentFrame_s >= getFrameList().Count)
                        currentFrame_s = 0;

                }
                return getFrameList()[currentFrame_s];
            }
            else
            {
                if (dt >= (moving_dt * 1000))
                {
                    currentFrame_m++;
                    dt = 0;
                    
                    if (currentFrame_m >= getFrameList().Count)
                        currentFrame_m = 0;

                }
                return getFrameList()[currentFrame_m];
            }

        }

        public List<Texture2D> getFrameList()
        {
            if (standing)
            {
                return standingFrames;
            }
            else
                return movingFrames;
        
        }
    }
}
