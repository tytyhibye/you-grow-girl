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


    public Plant(string name, string species)
    {
      Name = name;
      Species = species;
      WaterStatus = 0;
      SunshineStatus = 0;
      FertilizerStatus = 0;
      SingStatus = 0;
      WalkStatus = 0;
      TotalCareStatus = 0;
    }

    
    // private static Dictionary<int, func<string, int>> _gameActions = new Dictionary<int, func<string, int>>() { {1, WaterPlant()}, {2, SunPlant() }, };

    public static Random rand = new Random();
    int count = rand.Next(1,3);

    public void InitiateGame(string name, string species)
    {
      Console.WriteLine(name + " the " + species + " is good to grow!");
      Console.WriteLine("Choose a plant based activity:");
      

    }

    public void DetermineNextStep()
    {
      WaterPlant();
      SunPlant();
      FertilizePlant();
      SingToPlant();
      WalkPlant();
      IsGameOver();
    }

    private void WaterPlant()
    {
      WaterStatus += 1;
      DetermineNextStep();
    }

    private void SunPlant()
    {
      SunshineStatus += 1;
      WaterStatus -= 1;
      DetermineNextStep();
    }

    private void FertilizePlant()
    {
      FertilizerStatus += 1;
      DetermineNextStep();
    }

    private void SingToPlant()
    {
      SingStatus += 1;
      DetermineNextStep();
    }

    private void WalkPlant()
    {
      WalkStatus += 1;
      DetermineNextStep();
    }

    private void IsGameOver()
    {
      if(TotalCareStatus >= 5 && Species == "cactus")
      {
        Console.WriteLine("You Win! Pretty fly for a cacti.");
        Console.WriteLine("*insert ASCII cactus here*");
      }
      else if (TotalCareStatus >= 5 && Species == "flower")
      {
        Console.WriteLine("You Win! Your flower is unbeleafable.");
        Console.WriteLine("*insert ASCII flower here*");
      }
      else 
      { 
        DetermineNextStep();
      }
    }
  }
}








// create Plant class
// give user input based name field to Plant class
// initiate game start
// 