namespace FilmesAPI.Data.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ReadEnderecoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string Logradouro { get; set; }
        
        public string Bairro { get; set; }
        
        public int Numero { get; set; }

    }
}
