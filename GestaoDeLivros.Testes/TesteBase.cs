using FluentValidation;
using GestaoDeLivros.Dominio.Interfaces;
using GestaoDeLivros.Dominio.Modelos;
using GestaoDeLivros.Dominio.Validadores;
using GestaoDeLivros.Infraestrutura.Repositorios;
using GestaoDeLivros.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoDeLivros.Testes
{
    public class TesteBase : IDisposable
    {
        protected ServiceProvider _serviceProvider;
        protected IServiceCollection _services;
        public TesteBase()
        {
            _services = ConfigurarServicos();
            _serviceProvider = _services.BuildServiceProvider();
        }

        protected IServiceCollection ConfigurarServicos()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ServicoLivro>();
            services.AddSingleton<ILivroRepositorio, RepositorioLivro>();
            services.AddSingleton<IValidator<Livro>, LivroValidator>();

            return services;
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
