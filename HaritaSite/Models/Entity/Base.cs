using System.ComponentModel.DataAnnotations;

namespace HaritaSite.Models.Entity
{
    public class Base
    {   
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Statu { get; set; }
    }
}
