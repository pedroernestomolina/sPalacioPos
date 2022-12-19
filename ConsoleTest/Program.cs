using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Contrato.IProvider IContrato = new ImpContrato.Provider(@"localhost\mssql14", "masterprofitpro", "pan_a", "profit", true);
            //Contrato.IProvider IContrato = new ImpContrato.Provider(@"192.168.1.4\mssql14", "masterprofitpro", "pan_a", "profit", true);
            Contrato.IProvider IContrato = new ImpContrato.Provider(@"192.168.11.238\sqlexpress", "masterprofitpro", "pan_a", "profit", false);
            var r01 = IContrato.Test_1();
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                Console.WriteLine("TEST 1");
                Console.WriteLine(r01.Mensaje);
            }
            else
            {
                Console.WriteLine("TEST 1, OK");
            }
            var r02 = IContrato.Test_2();
            if (r02.Result == DTO.Enumerados.EnumResult.isError)
            {
                Console.WriteLine("TEST 2");
                Console.WriteLine(r02.Mensaje);
            }
            else
            {
                Console.WriteLine("TEST 2, OK");
            }
            Console.ReadKey();
            //var r03 = IContrato.cjPago_Lista();
            //var r04 = IContrato.cjPago_GetCajaPagoById("EF");


            //var r03 = IContrato.art_pSeleccionarUnidadArticulo("c06");
            //var r04 = IContrato.vta_pValidarClienteProcesoVenta("49");
            ////
            //var r05 = IContrato.art_GetArticuloById("R06");
            //var r06 = IContrato.art_pObtenerUltimoCosto(r05.Entidad.rowguid, "01", DateTime.Now.Date);
            //
            //var r07 = IContrato.art_pStockActualizar("01", "P16", "UND", 1m, "COM", false, true);
            //var r08 = IContrato.art_pStockActualizar("01", "P16", "UND", 1m, "DES", true, true);
            //var r09 = IContrato.art_pStockActualizar("01", "P16", "UND", 1m, "ACT", false, true);
            //


            //var r0A = IContrato.vta_ObtenerPedidoRenglones("0000145889");
            //var _stockAct = new List<DTO.Venta.Insertar.stockActualizar>();
            //foreach (var rg in r0A.Lista)
            //{
            //    var ncom = new DTO.Venta.Insertar.stockActualizar()
            //    {
            //        cnt = rg.total_art,
            //        codAlm = rg.co_alma,
            //        codArt = rg.co_art,
            //        codUnd = rg.co_uni,
            //        permiteStockNegativo = true,
            //        sumarStock = false,
            //        tipoStock = "COM",
            //    };
            //    var ndes = new DTO.Venta.Insertar.stockActualizar()
            //    {
            //        cnt = rg.total_art,
            //        codAlm = rg.co_alma,
            //        codArt = rg.co_art,
            //        codUnd = rg.co_uni,
            //        permiteStockNegativo = true,
            //        sumarStock = true,
            //        tipoStock = "DES",
            //    };
            //    var nact = new DTO.Venta.Insertar.stockActualizar()
            //    {
            //        cnt = rg.total_art,
            //        codAlm = rg.co_alma,
            //        codArt = rg.co_art,
            //        codUnd = rg.co_uni,
            //        permiteStockNegativo = true,
            //        sumarStock = false,
            //        tipoStock = "ACT",
            //    };
            //    if (rg.pendiente > 0) 
            //    {
            //        _stockAct.Add(ncom);
            //    }
            //    _stockAct.Add(ndes);
            //    _stockAct.Add(nact);
            //}
            //var _stockPend = new List<DTO.Venta.Insertar.stockPendActualizar>();
            //foreach (var rg in r0A.Lista.Where(w => w.pendiente > 0).ToList())
            //{
            //    var nr = new DTO.Venta.Insertar.stockPendActualizar()
            //    {
            //        cnt = rg.pendiente,
            //        rowguid = rg.rowguid,
            //        tipoDoc = "PCLI",
            //    };
            //    _stockPend.Add(nr);
            //}
            //var items = new List<DTO.Venta.Insertar.cuerpoAgregar>();
            //var it1 = new DTO.Venta.Insertar.cuerpoAgregar()
            //{
            //    coAlma = "01",
            //    coArt = "PC02",
            //    coPrecio = "01",
            //    coSucIn = "02",
            //    coUni = "UND",
            //    coUsIn = "CE02",
            //    montoImp = 0m,
            //    pendiente = 1m,
            //    porcImp = 0m,
            //    precVta = 13m,
            //    rengNeto = 13m,
            //    tipoDoc = "PCLI",
            //    tipoImp = "7",
            //    totalArt = 1m,
            //};
            //items.Add(it1);
            //var ficha = new DTO.Venta.Insertar.FichaAgregar()
            //{
            //    coSerieDocumento = "DOC_VEN_FACT_3",
            //    coSerieControl = "FACT_VTA_N_CON",
            //    NombreEquipo = "DESARROLLOMOVIL",
            //    encabezado = new DTO.Venta.Insertar.encabezadoAgregar()
            //    {
            //        coCli = "49",
            //        coTran = "000001",
            //        coCond = "000001",
            //        coVen = "CE02",
            //        coMone = "US$",
            //        contrib = true,
            //        coSuc = "02",
            //        coUsu = "CE02",
            //        totalBruto = 49.44m,
            //        tasaCambio = 9.98m,
            //        totalNeto = 51.68m,
            //        montoImp = 2.24m,
            //        saldo = 51.68m,
            //    },
            //    cuerpo = items,
            //    stockAct = _stockAct,
            //    stockPendAct = _stockPend,
            //};
            //var r0c = IContrato.vta_Insertar(ficha);
            //Console.ReadKey();


            //var codUsu = "CE02";
            //var psw = "ce0202";
            //var codProducto = "ADMI";
            //var codEmp = "";
            //var codSuc = "";
            //var seg = 0;

            //var s01 = IContrato.vta_ObtenerSerieProceso("DOC_VEN_FACT","02","PAN_A"); 


            //var s01 = IContrato.Get_FechaServidor();
            //var v00 = IContrato.cli_ObtenerFicha("05");
            //var codCli = v00.Entidad.co_cli;
            //var v01 = IContrato.vta_ObtenerUltimoDocPedidoByCodCli(codCli);
            //var codPed = v01.Entidad.Trim();
            //var v02 = IContrato.vta_ObtenerPedido(codPed);
            //var v03 = IContrato.vta_ObtenerPedidoRenglones(codPed);
            //var v04 = IContrato.tasa_ObtenerTipoTasaFiscal();
            //var v05 = IContrato.tasa_ObtenerTasaPorTipoValor(s01.Entidad);


            ////VERIFICA EXISTENCIA Y ESTADO DEL USUARIO 
            //var r00 = IContrato.AutenticarUsuario("PROFIT", "profit");
            //var r01 = IContrato.Get_EstatusFechaServidor(codProducto);
            //var r02 = IContrato.Get_EstatusUsuario(codUsu);
            //if (r02.Entidad != null)
            //{
            //    if (r02.Entidad.Estado != "I")
            //    {
            //        var r03 = IContrato.AutenticarUsuario(codUsu, psw);
            //        if (r03.Entidad != 0)
            //        {
            //            var r04 = IContrato.SeleccionarUsuario(codUsu);
            //            var r05 = IContrato.ActualizarNumeroIntentos(codUsu, true);
            //            var r06 = IContrato.ActualizarFechaUltimoLogueo(codUsu);
            //            var r07 = IContrato.InsertarPista(codUsu, "Login", "I", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Ingreso al Sistema</Info></Data>");
            //            var r08 = IContrato.Get_MpConfiguracion();
            //            var r09 = IContrato.ConsultarUsuarioAccesos(codUsu, codProducto);
            //            var r0A = IContrato.SeleccionarUsuario(codUsu);

            //            if (r0A.Entidad.Sel_Emp_Admi) //PUEDO SELECCIONAR LA EMPRESA
            //            {
            //                //SELECCIONAR QUE EMPRESA
            //                var s01 = IContrato.SeleccionarMpEmpresa(codEmp); 
            //                var l01 = IContrato.InsertarPista("GP", "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Selecciona empresa PAN_A</Info></Data>");
            //            }
            //            else 
            //            {
            //                codEmp = r0A.Entidad.Cod_Empresa_Admi; // YA VIENE PREDETERMINADA
            //                var s01 = IContrato.SeleccionarMpEmpresa(codEmp); 
            //            }

            //            if (r0A.Entidad.Pide_Sucu) // PUEDO SELECCIONAR QUE SUCURSAL 
            //            {
            //                if (r0A.Entidad.Camb_Sucu)  // MOSTRAR y SELECCIONAR LA SUCURSAL A TRABAJAR
            //                {
            //                    codSuc = r0A.Entidad.Sucursal;
            //                    var s02 = IContrato.Get_Sucursales();//OBTENER LISTA DE SUCURSALES
            //                    var l02 = IContrato.InsertarPista(codUsu, "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Selecciona sucursal 02</Info></Data>");
            //                    var l03 = IContrato.InsertarPista(codUsu, "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Ingresa en empresa PAN_A</Info></Data>");

            //                    r09 = IContrato.ConsultarUsuarioAccesos(codUsu, codProducto);
            //                    var r0B = IContrato.ObtenerMapaUsuario(codUsu, psw, codEmp, codProducto); //OBTENER CODIGO MAPA 
            //                    var codMapa= r0B.Entidad;
            //                    var r0C = IContrato.SeleccionarMapa(codMapa,codProducto); //OBTENER CODIGO MAPA 
            //                    seg = 1;
            //                }
            //            }
            //            else
            //            {
            //                codSuc = r0A.Entidad.Sucursal;
            //            }
            //        }
            //        else
            //        {
            //            var r = IContrato.InsertarPista(codUsu, "Login", "I", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Código de usuario o clave incorrecta</Info></Data>");
            //        }
            //    }
            //    else
            //    {
            //        var r = IContrato.InsertarPista(codUsu, "Login", "I", Environment.MachineName.ToString(), "ADM81", "<Data><Id>638034988732337502</Id><Info>Usuario Inactivo</Info></Data>");
            //    }
            //}
            //else
            //{
            //    var r = IContrato.InsertarPista(codUsu, "Login", "I", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Código de usuario o clave incorrecta</Info></Data>");
            //}



            ////FACTURACION
            //if (seg == 1)
            //{
            //    var flog1 = IContrato.InsertarPista(codUsu, "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Selecciona forma FacturaVentaForm</Info></Data>");
            //    var f01 = IContrato.SeleccionarParametrosEmpresa(codEmp);
            //    var f04 = IContrato.SeleccionarUsuario(codUsu);
            //    var f05 = IContrato.ObtenerMapaUsuario(codUsu, psw, codEmp, codProducto);
            //    var codMapa = f05.Entidad;
            //    var f06 = IContrato.SeleccionarMapa(codMapa, codProducto); //OBTENER CODIGO MAPA 
            //}


            ////BUSCAR / CONSULTAR PRODUCTO / PRECIO
            //var a01 = IContrato.Get_BusquedaArticuloUnidad("r0");
            //var a02 = IContrato.Get_ArticuloById("r04");
            //var a03 = IContrato.Get_ObtenerPrecioxArtAlma("P05", DateTime.Now, "01", "01", "BSS", true, "UND");
            //var a04 = IContrato.Get_ObtenerFechaTasa ("US$", DateTime.Now);


            ////INICIO
            //var r01 = IContrato.Get_FechaServidor();
            //var r02 = IContrato.Get_EstatusUsuario("GP");
            //var r03 = IContrato.AutenticarUsuario("GP","ga195301");
            //var r04 = IContrato.SeleccionarUsuario("GP");
            //var r05 = IContrato.ActualizarNumeroIntentos("GP", true);
            //var r06 = IContrato.ActualizarFechaUltimoLogueo("GP");
            //var r07 = IContrato.InsertarPista("GP", "Login", "I", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Ingreso al Sistema</Info></Data>");
            //var r08 = IContrato.ConsultarUsuarioAccesos("GP", "ADMI"); // LIST LAS EMPRESAS DISPONIBLES 
            //var r09 = IContrato.SeleccionarMpEmpresa("PAN_A"); //SELECCIONA EMPRESA A TRABAJAR
            //var r0A = IContrato.InsertarPista("GP", "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id></Id><Info>Selecciona empresa PAN_A</Info></Data>");
            //var r0B = IContrato.SeleccionarParametrosEmpresa("PAN_A");//VERIFICO SI MANEJA SUCURSALES
            //var r0C = IContrato.Get_Sucursales();//OBTENER LISTA DE SUCURSALES
            //var r0D = IContrato.InsertarPista("GP", "Login", "M", Environment.MachineName.ToString(), "ADM81", "<Data><Id>638029839963659298</Id><Info>Selecciona sucursal 02</Info></Data>");
            //var r0E = IContrato.ObtenerMapaUsuario("GP", "ga195301", "PAN_A", "ADMI"); //OBTENER CODIGO MAPA 
            //var r0F = IContrato.SeleccionarMapa("300", "ADMI");

        }
    }
}
