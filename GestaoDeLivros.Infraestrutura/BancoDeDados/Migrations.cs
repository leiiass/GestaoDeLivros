using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace GestaoDeLivros.Infraestrutura.BancoDeDados
{
    public class Migrations
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["Livraria"].ConnectionString;

        public static void ConfiguracaoMigracao()
        {
            using var serviceProvider = CriacaoServicos();
            using var scope = serviceProvider.CreateScope();
            AtualizarBancoDeDados(scope.ServiceProvider);
        }

        private static ServiceProvider CriacaoServicos()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(x => x.AddSqlServer()
                .WithGlobalConnectionString(connectionString)
                .ScanIn(typeof(_20240917111800_AddLivro).Assembly).For
                .Migrations())
                .AddLogging(c => c.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void AtualizarBancoDeDados(IServiceProvider serviceProvider)
        {
            var inicializar = serviceProvider.GetRequiredService<IMigrationRunner>();
            inicializar.MigrateUp();
        }
    }
}
