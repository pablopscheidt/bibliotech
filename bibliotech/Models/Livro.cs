namespace bibliotech.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public required string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
