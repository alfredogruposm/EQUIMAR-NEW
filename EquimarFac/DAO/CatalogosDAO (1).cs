using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EquimarFac.DAO
{
    class CatalogosDAO
    {

        //table Navieras(IDNaviera int not null identity(100, 1) primary key,
        //                Nombre varchar(max),
        //                Direccion varchar(max),
        //                Poblacion varchar(max),
        //                Telefono varchar(max),
        //                RFC varchar(max),
        //                Contacto varchar(max));

        public int idnavieras { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string poblacion { get; set; }
        public string telefono { get; set; }
        public string rfc { get; set; }
        public string contacto { get; set; }
        public string estadoextranjero { get; set; }
        public string paisextranjero { get; set; }
        //table Clientes(IDCliente int not null identity(100, 1) primary key,
        //                Naviera int foreign key references Navieras(IDNaviera),
        //                Nombre varchar(max),
        //                Direccion varchar(max),
        //                Poblacion varchar(max),
        //                Telefono varchar(max),
        //                RFC varchar(max),
        //                Contacto varchar(max),
        //                Moneda Varchar(max),
        //                Nacionalidad varchar(max));
        public int idcliente { get; set; }
        public string moneda { get; set; }
        public string nacionalidad { get; set; }
        public string calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string ReferenciasDir { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Email { get; set; }
        public string CodigoPostal { get; set; }
        


        //table Remolcadores(IDRemolcador int not null identity(100, 1) primary key,
        //                    Nombre varchar(max),
        //                    Caballaje varchar(max),
        //                    Tamaño varchar(max));
        public int idremolcador { get; set; }
        public string Caballaje { get; set; }
        public string tamaño { get; set; }



        //table Servicios(IDServicio int not null identity(100, 1) primary key,
        //                Nombre varchar(max),
        //                Descuento int);
        public int idservicio { get; set; }
        public int descuento { get; set; }
        //table Barcos(IDBarco int not null identity(100, 1) primary key,
        //            Nombre varchar(max),
        //            TRB int, 
        //            TipoCarga varchar(max));
        public int idbarco { get; set; }
        public int trb { get; set; }
        public string TipoCarga { get; set; }

        //IDTarifas int not null identity(100, 1) primary key,
        //                Nombre varchar(max),
        //                Cuota_Basica1 decimal(18, 2),
        //                Cuotabasica2 decimal(18, 2),
        //                CuotaBasica3 decimal(18, 2),
        //                CuotaBasica4 decimal(18, 2),
        //                RemolcadorExtraP decimal(18, 2),
        //                RemolcadorExtraM decimal(18, 2),
        //                RemolcadorExtraG decimal(18, 2),
        //                ServicioContinuoA decimal(18, 2),
        //                ServicioContinuoB decimal(18, 2),
        //                ServicioContinuoC decimal(18, 2))

        public int IDTarifas { get; set; }
        public decimal Cuota_Basica1 { get; set; }
        public decimal Cuotabasica2 { get; set; }
        public decimal CuotaBasica3 { get; set; }
        public decimal CuotaBasica4 { get; set; }
        public decimal RemolcadorExtraP { get; set; }
        public decimal RemolcadorExtraM { get; set; }
        public decimal RemolcadorExtraG { get; set; }
        public decimal ServicioContinuoA { get; set; }
        public decimal ServicioContinuoB { get; set; }
        public decimal ServicioContinuoC { get; set; }

        public DataTable devuelvetarifas()
        {
            BO.DS_CatalogosTableAdapters.TarifasTableAdapter tarifas = new EquimarFac.BO.DS_CatalogosTableAdapters.TarifasTableAdapter();
            return tarifas.GetData();
        }


        public DataTable devuelvenavieras()
        {
            BO.DS_CatalogosTableAdapters.NavierasTableAdapter navieras = new EquimarFac.BO.DS_CatalogosTableAdapters.NavierasTableAdapter();
            return navieras.GetData();
        }

        public DataTable devuelveclientes()
        {
            BO.DS_CatalogosTableAdapters.vistaclientesTableAdapter clientes = new EquimarFac.BO.DS_CatalogosTableAdapters.vistaclientesTableAdapter();
            return clientes.GetData();
        }

        public DataTable devuelveremolcadores()
        {
            BO.DS_CatalogosTableAdapters.RemolcadoresTableAdapter remolcadores = new EquimarFac.BO.DS_CatalogosTableAdapters.RemolcadoresTableAdapter();
            return remolcadores.GetData();
        }

        public DataTable devuelveservicios()
        {
            BO.DS_CatalogosTableAdapters.ServiciosTableAdapter servicios = new EquimarFac.BO.DS_CatalogosTableAdapters.ServiciosTableAdapter();
            return servicios.GetData();
        }

        public DataTable devuelvebarcos()
        {
            BO.DS_CatalogosTableAdapters.BarcosTableAdapter barcos = new EquimarFac.BO.DS_CatalogosTableAdapters.BarcosTableAdapter();
            return barcos.GetData();
        }
        public DataTable devuelveclientepornombre()
        {
            BO.DS_CatalogosTableAdapters.devuelveclientenombreTableAdapter cliente=new EquimarFac.BO.DS_CatalogosTableAdapters.devuelveclientenombreTableAdapter();

            return cliente.GetData(this.nombre);
        }

        public string insertatarifas()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.TarifasTableAdapter tarifas = new EquimarFac.BO.DS_CatalogosTableAdapters.TarifasTableAdapter();
                tarifas.Insert(this.nombre, this.Cuota_Basica1, this.Cuotabasica2, this.CuotaBasica3, this.CuotaBasica4, this.RemolcadorExtraP, this.RemolcadorExtraM, this.RemolcadorExtraG, this.ServicioContinuoA, this.ServicioContinuoB, this.ServicioContinuoC);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertanavieras()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.NavierasTableAdapter navieras = new EquimarFac.BO.DS_CatalogosTableAdapters.NavierasTableAdapter();
                navieras.Insert(this.nombre, this.direccion, this.poblacion, this.telefono, this.rfc, this.contacto);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertaclientes()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.ClientesTableAdapter clientes = new EquimarFac.BO.DS_CatalogosTableAdapters.ClientesTableAdapter();
                clientes.Insert(this.idnavieras, this.nombre, this.direccion, this.poblacion, this.telefono, this.rfc, this.contacto, this.moneda, this.nacionalidad, this.calle, this.NumExt, this.NumInt, this.Colonia, this.Localidad, this.ReferenciasDir, this.Estado, this.Pais, this.Email, this.CodigoPostal, this.paisextranjero, this.estadoextranjero);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertaremolcadores()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.RemolcadoresTableAdapter remolcadores = new EquimarFac.BO.DS_CatalogosTableAdapters.RemolcadoresTableAdapter();
                remolcadores.Insert(this.nombre, this.Caballaje, this.tamaño);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertaservicios()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.ServiciosTableAdapter servicios = new EquimarFac.BO.DS_CatalogosTableAdapters.ServiciosTableAdapter();
                servicios.Insert(this.nombre, this.descuento);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertabarcos()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.BarcosTableAdapter barcos = new EquimarFac.BO.DS_CatalogosTableAdapters.BarcosTableAdapter();
                barcos.Insert(this.nombre, this.trb, this.TipoCarga);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_tarifas()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificatarifa(this.IDTarifas, this.nombre, this.Cuota_Basica1, this.Cuotabasica2, this.CuotaBasica3, this.CuotaBasica4, this.RemolcadorExtraP, this.RemolcadorExtraM, this.RemolcadorExtraG, this.ServicioContinuoA, this.ServicioContinuoB, this.ServicioContinuoC);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_navieras()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificanavieras(this.idnavieras, this.nombre, this.direccion, this.poblacion, this.telefono, this.rfc, this.contacto);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_clientes()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificaclientes(this.idcliente, this.idnavieras, this.nombre, this.direccion, this.poblacion, this.telefono, this.rfc, this.contacto, this.moneda, this.nacionalidad, this.calle, this.NumExt, this.NumInt, this.Colonia, this.Localidad, this.ReferenciasDir, this.Estado, this.Pais, this.Email, this.CodigoPostal, this.estadoextranjero, this.paisextranjero);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_remolques()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificaremolcador(this.idremolcador, this.nombre, this.Caballaje, this.tamaño);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_servicios()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificaservicios(this.idservicio, this.nombre, this.descuento);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string modifica_barcos()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.modificabarcos(this.idbarco, this.nombre, this.trb, this.TipoCarga);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_navieras()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminanavieras(this.idnavieras);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_clientes()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminaclientes(this.idcliente);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_remolcadores()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminaremolcador(this.idremolcador);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_servicios()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminaservicios(this.idservicio);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_barcos()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminabarcos(this.idbarco);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string elimina_tarifas()
        {
            try
            {
                BO.DS_CatalogosTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_CatalogosTableAdapters.QueriesTableAdapter();
                queries.eliminatarifas(this.IDTarifas);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

    }
}
