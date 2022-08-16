namespace FilmesApi.Data.Dtos.Sessao
{
    using System;

    public class ReadSessaoDto
    {
        public int Id { get; set; }

        public Models.Cinema Cinema { get; set; }

        public Models.Filme Filme { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

        public DateTime HorarioDeInicio { get; set; }
    }
}