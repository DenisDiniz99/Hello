﻿using FluentValidation;
using Prefeitura.SysCras.Business.Entities;

namespace Prefeitura.SysCras.Business.Validations
{
    public class AtendimentoValidator : AbstractValidator<Atendimento>
    {
        public AtendimentoValidator()
        {
            //Validação do campo TipoAtendimento
            RuleFor(atendimento => atendimento.TipoAtendimento)
                .NotEmpty()
                .WithMessage("O Tipo de Atendimento não pode ser vazio.");

            //Validação do campo Descrição
            RuleFor(atendimento => atendimento.Descricao)
                .NotNull()
                .WithMessage("A Descrição não pode ser nula.");

            RuleFor(atendimento => atendimento.Descricao)
                .NotEmpty()
                .WithMessage("A Descrição não pode ser vazia.");

            RuleFor(atendimento => atendimento.Descricao)
                .MaximumLength(500)
                .WithMessage("A Descrição deve ter até 500 caracteres.");

            RuleFor(atendimento => atendimento.Descricao)
                .MinimumLength(10)
                .WithMessage("A Descrição deve ter ao menos 10 caracteres.");

            //Validação do campo StatusAtendimento
            RuleFor(atendimento => atendimento.StatusAtendimento)
                .NotEmpty()
                .WithMessage("O Status do Atendimento não pode ser vazio.");

            //Validação do campo Observacao
            RuleFor(atendimento => atendimento.Observacao)
                .MaximumLength(500)
                .WithMessage("A Observação deve ter até 200 caracteres.");
        }
    }
}
