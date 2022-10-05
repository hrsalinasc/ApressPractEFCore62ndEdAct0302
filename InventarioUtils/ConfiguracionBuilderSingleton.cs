using Microsoft.Extensions.Configuration;

namespace InventarioUtils
{
    public sealed class ConfiguracionBuilderSingleton
    {
        private static readonly object _instanciaBloqueo = new object();

        private static ConfiguracionBuilderSingleton _instancia = null;
        public static ConfiguracionBuilderSingleton Instancia
        {
            get
            {
                lock (_instanciaBloqueo)
                {
                    if(_instancia == null)
                    {
                        _instancia = new ConfiguracionBuilderSingleton();
                    }
                    return _instancia;
                }
            }
        }

        private static IConfigurationRoot _configuracion;
        public static IConfigurationRoot ConfiguracionRoot
        {
            get
            {
                if (_configuracion == null)
                {
                    var x = Instancia;
                }
                return _configuracion;
            }
        }

        private ConfiguracionBuilderSingleton()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuracion = builder.Build();
        }
    }
}
