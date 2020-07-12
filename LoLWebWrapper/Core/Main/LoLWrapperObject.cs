using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.xNet;
using LoLWebWrapper.Core.Modules;

namespace LoLWebWrapper.Core.Main
{
    public class LoLWrapperObject
    {
        public uGGParser uggParser = new uGGParser();

        public LoLWrapperObject()
        {
            cout("LoLWebWrapper init.");
        }

        public uGGParser getUGG(string championName, string role)
        {
            return uggParser.populateData(championName, role);
        }

        public static void cout(object s)
        {
            Console.WriteLine("[Rune Wrapper] : " + s);
        }
    }
}
