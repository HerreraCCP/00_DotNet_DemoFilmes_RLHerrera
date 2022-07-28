namespace FilmesAPI.Data.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
    }
}
