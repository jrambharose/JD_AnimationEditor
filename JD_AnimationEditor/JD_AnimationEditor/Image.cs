using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_AnimationEditor
{
    abstract public class Image
    {
        abstract public void Draw(float x, float y);
        abstract public void Draw(float x, float y, float width, float height);
    }
}
