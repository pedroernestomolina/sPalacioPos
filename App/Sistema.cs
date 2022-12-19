using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App
{
    
    public class Sistema
    {
        public class Servidor 
        {
            public string Instancia { get; set; }
            public string Catalogo1 { get; set; }
            public string Catalogo2 { get; set; }
            public string Usuario { get; set; }
        }
        public class Configuracion 
        {
            public string DescEmpresa { get; set; }
            public string codEmpresa { get; set; }
            public string codPaquete { get; set; }
            public string codMoneda_PrecioArticulo { get; set; }
            public string codMoneda_Trabajo { get; set; }
            public string codAlmacen { get; set; }
            public string codPrecio { get; set; }
            public string codSucursal { get; set; }
            public string DescSucursal { get; set; }
            public DateTime FechaServidor { get; set; }
            public OOB.Venta.SerieProceso SerieProcesar { get; set; }
            public string NombreEquipo { get; set; }
        }

        public static Servidor MyServidor;
        public static DataProv.IDataProv MyData;
        public static OOB.Usuario Usuario;
        public static Configuracion MyConfiguracion;
        public static Imprimir.IDocumento ImprimirFactura;
    }

}