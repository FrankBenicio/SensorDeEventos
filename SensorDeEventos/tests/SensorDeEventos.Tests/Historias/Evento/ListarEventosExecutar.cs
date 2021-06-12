using SensorDeEventos.Domain.Enums;
using SensorDeEventos.Historias.EventoHistoria;
using SensorDeEventos.Historias.EventoHistoria.Dto;
using SensorDeEventos.Historias.Extensoes;
using SensorDeEventos.Tests.Utils;
using System;
using System.Threading.Tasks;
using Xunit;
namespace SensorDeEventos.Tests.Historias.Evento
{
    public class ListarEventosExecutar
    {
        [Fact]
        public async Task DeveRetornarListaDeEventos()
        {

            var contextoFake = await ContextoFake.Gerar(nomeDoBancoDeDados: "dbSul");

            var eventoDto = new PostEventoDto
            {
                Tag = "brasil.sudeste.sensor01",
                TimeStamp = 1539112021301,
                Valor = "10"
            };

            var eventoCadastrar = new CadastrarEvento(contextoFake);
            var listarEventos = new ListarEventos(contextoFake);
            await eventoCadastrar.Executar(eventoDto);


            var eventos = await listarEventos.Executar();



            Assert.NotEmpty(eventos);
            Assert.Equal("brasil.sudeste.sensor01", eventos[0].Tag);
            Assert.Equal("10", eventos[0].Valor);
            Assert.Equal(Status.Processado.ToString(), eventos[0].Status);

            var dateTime = eventoDto.TimeStamp.ToDateTime();
            Assert.Equal(dateTime, eventos[0].DataEHora);

        }

        [Fact]
        public async Task DeveRetornarListaDeEventosVazia()
        {

            var contextoFake = await ContextoFake.Gerar(nomeDoBancoDeDados: "dbNorte");

            var listarEventos = new ListarEventos(contextoFake);

            var eventos = await listarEventos.Executar();

            Assert.Empty(eventos);

        }
    }
}
