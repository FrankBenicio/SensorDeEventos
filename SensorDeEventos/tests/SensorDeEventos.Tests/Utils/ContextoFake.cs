
using Microsoft.EntityFrameworkCore;
using SensorDeEventos.Data.Contexto;
using System.Threading.Tasks;

namespace SensorDeEventos.Tests.Utils
{
    public class ContextoFake
    {
        public static async Task<SensorDeEventosContexto> Gerar(string nomeDoBancoDeDados)
        {
            var options = new DbContextOptionsBuilder<SensorDeEventosContexto>()
                .UseInMemoryDatabase(databaseName: nomeDoBancoDeDados)
                .Options;

            var contexto = new SensorDeEventosContexto(options);

            return await Task.FromResult(contexto);
        }
    }
}
