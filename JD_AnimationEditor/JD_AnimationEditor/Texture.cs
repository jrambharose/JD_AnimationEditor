using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_AnimationEditor
{
    class Texture
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get; set; }

        public Texture()
        {
            Id = 0;
            Width = 0;
            Height = 0;
            Path = "";
        }

        public Texture(int id, int width, int height, string path)
            : this(id, width, height)
        {
            Path = path;
        }


        public Texture(int id, int width, int height)
        {
            Id = id;
            Width = width;
            Height = height;
        }

    }
}
