
using SensorDeEventos.Domain.Enums;
using SensorDeEventos.Historias.EventoHistoria;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using SensorDeEventos.Tests.Utils;
using System.Threading.Tasks;
using Xunit;

namespace SensorDeEventos.Tests.Historias.Evento
{
    public class CadastrarEventoExecutar
    {
        [Fact]
        public async Task DeveCadastrarOEventoProcessado()
        {

            var contextoFake = await ContextoFake.Gerar(nomeDoBancoDeDados: "dbSudeste");

            var eventoDto = new PostEventoDto
            {
                Tag = "brasil.sudeste.sensor01",
                TimeStamp = 1539112021301,
                Valor = "10"
            };

            var eventoCadastrar = new CadastrarEvento(contextoFake);


            await eventoCadastrar.Executar(eventoDto);


            var evento = await contextoFake.Eventos.FindAsync(eventoDto.Id);

            Assert.Equal("brasil.sudeste.sensor01", evento.Tag);
            Assert.Equal(1539112021301, evento.TimeStamp);
            Assert.Equal("10", evento.Valor);
            Assert.Equal(Status.Processado, evento.Status);

        }

        [Fact]
        public async Task DeveCadastrarOEventoComError()
        {

            var contextoFake = await ContextoFake.Gerar(nomeDoBancoDeDados: "dbSudeste");

            var eventoDto = new PostEventoDto
            {
                Tag = "brasil.sudeste.sensor01",
                TimeStamp = 1539112021301,
                Valor = null
            };

            var eventoCadastrar = new CadastrarEvento(contextoFake);


            await eventoCadastrar.Executar(eventoDto);


            var evento = await contextoFake.Eventos.FindAsync(eventoDto.Id);

            Assert.Equal("brasil.sudeste.sensor01", evento.Tag);
            Assert.Equal(1539112021301, evento.TimeStamp);
            Assert.Null(evento.Valor);
            Assert.Equal(Status.Error, evento.Status);

        }
    }
}
