﻿namespace FilmesApi.Data.Dtos.Sessao
{
    using System;

    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }

        public int FilmeId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }

    }
}
