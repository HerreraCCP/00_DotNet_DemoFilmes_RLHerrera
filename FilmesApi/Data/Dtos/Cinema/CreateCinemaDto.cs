namespace FilmesAPI.Data.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
        
        public int GerenteId { get; set; }
    }
}
