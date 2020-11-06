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
    public class TrabajoFormularioController : Controller
    {
        private readonly IFormularioRepository _formularioRepository;
        private readonly IOrdenServicioRepository _ordenServicioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TrabajoFormularioController(IFormularioRepository formularioRepository, IOrdenServicioRepository ordenServicioRepository, IUnitOfWork unitOfWork)
        {
            _formularioRepository = formularioRepository;
            _ordenServicioRepository = ordenServicioRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] TrabajoFormularioViewModel formulario)
        {
            try
            {

                Guid guidCita = new Guid(formulario.CitaId);
                Cita cita = await _ordenServicioRepository.GetCitaById(guidCita);
                FormularioTrabajo obj = new FormularioTrabajo(formulario.Informe, formulario.MedidaAtencion, cita);

                OrdenServicio orden = await _ordenServicioRepository.GetOrdenServicioBiIdCita(cita.Id);
                orden.FinalizarServicio();

                await _formularioRepository.Insert(obj);
                await _unitOfWork.Commit();

                return Ok();
            }
            catch (Exception )
            {

                throw;
            }

            //| return BadRequest();
        }





        [HttpGet]
        public IActionResult getAll()
        {

            List<FormularioTrabajo> listFormularios = _formularioRepository.GetAll();

            return Ok(new { formularios = listFormularios });
        }


        [HttpGet]
        [Route("formbyid")]
        public async Task<IActionResult> getFormulariocoById(string formularioId)
        {
            try
            {

                Guid guidFormulario = new Guid(formularioId);

                FormularioTrabajo formulario = await _formularioRepository.GetFormularioBiId(guidFormulario);

                await _unitOfWork.Commit();

                return Ok(formulario);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> formularioDelete(string formularioId)
        {
            try
            {

                Guid guidFormulario = new Guid(formularioId);

                await _formularioRepository.formularioDelelete(guidFormulario);

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
