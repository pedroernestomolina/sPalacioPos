using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Imprimir.Tickera80
{


    public class Documento : IDocumento
    {

        private data _ds;
        private Ticket _tick;
        private string _data;
        private Bitmap _imagenQR;


        public Documento()
        {
            _tick = new Ticket();
        }


        public void ImprimirDoc()
        {
            Imprimir();
        }

        public void ImprimirCopiaDoc()
        {
            Imprimir();
        }

        private void Imprimir()
        {
            //PARA EL TICKET
            _tick.Cliente.Limpiar();
            _tick.Cliente.cirif = _ds.encabezado.CiRifCli;
            _tick.Cliente.nombre_1 = _ds.encabezado.NombreCli;
            _tick.Cliente.dirFiscal_1 = _ds.encabezado.DireccionCli;
            _tick.Cliente.telefono_1 = _ds.encabezado.TelefonoCli;
            _tick.Cliente.condicionpago = _ds.encabezado.DocumentoCondicionPago;
            _tick.Cliente.estacion = _ds.encabezado.EstacionEquipo;
            _tick.Cliente.usuario = _ds.encabezado.Usuario;

            var iva= Math.Round(_ds.encabezado.MontoIva, 2, MidpointRounding.AwayFromZero);
            var tot = Math.Round(_ds.encabezado.Total, 2, MidpointRounding.AwayFromZero);
            var stot = Math.Round(_ds.encabezado.SubTotalItemFull, 2, MidpointRounding.AwayFromZero);
            var sbtot = Math.Round(_ds.encabezado.SubTotalItemFull, 2, MidpointRounding.AwayFromZero);
            var totDivisa = Math.Round(_ds.encabezado.TotalDivisa, 2, MidpointRounding.AwayFromZero);

            _tick.Documento.Limpiar();
            _tick.Documento.nombre = _ds.encabezado.DocumentoNombre;
            _tick.Documento.aplicaA = _ds.encabezado.DocumentoAplica;
            _tick.Documento.numero = _ds.encabezado.DocumentoNro;
            _tick.Documento.fecha = _ds.encabezado.DocumentoFecha.ToShortDateString();
            _tick.Documento.hora = _ds.encabezado.DocumentoHora;
            _tick.Documento.subtotalNeto = "Bs " + sbtot.ToString("n2");
            _tick.Documento.subtotal = "Bs " + stot.ToString("n2");
            _tick.Documento.iva = "Bs " + iva.ToString("n2");
            _tick.Documento.total = "Bs " + tot.ToString("n2");
            _tick.Documento.cambio = "Bs " + _ds.encabezado.CambioDar.ToString("n2");
            _tick.Documento.descuentoMonto = "Bs " + _ds.encabezado.Descuento.ToString("n2");
            _tick.Documento.descuentoPorct = _ds.encabezado.DescuentoPorc.ToString("n2").Trim() + "%";
            _tick.Documento.cargoMonto = "Bs " + _ds.encabezado.Cargo.ToString("n2");
            _tick.Documento.cargoPorct = _ds.encabezado.CargoPorc.ToString("n2").Trim() + "%";
            _tick.Documento.HayDescuento = _ds.encabezado.DescuentoPorc > 0.0m;
            _tick.Documento.HayCargo = _ds.encabezado.CargoPorc > 0.0m;
            _tick.Documento.factorCambio = _ds.encabezado.FactorCambio;
            _tick.Documento.totalDivisa = "($) " + totDivisa.ToString("n2");
            _tick.Documento.ImageQR = _imagenQR;
            _tick.Documento.vueltoEfectivo = _ds.encabezado.VueltoEfectivo <= 0m ? "" : "Bs " + _ds.encabezado.VueltoEfectivo.ToString("n2");
            _tick.Documento.vueltoDivisa = _ds.encabezado.CntDivisaVueltoDivisa <= 0 ? "" : "$" + _ds.encabezado.CntDivisaVueltoDivisa.ToString("n0") + " Bs " + _ds.encabezado.VueltoDivisa.ToString("n2");
            _tick.Documento.vueltoPagoMovil = _ds.encabezado.VueltoPagoMovil <= 0m ? "" : "Bs " + _ds.encabezado.VueltoPagoMovil.ToString("n2");

            foreach (var r in _ds.item)
            {
                var _importe = r.Cantidad * r.PrecioFull;
                var it = new Ticket.DatosDocumento.Item()
                {
                    cantidad = r.Cantidad,
                    precio = Math.Round(r.PrecioFull, 2, MidpointRounding.AwayFromZero),
                    isExento = r.EsExento,
                    isPesado = false,
                    descripcion = r.NombrePrd,
                    importe = Math.Round(_importe, 2, MidpointRounding.AwayFromZero),
                    empDesc=r.Empaque,
                    empCont=r.Contenido,
                    factorCambio= _ds.encabezado.FactorCambio,
                };
                _tick.Documento.Items.Add(it);
            }

            foreach (var r in _ds.metodoPago)
            {
                var it = new Ticket.DatosDocumento.MedioPago()
                {
                    descripcion = r.descripcion,
                    monto = "Bs " + r.monto.ToString("n2"),
                };
                _tick.Documento.MediosPago.Add(it);
            }

            foreach (var r in _ds.medidaEmp)
            {
                var _desc = r.desc.Trim().PadRight(20,' ')+", ";
                var _cnt = r.cant.ToString("n0").Trim().PadLeft(10, ' ')+", ";
                var _peso = r.peso.ToString("n3").Trim().PadLeft(10, ' ')+", ";
                var _volumen = r.volumen.ToString("n3").Trim().PadLeft(10, ' ');
                var it = new Ticket.DatosDocumento.MedidaEmp()
                {
                    nombre= _desc+_cnt+_peso+_volumen,
                };
                _tick.Documento.MedidasEmp.Add(it);
            }

            _tick.Imrpimir();
        }

        public void setData(data ds)
        {
            _ds = ds;
        }

        public void setControlador(System.Drawing.Printing.PrintPageEventArgs e)
        {
            _tick.setControlador(e);
        }

        public void setDatosEmpresa(string rifEmp, string nombreEmp, string dirEmp, string telEmp)
        {
            _tick.Negocio.setDatosEmpresa(rifEmp, nombreEmp, dirEmp, telEmp);
        }

        //
        public bool IsModoTicket { get { return true; } }
    }

}