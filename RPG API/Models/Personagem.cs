namespace RPG_API.Models
{
    public class Personagem
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Sobrenome { get; set; }
        public string? Fantasia { get; set; }
        public string? Local { get;set; }


    }
}
