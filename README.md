# LoLWebWrapper | U.GG API

LoLWebWrapper is a simple wrapper around websites such as U.GG written in C# that allows you to retreive runes and items information, Currently it only supports U.GG as I wrote this just for fun while working on a project that required this functionality, however I may add support for other websites such as Champion.GG and OP.GG later on. It is written very poorly using mostly Regex due to the reason stated before but I still decided to release it incase someone had a use for it.

(U.GG) Right now it only gets the most popular build on the front page for Platnium+ but it would be very easy to add functionaility for choosing ranks.

TODO:
Make everything ASYNC,
It also currently has almost 0 error handling.

Usage:

```C#
using LoLWebWrapper.Core.Main;
using LoLWebWrapper.Core.Components;
using LoLWebWrapper.Core.Modules;

LoLWrapperObject wrapper = new LoLWrapperObject();

uGGParser uGGParser = wrapper.getUGG("Yasuo", "Middle"); //Champion (String), Role(String)

Console.WriteLine("[Primary Runes]");
Console.WriteLine("     Main Rune: " + uGGParser.model.primaryRune.mainRune);
Console.WriteLine("     Key Stone: " + uGGParser.model.primaryRune.keyStone);
Console.WriteLine("     Choice 1: " + uGGParser.model.primaryRune.choice1);
Console.WriteLine("     Choice 2: " + uGGParser.model.primaryRune.choice2);
Console.WriteLine("     Choice 3: " + uGGParser.model.primaryRune.choice3);

Console.WriteLine("[Secondary Runes]");
Console.WriteLine("     Main Rune: " + uGGParser.model.secondaryRune.mainRune);
Console.WriteLine("     Choice 1: " + uGGParser.model.secondaryRune.choice1);
Console.WriteLine("     Choice 2: " + uGGParser.model.secondaryRune.choice2);

Console.WriteLine("[Minor Runes]");
Console.WriteLine("     Shard 1: " + uGGParser.model.minorRune.choice1);
Console.WriteLine("     Shard 2: " + uGGParser.model.minorRune.choice2);
Console.WriteLine("     Shard 3: " + uGGParser.model.minorRune.choice3);

Console.WriteLine("[Summoner Spells]");
Console.WriteLine("     Primary: " + uGGParser.model.primarySummonerSpell);
Console.WriteLine("     Secondary: " + uGGParser.model.secondarySummonerSpell);

```
