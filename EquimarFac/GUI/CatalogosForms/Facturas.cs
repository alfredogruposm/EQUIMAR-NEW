using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace EquimarFac.GUI.CatalogosForms
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
        }
        public void cargacuentas()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            dataGridView2.DataSource = facturasdao.devuelvedatospac();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                comboBox2.Items.Add(row.Cells[1].Value.ToString());
            }

        }
        private void Facturas_Load(object sender, EventArgs e)
        {
            actualizagrid();
            comboBox1.SelectedIndex = 0;
            cargacuentas();
        }

        public void actualizagrid()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            if (comboBox1.Text == "Canceladas")
            {
                dataGridView1.DataSource = facturas.devuelvefacturascanceladas();
                
            }
            else
            {
                dataGridView1.DataSource = facturas.devuelvefacturas();
            }
            this.dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.FacturasCtrl facturas = new FacturasCtrl();
            facturas.MdiParent = this.MdiParent;
            facturas.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Reportes.ReporteFactura reporte = new EquimarFac.GUI.CatalogosForms.Reportes.ReporteFactura();
            reporte.factura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
            reporte.Show();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = comboBox1.Text;
                DataView dv;
                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();

                if (campo == "Canceladas")
                {
                    actualizagrid();
                }
                else
                {
                    dv = new DataView(facturas.devuelvefacturas());
                    dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                    dataGridView1.DataSource = dv;
                    
                }
                
            }
            catch
            {
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
            //    GUI.CatalogosForms.IngresaFac facturas = new IngresaFac(this);
            //    facturas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            //    facturas.MdiParent = this.MdiParent;
            //    facturas.Show();
            //}
            //catch
            //{
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                    facturas.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    string resultado = facturas.cancelafactura();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                    }
                }
            }
            catch
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 4)
            {
                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                dataGridView1.DataSource = facturas.devuelvenotascanceladas280616();
            }
            if (comboBox1.SelectedIndex== 3)
            {
                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                dataGridView1.DataSource = facturas.devuelvefacturascanceladas();
            }
            if((comboBox1.SelectedIndex!=4)&& (comboBox1.SelectedIndex != 3))
            {
                actualizagrid();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() == "")
                {
                    MessageBox.Show("Es necesario primero emitir la factura");
                }
                else
                {
                    //if (dataGridView1.CurrentRow.Cells["NumeroProgresivo"].Value.ToString() != "")
                    //{
                    //    GUI.CatalogosForms.NotaCredito notas = new NotaCredito(this);
                    //    notas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    //    notas.textBox8.Text = dataGridView1.CurrentRow.Cells["NumeroProgresivo"].Value.ToString();
                    //    notas.textBox13.Text = dataGridView1.CurrentRow.Cells["Subtotal Nota"].Value.ToString();
                    //    notas.textBox14.Text = dataGridView1.CurrentRow.Cells["Iva Nota"].Value.ToString();
                    //    notas.textBox15.Text = dataGridView1.CurrentRow.Cells["Total Nota"].Value.ToString();
                    //    notas.richTextBox1.Text = dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString();
                    //    notas.lbl_moneda.Text = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
                    //    notas.lblcantidad.Text = dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString();
                    //    notas.Show();
                    //}
                    //else
                    //{
                    GUI.CatalogosForms.NotaCredito notas = new NotaCredito(this);
                    notas.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    notas.textBox8.Text = dataGridView1.CurrentRow.Cells["Factura"].Value.ToString();
                    notas.lbl_moneda.Text = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
                    notas.lblcantidad.Text = dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString();
                    notas.lblcliente.Text = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                    notas.lblAgencia.Text = dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString();
                    notas.lblNumCuenta.Text = dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString();
                    notas.Show();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error probablemente esta es una factura cancelada o es un error de base de datos :" + ex.ToString());
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void cargacliente()
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            catalogos.nombre = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
            dataGridView2.DataSource = catalogos.devuelveclientepornombre();
        }

        public void cargaconceptos()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString());
            dataGridView2.DataSource = facturasdao.devuelveserviciosf();
        }

        public void cargafacturadetalle()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            dataGridView2.DataSource = facturasdao.reportefacturas();
        }

        

        private void generarSFDIToolStripMenuItem_Click(object sender, EventArgs e)
        {
//            DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
//            cargacliente();
//            foreach (DataGridViewRow row in dataGridView2.Rows)
//            {
//                felweb.NombreCliente = row.Cells[1].Value.ToString();
//                felweb.Contacto = row.Cells[6].Value.ToString();
//                felweb.Telefono = row.Cells[4].Value.ToString();
//                felweb.Email = row.Cells[18].Value.ToString();
//                felweb.rfcReceptor = row.Cells[5].Value.ToString();
//                felweb.nombreReceptor = row.Cells[1].Value.ToString();
//                felweb.calleReceptor = row.Cells[10].Value.ToString();
//                felweb.noExteriorReceptor = row.Cells[11].Value.ToString();
//                felweb.noInteriorReceptor = row.Cells[12].Value.ToString();
//                felweb.coloniaReceptor = row.Cells[13].Value.ToString();
//                felweb.localidadReceptor = row.Cells[14].Value.ToString();
//                felweb.referenciaReceptor = row.Cells[1].Value.ToString();
//                felweb.municipioReceptor = row.Cells[1].Value.ToString();
//                felweb.estadoReceptor = row.Cells[1].Value.ToString();
//                felweb.paisReceptor = row.Cells[1].Value.ToString();
//                felweb.codigoPostalReceptor = row.Cells[1].Value.ToString();
//            }
//            felweb.ClaveCFDI = "FAC";
//            felweb.formaDePago = "Pago en una sola exhibición";
//            felweb.parcialidades = "";
//            felweb.condicionesDePago = "";
//            felweb.metodoDePago = dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString();

//            decimal descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["descuento"].Value),
//                porcentajedescuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["porcentajeDescuento"].Value),
//                iva = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Iva"].Value),
//                total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value),
//                subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value),
//                tipodecambio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["tipodecambio"].Value);
            
//            string descuentostring = descuento.ToString("N4");
//            string porcentajedescuentostring = porcentajedescuento.ToString("N4");
//            string ivastring = iva.ToString("N4");
//            string totalstring = total.ToString("N4");
//            string subtotalstring = subtotal.ToString("N4");
//            string tipodecambiostring = tipodecambio.ToString("N4");

//            felweb.descuento = descuentostring;
//            felweb.porcentajeDescuento = porcentajedescuentostring;
//            felweb.motivoDescuento = dataGridView1.CurrentRow.Cells["motivodescuento"].Value.ToString();
//            felweb.moneda = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
//            felweb.tipoCambio = tipodecambiostring;
//            felweb.fechaTipoCambio = dataGridView1.CurrentRow.Cells["fechatipodecambio"].Value.ToString();
//            felweb.totalImpuestosRetenidos = "0.000000";
//            felweb.totalImpuestosTrasladados = ivastring;
//            felweb.subTotal = subtotalstring;
//            felweb.total = totalstring;
//            felweb.importeConLetra = dataGridView1.CurrentRow.Cells["ConceptoT"].Value.ToString();
//            felweb.LugarExpedicion = dataGridView1.CurrentRow.Cells["LugarExpedicion"].Value.ToString();
//            felweb.NumCuentaPago = "";
//            felweb.FolioFiscalOrig = "";
//            felweb.SerieFolioFiscalOrig = "";
//            felweb.FechaFolioFiscalOrig = "";
//            felweb.MontoFolioFiscalOrig = "";
//            //Datos Varios
//            felweb.datosEtiquetas1 = "";
//            felweb.datosEtiquetas2 = "";
//            List<string> datosConceptos = new List<string>(), datosInfoAduanera = new List<string>();
//            cargaconceptos();
//            foreach (DataGridViewRow row in dataGridView2.Rows)
//            {
////El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
////Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					

//                datosConceptos.Add("|1|1|||" + "Servicio " + row.Cells[1].Value.ToString() + " Barco " + row.Cells[2].Value.ToString() + " TRB " + row.Cells[3].Value.ToString() + " Muelles " + row.Cells[4].Value.ToString() + " Fecha " + row.Cells[5].Value.ToString() + " Horario " + row.Cells[6].Value.ToString() + " Tiempo transcurrido " + row.Cells[7].Value.ToString() + "||" + (decimal.Parse(row.Cells[8].Value.ToString()) + decimal.Parse(row.Cells[9].Value.ToString())).ToString() + "||" + row.Cells[8].Value.ToString() + "|");
//                datosInfoAduanera.Add("");
//            }
//            felweb.conceptos = datosConceptos;
//            felweb.infoaduanera = datosInfoAduanera;
//            //felweb.datosConceptos = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
//            //felweb.datosInfoAduanera = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
//            felweb.datosRetenidosIVA = "";
//            felweb.datosRetenidosISR = "";
//            felweb.datosTraslados1 = "|IVA (IVA 16.00%)|IVA|16.00|" + dataGridView1.CurrentRow.Cells["Iva"].Value.ToString() + "|";
//            felweb.datosRetenidosLocales1 = "";
//            felweb.datosRetenidosLocales2 = "";
//            felweb.datosTrasladosLocales1 = "";
//            string[] respuesta = new string[4];
//            respuesta = felweb.GenerarCDFI();
//            if (respuesta[0] == "true")
//            {
//                XmlDocument xmldoc = new XmlDocument();
//                xmldoc.Load(respuesta[3]);
//                xmldoc.Save("C:\\MiXML_Timbrado.xml");
//                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
//                facturasdao.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
//                facturasdao.facturaimpresa = xmldoc.Attributes.GetNamedItem("UUID").ToString();
//                string resultado = facturasdao.insertanumfacturaimpresa();
                

//            }
//            else
//            {
//                MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
//            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea emitir esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    if (dataGridView1.CurrentRow.Cells[2].Value.ToString() == "")
                    {
                        DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
                        cargacliente();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            felweb.NombreCliente = row.Cells[1].Value.ToString();
                            felweb.Contacto = row.Cells[6].Value.ToString();
                            felweb.Telefono = row.Cells[4].Value.ToString();
                            felweb.Email = row.Cells[18].Value.ToString();
                            felweb.rfcReceptor = row.Cells[5].Value.ToString();
                            felweb.nombreReceptor = row.Cells[8].Value.ToString();
                            felweb.calleReceptor = row.Cells[10].Value.ToString();
                            felweb.noExteriorReceptor = row.Cells[11].Value.ToString();
                            felweb.noInteriorReceptor = row.Cells[12].Value.ToString();
                            felweb.coloniaReceptor = row.Cells[13].Value.ToString();
                            felweb.localidadReceptor = row.Cells[14].Value.ToString();
                            felweb.referenciaReceptor = row.Cells[15].Value.ToString();
                            felweb.municipioReceptor = row.Cells[3].Value.ToString();
                            felweb.estadoReceptor = row.Cells[16].Value.ToString();
                            felweb.paisReceptor = row.Cells[17].Value.ToString();
                            felweb.codigoPostalReceptor = row.Cells[19].Value.ToString();
                        }
                        DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                        facturasdao1.Nombre = comboBox2.Text;
                        dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            felweb.CuentaFEL = row.Cells[1].Value.ToString();
                            felweb.emisorRFC = row.Cells[0].Value.ToString();
                            felweb.PasswordFEL = row.Cells[2].Value.ToString();
                        }
                        
                        
                        felweb.ClaveCFDI = "FAC";
                        
                       
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString()=="01- Efectivo.")
                        {
                            felweb.metodoDePago = "01";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "02- Cheque nominativo.")
                        {
                            felweb.metodoDePago = "02";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "03- Transferencia electrónica de fondos.")
                        {
                            felweb.metodoDePago = "03";
                        }
                        if (dataGridView1.CurrentRow.Cells["formaDePago"].Value.ToString() == "04- Tarjeta de Crédito.")
                        {
                            felweb.metodoDePago = "04";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "05- Monedero Electrónico.")
                        {
                            felweb.metodoDePago = "05";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "06- Dinero electrónico².")
                        {
                            felweb.metodoDePago = "06";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "07- Vales de despensa.")
                        {
                            felweb.metodoDePago = "07";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "08- Tarjeta de Débito.")
                        {
                            felweb.metodoDePago = "08";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "28- Tarjeta de Servicio.")
                        {
                            felweb.metodoDePago = "28";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "99- Otros.")
                        {
                            felweb.metodoDePago = "99";
                        }
                        if (dataGridView1.CurrentRow.Cells["metodoDePago"].Value.ToString() == "NA-NA")
                        {
                            felweb.metodoDePago = "NA-NA";
                        }
                        felweb.parcialidades = "";
                        felweb.condicionesDePago = "";
                        felweb.formaDePago = dataGridView1.CurrentRow.Cells["formaDePago"].Value.ToString();
                        string descuentostring;
                        string porcentajedescuentostring;
                        if (dataGridView1.CurrentRow.Cells["descuento"].Value.ToString() == "")
                        {
                            decimal descuento = 0, porcentajedescuento = 0;
                            descuentostring = descuento.ToString("N6");
                            porcentajedescuentostring = porcentajedescuento.ToString("N6");
                        }
                        else
                        {
                            decimal descuento = decimal.Parse(dataGridView1.CurrentRow.Cells["descuento"].Value.ToString()),
                            porcentajedescuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["porcentajeDescuento"].Value);
                            descuentostring = descuento.ToString("N4");
                            porcentajedescuentostring = porcentajedescuento.ToString("N4");
                        }

                        decimal iva = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Iva"].Value),
                         total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value), subtotal;
                        if (dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() != "")
                        {
                            subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value) + Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Descuento"].Value);
                        }
                        else
                        {
                            subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value);
                        }
                        decimal tipodecambio;
                        string tipodecambiostring;
                        if (dataGridView1.CurrentRow.Cells["tipodecambio"].Value.ToString() == "")
                        {

                            tipodecambiostring = "";
                        }
                        else
                        {
                            tipodecambio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["tipodecambio"].Value);
                            tipodecambiostring = tipodecambio.ToString();
                        }


                        string ivastring = iva.ToString("N4");
                        string totalstring = total.ToString("N4");
                        string subtotalstring = subtotal.ToString("N4");


                        felweb.descuento = descuentostring;
                        felweb.porcentajeDescuento = porcentajedescuentostring;
                        felweb.motivoDescuento = dataGridView1.CurrentRow.Cells["motivodescuento"].Value.ToString();
                        felweb.moneda = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
                        felweb.tipoCambio = tipodecambiostring;
                        if (tipodecambiostring == "")
                        {
                            felweb.fechaTipoCambio = "";

                            
                            
                        }
                        else
                        {
                            felweb.fechaTipoCambio = dataGridView1.CurrentRow.Cells["fechatipodecambio"].Value.ToString();
                        }
                        felweb.totalImpuestosRetenidos = "0.000000";
                        felweb.totalImpuestosTrasladados = ivastring;
                        felweb.subTotal = subtotalstring;
                        felweb.total = totalstring;
                        //felweb.importeConLetra = dataGridView1.CurrentRow.Cells["ConceptoT"].Value.ToString();
                        felweb.LugarExpedicion = dataGridView1.CurrentRow.Cells["LugarExpedicion"].Value.ToString();
                        //felweb.NumCuentaPago = "";
                        felweb.FolioFiscalOrig = "";
                        felweb.SerieFolioFiscalOrig = "";
                        felweb.FechaFolioFiscalOrig = "";
                        felweb.MontoFolioFiscalOrig = "";

                        //Datos Varios
                        felweb.datosEtiquetas1 = "|B/R|" + dataGridView1.CurrentRow.Cells["Remolcadores"].Value.ToString() + "|";
                        cargafacturadetalle();
                        if (dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString() == "")
                        {

                            felweb.datosEtiquetas2 = "|Viaje|" + dataGridView2.Rows[0].Cells["Viaje"].Value.ToString() + "|";
                            if (dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString() == "")
                            {
                                felweb.NumCuentaPago = "";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas3 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas4 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                            else
                            {
                                felweb.NumCuentaPago = dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString();
                                //felweb.datosEtiquetas3 = "|NumCuenta|" + dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString() + "|";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas3 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas4 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                        }
                        else
                        {
                            felweb.datosEtiquetas2 = "|Agencia|" + dataGridView1.CurrentRow.Cells["Agencia"].Value.ToString() + "|";
                            felweb.datosEtiquetas3 = "|Viaje|" + dataGridView2.Rows[0].Cells["Viaje"].Value.ToString() +"|";

                            if (dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString() == "")
                            {
                                felweb.NumCuentaPago = "";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas4 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas5 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                            else
                            {
                                felweb.NumCuentaPago = dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString();
                                //felweb.datosEtiquetas4 = "|NumCuenta|" + dataGridView1.CurrentRow.Cells["NumCuenta"].Value.ToString() + "|";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas4 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas5 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                        }
                        

                        felweb.importeConLetra = dataGridView1.CurrentRow.Cells["TotalLetras"].Value.ToString();
                        List<string> datosConceptos = new List<string>(), datosInfoAduanera = new List<string>();
                        cargaconceptos();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            //El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
                            //Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					
                            //|cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                            datosConceptos.Add("|1|1||" + row.Cells[1].Value.ToString() + " B/M: " + row.Cells[2].Value.ToString() + " TRB: " + row.Cells[3].Value.ToString() + " Muelle: " + row.Cells[4].Value.ToString() + " FECHA DE MOVIMIENTO: " + row.Cells[5].Value.ToString() + " HORARIO: " + row.Cells[6].Value.ToString() + " TIEMPO TRANSCURRIDO: " + row.Cells[7].Value.ToString() + "|" + (decimal.Parse(row.Cells[8].Value.ToString()) + decimal.Parse(row.Cells[9].Value.ToString())).ToString() + "|" + row.Cells[8].Value.ToString() + "|");
                            datosInfoAduanera.Add("");
                        }
                        felweb.conceptos = datosConceptos;
                        felweb.infoaduanera = datosInfoAduanera;
                        //felweb.datosConceptos = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        //felweb.datosInfoAduanera = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                        felweb.datosRetenidosIVA = "";
                        felweb.datosRetenidosISR = "";
                        felweb.datosTraslados1 = "|IVA (IVA 16.00%)|IVA|16.00|" + dataGridView1.CurrentRow.Cells["Iva"].Value.ToString() + "|";
                        felweb.datosRetenidosLocales1 = "";
                        felweb.datosRetenidosLocales2 = "";
                        felweb.datosTrasladosLocales1 = "";
                        string[] respuesta = new string[5];


                        respuesta = felweb.GenerarCDFI();
                        if (respuesta[0] == "True")
                        {
                            
                            XmlDocument xmldoc = new XmlDocument();
                            string resultado1 = respuesta[3].ToString();
                            //XmlWriterSettings settings;

                            ////settings = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, CheckCharacters = false };

                            //XmlReader reader = XmlReader.Create(resultado1, settings.Encoding.EncodingName = UTF8Encoding);
                            XmlReaderSettings rs = new XmlReaderSettings();
                            rs.CheckCharacters = false;

                            //// XmlXapResolver is the default resolver.
                            //using (XmlReader reader = XmlReader.Create(resultado1, rs))
                            //{
                            //    xmldoc.in
                            //    xmldoc.Load(reader);
                            //}

                            xmldoc.LoadXml(resultado1);

                            //xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\FacturasMiXML_Timbrado.xml");
                            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                            facturasdao.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            //// Move to an element.
                            //XmlElement root = doc.DocumentElement;

                            //// Get an attribute.
                            //XmlAttribute attr = root.GetAttributeNode("ISBN");

                            //// Display the value of the attribute.
                            //String attrValue = attr.InnerXml;
                            //Console.WriteLine(attrValue);
                            XmlElement elementoxml = xmldoc.DocumentElement;
                            string lstVideos = elementoxml.ChildNodes.Count.ToString();
                            //XmlAttribute atributeelement = elementoxml.get
                            string atributouuid = lstVideos;
                            XmlNodeList nodelist = elementoxml.ChildNodes;
                            XmlNodeList nodelist2 = nodelist.Item(4).ChildNodes;
                           // XmlNodeList nodelist3 = nodelist2.Item(0).ChildNodes;
                            XmlAttributeCollection elemento2 = nodelist2.Item(0).Attributes;
                            //XmlAttribute atrib = elemento2.GetNamedItem("UUID");
                            string nodotexto = elemento2.GetNamedItem("UUID").InnerText;

                            XmlAttributeCollection elemento3 = elementoxml.Attributes;
                            string nodotexto2 = elemento3.GetNamedItem("folio").InnerText;
                            facturasdao.facturaimpresa = nodotexto2;
                            xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\" + nodotexto2 + ".xml");
                            Image imagen = Base64ToImage(respuesta[4]);
                            imagen.Save("C:\\Facturas CFDI\\FacturasCBD\\" + nodotexto2 + ".png");
                            facturasdao.ClaveCFDI = nodotexto;

                            string resultado = facturasdao.insertanumfacturaimpresa();
                            MessageBox.Show("Correcto");
                            actualizagrid();

                        }
                        else
                        {
                            MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para volver a emitir una factura es necesario volver a crearla");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario elegir una cuenta");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                string[] respuesta = new string[3];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.GenerarFacturaBidimensional();

                if (respuesta[0] == "True")
                {

                    Image imagen = Base64ToImage(respuesta[2]);
                    imagen.Save("C:\\Facturas CFDI\\FacturasCBD\\" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + ".png");
                    MessageBox.Show("Guardado correctamente");
                }
                else
                {
                    MessageBox.Show(respuesta[1].ToString());
                }
            }
            else
            {
                MessageBox.Show("Genere el CFDI primero");
            }



        }
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);
           

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta factura?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                        webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                        string[] respuesta = new string[3];
                        DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                        facturasdao1.Nombre = comboBox2.Text;
                        dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            webservice.CuentaFEL = row.Cells[1].Value.ToString();
                            webservice.emisorRFC = row.Cells[0].Value.ToString();
                            webservice.PasswordFEL = row.Cells[2].Value.ToString();
                        }
                        respuesta = webservice.cancelacdfi();
                        if (((respuesta[0] == "True"))&&((respuesta[2] != null)))
                        {
                            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                            facturas.IDFactura = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            facturas.ConceptoT = respuesta[2];
                            string resultado = facturas.cancelafactura();
                            if (resultado != "Correcto")
                            {
                                MessageBox.Show("Error de guardado en la base de datos" + respuesta[1].ToString());
                            }
                            else
                            {
                                MessageBox.Show("Operacion exitosa" + ' ' + respuesta[1].ToString());
                                actualizagrid();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error " + respuesta[1].ToString());
                        }
                            
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error :" + ex);
                }
            }
            else
            {
                MessageBox.Show("Una factura no emitida en CFDI se cancela con el boton de cancelar factura");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea enviar esta factura? Se enviara al Email que tiene registrado del cliente", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
                    DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
                    catalogos.nombre = dataGridView1.CurrentRow.Cells["Cliente"].Value.ToString();
                    dataGridView2.DataSource = catalogos.devuelveclientepornombre();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        felweb.Email = row.Cells[18].Value.ToString();
                    }
                    felweb.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                    string[] resultado = new string[2];
                    DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                    facturasdao1.Nombre = comboBox2.Text;
                    dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        felweb.CuentaFEL = row.Cells[1].Value.ToString();
                        felweb.emisorRFC = row.Cells[0].Value.ToString();
                        felweb.PasswordFEL = row.Cells[2].Value.ToString();
                    }
                    resultado = felweb.enviacfdicorreo();
                    if (resultado[0] == "True")
                    {
                        MessageBox.Show("Enviado");
                    }
                    else
                    {
                        MessageBox.Show(resultado[1]);
                    }
                }
                else
                {
                    MessageBox.Show("Genere el CFDI primero");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                if (comboBox1.SelectedIndex ==4)
                {
                    webservice.UUID = dataGridView1.CurrentRow.Cells["UUID"].Value.ToString();
                }
                else
                { 
                webservice.UUID = dataGridView1.CurrentRow.Cells["ClaveCFDI"].Value.ToString();
                }
                string[] respuesta = new string[4];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.obtenerpdf();
                if (respuesta[0] == "True")
                {
                    byte[] bytes = Convert.FromBase64String(respuesta[3]);
                    //Step 2 is saving the byte array to disk:
                    try
                    {

                        if(comboBox1.SelectedIndex==0)
                        {
                            System.IO.FileStream stream =
                                    new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\" + dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() + ".pdf", FileMode.CreateNew);
                            System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                            writer.Write(bytes, 0, bytes.Length);
                            writer.Close();
                        }
                        if((comboBox1.SelectedIndex==1)|(comboBox1.SelectedIndex==2))
                                {
                            System.IO.FileStream stream =
                                    new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\" + dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() + ".pdf", FileMode.CreateNew);
                            System.IO.BinaryWriter writer =
                        new BinaryWriter(stream);
                            writer.Write(bytes, 0, bytes.Length);
                            writer.Close();
                        }
                             


                        if (comboBox1.SelectedIndex == 3)
                        {
                            if (comboBox1.SelectedIndex == 3)
                            {
                                System.IO.FileStream stream =
                                    new FileStream(@"C:\\Facturas CFDI\\FacturasPDFCanceladas\\" + dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() + ".pdf", FileMode.CreateNew);
                                System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                                writer.Write(bytes, 0, bytes.Length);
                                writer.Close();
                            }
                            else
                            {
                                System.IO.FileStream stream =
                                    new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\" + dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() + ".pdf", FileMode.CreateNew);
                                System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                                writer.Write(bytes, 0, bytes.Length);
                                writer.Close();
                            }
                        }
                        else
                        {
                        }

                        if (comboBox1.SelectedIndex == 4)
                        {
                            if (comboBox1.SelectedIndex == 4)
                            {

                                System.IO.FileStream stream =
                                new FileStream(@"C:\\Facturas CFDI\\FacturasPDFCanceladas\\NC " + dataGridView1.CurrentRow.Cells["Folio"].Value.ToString() + ".pdf", FileMode.CreateNew);
                                System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                                writer.Write(bytes, 0, bytes.Length);
                                writer.Close();
                            }
                            else
                            {
                                System.IO.FileStream stream =
                                    new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\ " + dataGridView1.CurrentRow.Cells["Factura"].Value.ToString() + ".pdf", FileMode.CreateNew);
                                System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                                writer.Write(bytes, 0, bytes.Length);
                                writer.Close();
                            }
                        }
                        else
                        {
                        }

                        
                        MessageBox.Show("Correcto guardado");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error de guardado del pdf, es posible que ya exista o que la carpeta se haya movido o cambiado, verifique la existencia de C:/Facturas CFDI/FacturasPDFCanceladas - Error " + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show(respuesta[1]);
                }
            }
            else
            {
                MessageBox.Show("Genere el CFDI primero");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if ((comboBox2.SelectedIndex !=-1))
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                string[] respuesta = new string[5];
                DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                facturasdao1.Nombre = comboBox2.Text;
                dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    webservice.CuentaFEL = row.Cells[1].Value.ToString();
                    webservice.emisorRFC = row.Cells[0].Value.ToString();
                    webservice.PasswordFEL = row.Cells[2].Value.ToString();
                }
                respuesta = webservice.consultarcreditos();
                if (respuesta[0] == "True")
                {
                    MessageBox.Show(" Creditos usados " + respuesta[3] + " Creditos restantes " + respuesta[4]);
                }
                else
                {
                    MessageBox.Show(" Error: " + respuesta[1] + " " + respuesta[2]);
                }
            }
            else
            {
                MessageBox.Show("Es necesario escoger una cuenta primero");
            }
        }
    }
}
