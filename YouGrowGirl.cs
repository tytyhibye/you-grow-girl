using System;
using System.Collections.Generic;

namespace Plant.Game
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

  
  private static Dictionary<int, func<string, int>> _gameActions = new Dictionary<int, func<string, int>>() {1, }
}









// create Plant class
// give user input based name field to Plant class
// initiate game start
// 