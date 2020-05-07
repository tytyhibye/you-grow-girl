using System;
using System.Collections.Generic;

namespace Plants.Game
{
  public class Plant{
    public string Name { get; set; }
    public string Species { get; set; }
    public int WaterStatus { get; set; }
    public int SunshineStatus { get; set; }
    public int FertilizerStatus { get; set; }
    public int SingStatus { get; set; }
    public int WalkStatus { get; set; }
    public int TotalCareStatus { get; set; }
    private Dictionary<int, Action> GameActions { get; set; }

    public Plant(string name, string species)
    {
      Name = name;
      Species = species;
      WaterStatus = 0;
      SunshineStatus = 0;
      FertilizerStatus = 0;
      SingStatus = 0;
      WalkStatus = 0;
      GameActions = new Dictionary<int, Action>() { {1, () => WaterPlant()}, {2, () => SunPlant() }, {3, () => FertilizePlant()}, {4, () => SingToPlant()}, {5, () => WalkPlant()} };
    }

    public static Random rand = new Random();
    int count = rand.Next(1,3);

    public void InitiateGame(string name, string species)
    {
      Console.WriteLine(name + " the " + species + " is good to grow!");
      DetermineNextStep();
    }

    public void DetermineNextStep()
    {
      IsGameOver();
      // Console.WriteLine("Current Water: " + WaterStatus + ", Current Sunshine: " + SunshineStatus + ", Current Fertilizer: " + FertilizerStatus);
      Console.WriteLine("Choose a plant based activity:");
      Console.WriteLine("1: Water, 2: Sun, 3: Fertilize, 4: Sing (Risky!), 5: Walk (Risky!)");
      Console.WriteLine("Enter a number 1-5.");
      int action = int.Parse(Console.ReadLine());
      GameActions[action].Invoke();
    }

    private void WaterPlant()
    {
      WaterStatus += 3;
      FertilizerStatus -= 1;
      DisplayWaterStatus();
      DetermineNextStep();
    }

    private void SunPlant()
    {
      SunshineStatus += 3;
      WaterStatus -= 1;
      DisplaySunshineStatus();
      DetermineNextStep();
    }

    private void FertilizePlant()
    {
      FertilizerStatus += 3;
      SunshineStatus -= 1;
      // DisplayFertilizerStatus();
      DetermineNextStep();
    }

    private void SingToPlant()
    {
      SingStatus += 1;
      // DisplaySingStatus();
      DetermineNextStep();
    }

    private void WalkPlant()
    {
      WalkStatus += 1;
      // DisplayWalkStatus();
      DetermineNextStep();
    }

    public void DisplayWaterStatus()
    {
      if(WaterStatus < 2)
      {
        Console.WriteLine(Name + " is still thirsty |>'_'|> !");
      }
      else if(WaterStatus == 2)
      {
        Console.WriteLine(Name + " is quenched! |^_^| <3");
      }
      else
      {
        Console.WriteLine(Name + " is drowning! |X_X| ");  
      }
    }

    
    public void DisplaySunshineStatus()
    {
      if(SunshineStatus > 2)
      {
        Console.WriteLine("It is hot in Topeka! Cool " + Name + " down a bit!");
      }
      else if(SunshineStatus == 2)
      {
        Console.WriteLine("The sun is shining! The tank is clean! " + Name + " is a happy camper! |^ w ^|");
      }
      else
      {
        Console.WriteLine("Eternal darkeness. " + Name + "'s life is a static void |X_x|");
      }
    }
    private void IsGameOver()
    {
      if(WaterStatus == 2 && SunshineStatus == 2 && FertilizerStatus == 2 && Species == "cactus")
      {
        Console.WriteLine("You Win! Pretty fly for a cacti.");
        Console.WriteLine(@"
              .    _    +     .  ______   .          .
           (      /|\      .    |      \      .   +
               . |||||     _    | |   | | ||         .
          .      |||||    | |  _| | | | |_||    .
             /\  ||||| .  | | |   | |      |       .
          __||||_|||||____| |_|_____________\__________
          . |||| |||||  /\   _____      _____  .   .
            |||| ||||| ||||   .   .  .         ________
           . \|`-'|||| ||||    __________       .    .
              \__ |||| ||||      .          .     .
            __    ||||`'|||  .       .    __________
           .    . |||| __/  ___________             .
              . _ ||||| . _               .   _________
           _   ___|||||__  _ _______    .          _
                _ `---'    ..   _   .   .    .
          _  ^      .  -    . _______ . ______ .    . 
        ");
        Environment.Exit(0);
      }
      else if (WaterStatus == 2 && SunshineStatus == 2 && FertilizerStatus == 2 && Species == "flower")
      {
        Console.WriteLine("You Win! Your flower is unbeleafable.");
        Console.WriteLine(@"
                        _(_)_                          wWWWw   _
            @@@@       (_)@(_)   vVVVv     _     @@@@  (___) _(_)_
           @@()@@ wWWWw  (_)\    (___)   _(_)_  @@()@@   Y  (_)@(_)
            @@@@  (___)     `|/    Y    (_)@(_)  @@@@   \|/   (_)\
             /      Y       \|    \|/    /(_)    \|      |/      |
          \ |     \ |/       | / \ | /  \|/       |/    \|      \|/
      jgs \\|//   \\|///  \\\|//\\\|/// \|///  \\\|//  \\|//  \\\|// 
      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        ");
        Environment.Exit(0);
      }
    }
  }
}