using AutoMapper;
using HBSIS.Domain.Entities;
using HBSIS.Presentation.ViewModels;
using HBSIS.Presentation.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Configuration;

namespace HSISBIS.Presentation.Controllers
{
    public class LivrariaController : Controller
    {
     
        private readonly string ApiBaseUrl = ConfigurationManager.AppSettings["urlBaseApi"];
        // GET: Livraria
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IncluirLivro(LivroViewModel livroViewModel)
        {


            var model = Mapper.Map<LivroViewModel, Livro>(livroViewModel);


            bool ret = this.CriarLivro(model);

            if (!ret)
            {
                TempData["warning"] = "Problemas de gravação de livro!";

            }
            else
            {
                TempData["success"] = "Livro incluido com sucesso.";
            }

            return RedirectToAction("ListaLivros", "Livraria");

        }


        [HttpPost]
        public ActionResult AtualizarLivro(LivroViewModel livroViewModel)
        {


            var model = Mapper.Map<LivroViewModel, Livro>(livroViewModel);


            bool ret = this.AtualizarLivro(model);

            if (!ret)
            {
                TempData["warning"] = "Problemas de gravação de livro!";

            }
            else
            {
                TempData["success"] = "Livro atualizado com sucesso.";
            }

            return RedirectToAction("ListaLivros", "Livraria");

        }


        [HttpPost]
        public ActionResult ExcluirLivro(LivroViewModel livroViewModel)
        {



            bool ret = this.DeleteLivro(livroViewModel.Id);

            if (!ret)
            {
                TempData["warning"] = "Problemas de exclusão de livro!";

            }
            else
            {
                TempData["success"] = "Livro excluído com sucesso.";
            }

            return RedirectToAction("ListaLivros", "Livraria");

        }





        [HttpGet]
        public ActionResult ListaLivros()
        {

            var modelVM = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroViewModel>>(Listar());

            return View(modelVM);


        }

        public PartialViewResult ExibirJanelaExcluiLivro(int id)
        {
            var modelVM = Mapper.Map<Livro, LivroViewModel>(BuscarPorId(id));

            return PartialView("_ExcluiLivro", modelVM);

        }


        public PartialViewResult ExibirJanelaEditaLivro(int id)
        {

            var modelVM = Mapper.Map<Livro, LivroViewModel>(BuscarPorId(id));

            return PartialView("_EditaLivro", modelVM);


        }


        public PartialViewResult ExibirJanelaIncluiLivro()
        {

            var modelVM = new LivroViewModel();

          
            return PartialView("_NovoLivro", modelVM);


        }


      


        private bool DeleteLivro(int id)
        {
            
            string MetodoPath = string.Format("Livro/Delete/{0}", id); //caminho do método a ser chamado
            bool ret = true;
            Uri u = new Uri(ApiBaseUrl + MetodoPath);
         
            try
            {
                
                var t = Task.Run(() => Helpers.HttpHelper.DeleteURI(u));
                t.Wait();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
                throw;
            }

            return ret;

        }

        private bool CriarLivro(Livro livro)
        {
           
            string MetodoPath = "Livro/Post"; //caminho do método a ser chamado
            bool ret = true;
            Uri u = new Uri(ApiBaseUrl + MetodoPath);
            var payload = JsonConvert.SerializeObject(livro);

            try
            {
                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => Helpers.HttpHelper.PostURI(u, c));
                t.Wait();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
                throw;
            }

            return ret;

        }

        private bool AtualizarLivro(Livro livro)
        {
            
            string MetodoPath = "Livro/Atualiza"; //caminho do método a ser chamado
            bool ret = true;
            Uri u = new Uri(ApiBaseUrl + MetodoPath);
            var payload = JsonConvert.SerializeObject(livro);

            try
            {
                HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => Helpers.HttpHelper.PutURI(u, c));
                t.Wait();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
                throw;
            }

            return ret;


        }


        private Livro BuscarPorId(int id)
        {


           
            string MetodoPath = string.Format("Livro/BuscaPorId/{0}", id); //caminho do método a ser chamado

            var model = new Livro();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<LivroUnitarioDataContract>(streamReader.ReadToEnd());

                    if (retorno != null)
                    {
                        model.Id = retorno.Object.Id;
                        model.ISBN = retorno.Object.ISBN;
                        model.Titulo = retorno.Object.Titulo;
                        model.Descricao = retorno.Object.Descricao;
                        model.Autor = retorno.Object.Autor;


                    }
                        
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw e;
            }


            return model;

        }



        private IEnumerable<Livro> Listar()
        {
            

            
            string MetodoPath = "Livro/Lista"; //caminho do método a ser chamado

            var modelVM = new LivroViewModel();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var retorno = JsonConvert.DeserializeObject<LivroDataContract>(streamReader.ReadToEnd());

                    if (retorno != null)
                        modelVM.ColecaoLivros = retorno.Object;
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw e;
            }


            return modelVM.ColecaoLivros;

        }


    }
}