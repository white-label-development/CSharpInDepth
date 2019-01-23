using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Specs
{
    public class PlayerCharacterStepsContext
    {
        //items we want to pass between step definition classes
        public PlayerCharacter Player { get; set; }

        public int StartingMagicalPower { get; set; }

    }
}
