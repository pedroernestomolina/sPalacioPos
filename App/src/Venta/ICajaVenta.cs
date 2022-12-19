using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.src.Venta
{
    
    public interface ICajaVenta: hlp.IGestion, hlp.IAbandonar
    {
        string GetTarjeta_ID { get; }
        string GetTarjeta_ID_TIPO { get; }
        bool BuscarTarjetaIsOk { get; }
        void setTarjeta(string idTarjeta);
        void BuscarTarjeta(bool isTarjetaIdCiRif = false);
        BindingSource GetData_Source { get; }

        //
        decimal GetSubTotalMonto { get; }
        decimal GetIvaMonto { get; }
        decimal GetTotalMonto { get; }
        decimal GetTotalDivisaMonto { get; }
        decimal GetTasaCambioActual { get; }

        //
        bool PedirTarjetaNuevaIsOk { get; }
        void PedirTarjetaNueva();
        void ConsultarPrecioArticulo();

        bool FacturarIsOk { get; }
        void Facturar();
        void TarjetaNueva();

        bool AgregarArticuloIsOk { get; }
        void AgregarArticulo();

        bool EliminarArticuloIsOk { get; }
        void EliminarArticulo();

        bool BuscarClienteIsOk { get; }
        void BuscarCliente();

        bool EditarItemIsOk { get; }
        void EditarItem();

        DateTime GetDoc_FechaEmision { get; }
        string GetDoc_RifCliente { get; }
        string GetDoc_NombreCliente { get; }
        string GetDoc_Vendedor { get; }
        string GetDoc_CondPago { get; }
        string GetDoc_Transporte { get; }
        string GetVersion { get; }
    }

}