﻿using Microsoft.AspNetCore.Mvc;
using ProjetoUsuarios.Helper;
using ProjetoUsuarios.Models;
using ProjetoUsuarios.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoUsuarios.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly ISessao _sessao;

        public UsuarioModel UsuarioModel { get; private set; }

        public LoginController(IUsuarioRepo usuarioRepo, ISessao sessao)
        {
            _usuarioRepo = usuarioRepo;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se usuário estiver logado, redirecionar para a Home
            if(_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepo.BuscarPorEmail(loginModel.Email);
                    if(usuario != null){
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário inválida. Tente novamente!";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválida(os). Por favor, tente novamente!";
                    return RedirectToAction("Index");
                }
                return View("Index");
            }catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login. Tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
