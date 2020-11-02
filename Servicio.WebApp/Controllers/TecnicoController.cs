using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Servicio.WebApp.ViewModel;
using Tienda.Servicio.Domain.Model.Servicio;
using Tienda.Servicio.Domain.Persistence;
using Tienda.Servicio.Domain.Persistence.Repository;

namespace Servicio.WebApp.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class TecnicoController : Controller
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TecnicoController(ITecnicoRepository tecnicoRepository, IUnitOfWork unitOfWork)
        {
            _tecnicoRepository = tecnicoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TecnicoViewModel tecnico)
        {
            try
            {
                Tecnico obj = new Tecnico(tecnico.Codigo, tecnico.NombreTecnico, tecnico.Telefono);

                await _tecnicoRepository.Insert(obj);
                await _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

            //| return BadRequest();
        }

        

        [HttpGet]
        
        public IActionResult getAll()
        {
          
            List<Tecnico> listTecnicos = _tecnicoRepository.GetAll();
            
            return Ok(new { tecnicos = listTecnicos});
        }
        


        [HttpGet]
        [Route("tecnicobyid")]
        public async Task<IActionResult> getTecnicoById(string tecnicoId )
        {
            try
            {

                Guid guidTecnico = new Guid(tecnicoId);

                Tecnico tecnico = await _tecnicoRepository.GetTecnicoBiId(guidTecnico);

                await _unitOfWork.Commit();

                return Ok(tecnico);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> tecnicoDelete(string tecnicoId)
        {
            try
            {

                Guid guidTecnico = new Guid(tecnicoId);

                await _tecnicoRepository.tecnicoDelete(guidTecnico);

                await _unitOfWork.Commit();

                return Ok();

            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
