using MASTER;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImpContrato
{
    
    public partial class Provider: Contrato.IProvider
    {

        public static EntityConnectionStringBuilder _master;
        private string _dataSource;
        private string _baseDatos;
        private string _usuario;
        private string _password;
        //
        public static EntityConnectionStringBuilder _gestion;
        private string _dataSource_g;
        private string _baseDatos_g;
        private string _usuario_g;
        private string _password_g;
        

        public Provider(string instancia, string catalogo1, string catalogo2, string user, bool isModoProduccion)
        {
            var _user = user;
            var _pw = "profit";
            if (isModoProduccion)
            {
                _user = "sa";
                _pw = "123";
            }
            _usuario = _user;//"PROFIT"
            _password = _pw;// "profit";
            _dataSource = instancia;// @"localhost\mssql14";
            _baseDatos = catalogo1;// "masterprofitpro";
            //
            _usuario_g = _user;// user;//"PROFIT";
            _password_g = _pw;//profit";
            _dataSource_g = instancia;// @"localhost\mssql14";
            _baseDatos_g = catalogo2;// "PAN_A";
            setConexion(isModoProduccion);
        }


        private void setConexion(bool isModoProduccion)
        {

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            sqlBuilder.DataSource = _dataSource;
            sqlBuilder.InitialCatalog = _baseDatos;
            sqlBuilder.UserID = _usuario;
            sqlBuilder.Password = _password;
            if (isModoProduccion)
            {
                //sqlBuilder.PersistSecurityInfo = true;
                //sqlBuilder.IntegratedSecurity = true;
            }
            else 
            {
                sqlBuilder.PersistSecurityInfo = true;
            }

            SqlConnectionStringBuilder sqlBuilder_g = new SqlConnectionStringBuilder();
            sqlBuilder_g.DataSource = _dataSource_g;
            sqlBuilder_g.InitialCatalog = _baseDatos_g;
            sqlBuilder_g.UserID = _usuario_g;
            sqlBuilder_g.Password = _password_g;
            if (isModoProduccion)
            {
                //sqlBuilder_g.PersistSecurityInfo = true;
                //sqlBuilder_g.IntegratedSecurity = true;
            }
            else
            {
                sqlBuilder_g.PersistSecurityInfo = true;
            }

            _master = new EntityConnectionStringBuilder();
            _master.Metadata = @"res://*/masterModel.csdl|res://*/masterModel.ssdl|res://*/masterModel.msl";
            _master.Provider = "System.Data.SqlClient";
            _master.ProviderConnectionString = sqlBuilder.ConnectionString;
            //
            _gestion = new EntityConnectionStringBuilder();
            _gestion.Metadata = @"res://*/pPanModel.csdl|res://*/pPanModel.ssdl|res://*/pPanModel.msl";
            _gestion.Provider = "System.Data.SqlClient";
            _gestion.ProviderConnectionString = sqlBuilder_g.ConnectionString;
        }


        public DTO.ResultadoEntidad<DateTime> 
            Get_FechaServidor()
        {
            var result = new DTO.ResultadoEntidad<DateTime>();

            try
            {
                using (var ctx = new masterprofitEntities(_master.ConnectionString))
                {
                    var fechaSistema = ctx.Database.SqlQuery<DateTime>("select GETDATE()").FirstOrDefault();
                    result.Entidad = fechaSistema.Date;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DTO.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}