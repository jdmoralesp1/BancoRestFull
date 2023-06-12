using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Nombre)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                    .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Apellido)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                    .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.FechaNacimiento)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacia");

            RuleFor(p => p.Telefono)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                    .Matches(@"^\d{4}-\d{5}$").WithMessage("{PropertyName} debe cumplir el formato 0000-00000")
                    .MaximumLength(10).WithMessage("{PropertyName} no debe exceder de {MAxLength} caracteres");

            RuleFor(p => p.Email)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                    .EmailAddress().WithMessage("{PropertyName} debe ser una dirección email valida")
                    .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(p => p.Direccion)
                    .NotEmpty().WithMessage("{PropertyName} no puede ser vacia")
                    .MaximumLength(120).WithMessage("{PropertyName} no debe exceder de {MAxLength} caracteres");

        }
    }
}
