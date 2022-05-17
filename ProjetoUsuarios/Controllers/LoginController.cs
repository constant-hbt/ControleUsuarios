using Microsoft.AspNetCore.Mvc;
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

        public UsuarioModel UsuarioModel { get; private set; }

        public LoginController(IUsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        public IActionResult Index()
        {
            return View();
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
