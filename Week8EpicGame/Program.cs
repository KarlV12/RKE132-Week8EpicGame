string folderPath = "C:\\Users\\aarne\\OneDrive\\Töölaud\\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "magic wand", "plastic fork", "banana", "wooden sword", "Lego brick" };




string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} saves the day!");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int VillainHP = GetCharacterHP(villain);
int villainStrikeStrength = VillainHP;
Console.WriteLine($"Today {villain} ({VillainHP} HP) with {villainWeapon} tries to take over the world!");


while(heroHP > 0 && VillainHP > 0)
{
    heroHP = heroHP - Hit(villain, VillainHP);
    VillainHP = VillainHP - Hit(hero, heroHP);
}


Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {VillainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (VillainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}


static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if(strike == characterHP - 0)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
        Console.WriteLine($"{characterName} hit {strike}!");

    return strike;
}