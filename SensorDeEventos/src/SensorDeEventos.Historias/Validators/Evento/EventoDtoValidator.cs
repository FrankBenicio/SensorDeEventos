using FluentValidation;
using SensorDeEventos.Historias.EventoHistoria.Dto;

namespace SensorDeEventos.Historias.Validators.Evento
{
    public class EventoDtoValidator : AbstractValidator<PostEventoDto>
    {
        public EventoDtoValidator()
        {
            RuleFor(x => x.Tag).NotEmpty().WithMessage("Por favor, informe uma Tag válida.");
            RuleFor(x => x.TimeStamp).GreaterThan(0).WithMessage("Por favor, informe um Time Stamp válido.");
        }
    }
}
