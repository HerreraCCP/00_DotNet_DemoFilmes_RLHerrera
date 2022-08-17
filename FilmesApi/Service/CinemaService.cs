using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Cinema;
using FilmesApi.Models;
using FluentResults;

namespace FilmesApi.Service
{
    public class CinemaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);

            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDto>(cinema);
        }


        public List<ReadCinemaDto> RecuperaCinemas(string nomeDoFilme)
        {
            var cinemas = _context.Cinemas.ToList();
            if (cinemas == null) return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
                cinemas = (from cinema in cinemas
                    where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                    orderby cinema.Nome
                    select cinema).ToList();

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
        }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return null;

            var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return cinemaDto;
        }

        public Result AtualizaCinema(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) Result.Fail("Filme nao encontrado");
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return Result.Fail("Filme nao encontrado");
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}