using System;

public class kelias
{
      protected bool Equals(kelias kitas)
		  {
			  return ((Equals(Nuo, kitas.Nuo)) || (Equals(Nuo, kitas.Iki))) && ((Equals(Iki, kitas.Iki)) || Equals(Iki, kitas.Nuo));
      }

      public kelias() {}
      
      public kelias(Location nuo, Location iki)
		  {
			  Nuo = nuo;
			  Iki = iki;
		  }

      public Location Nuo { get; set; }
		  public Location Iki { get; set; }

      //formulės realizavimas apskaičiavimui atstumo pagal pateiktas koordinates
      public double Atstumas()
      {
        double theta = Nuo.Lat - Iki.Lat;
        double dist = Math.Sin(Deg2Rad(Nuo.Lat)) * Math.Sin(Deg2Rad(Iki.Lat)) + Math.Cos(Deg2Rad(Nuo.Lat)) * Math.Cos(Deg2Rad(Iki.Lat)) * Math.Cos(Deg2Rad(theta));
        dist = Math.Acos(dist);
        dist = Rad2Deg(dist);
        return dist * 60 * 1.1515;
      }

      
      //skaiciavimo formule
      private static double Deg2Rad(double deg)
      {
        return (deg * Math.PI / 180.0);
      }

      //skaiciavimo formule
      private static double Rad2Deg(double rad)
      {
        return (rad / Math.PI * 180.0);
      }
		}
