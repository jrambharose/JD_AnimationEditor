using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD_AnimationEditor
{
    class KernKey
    {
        public int FirstCharacter { get; set; }
        public int SecondCharacter { get; set; }

        public KernKey(int firstCharacter, int secondCharacter)
        {
            FirstCharacter = firstCharacter;
            SecondCharacter = secondCharacter;
        }
    }
}
