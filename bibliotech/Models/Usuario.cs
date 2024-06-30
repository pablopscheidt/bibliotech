namespace bibliotech.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
