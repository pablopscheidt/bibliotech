namespace bibliotech.Models
{
    public class Emprestimo
    {
        public int ID { get; set; }
        public int LivroID { get; set; }
        public Livro Livro { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
