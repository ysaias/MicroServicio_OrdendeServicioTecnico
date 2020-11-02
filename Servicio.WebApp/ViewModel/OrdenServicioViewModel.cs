using Servicio.WebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Servicio.Domain.Model.Servicio;

namespace Servicio.WebApp.ViewModel
{
    public class OrdenServicioViewModel
    {

        public string Precio { get; set; }
        public ClienteViewModel ClienteView { get; set; }
        //public DetalleServicioViewModel DetalleServicioView { get; set; }
        public List<CitaViewModel> CitasView { get; set; }
        public List<TipoServicioViewModel> TipoServicioView { get; set; }

        public OrdenServicioViewModel()
        {
            TipoServicioView = new List<TipoServicioViewModel>();
            ClienteView = new ClienteViewModel();
           // DetalleServicioView = new DetalleServicioViewModel();
            CitasView = new List<CitaViewModel>();
        }
    }
}
