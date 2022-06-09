using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckSys.Entities
{
    [Table("Truck")]
    public class Truck
    {
        public Truck()
        {
            errormessages = new List<string>();
        }

        public Truck(int? id, string modelo, int anoFabricacao, int anoModelo)
        {
            Id = id ?? 0;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            errormessages = new List<string>();
        }

        [Key]
        [Column("Id")]
        [Display(Name ="Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Modelo", TypeName = "varchar(2)")]
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Column("AnoFabricacao")]
        [Display(Name = "Ano de Fabricação")]
        [Required(ErrorMessage = "Campo Ano de Fabricação é obrigatório")]
        public int AnoFabricacao { get; set; }

        [Column("AnoModelo")]
        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "Campo Ano do Modelo é obrigatório")]
        public int AnoModelo { get; set; }

        [NotMapped]
        public List<string> errormessages { get; set; }
    }
}
