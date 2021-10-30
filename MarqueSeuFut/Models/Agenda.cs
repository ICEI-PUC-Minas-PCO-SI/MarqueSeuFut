 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public string Localizacao { get; set; }

        public int TimeCasaId { get; set; } //para chave estrangeira

        [ForeignKey("TimeCasaId")]
        public Time TimeCasa { get; set; } //para chave estrangeira

        public int TimeVisitanteId { get; set; } //para chave estrangeira

        [ForeignKey("TimeVisitanteId")]
        public Time TimeVisitante { get; set; } //para chave estrangeira
    }
}
