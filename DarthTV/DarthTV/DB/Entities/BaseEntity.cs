using System.ComponentModel.DataAnnotations;

namespace DarthTV.DB.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
