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

    // public static Random rand = new Random();
    // int count = rand.Next(1,3);

    public void InitiateGame(string name, string species)
    {
      Console.WriteLine(name + " the " + species + " is good to grow!");
      DetermineNextStep();
    }

    public void DetermineNextStep()
    {
      IsGameOver();
      Console.WriteLine("Choose a plant based activity:");
      Console.WriteLine("1: Water, 2: Sun, 3: Fertilize, 4: Sing (Risky!), 5: Walk (Reset your bearings!)");
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
      DisplayFertilizerStatus();
      DetermineNextStep();
    }

    private void SingToPlant()
    {
      Random rand = new Random();
      int count = rand.Next(1,5);

      if(count == 1)
      {
        WaterStatus = 2;
        SunshineStatus = 2;
        FertilizerStatus = 2;
        SingStatus = 1;
      }
      else if(count == 2)
      {
        WaterStatus -= 1;
        SunshineStatus -= 1;
        FertilizerStatus -= 1;
        SingStatus = -1;
      }
      
      DisplaySingStatus();
      SingStatus = 0;
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
        Console.WriteLine(Name + " is drowning! |X_X| help dry them out.");  
      }
    }

    
    public void DisplaySunshineStatus()
    {
      if(SunshineStatus > 2)
      {
        Console.WriteLine("It is hot in Topeka! With a little help, " + Name + " will be ready to grow and ready to go! |> w <|");
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

    public void DisplayFertilizerStatus()
    {
      if(FertilizerStatus < 2)
      {
        Console.WriteLine(Name + "'s starving! Their fangs are out RUN FOR YOUR LIFE |>'M'|>.");
      }
      else if(FertilizerStatus == 2)
      {
        Console.WriteLine("*om nom nom*" + Name + " is perfectly full |^ w ^|");
      }
      else{
        Console.WriteLine(Name + " is too full! <(   *_*   )> Give them something to break down the food!");
      }
    }

    public void DisplaySingStatus()
    {
      if (SingStatus > 0)
      {
        Console.WriteLine("Your beautiful voice has spoken to " + Name + "! Something magical is happening! |0 w 0|");
      }
      else if (SingStatus < 0)
      {
        Console.WriteLine("Oof I don't think " + Name + " liked that. They look upsetti sphaghetti |# > n <|");
      }
      else
      {
        Console.WriteLine("We're not sure if " + Name + " heard you.... It's not very effective... |- . -|");
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