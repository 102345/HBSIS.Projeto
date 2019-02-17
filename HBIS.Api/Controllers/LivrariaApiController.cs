using HBSIS.Service.Interface;
using HBSIS.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBIS.Api.Controllers
{
    public class LivrariaApiController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrariaApiController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        [HttpGet]
        [Route("api/v1/Livro/BuscaPorId/{id}")]
        public HttpResponseMessage BuscaPorId(int id)
        {
            try
            {
                var livro = _livroService.BuscarLivro(id);

                if (livro.Id == 0)
                {

                    JsonResult.Status = false;
                    JsonResult.Message = "404 Not Found";
                    return Request.CreateResponse(HttpStatusCode.NotFound, JsonResult);

                }

                JsonResult.Status = true;
                JsonResult.Object = livro;
                JsonResult.Message = "Encontrado com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }


        }




        [HttpGet]
        [Route("api/v1/Livro/Lista")]
        public HttpResponseMessage Lista()
        {

            try
            {
                var livros =  _livroService.ListarLivros();

                JsonResult.Status = true;
                JsonResult.Object = livros;
                JsonResult.Message = "Listado com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }



        }



        [HttpDelete]
        [Route("api/v1/Livro/Delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var livro = _livroService.BuscarLivro(id);

                if (livro.Id == 0)
                {

                    JsonResult.Status = false;
                    JsonResult.Message = "404 Not Found";
                    return Request.CreateResponse(HttpStatusCode.NotFound, JsonResult);

                }


                _livroService.ExcluirLivro(id);

                JsonResult.Status = true;
                JsonResult.Object = null;
                JsonResult.Message = "Excluido com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }

        }


        [HttpPut]
        [Route("api/v1/Livro/Atualiza")]
        public HttpResponseMessage Atualiza([FromBody]Livro livro)
        {
            try
            {

                var livroRet = _livroService.BuscarLivro(livro.Id);

                if (livroRet.Id == 0)
                {

                    JsonResult.Status = false;
                    JsonResult.Message = "404 Not Found";
                    return Request.CreateResponse(HttpStatusCode.NotFound, JsonResult);

                }


                _livroService.AtualizarLivro(livro);

                JsonResult.Status = true;
                JsonResult.Object = null;
                JsonResult.Message = "Atualizado com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }

        }



        [HttpPost]
        [Route("api/v1/Livro/Post")]
        public HttpResponseMessage Post([FromBody]Livro livro)
        {
            try
            {
                _livroService.InserirLivro(livro);

                JsonResult.Status = true;
                JsonResult.Object = null;
                JsonResult.Message = "Gravado com sucesso";
                return Request.CreateResponse(HttpStatusCode.OK, JsonResult);
            }
            catch (Exception ex)
            {

                JsonResult.Status = false;
                JsonResult.Message = ex.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, JsonResult);
            }

        }
    }
}
