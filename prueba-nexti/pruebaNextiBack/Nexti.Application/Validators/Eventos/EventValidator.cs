using FluentValidation;
using Nexti.Application.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexti.Application.Validators.Eventos
{
    public class EventValidator: AbstractValidator<EventoRequestDto>
    {
        public EventValidator()
        {
            RuleFor(x => x.Descripcion)
                .NotNull().WithMessage("Descripcion no puede ser nula")
                .NotEmpty().WithMessage("El campo descripcion no puede ser vacio");
        }
    }
}
