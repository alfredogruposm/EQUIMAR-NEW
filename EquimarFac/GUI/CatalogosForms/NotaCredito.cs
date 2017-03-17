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
    public partial class NotaCredito : Form
    {
        GUI.CatalogosForms.Facturas facturasgui;
        public NotaCredito(GUI.CatalogosForms.Facturas fr1)
        {
            facturasgui = new Facturas();
            facturasgui = fr1;
            InitializeComponent();
        }
        public decimal descuentopublic { get; set; }

        public decimal descuentoporcentajepublic { get; set; }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox1.Checked;
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox2.Checked;
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            calculaprecios();

        }
        public void carganotasgrid()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(this.Text);
            dataGridView1.DataSource = facturasdao.devuelvenotasdecreditofactura();
        }
        public void carganotasgridcanceladas()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(this.Text);
            dataGridView1.DataSource = facturasdao.devuelvenotasdecreditofacturacanceladas();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                calculaprecios();
                if ((richTextBox1.Text != "") && (textBox8.Text != "") && (textBox13.Text != "") && (comboBox3.SelectedIndex != -1) && (comboBox1.SelectedIndex != -1))
                {
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    //this.IDFactura, this.NumeroProgresivo, this.Fecha, this.Concepto, this.Subtotal, this.Iva, this.Total, this.ConceptoT);
                    facturasdao.IDFactura = int.Parse(this.Text);
                    //facturasdao.Folio = (textBox8.Text);
                    facturasdao.NumeroProgresivo = 1;
                    facturasdao.Fecha = DateTime.Now;
                    facturasdao.Concepto = richTextBox1.Text;
                    facturasdao.Subtotal = decimal.Parse(textBox13.Text);
                    facturasdao.Iva = decimal.Parse(textBox14.Text);
                    facturasdao.Total = decimal.Parse(textBox15.Text);
                    //, this.Descuento_decimal, this.MotivoDescuento_string, this.PorcentajeDescuento_decimal, this.Moneda, this.TipoDeCambio_decimal, this.FechaTipoCambio_datetime, this.UUID, this.Folio);
                    if (((checkBox3.Checked) | (checkBox4.Checked)) && textBox2.Text!="")
                    {
                        if (checkBox3.Checked)
                        {
                            //porcentaje
                            facturasdao.Descuento_decimal = descuentopublic;
                            facturasdao.PorcentajeDescuento_decimal = descuentoporcentajepublic;

                        }

                        if (checkBox4.Checked)
                        {
                            //cantidad
                            facturasdao.Descuento_decimal = descuentopublic;
                            facturasdao.PorcentajeDescuento_decimal = descuentoporcentajepublic;
                        }

                    }
                    else
                    {

                    }
                    facturasdao.MotivoDescuento_string = textBox3.Text;
                    facturasdao.Moneda = comboBox3.Text;
                    if (textBox4.Text != "")
                    {
                        facturasdao.TipoDeCambio_decimal = decimal.Parse(textBox4.Text);
                    }
                    else
                    {
                    }
                    //facturasdao.TipoDeCambio_decimal = decimal.Parse(textBox4.Text);
                    facturasdao.FechaTipoCambio_datetime = (dateTimePicker5.Value);
                    facturasdao.UUID = "";
                    facturasdao.Folio = "";
                    Numalet let = new Numalet();
                    if (comboBox3.Text == "USD")
                    {
                        let.MascaraSalidaDecimal = "00'/100 U.S.D'";
                        let.SeparadorDecimalSalida = "Dolares";
                        //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                        let.ApocoparUnoParteEntera = true;

                        facturasdao.ConceptoT = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                        //Son: un mil ciento veintiún pesos 24/100 M.N.
                    }
                    else
                    {
                        let.MascaraSalidaDecimal = "00'/100 M.N'";
                        let.SeparadorDecimalSalida = "Pesos";
                        //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                        let.ApocoparUnoParteEntera = true;

                        facturasdao.ConceptoT = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                        //Son: un mil ciento veintiún pesos 24/100 M.N.
                    }
                    string resultado = facturasdao.actualiza_notacredito();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        //facturasgui.actualizagrid();
                        //this.Close();
                        carganotasgrid();
                    }

                }
                else
                {
                    MessageBox.Show("Verifique su informacion por datos faltantes");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
        private void NotaCredito_Load(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = 0;
            carganotasgrid();
            cargacuentas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Reportes.ReporteNotas reporte = new EquimarFac.GUI.CatalogosForms.Reportes.ReporteNotas();
            reporte.idfactura = int.Parse(this.Text);
            reporte.Show();
        }
        public void calculaprecios()
        {
            try
            {
                if (((checkBox3.Checked) | (checkBox4.Checked)) && textBox2.Text!="")
                {
                    if (checkBox3.Checked)
                    {
                        if (decimal.Parse(textBox2.Text) > 100)
                        {
                            MessageBox.Show("Es necesario poner un numero menor o igual a 100");
                            textBox2.Text = "";
                        }
                        else
                        {
                            
                            if (checkBox1.Checked)
                            {
                                decimal descuento = (decimal.Parse(textBox2.Text) / 100) * (decimal.Parse(lblcantidad.Text) - (decimal.Parse(textBox1.Text)));
                                descuentopublic = descuento;
                                descuentoporcentajepublic = decimal.Parse(textBox2.Text);
                                textBox13.Text = (decimal.Round((decimal.Parse(textBox1.Text)) - descuento, 2)).ToString();
                                textBox14.Text = decimal.Round(((decimal.Parse(textBox13.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                            }

                            if (checkBox2.Checked)
                            {
                                if (decimal.Parse(textBox1.Text) > 99)
                                {
                                    MessageBox.Show("Es necesario poner un numero menor a 100");
                                }
                                else
                                {
                                    decimal descuento = (decimal.Parse(textBox2.Text) / 100) * (decimal.Parse(lblcantidad.Text) - ((decimal.Parse(lblcantidad.Text) * (decimal.Parse(textBox1.Text) / 100))));
                                    descuentopublic = descuento;
                                    descuentoporcentajepublic = decimal.Parse(textBox2.Text);
                                    textBox13.Text = (decimal.Round(((decimal.Parse(lblcantidad.Text) * (decimal.Parse(textBox1.Text) / 100)) + descuento), 2)).ToString();
                                    textBox14.Text = decimal.Round(((decimal.Parse(textBox13.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                    textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                                }
                            }
                        }
                    }

                    if (checkBox4.Checked)
                    {

                        if (decimal.Parse(textBox2.Text) > decimal.Parse(lblcantidad.Text))
                        {
                            MessageBox.Show("Es necesario poner un numero menor o igual al monto de la factura");
                            textBox2.Text = "";
                        }
                        else
                        {
                            
                            if (checkBox1.Checked)
                            {
                                decimal descuento = (decimal.Parse(textBox2.Text)) + (decimal.Parse(lblcantidad.Text) - (decimal.Parse(textBox1.Text)));
                                descuentopublic = descuento;
                                descuentoporcentajepublic = ((decimal.Parse(textBox2.Text)) * 100) / (decimal.Parse(lblcantidad.Text) - (decimal.Parse(textBox1.Text)));
                                textBox13.Text = (decimal.Round((decimal.Parse(textBox1.Text)) + descuento, 2)).ToString();
                                textBox14.Text = decimal.Round(((decimal.Parse(textBox13.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                            }

                            if (checkBox2.Checked)
                            {
                                decimal descuento = decimal.Parse(textBox2.Text) ;
                                descuentopublic = descuento;
                                descuentoporcentajepublic = ((decimal.Parse(textBox2.Text)) * 100) / (decimal.Parse(lblcantidad.Text) * (decimal.Parse(textBox1.Text) / 100));
                                if (decimal.Parse(textBox1.Text) > 99)
                                {
                                    MessageBox.Show("Es necesario poner un numero menor a 100");
                                }
                                else
                                {
                                    textBox13.Text = (decimal.Round(((decimal.Parse(lblcantidad.Text) * (decimal.Parse(textBox1.Text) / 100)) + descuento), 2)).ToString();
                                    textBox14.Text = decimal.Round(((decimal.Parse(textBox13.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                    textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                                }
                            }
                        }

                    }

                }
                else
                {
                    //MessageBox.Show("Seleccione una opcion");
                }
                if (textBox2.Text == "")
                {
                    try
                    {
                        if ((checkBox1.Checked) | (checkBox2.Checked))
                        {
                            if (checkBox1.Checked)
                            {
                                descuentoporcentajepublic = 0;
                                descuentopublic = 0;
                                textBox13.Text = decimal.Round((decimal.Parse(textBox1.Text)), 2).ToString();
                                textBox14.Text = decimal.Round(((decimal.Parse(textBox1.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                            }

                            if (checkBox2.Checked)
                            {
                                if (decimal.Parse(textBox1.Text) > 99)
                                {
                                    MessageBox.Show("Es necesario poner un numero menor a 100");
                                }
                                else
                                {
                                    descuentoporcentajepublic = 0;
                                    descuentopublic = 0;
                                    textBox13.Text = decimal.Round((decimal.Parse(lblcantidad.Text) * (decimal.Parse(textBox1.Text) / 100)), 2).ToString();
                                    textBox14.Text = decimal.Round(((decimal.Parse(textBox13.Text)) * Convert.ToDecimal(.16)), 2).ToString();
                                    textBox15.Text = decimal.Round(((decimal.Parse(textBox13.Text) + decimal.Parse(textBox14.Text))), 2).ToString();
                                }
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Seleccione una opcion primero");
                        }
                    }
                    catch
                    {
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en el calculo de los precios" + ex.ToString());
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            calculaprecios();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox4.Checked;
            if (checkBox3.Checked == true)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox3.Checked;
            if (checkBox4.Checked == true)
            {
                checkBox4.Checked = false;
                
            }
        }
        public void cargacliente()
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            catalogos.nombre = lblcliente.Text;
            dataGridView2.DataSource = catalogos.devuelveclientepornombre();
        }
        public void cargafacturadetalle()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(this.Text);
            dataGridView2.DataSource = facturasdao.reportefacturas();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿De verdad desea emitir esta nota de credito? Es necesario que esten llenas las casillas de forma de pago y moneda.", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if ((comboBox2.SelectedIndex != -1) && (comboBox3.SelectedIndex != -1) && (comboBox1.SelectedIndex != -1))
                {
                    if (dataGridView1.CurrentRow.Cells["Folio"].Value.ToString() == "")
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
                            felweb.nombreReceptor = row.Cells[1].Value.ToString();
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

                        felweb.ClaveCFDI = "CRE";

                        DAO.FacturasDAO facturasdao1 = new EquimarFac.DAO.FacturasDAO();
                        facturasdao1.Nombre = comboBox2.Text;
                        dataGridView2.DataSource = facturasdao1.devuelvedatospacpornombre();
                        foreach (DataGridViewRow row in dataGridView2.Rows)
                        {
                            felweb.CuentaFEL = row.Cells[1].Value.ToString();
                            felweb.emisorRFC = row.Cells[0].Value.ToString();
                            felweb.PasswordFEL = row.Cells[2].Value.ToString();
                        }
                        if (checkBox5.Checked)
                        {
                            felweb.formaDePago = "Parcialidades";
                        }
                        else
                        {
                            felweb.formaDePago = "Pago en una sola exhibición";
                        }
                        felweb.parcialidades = "";
                        felweb.condicionesDePago = "";



                        if (comboBox1.Text == "01- Efectivo.")
                        {
                            felweb.metodoDePago = "01";
                        }
                        if (comboBox1.Text == "02- Cheque nominativo.")
                        {
                            felweb.metodoDePago = "02";
                        }
                        if (comboBox1.Text == "03- Transferencia electrónica de fondos.")
                        {
                            felweb.metodoDePago = "03";
                        }
                        if (comboBox1.Text == "04- Tarjeta de Crédito.")
                        {
                            felweb.metodoDePago = "04";
                        }
                        if (comboBox1.Text == "05- Monedero Electrónico.")
                        {
                            felweb.metodoDePago = "05";
                        }
                        if (comboBox1.Text == "06- Dinero electrónico².")
                        {
                            felweb.metodoDePago = "06";
                        }
                        if (comboBox1.Text == "07- Vales de despensa.")
                        {
                            felweb.metodoDePago = "07";
                        }
                        if (comboBox1.Text == "08- Tarjeta de Débito.")
                        {
                            felweb.metodoDePago = "08";
                        }
                        if (comboBox1.Text == "28- Tarjeta de Servicio.")
                        {
                            felweb.metodoDePago = "28";
                        }
                        if (comboBox1.Text == "99- Otros.")
                        {
                            felweb.metodoDePago = "99";
                        }
                        if (comboBox1.Text == "NA-NA")
                        {
                            felweb.metodoDePago = "NA-NA";
                        }

                        decimal iva = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Iva"].Value),
                         total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Total"].Value),
                         subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Subtotal"].Value);
                        decimal tipodecambio;
                        string tipodecambiostring;
                        //            NotaCredito.Folio,
                        //NotaCredito.Fecha,
                        //NotaCredito.Concepto,
                        //NotaCredito.Subtotal,
                        //NotaCredito.Iva,
                        //NotaCredito.Total,
                        //NotaCredito.ConceptoT as 'Monto en letras',
                        //NotaCredito.Descuento,
                        //NotaCredito.MotivoDescuento,
                        //NotaCredito.PorcentajeDescuento,
                        //NotaCredito.Moneda,
                        //NotaCredito.TipoDeCambio,
                        //NotaCredito.FechaTipoCambio,
                        //NotaCredito.UUID
                        if ((dataGridView1.CurrentRow.Cells["TipoDeCambio"].Value.ToString() == "")|(dataGridView1.CurrentRow.Cells["TipoDeCambio"].Value.ToString() == "0.00"))
                        {

                            tipodecambiostring = "";
                            felweb.fechaTipoCambio = "";
                        }
                        else
                        {
                            tipodecambio = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["TipoDeCambio"].Value);
                            tipodecambiostring = tipodecambio.ToString();
                            felweb.fechaTipoCambio = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["FechaTipoCambio"].Value).ToShortDateString();
                        }


                        string ivastring = iva.ToString();
                        string totalstring = total.ToString();
                        string subtotalstring = subtotal.ToString();


                        
                        
                        felweb.moneda = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();                        
                        felweb.tipoCambio = tipodecambiostring;
                       
                        felweb.totalImpuestosRetenidos = "0.000000";
                        felweb.totalImpuestosTrasladados = ivastring;
                        felweb.subTotal = subtotalstring;
                        felweb.total = totalstring;
                        felweb.importeConLetra = dataGridView1.CurrentRow.Cells["Monto en letras"].Value.ToString();
                        felweb.LugarExpedicion = "Progreso, Yucatan";
                        //felweb.NumCuentaPago = "";
                        felweb.FolioFiscalOrig = "";
                        felweb.SerieFolioFiscalOrig = "";
                        felweb.FechaFolioFiscalOrig = "";
                        felweb.MontoFolioFiscalOrig = "";
                        //Datos Varios
                        felweb.datosEtiquetas1 = "|Factura folio|" + textBox8.Text + "|";

                        if (lblAgencia.Text == "")
                        {
                            
                            //felweb.datosEtiquetas2 = "|Viaje|" + dataGridView2.Rows[0].Cells["Viaje"].Value.ToString() + "|";
                            if (lblNumCuenta.Text == "")
                            {
                                felweb.NumCuentaPago = "";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas2 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas3 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                            else
                            {
                                felweb.NumCuentaPago = lblNumCuenta.Text;
                                //felweb.datosEtiquetas3 = "|NumCuenta|" + lblNumCuenta.Text + "|";
                                cargacliente();
                                foreach (DataGridViewRow row in dataGridView2.Rows)
                                {
                                    if ((row.Cells[16].Value.ToString() == "Estado Extranjero") && (row.Cells[17].Value.ToString() == "País Extranjero"))
                                    {
                                        felweb.datosEtiquetas2 = "|País|" + row.Cells["PaisExtranjero"].Value.ToString() + "|";
                                        felweb.datosEtiquetas3 = "|Estado|" + row.Cells["EstadoExtranjero"].Value.ToString() + "|";
                                    }

                                }
                            }
                        }
                        else
                        {
                            felweb.datosEtiquetas2 = "|Agencia|" + lblAgencia.Text + "|";
                            //felweb.datosEtiquetas3 = "|Viaje|" + dataGridView2.Rows[0].Cells["Viaje"].Value.ToString() + "|";

                            if (lblNumCuenta.Text == "")
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
                                felweb.NumCuentaPago = lblNumCuenta.Text;
                                //felweb.datosEtiquetas4 = "|NumCuenta|" + lblNumCuenta.Text + "|";
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





                        
                        
                        //decimal descuentodecimal;
                        
                        //if (dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() != "")
                        //{
                        //    descuentodecimal = decimal.Parse(dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString());
                        //}
                        //else
                        //{
                        //    descuentodecimal = 0;
                        //}

                        felweb.importeConLetra = dataGridView1.CurrentRow.Cells["Monto en letras"].Value.ToString();
                        List<string> datosConceptos = new List<string>(), datosInfoAduanera = new List<string>();
                        ////cargaconceptos();
                        ////foreach (DataGridViewRow row in dataGridView2.Rows)
                        ////{
                        ////El esquema, para incluir los conceptos sera el siguiente: | Cantidad | Unidad | noIdentificacion | Descripcion | valorUnitario | Importe |					
                        ////Haciendo uso del caracter "|" pipe, para separar cada uno de los valores correspondientes. Ejemplo: |1|mtro.||alambre 1/2 pulgada|1.0|1.0|					
                        ////|cantidad|unidad|noIdentificacion|descripcion|valorUnitario|importe|
                        decimal valorconcepto = 0;
                        if ((dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() == "") | (dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() == "0.00"))
                        {
                            valorconcepto = (decimal.Parse(dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString()));
                        }
                        else
                        {
                            valorconcepto = (decimal.Parse(dataGridView1.CurrentRow.Cells["Subtotal"].Value.ToString())) - (decimal.Parse(dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString()));
                        }
                        
                        datosConceptos.Add("|1|1||" + dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString() + "|" + valorconcepto.ToString() + "|" + valorconcepto.ToString() + "|");
                        datosInfoAduanera.Add("");
                        // }
                        string descuentostring = "";
                        string porcentajedescuentostring = "";
                        if ((dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() == "") | (dataGridView1.CurrentRow.Cells["Descuento"].Value.ToString() == "0.00"))
                        {
                            felweb.descuento = "0";
                            felweb.porcentajeDescuento = "0";
                            felweb.motivoDescuento = "";
                        }
                        else
                        {
                            decimal descuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Descuento"].Value),
                            porcentajedescuento = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["PorcentajeDescuento"].Value);
                            descuentostring = descuento.ToString();
                            porcentajedescuentostring = porcentajedescuento.ToString();
                            felweb.descuento = "0";
                            felweb.porcentajeDescuento = "0";
                            felweb.motivoDescuento = "";
                            datosConceptos.Add("|1|1||" + dataGridView1.CurrentRow.Cells["MotivoDescuento"].Value.ToString() + "|" + descuentostring + "|" + descuentostring + "|");
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
                            facturasdao.IDNotaCredito = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
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
                            XmlNodeList nodelist3 = nodelist2.Item(0).ChildNodes;
                            XmlAttributeCollection elemento2 = nodelist2.Item(0).Attributes;
                            //XmlAttribute atrib = elemento2.GetNamedItem("UUID");
                            string nodotexto = elemento2.GetNamedItem("UUID").InnerText;

                            XmlAttributeCollection elemento3 = elementoxml.Attributes;
                            string nodotexto2 = elemento3.GetNamedItem("folio").InnerText;
                            facturasdao.Folio = nodotexto2;
                            xmldoc.Save("C:\\Facturas CFDI\\FacturasXML\\NC " + nodotexto2 + ".xml");
                            Image imagen = Base64ToImage(respuesta[4]);
                            imagen.Save("C:\\Facturas CFDI\\FacturasCBD\\NC " + nodotexto2 + ".png");
                            facturasdao.UUID = nodotexto;

                            string resultado = facturasdao.actualizanotascreditocfdi();
                            MessageBox.Show("Correcto");
                            carganotasgrid();

                        }
                        else
                        {
                            MessageBox.Show("Error de generacion del CFDI " + respuesta[1] + " " + respuesta[2]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para volver a emitir una Nota es necesario volver a crearla");
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario elegir una cuenta, la moneda y el tipo de pago");
                }
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells["UUID"].Value.ToString() != "")
                {
                    DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                    webservice.UUID = dataGridView1.CurrentRow.Cells["UUID"].Value.ToString();
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
                        imagen.Save("C:\\Facturas CFDI\\FacturasCBD\\NC " + dataGridView1.CurrentRow.Cells["Folio"].Value.ToString() + ".png");
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
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString());
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
            if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("¿De verdad desea cancelar esta nota de credito?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                        webservice.UUID = dataGridView1.CurrentRow.Cells["UUID"].Value.ToString();
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
                        if (respuesta[0] == "True")
                        {
                            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                            facturas.IDNotaCredito = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                            facturas.ConceptoT = respuesta[2];
                            string resultado = facturas.cancelanotasdecreditocfdi();
                            if (resultado != "Correcto")
                            {
                                MessageBox.Show("Error :" + resultado[1].ToString());
                            }
                            else
                            {
                                MessageBox.Show("Operacion exitosa" + ' ' +
                                    respuesta[1].ToString());
                                carganotasgrid();
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Para cancelar un CFDI es necesario emitirlo primero");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Folio"].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO felweb = new EquimarFac.DAO.FelWebServiceDAO();
                DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
                catalogos.nombre = lblcliente.Text;
                dataGridView2.DataSource = catalogos.devuelveclientepornombre();
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    felweb.Email = row.Cells[18].Value.ToString();
                }
                felweb.UUID = dataGridView1.CurrentRow.Cells["UUID"].Value.ToString();
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

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Folio"].Value.ToString() != "")
            {
                DAO.FelWebServiceDAO webservice = new EquimarFac.DAO.FelWebServiceDAO();
                webservice.UUID = dataGridView1.CurrentRow.Cells["UUID"].Value.ToString();
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
                        System.IO.FileStream stream;
                        if (comboBox4.SelectedIndex == 1)
                        {
                            stream =
                                new FileStream(@"C:\\Facturas CFDI\\FacturasPDFCanceladas\\" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ".pdf", FileMode.CreateNew);
                        }
                        else
                        {
                            stream =
                                new FileStream(@"C:\\Facturas CFDI\\FacturasPDF\\NC " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ".pdf", FileMode.CreateNew);
                        }
                        System.IO.BinaryWriter writer =
                            new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                        MessageBox.Show("Correcto guardado");
                    }
                    catch
                    {
                        MessageBox.Show("Esta nota de credito ya existe o la carpeta de guardado no existe");
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                carganotasgrid();
            }
            else
            {
                carganotasgridcanceladas();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
