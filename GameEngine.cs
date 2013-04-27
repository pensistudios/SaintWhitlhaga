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
    class GameEngine
    {
        Player player;
        Weapon weapon;
        List<Zombie> zombies;
        List<Projectile> projectiles;

        
        float shoot_dt = 0.25f;

        int width;
        int height;
        
        float dt = 0;

        int last_key = 0;

        TextureManager tm;

        public GameEngine(int w, int h)
        {
            player = new Player();
            weapon = new Weapon(52, 54, -52, 54);
            weapon.standing_dt = 0.25f;

            player.bound.Height = 50;
            player.bound.Width = 50;

            projectiles = new List<Projectile>();
            zombies = new List<Zombie>();

            
            width = w;
            height = h;

            tm = new TextureManager();

        }

        public void Load(ContentManager Content)
        {
            /*tm.loadTexture(Content, "demonicgooA1trans");
            tm.loadTexture(Content, "demonicgooB1trans");
            tm.loadTexture(Content, "demonicgooC1");
            tm.loadTexture(Content, "lasershag9000A1");
            tm.loadTexture(Content, "lasershag9000B1");
            tm.loadTexture(Content, "lasershag9000C1");
            tm.loadTexture(Content, "lasershag9000fire");
            tm.loadTexture(Content, "BULLET");
            tm.loadTexture(Content, "BULLET2");
            tm.loadTexture(Content, "BULLET3");
            tm.loadTexture(Content, "BULLET4");
            tm.loadTexture(Content, "stripper");*/

            player.standingFrames.Add(tm.getTexture("demonicgooA1trans"));
            player.standingFrames.Add(tm.getTexture("demonicgooB1trans"));
            player.standingFrames.Add(tm.getTexture("demonicgooC1"));
            player.standingFrames.Add(tm.getTexture("demonicgooB1trans"));
            player.movingFrames.Add(tm.getTexture("demonicgooA1trans"));
            player.movingFrames.Add(tm.getTexture("demonicgooB1trans"));
            player.movingFrames.Add(tm.getTexture("demonicgooC1"));
            player.movingFrames.Add(tm.getTexture("demonicgooB1trans"));

            weapon.standingFrames.Add(tm.getTexture("lasershag9000A1"));
            weapon.standingFrames.Add(tm.getTexture("lasershag9000B1"));
            weapon.standingFrames.Add(tm.getTexture("lasershag9000C1"));

            weapon.movingFrames.Add(tm.getTexture("lasershag9000fire"));

            zombies.Add(new Zombie());
            zombies[0].standingFrames.Add(tm.getTexture("stripper"));
            zombies[0].pos.X = 600;
            zombies[0].pos.Y = 300;
        }


        public void Update(bool[] input, int millis)
        {
            dt += millis;

            if (input[0])
            {
                player.standing = false;
                player.moving_left = true;
                if ((player.pos.X - player.pmove_speed) >= 0)
                {
                    player.pos.X -= player.pmove_speed;
                }
            }
            if (input[2])
            {
                player.standing = false;
                player.moving_left = false;
                if ((player.pos.X + player.pmove_speed) <= width)
                {
                    player.pos.X += player.pmove_speed;
                }
            }
            if (input[1])
            {
                player.standing = false;
                if ((player.pos.Y + player.pmove_speed) <= height)
                {
                    player.pos.Y += player.pmove_speed;
                }
            }
            if(input[3])
            {
                player.standing = false;
                if ((player.pos.Y - player.pmove_speed) >= 0)
                {
                    player.pos.Y -= player.pmove_speed;
                }
            }
            if (!(input[0] || input[1] || input[2] || input[3]))
            {
                player.standing = true;
            }

            weapon.pos = player.pos;
            player.bound.X = (int) player.pos.X;
            player.bound.Y = (int) player.pos.Y;

            zombies[0].Update(player.bound);

            if (input[4])
            {
                if (dt >= (shoot_dt * 1000))
                {
                    dt = 0;

                    

                    Projectile p;
                    Vector2 offset;
                    if (!player.moving_left)
                    {
                        p = new Projectile(20, 10);
                        offset = new Vector2(84, 59);
                        p.pos = player.pos + offset;
                        weapon.switchFrameList(false);
                    }
                    else
                    {
                        p = new Projectile(20, -10);
                        offset = new Vector2(-84, 59);
                        p.pos = player.pos + offset;
                        weapon.switchFrameList(false);
                    }


                    p.standing_dt = 0.05f;
                    p.standingFrames.Add(tm.getTexture("BULLET"));
                    p.standingFrames.Add(tm.getTexture("BULLET2"));
                    p.standingFrames.Add(tm.getTexture("BULLET3"));
                    p.standingFrames.Add(tm.getTexture("BULLET4"));

                    projectiles.Add(p);
                }
                
            }
            else
            {
                weapon.switchFrameList(true);
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update();
                if(outOfLevel(projectiles[i]))
                {
                    projectiles.RemoveAt(i);
                }
                
            }

        }

        public void Draw(SpriteBatch s, int milli)
        {
            if (!player.moving_left)
            {
                s.Draw(player.getFrame(milli), player.getPosition(milli), Color.White);
                s.Draw(weapon.getFrame(milli), weapon.getPosition(false), Color.White);
            }
            else
            {
                s.Draw(player.getFrame(milli), player.getPosition(milli), null, Color.White, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0.0f);
                s.Draw(weapon.getFrame(milli), weapon.getPosition(true), null, Color.White, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally,0.0f);
            }


            for (int i = 0; i < projectiles.Count; i++)
            {
                s.Draw(projectiles[i].getFrame(milli), projectiles[i].pos, null, Color.White, 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None,0.0f);
            }

            s.Draw(zombies[0].getFrame(milli), zombies[0].pos, Color.White);
        }


        private bool outOfLevel(Entity e)
        {
            if ((e.pos.X + e.bound.Width) <= 0)
            {
                return true;
            }
            if (e.pos.X >= width)
            {
                return true;
            }
            if ((e.pos.Y + e.bound.Height) <= 0)
            {
                return true;
            }
            if (e.pos.Y >= height)
            {
                return true;
            }
            return false;
        }

    }
}
