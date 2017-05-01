namespace NamyWork.Data.Entities
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
    }

    public enum AppCity
    {
        Abuja,
        Ibadan,
        Ilorin,
        Porthcourth
    }
}