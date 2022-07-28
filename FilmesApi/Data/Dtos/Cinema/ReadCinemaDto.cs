﻿namespace FilmesAPI.Data.Dtos
{
    using FilmesApi.Models;
    using System.ComponentModel.DataAnnotations;

    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        
        public Endereco Endereco { get; set; }
        
        public Gerente Gerente { get; set; }
    }
}
