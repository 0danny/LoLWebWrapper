using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using LoLWebWrapper.Core.Components;
using LoLWebWrapper.Core.Modules;

namespace LoLWebWrapper.Core.Main
{
    public class LoLWrapperObject
    {
        public uGGParser uggParser = new uGGParser();

        public static bool consoleOutput = true;

        public LoLWrapperObject()
        {
            cout("LoLWebWrapper init.");
        }

        public uGGParser getUGG(string championName, championRole role)
        {
            return uggParser.populateData(championName, role);
        }

        public static void cout(object s)
        {
            if (consoleOutput)
            {
                Console.WriteLine("[LoLWeb Wrapper] : " + s);
            }
        }
    }
}
