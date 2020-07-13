using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLWebWrapper.Core.Components
{
    public enum championRole
    {
        Top,
        Jungle,
        Middle,
        ADC,
        Support
    }

    public class RuneBuildModel
    {
        public PrimaryRune primaryRune;
        public SecondaryRune secondaryRune;
        public MinorRune minorRune;

        public string primarySummonerSpell = "";
        public string secondarySummonerSpell = "";
    }

    public class PrimaryRune
    {
        public string mainRune = "";
        public string keyStone = "";
        public string choice1 = "";
        public string choice2 = "";
        public string choice3 = "";
    }

    public class SecondaryRune
    {
        public string mainRune = "";
        public string choice1 = "";
        public string choice2 = "";
    }

    public class MinorRune
    {
        public string choice1 = "";
        public string choice2 = "";
        public string choice3 = "";
    }
}
