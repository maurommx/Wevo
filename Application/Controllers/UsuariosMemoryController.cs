using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wevo.Domain;
using Wevo.Repository;

namespace Wevo.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosMemoryController : ControllerBase
    {

        private readonly ILogger<UsuariosMemoryController> _logger;
        private readonly IUsuarioRepository _repository;

        public UsuariosMemoryController(ILogger<UsuariosMemoryController> logger, IUsuarioMemoryRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{Id}")]
        public  async Task<IActionResult> Get(int Id) {
            try
            {
                var result = await _repository.GetAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repository.Add(usuario);
                return Ok(usuario);
            } catch(Exception ex) {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int Id, Usuario usuario) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repository.GetAsync(Id);
            if (result == null)
                return NotFound();
                usuario.Id = Id;
            result = await _repository.Update(Id, usuario);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id) {
            var result = await _repository.GetAsync(Id);
            if (result == null)
                return NotFound();
            return Ok(await _repository.Delete(result));
        }

    }
}
