using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EquimarFac.DAO
{
    class FacturasDAO
    {
        //Create table Facturas(IDFactura int not null identity(100, 1) primary key,
        //                ClienteFactura int not null foreign key references Clientes(IDCliente),
        //                Barco int not null foreign key references Barcos(IDBarco),
        //                Remolcador int not null foreign key references RemolcadoresFacturas(IDRemolcadoresF),
        //                Remolcadores varchar(max),
        //                Moneda varchar(max),
        //                Subtotal decimal,
        //                Iva decimal,
        //                Total decimal,
        //                Cancelada int,
        //                TotalLetras varchar(max),
        //                FacturadaL int);


        //IDFServicios int not null identity(100, 1) primary key,
        //                        Factura int not null foreign key references Facturas(IDFactura),
        //                        Servicio varchar(max),
        //                        Barco varchar(max),
        //                        TRB varchar(max),
        //                        Muelles varchar(max),
        //                        Fecha varchar(max),
        //                        Horario varchar(max),
        //                        TiempoTrancurrido varchar(max),
        //                        Importe decimal);


        public int IDFServicios { get; set; }
        public string Servicio { get; set; }
        public string BarcoT { get; set; }
        public string TRB { get; set; }
        public string Muelles { get; set; }
        public string FechaT { get; set; }
        public DateTime Fecha { get; set; }
        public string Horario { get; set; }
        public string TiempoTrancurrido { get; set; }
        public decimal Importe { get; set; }
        public string facturaimpresa { get; set; }
        public int IDFactura { get; set; }
        public int ClienteFactura { get; set; }
        public int BarcoID { get; set; }
        public int Remolcador { get; set; }
        public string Remolcadores { get; set; }
        public string Moneda { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public int cancelada { get; set; }
        public string TotalLetras { get; set; }
        public int FacturadaL { get; set; }
        public int Remolcador1 { get; set; }
        public int? Remolcador2 { get; set; }
        public int? Remolcador3 { get; set; }
        public string Agencia { get; set; }
        public string ClaveCFDI { get; set; }
        public string formaDePago { get; set; }
        public string metodoDePago { get; set; }
        public string descuento { get; set; }
        public string porcentajeDescuento { get; set; }
        public string motivodescuento { get; set; }
        public string tipodecambio { get; set; }
        public string fechatipodecambio { get; set; }
        public string totalImpuestosretenidos { get; set; }
        public string totalimpuestostrasladados { get; set; }
        public string LugarExpedicion { get; set; }

        //IDNotaCredito int not null identity(100, 1) primary key,
        //                    Factura int not null foreign key references Facturas(IDFactura),
        //                    NumeroProgresivo decimal,
        //                    Fecha datetime,
        //                    Concepto varchar(max),
        //                    Subtotal decimal(18, 2),
        //                    Iva decimal(18, 2),
        //                    Total decimal(18, 2),
        //                    ConceptoT varchar(max)
        public int IDNotaCredito { get; set; }
        public decimal NumeroProgresivo { get; set; }
        public string Concepto { get; set; }
        public string ConceptoT { get; set; }
        public string viaje { get; set; }
        public string DescuentoT { get; set; }

        public int IDCuentaPac { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        //        alter table NotaCredito add Descuento decimal(18, 2);
        //alter table NotaCredito add MotivoDescuento varchar(max);
        //alter table NotaCredito add PorcentajeDescuento decimal(18, 2); 
        //alter table NotaCredito add Moneda varchar(max);
        //alter table NotaCredito add TipoDeCambio decimal(18, 2);
        //alter table NotaCredito add FechaTipoCambio datetime;
        //alter table NotaCredito add UUID varchar(max);
        //alter table NotaCredito add Folio varchar(max);

        public decimal Descuento_decimal { get; set; }
        public string MotivoDescuento_string { get; set; }
        public decimal PorcentajeDescuento_decimal { get; set; }
        public decimal TipoDeCambio_decimal { get; set; }
        public DateTime FechaTipoCambio_datetime { get; set; }
        public string UUID { get; set; }
        public string Folio { get; set; }
        public string NumCuenta { get; set; }

        public DataTable notacreditoimpresion()
        {
            BO.DS_FacturasTableAdapters.notacreditoimpresionTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.notacreditoimpresionTableAdapter();
            return facturas.GetData(this.IDFactura);
        }

        public DataTable notacreditoimpresiondetalle()
        {
            BO.DS_FacturasTableAdapters.devuelvenotadetalleimpresionTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.devuelvenotadetalleimpresionTableAdapter();
            return facturas.GetData(this.IDFactura);
        }

        public DataTable devuelvefacturas()
        {
            BO.DS_FacturasTableAdapters.vistaFacturasTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.vistaFacturasTableAdapter();
            return facturas.GetData();
        }

        public DataTable devuelvefacturascanceladas()
        {
            BO.DS_FacturasTableAdapters.vistaFacturasCanceladasTableAdapter facturasc = new EquimarFac.BO.DS_FacturasTableAdapters.vistaFacturasCanceladasTableAdapter();
            return facturasc.GetData();
        }

        public DataTable devuelveserviciosf()
        {
            BO.DS_FacturasTableAdapters.devuelveserviciosfacturadescuentoTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.devuelveserviciosfacturadescuentoTableAdapter();
            return facturas.GetData(this.IDFactura);
        }

        public string insertaRemolcadores()
        {
            try
            {
                BO.DS_FacturasTableAdapters.RemolcadoresFacturasTableAdapter remolcadores = new EquimarFac.BO.DS_FacturasTableAdapters.RemolcadoresFacturasTableAdapter();
                remolcadores.Insert(this.Remolcador1, this.Remolcador2, this.Remolcador3);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertaviaje()
        {
            try
            {
                BO.DS_FacturasTableAdapters.viajefacturaTableAdapter viajes = new EquimarFac.BO.DS_FacturasTableAdapters.viajefacturaTableAdapter();
                viajes.Insert(this.IDFactura, this.viaje);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable reportefacturas()
        {
            BO.DS_FacturasTableAdapters.reportefacturasTableAdapter reporte = new EquimarFac.BO.DS_FacturasTableAdapters.reportefacturasTableAdapter();
            return reporte.GetData(this.IDFactura);
        }

        public DataTable reporteservicios()
        {
            BO.DS_FacturasTableAdapters.reporteserviciosTableAdapter reporte = new EquimarFac.BO.DS_FacturasTableAdapters.reporteserviciosTableAdapter();
            return reporte.GetData(this.IDFactura);
        }
       

        public string insertaserviciosfactura()
        {
            try
            {
                BO.DS_FacturasTableAdapters.FacturasDetalleTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.FacturasDetalleTableAdapter();

                this.Importe = Decimal.Round(this.Importe, 2);
                facturas.Insert(this.IDFactura, this.Servicio, this.BarcoT, this.TRB, this.Muelles, this.FechaT, this.Horario, this.TiempoTrancurrido, this.Importe);
                return "Correcto";
            }
            catch
            {
                return "Error (inserta servicios)";
            }
        }

        public string insertaserviciosdescuento()
        {
            try
            {
                BO.DS_FacturasTableAdapters.facturasdetalledescuentosTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.facturasdetalledescuentosTableAdapter();
                facturas.Insert(this.IDFServicios, this.DescuentoT, this.Importe);
                return "Correcto";
            }
            catch
            {
                return "Error (inserta servicios)";
            }
        }

        public string eliminaserviciosfac()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.eliminaservicio(this.IDFServicios);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public string insertadatospac()
        {
            try
            {
                BO.DS_FacturasTableAdapters.CuentaPACTableAdapter tablacuentapac = new EquimarFac.BO.DS_FacturasTableAdapters.CuentaPACTableAdapter();
                tablacuentapac.Insert(this.Nombre, this.Usuario, this.Cuenta, this.Password);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public string modificadatospac()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.modificadatospac(this.IDCuentaPac, this.Nombre, this.Usuario, this.Cuenta, this.Password);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public string eliminadatospac()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.eliminadatospac(this.IDCuentaPac);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public DataTable devuelvedatospac()
        {
            BO.DS_FacturasTableAdapters.devuelvedatospacTableAdapter tabladatos = new EquimarFac.BO.DS_FacturasTableAdapters.devuelvedatospacTableAdapter();
            return tabladatos.GetData();
        }
        public DataTable devuelvenotascanceladas280616()
        {
            BO.DS_FacturasTableAdapters.notascreditocanceladasTableAdapter tabladatos = new BO.DS_FacturasTableAdapters.notascreditocanceladasTableAdapter();
            return tabladatos.GetData();
        }
        public DataTable devuelvedatospacpornombre()
        {
            BO.DS_FacturasTableAdapters.devuelvedatospacNOMBRETableAdapter tabladatos = new EquimarFac.BO.DS_FacturasTableAdapters.devuelvedatospacNOMBRETableAdapter();

            return tabladatos.GetData(this.Nombre);
        }
        public string actualizanotascreditocfdi()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.actualizaNotaCreditocfdi(this.IDNotaCredito, this.UUID, this.Folio);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public string actualizafacturatermina()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.actualizafacturaparcial(this.IDFactura, this.Remolcadores, this.Moneda, this.Subtotal, this.Iva, this.Total, this.TotalLetras, this.ClaveCFDI, this.formaDePago, this.metodoDePago, this.descuento, this.porcentajeDescuento, this.motivodescuento, this.tipodecambio, this.fechatipodecambio, this.totalImpuestosretenidos, this.totalimpuestostrasladados, this.LugarExpedicion, this.Agencia, this.NumCuenta);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string insertaparcialfactura()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.insertaFacturaparcial(this.Fecha, this.ClienteFactura, this.BarcoID, this.Remolcador);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string cancelafactura()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.cancelafactura(this.IDFactura, this.ConceptoT);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }
        public string cancelanotasdecreditocfdi()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.cancelanotadecreditocfdi(this.IDNotaCredito, this.ConceptoT);
                return "Correcto";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public string insertanumfacturaimpresa()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.ingresa_actualizafac(this.IDFactura, this.ClaveCFDI, this.facturaimpresa);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string creanota()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.creanotacredito(this.IDFactura);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public string actualiza_notacredito()
        {
            try
            {
                BO.DS_FacturasTableAdapters.QueriesTableAdapter queries = new EquimarFac.BO.DS_FacturasTableAdapters.QueriesTableAdapter();
                queries.actualizaNotaparcial(this.IDFactura, this.NumeroProgresivo, this.Fecha, this.Concepto, this.Subtotal, this.Iva, this.Total, this.ConceptoT, this.Descuento_decimal, this.MotivoDescuento_string, this.PorcentajeDescuento_decimal, this.Moneda, this.TipoDeCambio_decimal, this.FechaTipoCambio_datetime, this.UUID, this.Folio);
                return "Correcto";
            }
            catch
            {
                return "Error de coneccion";
            }
        }

        public DataTable devuelvenotasdecreditofactura()
        {
            BO.DS_FacturasTableAdapters.devuelvenotasdecreditofacturaTableAdapter notascredito = new EquimarFac.BO.DS_FacturasTableAdapters.devuelvenotasdecreditofacturaTableAdapter();
            return notascredito.GetData(this.IDFactura);
        }
        public DataTable devuelvenotasdecreditofacturacanceladas()
        {
            BO.DS_FacturasTableAdapters.devuelvenotasdecreditofacturacanceladasTableAdapter notascredito = new EquimarFac.BO.DS_FacturasTableAdapters.devuelvenotasdecreditofacturacanceladasTableAdapter();
            return notascredito.GetData(this.IDFactura);
        }
        //public int devuelveid()
        //{
        //    return Convert.ToInt32(numeroficha.GetData().Max().Column1);
        //}

        public int devuelveidremolcadores()
        {
            BO.DS_FacturasTableAdapters.numeroremolcadoresfTableAdapter remolcadores = new EquimarFac.BO.DS_FacturasTableAdapters.numeroremolcadoresfTableAdapter();
            return Convert.ToInt32(remolcadores.GetData().Max().Column1);
        }

        public int devuelveidfacturas()
        {
            BO.DS_FacturasTableAdapters.numerofacturasTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.numerofacturasTableAdapter();
            return Convert.ToInt32(facturas.GetData().Max().Column1);
        }

        public int devuelveiddetallefac()
        {
            BO.DS_FacturasTableAdapters.numerodetallefacTableAdapter facturas = new EquimarFac.BO.DS_FacturasTableAdapters.numerodetallefacTableAdapter();
            return Convert.ToInt32(facturas.GetData().Max().Column1);
        }


    }
}
