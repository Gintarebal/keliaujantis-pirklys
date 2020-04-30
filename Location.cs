public class Location
{
  public Location(){}

  //koordinačių konstruktorius
  public Location(string pavadinimas, double lat, double lng)
	{
		Pavadinimas = pavadinimas;
		Lat = lat;
		Lng = lng;
	}

  public string Pavadinimas;
  public double Lat { get; set; }
	public double Lng { get; set; }
}
