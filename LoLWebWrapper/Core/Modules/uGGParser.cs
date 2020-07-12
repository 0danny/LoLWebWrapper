using Leaf.xNet;
using LoLWebWrapper.Core.Components;
using LoLWebWrapper.Core.Main;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoLWebWrapper.Core.Modules
{
    public class uGGParser
    {
        public RuneBuildModel model;

        public uGGParser populateData(string championName, string role)
        {
            string webData = NetworkRequest.getString("https://u.gg/lol/champions/" + championName + "/build?role=" + role);

            LoLWrapperObject.cout("Requesting data from U.GG..");

            //First Rune Path
            MatchCollection buildPath = Regex.Matches(webData, "<div class=\"perk perk-active\"><img class=\"\" src=\"(.*?)\" alt=\"(.*?)\"/></div>");
            //Minor Rune Path
            MatchCollection minorPath = Regex.Matches(webData, "<div class=\"shard shard-active\"><img class=\"\" src=\"(.*?)\"/>");
            string primaryMainRune = Regex.Matches(webData, "<div class=\"perk-style-title\"><div>(.*?)</div></div>")[0].Groups[1].Value;
            string secondaryMainRune = Regex.Matches(webData, "<div class=\"perk-style-title\"><div>(.*?)</div></div>")[1].Groups[1].Value;
            string primarySummonerSpell = Regex.Matches(webData, "<div class=\"image-wrapper\"><img class=\"\" src=\"(.*?)\" alt=\"(.*?)\"/>")[0].Groups[2].Value;
            string secondarySummonerSpell = Regex.Matches(webData, "<div class=\"image-wrapper\"><img class=\"\" src=\"(.*?)\" alt=\"(.*?)\"/>")[1].Groups[2].Value;

            model = new RuneBuildModel()
            {
                primaryRune = new PrimaryRune()
                {
                    mainRune = primaryMainRune,
                    keyStone = buildPath[0].Groups[2].Value,
                    choice1 = buildPath[1].Groups[2].Value,
                    choice2 = buildPath[2].Groups[2].Value,
                    choice3 = buildPath[3].Groups[2].Value
                },
                secondaryRune = new SecondaryRune()
                {
                    mainRune = secondaryMainRune,
                    choice1 = buildPath[4].Groups[2].Value,
                    choice2 = buildPath[5].Groups[2].Value
                },
                minorRune = new MinorRune()
                {
                    choice1 = cleanMinorRunes(minorPath[0].Groups[1].Value),
                    choice2 = cleanMinorRunes(minorPath[1].Groups[1].Value),
                    choice3 = cleanMinorRunes(minorPath[2].Groups[1].Value)
                },
                primarySummonerSpell = primarySummonerSpell,
                secondarySummonerSpell = secondarySummonerSpell
            };

            return this;
        }

        private string cleanMinorRunes(string text)
        {
            return AddSpacesToSentence(text.Trim().Replace("https://static.u.gg/lol/static/images/StatMods/StatMods", "").Replace("Icon.png", ""));
        }

        private string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}
