﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Entities;
using Prefeitura.SysCras.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prefeitura.SysCras.Web.Controllers
{
    [Authorize]
    public class CidadaoController : BaseController
    {
        private readonly ICidadaoRepositorio _repositorio;
        private readonly ICidadaoServico _servico;
        private readonly IMapper _mapper;
        

        public CidadaoController(ICidadaoRepositorio repositorio, ICidadaoServico servico,
                                    IMapper mapper, INotificador notificador) : base(notificador)
        {
            _repositorio = repositorio;
            _servico = servico;
            _mapper = mapper;
        }

        //Index - Cidadão
        //Retorna a View com os dados dos Cidadãos cadastrados
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CidadaoViewModel>>(await _repositorio.ObterTodos()));
        }


        //Retorna a View com os dados do Cidadão selecionado pelo Id
        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await ObterPorId(id);

            return model == null ? NotFound() : (IActionResult)View(model);
        }


        //Retorna a View de Cadastro de Cidadão
        public IActionResult Cadastrar()
        {
            return View();
        }


        //Cadastro de Cidadão
        [HttpPost]
        public async Task<IActionResult> Cadastrar(CidadaoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid) 
                return View(model);

            model.DataCad = DateTime.Now.Date;

            await _servico.Adicionar(_mapper.Map<Cidadao>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach(var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Index");
        }


        //Retorna a View de Atualização de Cidadão com os dados do cidadão selecionado pelo Id
        public async Task<IActionResult> Atualizar(Guid id)
        {
            var model = await ObterPorId(id);

            return model == null ? NotFound() : (IActionResult)View(model);
        }


        //Atualização de Cidadão
        [HttpPost]
        public async Task<IActionResult> Atualizar(Guid id, CidadaoViewModel model)
        {
            if (id != model.Id) 
                return BadRequest();

            if (!ModelState.IsValid) 
                return View(model);

            await _servico.Atualizar(_mapper.Map<Cidadao>(model));

            if (!OperacaoValida())
            {
                var notificacoes = _notificador.ObterNotificacoes();
                foreach(var item in notificacoes)
                {
                    AdicionarErros(item.Mensagem);
                }
                return View(model);
            }

            return RedirectToAction("Index");
        }


        //Retorna a View de confirmação de exclusão do Cidadão selecionado pelo Id
        public async Task<IActionResult> Excluir(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) 
                return NotFound();

            return View(model);
        }


        //Exclui o Cidadão selecionado
        [HttpPost, ActionName("excluir")]
        public async Task<IActionResult> ConfirmarExclusao(Guid id)
        {
            var model = await ObterPorId(id);

            if (model == null) 
                return NotFound();

            try
            {
                await _servico.Excluir(_mapper.Map<Cidadao>(model));
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }

            if (!OperacaoValida()) 
                return BadRequest();

            return RedirectToAction("Index");
        }

        #region Métodos Privados

        //Método privado para pesquisar dados pelo Id
        private async Task<CidadaoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<CidadaoViewModel>(await _repositorio.ObterPorId(id));
        }

        #endregion
    }
}