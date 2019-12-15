using Microsoft.Extensions.DependencyInjection;
using Salvage.Application;
using Salvage.Application.Interfaces;
using Salvage.Domain.Interfaces.Repositories;
using Salvage.Domain.Interfaces.Services;
using Salvage.Domain.Services;
using Salvage.Infra.Data.Repositories.SQL;
using Salvage.Infra.EnvioEmail;
using Salvage.Infra.EnvioEmail.Interfaces;

namespace Salvage.Infra.CrossCutting.IoC
{
    public class InjetorNativo
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAppDespachanteService, AppDespachanteService>();
            services.AddScoped<IDespachanteService, DespachanteService>();
            services.AddTransient<IDespachanteRepository, DespachanteRepository>();

            services.AddScoped<IAppGuincheiroService, AppGuincheiroService>();
            services.AddScoped<IGuincheiroService, GuincheiroService>();
            services.AddTransient<IGuincheiroRepository, GuincheiroRepository>();

            services.AddScoped<IAppOficinaService, AppOficinaService>();
            services.AddScoped<IOficinaService, OficinaService>();
            services.AddTransient<IOficinaRepository, OficinaRepository>();

            services.AddScoped<IAppPatioService, AppPatioService>();
            services.AddScoped<IPatioService, PatioService>();
            services.AddTransient<IPatioRepository, PatioRepository>();

            services.AddScoped<IAppSeguradoraService, AppSeguradoraService>();
            services.AddScoped<ISeguradoraService, SeguradoraService>();
            services.AddTransient<ISeguradoraRepository, SeguradoraRepository>();

            services.AddScoped<IAppSalvadoService, AppSalvadoService>();
            services.AddScoped<ISalvadoService, SalvadoService>();
            services.AddTransient<ISalvadoRepository, SalvadoRepository>();

            services.AddScoped<IAppUsuarioService, AppUsuarioService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IAppWorkflowPassoService, AppWorkflowPassoService>();
            services.AddScoped<IWorkflowPassoService, WorkflowPassoService>();
            services.AddTransient<IWorkflowPassoRepository, WorkflowPassoRepository>();

            services.AddScoped<IAppWorkflowService, AppWorkflowService>();
            services.AddScoped<IWorkflowService, WorkflowService>();
            services.AddTransient<IWorkflowRepository, WorkflowRepository>();

            services.AddScoped<IAppContatoService, AppContatoService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddTransient<IContatoRepository, ContatoRepository>();

            services.AddScoped<IEnvioEmail, EmailSendGrid>();

            services.AddScoped<IAppRelatoriosService, AppRelatoriosService>();
        }
    }
}
