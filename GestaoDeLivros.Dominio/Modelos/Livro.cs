using LinqToDB.Mapping;
using System;

namespace GestaoDeLivros.Dominio.Modelos
{
    [Table("Livro")]
    public class Livro
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public int ISBN { get; set; }
        public Genero Genero { get; set; }
    }
}
