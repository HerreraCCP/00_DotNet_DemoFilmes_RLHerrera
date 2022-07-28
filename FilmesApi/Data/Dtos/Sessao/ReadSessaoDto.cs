namespace FilmesApi.Data.Dtos.Sessao
{
    using FilmesAPI.Models;
    using System;

    public class ReadSessaoDto
    {
        public int Id { get; set; }

        public Cinema Cinema { get; set; }

        public Filme Filme { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

        public DateTime HorarioDeInicio { get; set; }
    }
}