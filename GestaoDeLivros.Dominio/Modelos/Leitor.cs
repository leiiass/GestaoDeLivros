using System.Collections.Generic;

namespace GestaoDeLivros.Dominio.Modelos
{
    public class Leitor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Genero> GeneroPreferido { get; set; }
        public int QuantidadeDeLivrosLidos { get; set; }
        public List<Livro> LivrosLidos { get; set; }
    }
}
