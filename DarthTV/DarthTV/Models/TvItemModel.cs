using DarthTV.DB.Entities.Tv;

namespace DarthTV.Models
{
    public class TvItemModel
    {
        public TvItemEntity Entity { get; set; }
        public string CardClasses
        {
            get
            {
                string backgroundColor;
                switch (Entity.Type)
                {
                    case Classes.Enums.TvType.Series:
                        backgroundColor = "border-info";
                        break;
                    case Classes.Enums.TvType.Movie:
                        backgroundColor = "border-primary";
                        break;
                        default:
                        backgroundColor = "border-light";
                        break;

                }

                return $"{backgroundColor}";
            }
        }
    }
}
