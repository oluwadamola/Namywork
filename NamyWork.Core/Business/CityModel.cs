using NamyWork.Data.Entities;

namespace NamyWork.Core.Business
{
    public class CityModel : Model
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public CityModel()
        {

        }

        public CityModel(City city)
        {
            this.Assign(city);
        }
    }
}