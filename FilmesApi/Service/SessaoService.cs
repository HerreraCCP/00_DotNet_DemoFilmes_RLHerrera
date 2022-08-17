using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;

namespace FilmesApi.Service
{
    public class SessaoService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public SessaoService(IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        public ReadSessaoDto RecuperaSessoesPorId(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
            return sessao != null 
                ? _mapper.Map<ReadSessaoDto>(sessao) 
                : null;
        }
    }
}