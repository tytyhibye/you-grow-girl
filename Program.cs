using System;
using Plants.Game;

namespace Plants
{
  public class Program
  {
    public static string DecideSpecies()
    {
      Console.WriteLine("Would you like to grow a flower or a cactus? F/C");
      string speciesInput = (Console.ReadLine().ToLower());
      if (speciesInput == "f")
      {
        return "flower";
      }
      else
      // } else if (speciesInput == "c")
      {
        return "cactus";
      }
    }
    public static void Main()
    {
      
      Console.WriteLine(@"
        __   __            _____                     _____ _      _ 
        \ \ / /           |  __ \                   |  __ (_)    | |
         \ V /___  _   _  | |  \/_ __ _____      __ | |  \/_ _ __| |
          \ // _ \| | | | | | __| '__/ _ \ \ /\ / / | | __| | '__| |
          | | (_) | |_| | | |_\ \ | | (_) \ V  V /  | |_\ \ | |  | |
          \_/\___/ \__,_|  \____/_|  \___/ \_/\_/    \____/_|_|  |_| ");
      Console.WriteLine("What would you like to name your plant?");
      string name = Console.ReadLine();
      Console.WriteLine("Welcome to the world " + name + "!");

      string species = DecideSpecies();

      if (species == "cactus")
       {
         Console.WriteLine(@"
             _x_x__x_____x
            x  / x | x x  \ 
           x  x x| x |x x  x 
           |  | |x | || |  |
           |  x || x x| |  x 
          __\__x_x_|_x_x__/__ 
          \                 / 
           `---------------' 
            |   =^ w ^=   |
            \_____________/ F_P
                  ");
       }
      else if (species == "flower")
      {
        Console.WriteLine(@"
                     ,
                 /\^/`\
                | \/   |
                | |    |
                \ \   /
                '\\//'
                  ||
                  ||
                  ||
                  ||  ,
              |\  ||  |\
              | | ||  | |
              | | || / /
               \ \||/ /
                `\\/ /`
           _______\_/_________ 
          \                 / 
           `---------------' 
            |   =^ w ^=   |
            \_____________/ jgs & F_P
        ");
      }

      Plant userPlant = new Plant(name, species);
      userPlant.InitiateGame(name, species);

      
    }
  }
}