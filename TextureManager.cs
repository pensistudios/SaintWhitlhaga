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
    class TextureManager
    {
        private Dictionary<String, Texture2D> rm;

        public TextureManager()
        {
            rm = new Dictionary<string, Texture2D>();
        }

        public void loadTexture(ContentManager cm, String filename)
        {
            rm.Add(filename, cm.Load<Texture2D>(filename));
        }

        public void Load(ContentManager Content)
        {
            loadTexture(Content, "demonicgooA1trans");
            loadTexture(Content, "demonicgooB1trans");
            loadTexture(Content, "demonicgooC1");
            loadTexture(Content, "lasershag9000A1");
            loadTexture(Content, "lasershag9000B1");
            loadTexture(Content, "lasershag9000C1");
            loadTexture(Content, "lasershag9000fire");
            loadTexture(Content, "BULLET");
            loadTexture(Content, "BULLET2");
            loadTexture(Content, "BULLET3");
            loadTexture(Content, "BULLET4");
            loadTexture(Content, "stripper");
        }

        public Texture2D getTexture(String filename)
        {
            return rm[filename];
        }


    }
}
