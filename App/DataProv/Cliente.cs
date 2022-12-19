using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.DataProv
{
    
    public partial class ImpDataProv: IDataProv
    {

        public OOB.ResultadoEntidad<OOB.Cliente.Ficha>
            cli_ObtenerFichaById(string codCli)
        {
            var rt = new OOB.ResultadoEntidad<OOB.Cliente.Ficha>();
            var r01 = ServiceProv.cli_ObtenerFicha(codCli);
            if (r01.Result == DTO.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var ent = new OOB.Cliente.Ficha()
            {
                ciudad = s.ciudad,
                cli_des = s.cli_des,
                co_cli = s.co_cli,
                co_cta_ingr_egr = s.co_cta_ing_egr,
                co_mone = s.co_mone,
                co_pais = s.co_pais,
                co_precio = s.co_precio,
                co_seg = s.co_seg,
                co_tab = s.co_tab,
                co_ven = s.co_ven,
                co_zon = s.co_zon,
                comentario = s.comentario,
                cond_pag = s.cond_pag,
                contrib = s.contrib,
                contribu_e = s.contribu_e,
                desc_glob = s.desc_glob,
                desc_ppago = s.desc_ppago,
                dir_ent2 = s.dir_ent2,
                direc1 = s.direc1,
                direc2 = s.direc2,
                domingo = s.domingo,
                email = s.email,
                estado = s.estado,
                fax = s.fax,
                fecha_reg = s.fecha_reg,
                frecu_vist = s.frecu_vist,
                horar_caja = s.horar_caja,
                id = s.id,
                inactivo = s.inactivo,
                jueves = s.jueves,
                juridico = s.juridico,
                login = s.login,
                lunes = s.lunes,
                martes = s.martes,
                matriz = s.matriz,
                miercoles = s.miercoles,
                mont_cre = s.mont_cre,
                nit = s.nit,
                password = s.password,
                plaz_pag = s.plaz_pag,
                porc_esp = s.porc_esp,
                puntaje = s.puntaje,
                respons = s.respons,
                rif = s.rif,
                sabado = s.sabado,
                salestax = s.salestax,
                serialp = s.serialp,
                sincredito = s.sincredito,
                telefonos = s.telefonos,
                tip_cli = s.tip_cli,
                tipo_adi = s.tipo_adi,
                tipo_per = s.tipo_per,
                valido = s.valido,
                ven_inactivo = s.ven_inactivo,
                viernes = s.viernes,
                website = s.website,
                zip = s.zip,
            };
            rt.Entidad = ent;
            return rt;
        }

    }

}
