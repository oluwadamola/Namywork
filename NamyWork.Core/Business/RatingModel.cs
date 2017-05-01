using NamyWork.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace NamyWork.Core.Business
{
    public class RatingModel : Model
    {
        public int RatingID { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Max { get; set; }

        [Range(0, int.MaxValue)]
        public int Min { get; set; }

        public RatingModel()
        {

        }

        public RatingModel(Rating entity)
        {
            this.Assign(entity);
        }

        public Rating Create()
        {
            var entity = new Rating() {

                RatingId = this.RatingID,
                Max = this.Max,
                Min = this.Min
            };
            
            //entity.Assign(this);
            SwapMinMax(entity);
            return entity;
        }

        private Rating SwapMinMax(Rating entity)
        {
            if (entity.Max < entity.Min)
            {
                var temp = entity.Min;
                entity.Min = entity.Max;
                entity.Max = temp;
            }
            return entity;
        }

        public Rating Update(Rating entity)
        {
            entity.Max = Max;
            entity.Min = Min;
            SwapMinMax(entity);
            return entity;
        }
    }
}
