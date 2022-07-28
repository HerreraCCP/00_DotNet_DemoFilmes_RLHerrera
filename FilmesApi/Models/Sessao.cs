namespace FilmesApi.Models
{
    using FilmesAPI.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual Filme Filme{ get; set; }

        public int FilmeId { get; set; }

        public int CinemaId  { get; set; }

        public DateTime HorarioEncerramento { get; set; }
    }
}