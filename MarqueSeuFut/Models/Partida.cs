using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarqueSeuFut.Models
{
    [Table("Partidas")]
    public class Partida
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a data!")] //Mensagem para quando o campo estiver nulo
        public DateTime Data { get; set; }

        [Display(Name = "Descrição")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar a descrição!")] //Mensagem para quando o campo estiver nulo
        public string  Descricao { get; set; }

        [Display(Name = "Time 1")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o time 1!")] //Mensagem para quando o campo estiver nulo
        public int Time1Id { get; set; }

        [ForeignKey("Time1Id")]
        public Time Time1 { get; set; }

        [Display(Name = "Time 2")] // palavra que vai ser exibida em nossa tela
        [Required(ErrorMessage = "Obrigatório informar o time 2!")] //Mensagem para quando o campo estiver nulo
        public int Time2Id { get; set; }

        [ForeignKey("Time2Id")]
        public Time Time2 { get; set; }


    }
}
