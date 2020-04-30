using System;
using System.Collections.Generic;

class MainClass 
{

  public static void Main (string[] args) 
  {
		var locQue = new Queue<Location>(5);
    //Nustatomos Lietuvos miestų koordinates kurioms bus skaičiuojamas trumpiausias kelias
    locQue.Enqueue(new Location("Vilnius", 54.7007582, 24.972848));
		locQue.Enqueue(new Location("Alytus", 54.4035106, 23.9598724));
		locQue.Enqueue(new Location("Kaunas", 54.8900919, 23.7871791));
		locQue.Enqueue(new Location("Ukmergė", 55.2393692, 24.7007296));
		locQue.Enqueue(new Location("Klaipėda", 55.7054542, 21.0178082));
		var locs = new Location[5];
		locQue.CopyTo(locs, 0);

		var keliai = new List<kelias>();
		var current = locQue.Dequeue();

    //ciklas skirtas kelių visų sąsajų išrinkimui
    while (current != null)
			{
				for (int i = locs.Length - 1; i >= 0; i--)
				{
					if (current != locs[i])
					{
						var kelias = new kelias()
						{
							Nuo = current,
							Iki = locs[i]
						};
						if (keliai.Contains(kelias) == false)
						{
							keliai.Add(kelias);
							Console.WriteLine("Pridedamas {0} į {1}", kelias.Nuo.Pavadinimas, kelias.Iki.Pavadinimas);
						}
					}
				}
				current = locQue.Count > 0 ? locQue.Dequeue() : null;
			}
      //parodo galimų kelių kiekį
      Console.WriteLine("Iš viso {0} keliai(-ų)", keliai.Count);

      
			var satNav = new KelioSkaiciavimas(keliai);
			satNav.PridetiMarsruta(locs[1]);
			satNav.PridetiMarsruta(locs[2]);
			satNav.PridetiMarsruta(locs[3]);
      satNav.PridetiMarsruta(locs[4]);

			//var route = satNav.TrumpiausiasKelias(locs[0]);
      satNav.TrumpiausiasKelias(locs[0]);
			
      Console.WriteLine("Paspauskite bet kurį klavišą norint išeiti...");
			Console.ReadKey();
  }

}
