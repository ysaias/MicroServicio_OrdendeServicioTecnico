using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    public class OrdenServicioController : Controller
    {
        private const string V = "ordenServicio";
        private const string V1 = "InsertCitaTecnico";
        private const string V2 = "DetalleCita";
        private readonly IOrdenServicioRepository _ordenServicioRepository;
        private readonly ITecnicoRepository _tecnicoRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OrdenServicioController(IOrdenServicioRepository ordenServicioRepository, ITecnicoRepository tecnicoRepository, IUnitOfWork unitOfWork)
        {
            _ordenServicioRepository = ordenServicioRepository;
            _tecnicoRepository = tecnicoRepository;
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        [Route(V)]
        public async Task<IActionResult> InsertOrder([FromBody] OrdenServicioViewModel ordenServicio)
        {
            try
            {
                List<Cita> citas = new List<Cita>();
                foreach (var cita in ordenServicio.CitasView)
                {
                    citas.Add(new Cita(cita.Codigo, cita.Direccion));
                }



                //DetalleServicio detalleServicio = new DetalleServicio(ordenServicio.DetalleServicioView.Detalle);

                Cliente cliente = new Cliente(ordenServicio.ClienteView.Id
                    , ordenServicio.ClienteView.NombreCliente, ordenServicio.ClienteView.Telefono);

                OrdenServicio obj = new OrdenServicio(ordenServicio.Precio, cliente, citas);

                await _ordenServicioRepository.Insert(obj);
                await _unitOfWork.Commit();


                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

            //return BadRequest();
        }

        [HttpGet]
        [Route("servicio")]
        public async Task<IActionResult> getOrdenServicio(string ordenid)
        {
            try
            {

                Guid guidOrden = new Guid(ordenid);

                OrdenServicio obj =  await _ordenServicioRepository.GetOrdenServicioBiId(guidOrden);

                List<Cita> listCitas = _ordenServicioRepository.GetListaCitasByOrdenId(guidOrden);

                //Cliente cliente = await _ordenServicioRepository.GetClienteById(obj.);

                List<Cita> objCitas = new List<Cita>();

                Cita cita ;

                foreach(var c in listCitas)
                {

                   cita = new Cita(c.Id, c.Codigo, c.Direccion);
                   objCitas.Add(cita) ;

                }

                await _unitOfWork.Commit();

                return Ok(new {obj.Id, obj.FechaRegistro, obj.Estado, obj.Precio, citas = objCitas });

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        [Route(V1)]
        public async Task<IActionResult> InsertCitaTecnico([FromBody] CitaTecnicoViewModel citaTecnico)
        {
            try
            {
                Guid guid = new Guid(citaTecnico.TecnicoId);
                Guid guidCita = new Guid(citaTecnico.CitaId);

                Tecnico tecnico = await _tecnicoRepository.GetTecnicoBiId(guid);
                Cita cita = await _ordenServicioRepository.GetCitaById(guidCita);

                DateTime fechaHora = new DateTime(int.Parse(citaTecnico.Year),
                int.Parse(citaTecnico.Mes), int.Parse(citaTecnico.Dia), int.Parse(citaTecnico.Hora),
                int.Parse(citaTecnico.Minuto), int.Parse(citaTecnico.Segundo));

                CitaTecnico obj = new CitaTecnico(citaTecnico.Codigo, fechaHora, tecnico, cita);

                await _ordenServicioRepository.InsertCitaTecnico(obj);
                await _unitOfWork.Commit();


                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

            //| return BadRequest();
        }


        [HttpPost]
        [Route(V2)]
        public async Task<IActionResult> InsertDetalleCita([FromBody] DetalleCitaViewModel detalleCita)
        {
            try {

                Guid guidCita = new Guid(detalleCita.CitaId);
                Cita cita = await _ordenServicioRepository.GetCitaById(guidCita);

                DetalleCita obj = new DetalleCita(detalleCita.Detalle, cita);

                await _ordenServicioRepository.InsertDetalleCita(obj);
                await _unitOfWork.Commit();

                return Ok();

            } catch (Exception)
            {
                throw;
            }

        } 
    


        [HttpPost]
        [Route("detalleservicio")]
        public async Task<IActionResult> InsertDetalleServicio([FromBody] DetalleServicioViewModel detalleServicio)
        {
            try
            {

                Guid guidOrden = new Guid(detalleServicio.OrdenId);
                OrdenServicio orden = await _ordenServicioRepository.GetOrdenServicioBiId(guidOrden);
                DetalleServicio obj = new DetalleServicio(detalleServicio.Detalle, orden);

                await _ordenServicioRepository.InsertDetalleServicio(obj);
                await _unitOfWork.Commit();

                return Ok();

            }
            catch (Exception)
            {
                throw;
            }

        }



        [HttpGet]
        [Route("hola")]
        public string hola()
        {
            return "Hola";
        }
    }

   
}
