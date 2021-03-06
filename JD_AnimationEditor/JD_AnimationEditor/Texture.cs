﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace JD_AnimationEditor
{
    public class Texture : Image
    {
        public static List<Texture> AllTextures = new List<Texture>();
        public static int Font = TextureManager.CreateTextureFromBitmap(GraphicsManager.GetFont());
        public static int Error = TextureManager.CreateTextureFromBitmap(GraphicsManager.GetError());

        public string Location;
        public string Name;
        public int ID;
        public float Width;
        public float Height;
        public float XOffset;
        public float YOffset;

        public Texture(string location)
        {
            init(location, 0, 0);
        }

        public Texture(string location, int x_offset, int y_offset)
        {
            init(location, x_offset, y_offset);
        }

        private void init(string loc, int x, int y)
        {
            Location = loc;
            ID = TextureManager.CreateTextureFromFile(loc);
            Name = StripName(loc);
            AllTextures.Add(this);

            Bitmap temp = new Bitmap(Bitmap.FromFile(loc));
            Width = temp.Width;
            Height = temp.Height;
            XOffset = x;
            YOffset = y;
        }

        public Texture(Bitmap img, string Name, int offsetX = 0, int offsetY = 0)
        {
            Location = "";
            ID = TextureManager.CreateTextureFromBitmap(img);
            this.Name = Name;
            Width = img.Width;
            Height = img.Height;
            XOffset = offsetX;
            YOffset = offsetY;

            AllTextures.Add(this);
        }

        private string StripName(string s)
        {
            string[] temp = s.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            return temp[temp.Length - 1].Split(new char[] { '.' })[0];
        }
        
        public override void Draw(float x, float y)
        {
            //GraphicsManager.DrawRectangle(x - XOffset, y - YOffset, Width, Height, this);
        }

        public override void Draw(float x, float y, float width, float height)
        {
            //GraphicsManager.DrawRectangle(x - XOffset, y - YOffset, width, height, this);
        }
        
        public Subimage Subimage(int x, int y, int width, int height)
        {
            return new Subimage(this, x, y, width, height);
        }
    }
}
