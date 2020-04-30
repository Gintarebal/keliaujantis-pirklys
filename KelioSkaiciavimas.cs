using System;
using System.Collections.Generic;
using System.Linq;

public class KelioSkaiciavimas
{
  private readonly IEnumerable<kelias> _mapData;
  private readonly List<Location> _marsrutai;

  public KelioSkaiciavimas(IEnumerable<kelias> mapData)
	{
		_mapData = mapData;
		_marsrutai = new List<Location>();
	}
  
  //prideda prie marsrutu
  public void PridetiMarsruta(Location marsrutas)
	{
		//jei nėra maršruto išmeta exception
    if (marsrutas == null)
			throw new ArgumentNullException("marsrutas");
      _marsrutai.Add(marsrutas);
	}

  //atvaizduoja visus trumpiausius marsrutus
  public void TrumpiausiasKelias(Location pradziosTaskas)
	{
    if(pradziosTaskas == null)
			throw new ArgumentNullException("pradziosTaskas");
			
		if(_marsrutai.Count == 0)
			throw new InvalidOperationException("Neivesti keliai");
      
     List<kelias> students = _mapData.OrderBy(o => o.Atstumas()).ToList();
     
    var query = students.GroupBy(x => x.Nuo.Pavadinimas).Select(y => y.FirstOrDefault());

    foreach(var item in students)
    {
      Console.WriteLine(item.Nuo.Pavadinimas + " -> " + item.Iki.Pavadinimas + " atstumas: " + item.Atstumas().ToString("0.0000"));
    }
    Console.WriteLine("Artimiausias atstumas: ");
		//loopinti ir rasti artimiausią
    foreach(var item in query)
    {
      Console.WriteLine(item.Nuo.Pavadinimas + " -> " + item.Iki.Pavadinimas + " atstumas: " + item.Atstumas().ToString("0.0000"));
      
    }
	}
}
