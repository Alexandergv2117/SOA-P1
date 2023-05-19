using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }
        [StringLength(15)]
        public string CURP { get; set; }
        [StringLength(13)]
        public string RFC { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }


    }
}
