using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class RandomNameGenerator
{
    public static List<string> firstNames = new List<string> 
    {
        "Alexi",
        "Baron",
        "Cassia",
        "Benjamin",
        "Dorian",
        "Lillith",
        "Esmerelda",
        "Sylas",
        "Isolde",
        "Seraphina",
    };

    public static List<string> lastNames = new List<string>
    {
        "Grimthorne",
        "Duskwither",
        "Blackgrave",
        "Nightvale",
        "Vexmoor",
        "Ravenshade",
        "Thornbrook",
        "Ashborn",
        "Briarthorne",
        "Vilecroft",
    };

    public static List<string> titles = new List<string>
    {
        "the Cursed",
        "the Wicked",
        "the Revenant",
        "the Withered",
        "the Cruel",
        "the Bloodied",
        "the Eternal",
        "the Malignant",
        "the Pale",
        "the Merciless",
    };


    //TODO Not yet implemented... Add this later for the lawlz... and the cats
    public static List<string> catNames = new List<string>
    {
        "Stewie",
        "Suzie",
        "Sammie",
        "SerPounce",
        "LawlzKitty",
    };


    public static string GenerateName() 
    {
        string first = firstNames[Random.Range(0, firstNames.Count)];
        string last = lastNames[Random.Range(0, lastNames.Count)];
        string title = titles[Random.Range(0, titles.Count)];

        return $"{first} {last}, {title}";
    }
}
