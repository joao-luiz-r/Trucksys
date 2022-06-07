using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckSys.Entities
{
    [Table("Truck")]
    public class Truck
    {
        public Truck()
        {

        }

        [Key]
        [Column("Id")]
        [Display(Name ="Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Modelo", TypeName = "varchar(2)")]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Column("AnoFabricacao")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Column("AnoModelo")]
        [Display(Name = "Ano do Modelo")]
        public int AnoModelo { get; set; }
    }
}
