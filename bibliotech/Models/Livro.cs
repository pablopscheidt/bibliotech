﻿namespace bibliotech.Models
{
    public class Livro
    {
        public int ID { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
