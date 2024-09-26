using FluentMigrator;

namespace GestaoDeLivros.Infraestrutura.BancoDeDados
{
    [Migration(20240917111800)]
    public class _20240917111800_AddLivro : Migration
    {
        public override void Down()
        {
            Delete.Table("Livro");
        }

        public override void Up()
        {
            Create.Table("Livro")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("titulo").AsString().NotNullable()
                .WithColumn("autor").AsString().NotNullable()
                .WithColumn("editora").AsString().NotNullable()
                .WithColumn("dataDaPublicacao").AsDateTime().NotNullable()
                .WithColumn("isbn").AsInt32().NotNullable()
                .WithColumn("genero").AsInt32().NotNullable();
        }
    }
}
