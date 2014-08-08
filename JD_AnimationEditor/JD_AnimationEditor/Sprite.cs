using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_AnimationEditor
{
    public class Sprite : Image
    {
        public int Width;
        public int Height;
        private float _currentframe;
        public float PlaybackSpeed = 1.0f;
        List<Image> Frames = new List<Image>();

        public float CurrentFrame
        { //Decimal point is % of the way done with a frame (for example, half speeds)
            get
            {
                return _currentframe;
            }
            set
            {
                _currentframe = value % Frames.Count;
                if (_currentframe < 0)
                {
                    _currentframe += Frames.Count;
                }
            }
        }


        public Sprite(Image frame)
        {
            Add(frame);
        }

        public Sprite(Image[] frames)
        {
            foreach (Image tf in frames)
            {
                Add(tf);
            }
        }

        public void Add(Image frame)
        {
            Frames.Add(frame);
        }

        public override void Draw(float x, float y)
        {
            if (Frames.Count > 0)
            {
                Frames[(int)Math.Floor(CurrentFrame)].Draw(x, y);
                CurrentFrame += PlaybackSpeed;
            }
        }

        public override void Draw(float x, float y, float width, float height)
        {
            if (Frames.Count > 0)
            {
                Frames[(int)Math.Floor(CurrentFrame)].Draw(x, y, width, height);
                CurrentFrame += PlaybackSpeed;
            }
        }
    }
}
