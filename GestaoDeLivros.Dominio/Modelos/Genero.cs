using System.ComponentModel;

namespace GestaoDeLivros.Dominio.Modelos
{
    public enum Genero
    {
        [Description("Narrativo")]
        Narrativo = 0,

        [Description("Épico")]
        Epico = 1,

        [Description("Lírico")]
        Lirico = 2,

        [Description("Dramático")]
        Dramatico = 3
    }
}
