using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFinaces.Models
{
    public class MovToFin
    {
        public int Id { get; set; }

        [DisplayName(@"Título")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [DisplayName(@"Descrição")]
        public string Description { get; set; }

        [DisplayName(@"Data Movimentação")]
        public DateTime DataMovto { get; set; } = DateTime.Now;

        [DisplayName(@"Ultima atualização")]
        public DateTime DataLastUpdate { get; set; }

        [DisplayName(@"Usuário")]
        public string User { get; set; }

        [DisplayName(@"Pago")]
        public bool Paid { get; set; }

    }
}
