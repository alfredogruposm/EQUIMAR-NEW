using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rnd = EquimarFac.FelWebService2;
using System.Collections;

namespace EquimarFac.DAO
{
    class FelWebServiceDAO
    {
        public List<string> conceptos, infoaduanera;
        public string emisorRFC;

        public string CuentaFEL;
            
        //"EPR911024AH7";

        //public string CuentaFELNotasCredito = "NOTACREDITO";

        //public string CuentaFELFacturas = "FACTURAS";

        public string PasswordFEL;

        // Datos Receptor
        public string NombreCliente { get; set; }

        public string Contacto {get; set;}

        public string Telefono {get; set;}

        public string Email {get; set;}

        public string rfcReceptor {get; set;}

        public string nombreReceptor {get; set;}

        public string calleReceptor {get; set;}

        public string noExteriorReceptor {get; set;}

        public string noInteriorReceptor {get; set;}

        public string coloniaReceptor {get; set;}

        public string localidadReceptor {get; set;}

        public string referenciaReceptor {get; set;}

        public string municipioReceptor {get; set;}

        public string estadoReceptor {get; set;}

        public string paisReceptor {get; set;}


        public string codigoPostalReceptor {get; set;}

        //Datos CFDI
        public string ClaveCFDI {get; set;}

        public string formaDePago {get; set;}

        public string parcialidades {get; set;}

        public string condicionesDePago {get; set;}

        public string metodoDePago {get; set;}

        public string descuento {get; set;}

        public string porcentajeDescuento {get; set;}

        public string motivoDescuento {get; set;}

        public string moneda {get; set;}

        public string tipoCambio {get; set;}

        public string fechaTipoCambio {get; set;}

        public string totalImpuestosRetenidos {get; set;}

        public string totalImpuestosTrasladados {get; set;}

        public string subTotal {get; set;}

        public string total {get; set;}

        public string importeConLetra { get; set; }

        public string LugarExpedicion { get; set; }

        public string NumCuentaPago { get; set; }

        public string FolioFiscalOrig { get; set; }

        public string SerieFolioFiscalOrig { get; set; }

        public string FechaFolioFiscalOrig { get; set; }

        public string MontoFolioFiscalOrig { get; set; }
        //Datos Varios
        public string datosEtiquetas1 { get; set; }
        public string datosEtiquetas2 { get; set; }
        public string datosEtiquetas3 { get; set; }
        public string datosEtiquetas4 { get; set; }
        public string datosEtiquetas5 { get; set; }
        public string datosEtiquetas6 { get; set; }
        public string datosConceptos { get; set; }
        public string datosInfoAduanera { get; set; }
        public string datosRetenidosIVA { get; set; }
        public string datosRetenidosISR { get; set; }
        public string datosTraslados1 { get; set; }
        public string datosRetenidosLocales1 { get; set; }
        public string datosRetenidosLocales2 { get; set; }
        public string datosTrasladosLocales1 { get; set; }
        public string UUID { get; set; }
        public string[] AUUID { get; set; }
      

        public string[] GenerarCDFI()
        {
            //string[] datosUsuario = new string[3];
            //string[] datosReceptor = new string[16];
            //string[] datosCFDI = new string[22];
            //string[] datosConceptos = new string[conceptos.Count];
            string[] datosInfoAduanera = new string[infoaduanera.Count];
            string[] datosRetenidos = new string[1];
            string[] datosTraslados = new string[1];
            string[] datosRetenidosLocales = new string[1];
            string[] datosTrasladosLocales = new string[1];
            string[] respuesta = new string[5];
            rnd.Credenciales datosUsuario = new rnd.Credenciales();
            rnd.ComprobanteRemota datosCFDI = new rnd.ComprobanteRemota();
            //rnd.ComprobanteRemota datoscfdi = new rnd.ComprobanteRemota();
            datosCFDI.Receptor = new rnd.ReceptorR();
            //rnd.ConceptoR datosConceptos = new rnd.ConceptoR();
            List<rnd.ConceptoR> listaconceptos = new List<rnd.ConceptoR>();
            List<rnd.RegimenFiscalR> listaRegimenFiscales = new List<rnd.RegimenFiscalR>();
            rnd.RegimenFiscalR Regimen = new rnd.RegimenFiscalR();
            List<rnd.EtiquetaPersonalizadaR> listaEtiquetasPersonalizadas = new List<rnd.EtiquetaPersonalizadaR>();
            rnd.DetallesConcepto detalles = new rnd.DetallesConcepto();
            List<rnd.RetencionR> listaImpuestosRetenidos = new List<rnd.RetencionR>();
            rnd.RetencionR impuestoRetenido = new rnd.RetencionR();
            List<rnd.TrasladoR> listaImpuestosTraslados = new List<rnd.TrasladoR>();
            rnd.TrasladoR ImpuestoTraslado = new rnd.TrasladoR();
            rnd.ConexionRemota coneccion = new rnd.ConexionRemota();
            rnd.RespuestaOperacion respuesta1 = new rnd.RespuestaOperacion();
            datosCFDI.Impuestos = new rnd.ImpuestosR();

            try
            {
                
                
                                // Vector para envío de datos de usuario.
                        //Dim datosUsuario As New WSRemota32.ArrayOfString
                        // RFC del emisor (REQUERIDO);. Posición 0.
                datosUsuario.Cuenta = CuentaFEL;
                        // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario.Usuario = emisorRFC;
                        // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario.Password = PasswordFEL;
                
                        //*************************************************************************************
                        // Sección de variables para identificar y actualizar los datos del Cliente o Receptor.
                        //*************************************************************************************
                        // Vector para envío de datos de cliente receptor.
                       
                        // Nombre del cliente (REQUERIDO;. Posición 0.
                datosCFDI.Receptor.NombreCliente = NombreCliente;
                        // Contacto de referencia del cliente (opcional;. Posición 1.
                datosCFDI.Receptor.Contacto = Contacto;
                        // Teléfono del cliente (opcional;. Posición 2.
                datosCFDI.Receptor.TelefonoContacto = Telefono;
                        // Email del cliente (opcional;. Posición 3.
                datosCFDI.Receptor.emailContacto = Email;
                        // RFC del receptor (REQUERIDO;. Posición 4.
                datosCFDI.Receptor.RFC = rfcReceptor; //WAPR7802271P5
                        // Nombre del receptor (REQUERIDO;. Posición 5.
                datosCFDI.Receptor.Nombre = nombreReceptor;
                        // Calle del receptor (REQUERIDO;. Posición 6.
                datosCFDI.Receptor.calle = calleReceptor;
                        // No. exterior del receptor (REQUERIDO;. Posición 7.
                datosCFDI.Receptor.noExterior = noExteriorReceptor;
                        // No. interior del receptor (opcional;. Posición 8.
                datosCFDI.Receptor.noInterior = noInteriorReceptor;
                        // Colonia del receptor (REQUERIDO;. Posición 9.
                datosCFDI.Receptor.colonia = coloniaReceptor;
                        // Localidad del receptor (opcional;. Posición 10.
                datosCFDI.Receptor.localidad = localidadReceptor;
                        // Referencia del receptor (opcional;. Posición 11.
                        datosCFDI.Receptor.referencia = referenciaReceptor;
                        // Municio del receptor (REQUERIDO;. Posición 12.
                        datosCFDI.Receptor.municipio = municipioReceptor;
                        // Estado del receptor (REQUERIDO;. Posición 13.
                        datosCFDI.Receptor.estado = estadoReceptor;
                        // País del receptor (REQUERIDO;. Posición 14.
                        datosCFDI.Receptor.pais = paisReceptor;
                        // Código postal del receptor (REQUERIDO;. Posición 15.
                        datosCFDI.Receptor.codigoPostal = codigoPostalReceptor;

                        //******************************************************
                        // Sección de variables de información general del CFDI.
                        //******************************************************
                        
                        // Clave del CFDI (REQUERIDO);. Posición 0.
                        datosCFDI.ClaveCFDI = ClaveCFDI;
                        // Forma de pago (REQUERIDO;. Posición 1.
                        datosCFDI.formaDePago = formaDePago;
                        // Pago en parcialidades (opcional;. Posición 2.
                        //datosCFDI.par = parcialidades;
                        // Condiciones de pago (opcional;. Posición 3.
                        datosCFDI.condicionesDePago = condicionesDePago;
                        // Método de pago (opcional;. Posición 4.
                        datosCFDI.metodoDePago = metodoDePago;
                        // El descuento usado (opcional;. Posición 5.
                        datosCFDI.descuento = Convert.ToDecimal(descuento);
                        // El porcentaje de descuento (opcional;. Posición 6.
                        datosCFDI.PorcentajeDescuento = Convert.ToDecimal(porcentajeDescuento);
                        // El motivo de descuento (opcional;. Posición 7.
                        datosCFDI.motivoDescuento = motivoDescuento;
                        // La moneda utilizada (REQUERIDO;. Posición 8.
                        datosCFDI.Moneda = moneda;
                        // Tipo de cambio (opcional;. Posición 9.
                        datosCFDI.TipoCambio = tipoCambio;
                        // Fecha del tipo de cambio (opcional;. Posición 10.
                        if (fechaTipoCambio != "")
                        {
                            datosCFDI.FechaTipoCambio = Convert.ToDateTime(fechaTipoCambio);
                        }
                        else
                        {
                            //datosCFDI.FechaTipoCambio = DateTime.MinValue;
                        }
                        
                        // El total de impuestos retenidos (REQUERIDO;. Posición 11.
                        datosCFDI.Impuestos.totalImpuestosRetenidos = Convert.ToDecimal(totalImpuestosRetenidos);
                        // El total de impuestos trasladados (REQUERIDO;. Posición 12.
                        //datosCFDI.t = totalImpuestosTrasladados;
                        // El subtotal del comprobante (REQUERIDO;. Posición 13.
                        datosCFDI.Impuestos.totalImpuestosTrasladados = Convert.ToDecimal(totalImpuestosTrasladados);
                        datosCFDI.subTotal = Convert.ToDecimal(subTotal);
                        // El total del comprobante (REQUERIDO;. Posición 14.
                        datosCFDI.total = Convert.ToDecimal(total);
                        // El importe con letra formado (REQUERIDO;. Posición 15.
                        datosCFDI.ImporteConLetra = importeConLetra;
                        // NUEVOS CAMPOS SAT 3.2
                        // (16; LugarExpedicion (REQUERIDO;
                        datosCFDI.LugarExpedicion = LugarExpedicion;
                        // (17; NumCuentaPago (OPCIONAL;
                        datosCFDI.NumCtaPago = NumCuentaPago;
                        // (18; FolioFiscalOrig (OPCIONAL;
                        datosCFDI.FolioFiscalOrig = FolioFiscalOrig;
                        // (19; SerieFolioFiscalOrig (OPCIONAL;
                        //datosCFDI.SerieFolioFiscalOrig = SerieFolioFiscalOrig;
                        //// (20; FechaFolioFiscalOrig (OPCIONAL;
                        //datosCFDI.FechaFolioFiscalOrig = Convert.ToDateTime(FechaFolioFiscalOrig);
                        //// (21; MontoFolioFiscalOrig (OPCIONAL;
                        //datosCFDI.MontoFolioFiscalOrig = Convert.ToDecimal(MontoFolioFiscalOrig);

                        
                        Regimen.Regimen = "Regimen general de ley de personas morales";
                        listaRegimenFiscales.Add(Regimen);
        //'Se agrega la lista de Regimen al comprobante.
                        datosCFDI.RegimenesFiscales = listaRegimenFiscales.ToArray();


                        //********************************************************************************************
                        // Sección de variables para el uso de información comercial y personal de la empresa emisora.
                        //********************************************************************************************
                        // Secuencia: |nombre|valor|
                        // Etequeta1(opceonal;.
                        
                        //int e = 0;
                        if (datosEtiquetas1 != null)
                        {
                            string[] r = new string[4];
                            r = datosEtiquetas1.Split('|');
                            rnd.EtiquetaPersonalizadaR Etiquetas = new rnd.EtiquetaPersonalizadaR();
                            //''Nombre Etiqueta (REQUERIDO).
                            Etiquetas.Nombre = r[1];
                            //''Valor Etiqueta (REQUERIDO).
                            Etiquetas.Valor = r[2];
                            //''Se agrega la Etiqueta Personalizada a la lista de Etiquetas
                            listaEtiquetasPersonalizadas.Add(Etiquetas);
                            //e++;
                        }
                        if (datosEtiquetas2 != null)
                        {
                            string[] r = new string[4];
                            r = datosEtiquetas2.Split('|');
                            rnd.EtiquetaPersonalizadaR Etiquetas = new rnd.EtiquetaPersonalizadaR();
                            //''Nombre Etiqueta (REQUERIDO).
                            Etiquetas.Nombre = r[1];
                            //''Valor Etiqueta (REQUERIDO).
                            Etiquetas.Valor = r[2];
                            //''Se agrega la Etiqueta Personalizada a la lista de Etiquetas
                            listaEtiquetasPersonalizadas.Add(Etiquetas);
                            //e++;
                        }
                        if (datosEtiquetas3 != null)
                        {
                            string[] r = new string[4];
                            r = datosEtiquetas3.Split('|');
                            rnd.EtiquetaPersonalizadaR Etiquetas = new rnd.EtiquetaPersonalizadaR();
                            //''Nombre Etiqueta (REQUERIDO).
                            Etiquetas.Nombre = r[1];
                            //''Valor Etiqueta (REQUERIDO).
                            Etiquetas.Valor = r[2];
                            //''Se agrega la Etiqueta Personalizada a la lista de Etiquetas
                            listaEtiquetasPersonalizadas.Add(Etiquetas);
                            //e++;
                        }
                        if (datosEtiquetas4 != null)
                        {
                            string[] r = new string[4];
                            r = datosEtiquetas4.Split('|');
                            rnd.EtiquetaPersonalizadaR Etiquetas = new rnd.EtiquetaPersonalizadaR();
                            //''Nombre Etiqueta (REQUERIDO).
                            Etiquetas.Nombre = r[1];
                            //''Valor Etiqueta (REQUERIDO).
                            Etiquetas.Valor = r[2];
                            //''Se agrega la Etiqueta Personalizada a la lista de Etiquetas
                            listaEtiquetasPersonalizadas.Add(Etiquetas);
                            //e++;
                        }
                        if (datosEtiquetas5 != null)
                        {
                            string[] r = new string[4];
                            r = datosEtiquetas5.Split('|');
                            rnd.EtiquetaPersonalizadaR Etiquetas = new rnd.EtiquetaPersonalizadaR();
                            //''Nombre Etiqueta (REQUERIDO).
                            Etiquetas.Nombre = r[1];
                            //''Valor Etiqueta (REQUERIDO).
                            Etiquetas.Valor = r[2];
                            //''Se agrega la Etiqueta Personalizada a la lista de Etiquetas
                            listaEtiquetasPersonalizadas.Add(Etiquetas);
                            //e++;
                        }
                        datosCFDI.Etiquetas = listaEtiquetasPersonalizadas.ToArray();
                        //string[] datosEtiquetas = new string[e];
                        ////rnd.EtiquetaPersonalizadaR etiquetalista = new rnd.EtiquetaPersonalizadaR();
                        ////etiquetalista.
                        ////datosEtiquetas[0] = datosEtiquetas1;
                        ////// Etiqueta2 (opcional;.
                        ////datosEtiquetas[1] = datosEtiquetas2;

                        //for (int x=0; e != 0; e--)
                        //{
                        //    datosEtiquetas[0] = datosEtiquetas1;
                        //    //// Etiqueta2 (opcional;.

                        //    datosEtiquetas[1] = datosEtiquetas2;
                        //    datosEtiquetas[2] = datosEtiquetas3;
                        //    datosEtiquetas[3] = datosEtiquetas4;
                        //    datosEtiquetas[4] = datosEtiquetas5;
                        //    x = x++;
                        //}
                        
                        //foreach (string s in datosEtiquetas)
                        //{
                            
                        //}
                        //datosEtiquetas[5] = datosEtiquetas6;

                        //*************************************************************************
                        // Sección de variables para la información y descripción de los conceptos.
                        //*************************************************************************
                        // Vector para referenciar los conceptos del comprobante.
                        
                       
                
                        // Secuencia: |cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                int contador = 0;
                
                        foreach(string i in conceptos)
                        {
                            //|cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                            string[] datosConceptos = new string[6];
                            rnd.ConceptoR concepto = new rnd.ConceptoR();
                            datosConceptos = i.Split('|');
                            concepto.cantidad = Convert.ToDecimal(datosConceptos[1]);
                            concepto.noIdentificacion = datosConceptos[3];
                            concepto.unidad = datosConceptos[2];
                            concepto.descripcion = datosConceptos[4];
                            concepto.valorUnitario = Convert.ToDecimal(datosConceptos[5]);
                            concepto.importe = Convert.ToDecimal(datosConceptos[6]);
                            concepto.DetalleConcepto=detalles;
                            //datosConceptos[contador] = i;
                            listaconceptos.Add(concepto);
                            contador=contador+1;
                        }
                        datosCFDI.Conceptos = listaconceptos.ToArray();
                        
           
                // Concepto1
                        //datosConceptos[] = |1|mtro.||Prueba de CFDI concepto1|1|1|);
                        //// Concepto2
                        //datosConceptos[] = |1|mtro.||Prueba de CFDI concepto2|1|1|);
                        //// Concepto3
                        //datosConceptos[] = |1|mtro.|104445|Prueba de CFDI concepto3|1|1|);
                        //// Concepto4
                        //datosConceptos[] = |1|ltro.|104445|Prueba de CFDI concepto4|1|1|);

                        //****************************************************************************************************
                        // Sección de variables para la información aduanera correspondiente a cada concepto usado en el CFDI.
                        //****************************************************************************************************
                        // Vector para referenciar la información aduanera.
                        
                        // Secuencia: |numero|fecha|aduana|
                        // IMPORTANTE: El tamaño del vector de aduanera debe coincidir respectivamente con el de conceptos, ya que es 1 a 1.
                        // Información aduanera para el concepto 1
                //contador=0;
                //foreach(string i in infoaduanera)
                //{
                //    datosInfoAduanera[contador] = i;
                //    contador=contador+1;
                //}
                 //       datosInfoAduanera[] = |777888|2012-02-07|Aduana de Puebla|);
                 //       // Información aduanera para el concepto 2
                 //// Algunos lenguajes no aceptan “nothing”, por lo que puede simplemente establecer un string vacío “” como una excepción a la regla.
                 //       datosInfoAduanera.Add;
                 //       // Información aduanera para el concepto 3
                 //       datosInfoAduanera[] = |444555|2012-02-05||);
                 //       // Información aduanera para el concepto 4
                 //       datosInfoAduanera[] = Nothing);

                        //*************************************************************************************************
                        // Sección de variables para la información de todos los impuestos retenidos utilizados en el CFDI.
                        //*************************************************************************************************
                        // Vector para referenciar los impuestos retenidos.
                        datosCFDI.Impuestos = new rnd.ImpuestosR();
                        datosCFDI.Impuestos.totalImpuestosRetenidos = Convert.ToDecimal(0.0);
                        datosCFDI.Impuestos.totalImpuestosTrasladados = Convert.ToDecimal(16.0);
                        // Secuencia: |NombreImpuesto|impuesto|importe|
                        // Impuesto retenido 1
                        
        //                ''Nombre del impuesto. (REQUERIDO).
        impuestoRetenido.NombreImpuesto = "IVA (IVA 16.00%)";
        //''Impuesto (REQUERIDO).
        impuestoRetenido.Impuesto = "IVA";
        //''Importe de la retencion. (REQUERIDO).
        impuestoRetenido.Importe = Convert.ToDecimal(0.00);
       // ''Se agrega el Impuesto Retenido a la lista de Impuestos Retenidos
        listaImpuestosRetenidos.Add(impuestoRetenido);
       // ''Se agrega la lista de impuestos Retenidos al comprobante
        datosCFDI.Impuestos.Retenciones = listaImpuestosRetenidos.ToArray();
                //datosRetenidos[0] = "|IVA (IVA 16.00%)|IVA|0.00|";
                        // Impuesto retenido 2
                        //datosRetenidos[] = datosRetenidosISR);

                        //***************************************************************************************************
                        // Sección de variables para la información de todos los impuestos trasladados utilizados en el CFDI.
                        //***************************************************************************************************
                        // Vector para referenciar los impuestos trasladados.
        
                datosTraslados = datosTraslados1.Split('|');
                //'Nombre del impuesto. (REQUERIDO).
        ImpuestoTraslado.NombreImpuesto = datosTraslados[1];
        //'Impuesto (REQUERIDO).
        ImpuestoTraslado.Impuesto = datosTraslados[2];
        //'Tasa del Impuesto (REQUERIDO).
        ImpuestoTraslado.Tasa = Convert.ToDecimal(datosTraslados[3]);
        //'Importe del Impuesto. (REQUERIDO).
        ImpuestoTraslado.Importe = Convert.ToDecimal(datosTraslados[4]);
       // 'Se agrega el Impuesto de Traslado a la lista de Impuestos Trasladados
        listaImpuestosTraslados.Add(ImpuestoTraslado);
       // 'Se agrega la lista de Impuestos Trasladados al Comprobante
        datosCFDI.Impuestos.Traslados = listaImpuestosTraslados.ToArray();
                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto trasladado no. 1.
                        

                        //*********************************************************************************************************
                        // Sección de variables para la información de todos los impuestos retenidos locales utilizados en el CFDI.
                        //*********************************************************************************************************
                        // Vector para referenciar los impuestos retenidos locales.
                        

                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto retenido local 1
                        //datosRetenidosLocales[0] = "|IVA (Local 16.00%)|IVA|16.00|0.00|";
                        // Impuesto retenido local 2
                        //datosRetenidosLocales[] = datosRetenidosLocales2);

                //***********************************************************************************************************
                        // Sección de variables para la información de todos los impuestos trasladados locales utilizados en el CFDI.
                        //***********************************************************************************************************
                        // Vector para referenciar los impuestos trasladados locales.
                        

                        // Secuencia: |NombreImpuesto|impuesto|tasa|importe|
                        // Impuesto trasladado local no. 1.
                        //datosTrasladosLocales[0] = "|IVA (Local 16.00%)|IVA|16.00|0.00|";
                        
                coneccion.PreAuthenticate = true;
                //rnd.Credenciales crenden=new rnd.Credenciales();
             
                // |cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                respuesta1 = coneccion.GenerarCFDIv32(datosUsuario, datosCFDI);
                respuesta[0] = respuesta1.OperacionExitosa.ToString();
                respuesta[4] = respuesta1.CBB;
                respuesta[3] = respuesta1.XML.ToString();
                return respuesta;


            }
            catch
            {
                respuesta[2] = respuesta1.ErrorDetallado.ToString();
                respuesta[1] = respuesta1.ErrorGeneral.ToString();
                return respuesta;
            }
        }

        public string[] GenerarFacturaBidimensional()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[3];
            try
            {
                datosUsuario[0] = emisorRFC;
                // Cuenta del usuario (REQUERIDO);. Posición 1.
                datosUsuario[1] = CuentaFEL;
                // Password del usuario (REQUERIDO);. Posición 2.
                datosUsuario[2] = PasswordFEL;

                rnd.ConexionRemota coneccion = new rnd.ConexionRemota();

                return respuesta; //= coneccion.GenerarCodigoBidimensional(datosUsuario, UUID);    
            }
            catch
            {
                return respuesta;
            }
        }

        public string[] cancelacdfi()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[3];
            string[] listaUUID = new string[1];
            rnd.Credenciales crendencial = new rnd.Credenciales();
            crendencial.Password = PasswordFEL;
            crendencial.Usuario = emisorRFC;
            crendencial.Cuenta = CuentaFEL;
            listaUUID[0] = UUID;
            rnd.ConexionRemota coneccion = new rnd.ConexionRemota();
            rnd.RespuestaCancelacionR respu = new rnd.RespuestaCancelacionR();
            rnd.RespuestaCancelacionDetallada re = new rnd.RespuestaCancelacionDetallada();
            try
            {
                //datosUsuario[0] = emisorRFC; ;
                //// Cuenta del usuario (REQUERIDO);. Posición 1.
                //datosUsuario[1] = CuentaFEL;
                //// Password del usuario (REQUERIDO);. Posición 2.
                //datosUsuario[2] = PasswordFEL;
                
                respu = coneccion.CancelarCFDIs(crendencial, listaUUID); //(datosUsuario, listaUUID);
                respuesta[0]=respu.OperacionExitosa.ToString();
                re = respu.UUIDS[0];
                respuesta[2] = respu.Acuse.ToString();
                respuesta[1] = re.RespuestaServicio + ' ' + re.UUID;
                
                
                
                return respuesta; // = coneccion.CancelarCFDI(datosUsuario, listaUUID);

            }
            catch
            {
                if ((respuesta[0] == "True")&&(respuesta[2] == null))
                {
                    try
                    {
                        respuesta[1] = respu.ErrorGeneral.ToString() + ' ' + respu.ErrorDetallado.ToString() + ' ' + re.MensajeError + ' ' + re.UUID;

                        return respuesta;
                    }
                    catch
                    {
                        respuesta[1] = re.MensajeError + ' ' + ' ' + re.UUID;
                        return respuesta;
                    }
                }
                else
                {
                    try
                    {
                        respuesta[1] = respu.ErrorGeneral.ToString() + ' ' + respu.ErrorDetallado.ToString() + ' ' + re.MensajeError + ' ' + re.UUID;

                        return respuesta;
                    }
                    catch
                    {
                        respuesta[1] = re.MensajeError + ' ' + ' ' + re.UUID;
                        return respuesta;
                    }
                }
                
            }
        }

        public string[] enviacfdicorreo()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[2];
            rnd.Credenciales crendencial = new rnd.Credenciales();
            crendencial.Password = PasswordFEL;
            crendencial.Usuario = emisorRFC;
            crendencial.Cuenta = CuentaFEL;
            rnd.ConexionRemota coneccion = new rnd.ConexionRemota();
            rnd.RespuestaOperacion respu = new rnd.RespuestaOperacion();
            try
            {
                //datosUsuario[0] = emisorRFC; ;
                //// Cuenta del usuario (REQUERIDO);. Posición 1.
                //datosUsuario[1] = CuentaFEL;
                //// Password del usuario (REQUERIDO);. Posición 2.
                //datosUsuario[2] = PasswordFEL;
                
                respu = coneccion.EnviarCFDI(crendencial, UUID, Email);
                respuesta[0] = respu.OperacionExitosa.ToString();
                return respuesta; // = coneccion.EnviarCFDI(datosUsuario, UUID, Email);
            }
            catch
                
            {
                
                return respuesta;
            }
        }


        public string[] obtenerpdf()
        {
            string[] datosUsuario = new string[3];
            string[] respuesta = new string[4];
            rnd.Credenciales crendencial = new rnd.Credenciales();
            crendencial.Password = PasswordFEL;
            crendencial.Usuario = emisorRFC;
            crendencial.Cuenta = CuentaFEL;
            rnd.ConexionRemota coneccion = new rnd.ConexionRemota();
            rnd.RespuestaOperacion oper = new rnd.RespuestaOperacion();
            try
            {
                //datosUsuario[0] = emisorRFC; ;
                //// Cuenta del usuario (REQUERIDO);. Posición 1.
                //datosUsuario[1] = CuentaFEL;
                //// Password del usuario (REQUERIDO);. Posición 2.
                //datosUsuario[2] = PasswordFEL;
                
                oper = coneccion.ObtenerPDF(crendencial, UUID);
                respuesta[0] = oper.OperacionExitosa.ToString();
                
                respuesta[3] = oper.PDF.ToString();
                return respuesta; 
            }
            catch
            {
                respuesta[1] = oper.ErrorGeneral.ToString();
                respuesta[2] = oper.ErrorDetallado.ToString();
                return respuesta;
            }
        }


        public string[] consultarcreditos()
        {
            //string[] datosUsuario = new string[3];
            string[] respue = new string[5];
            rnd.Credenciales crendencial = new rnd.Credenciales();
            crendencial.Password = PasswordFEL;
            crendencial.Usuario = emisorRFC;
            crendencial.Cuenta = CuentaFEL;
            rnd.RespuestaNumeroCreditos respuesta = new rnd.RespuestaNumeroCreditos();
            rnd.ConexionRemota coneccion = new rnd.ConexionRemota();
            try
            {
                

                respuesta = coneccion.ObtenerNumeroCreditos(crendencial);
                respue[0] = respuesta.OperacionExitosa.ToString();
                respue[3] = respuesta.CreditosUsados.ToString();
                respue[4] = respuesta.CreditosRestantes.ToString();
                return respue;
            }
            catch
            {
                respue[1] = respuesta.ErrorGeneral.ToString();
                respue[2] = respuesta.ErrorDetallado.ToString();
                return respue;
            }
        }
















            
    }
}
