using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EquimarFac.DAO;

namespace EquimarFac.GUI.CatalogosForms
{
    public partial class FacturasCtrl : Form
    {
        
        public FacturasCtrl()
        {
            
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.ClientesBusqueda clientes = new ClientesBusqueda(this);
            clientes.MdiParent = this.MdiParent;
            clientes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            remolcadores.Text = "1";
            remolcadores.MdiParent = this.MdiParent;
            remolcadores.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            remolcadores.Text = "2";
            remolcadores.MdiParent = this.MdiParent;
            remolcadores.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.RemolcadoresBusqueda remolcadores = new RemolcadoresBusqueda(this);
            remolcadores.Text = "3";
            remolcadores.MdiParent = this.MdiParent;
            remolcadores.Show();
        }
        public void checartrb()
        {
            if (Convert.ToInt32(textBox9.Text) <= 500)
            {
                //descuentot += "30% Descuento sobre total por TRB Menor a 500 Ton";
                textBox17.Text = "30% Descuento sobre total por TRB Menor a 500 Ton";
                //costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.70);
                //descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.30);
                checkBox7.Checked = true;
                textBox16.Text = "30";
            }
            if ((Convert.ToInt32(textBox9.Text) >= 501) && (Convert.ToInt32(textBox9.Text) <= 1500))
            {
                //descuentot += "5% Descuento sobre total por TRB Menor a 1500 Ton";
                textBox17.Text = "5% Descuento sobre total por TRB Menor a 1500 Ton";
                //costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.95);
                //descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.05);
                checkBox7.Checked = true;
                textBox16.Text = "5";

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.BarcosBusqueda barcos = new BarcosBusqueda(this);
            barcos.MdiParent = this.MdiParent;
            barcos.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.ServiciosBusqueda servicios = new ServiciosBusqueda(this);
            servicios.MdiParent = this.MdiParent;
            servicios.Show();
        }

        public int numeroinsertados()
        {
            DAO.FacturasDAO facturas=new EquimarFac.DAO.FacturasDAO();
            return facturas.devuelveidremolcadores(); 
        }


        public string insertaremolcadores()
        {
            //try
            //{
                if (lbl_rinsertados.Text == "1")
                {
                    return "Correcto";
                }
                else
                {
                    DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                    facturas.Remolcador1 = int.Parse(id_R1.Text);

                    if (id_R2.Text != "")
                    {
                        facturas.Remolcador2 = int.Parse(id_R2.Text);
                    }

                    if (id_R3.Text != "")
                    {
                        facturas.Remolcador3 = int.Parse(id_R3.Text);
                    }

                    return facturas.insertaRemolcadores();
                }
            //}
            //catch
            //{
            //    return "Error (inserta remolcadores)";
            //}
        }

        public string insertafacturaparcial()
        {
            try
            {
                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                facturasdao.Fecha = Convert.ToDateTime(dateTimePicker4.Value.ToShortDateString());
                facturasdao.ClienteFactura = int.Parse(lbl_idCliente.Text);
                facturasdao.BarcoID = int.Parse(lb_idbarco.Text);
                facturasdao.Remolcador = int.Parse(idrinsertados.Text);
                return facturasdao.insertaparcialfactura();
            }
            catch
            {
                return "Error, vuelva a intentarlo";
            }
        }

        public int numerofactura()
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            return facturas.devuelveidfacturas();
        }
        string descuentot="";
        decimal descuento=0;
        public decimal calculaimporte()
        {
            try
            {
                decimal DCB1 = decimal.Parse(CB1.Text);
                decimal DCB2 = decimal.Parse(CB2.Text);
                decimal DCB3 = decimal.Parse(CB3.Text);
                decimal DCB4 = decimal.Parse(CB4.Text);
                decimal DREP = decimal.Parse(REP.Text);
                decimal DREM = decimal.Parse(REM.Text);
                decimal DREG = decimal.Parse(REG.Text);
                decimal DSCA = decimal.Parse(SCA.Text);
                decimal DSCB = decimal.Parse(SCB.Text);
                decimal DSCC = decimal.Parse(SCC.Text);
                decimal importehoras = decimal.Truncate(Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60));
                decimal numerominutos = Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).Minutes); ;
                decimal cuotabasica = 0;
                decimal costototal = 0;
                decimal ServicioContinuoR1 = 0, ServicioContinuoR2 = 0, ServicioContinuoR3 = 0;
                int trb = int.Parse(textBox9.Text);
                if (importehoras < 1)
                {
                    importehoras = 1;
                    numerominutos = 0;

                }
                //if (importehoras == 1)
                //{
                //    numerominutos = 0;
                //}
                //if (importehoras > 1)
                //{
                //    //numerominutos = Convert.ToDecimal((((((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60) % 1) * 15) / 25));
                //    numerominutos = Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).Minutes);
                //}
                decimal importeminutos = 0;
                if ((numerominutos >= 1)&&(numerominutos <= 15))
                {
                    importeminutos = 25;
                }
                if ((numerominutos > 15) && (numerominutos <= 30))
                {
                    importeminutos = 50;
                }
                if ((numerominutos > 30) && (numerominutos <= 45))
                {
                    importeminutos = 75;
                }
                if ((numerominutos > 45) && (numerominutos <= 59))
                {
                    importeminutos = 100;
                }

                if (checkBox1.Checked == true)
                {
                    if (lbl_tamaño1.Text == "Chico")
                    {
                        ServicioContinuoR1 = DSCA;
                    }
                    if (lbl_tamaño1.Text == "Mediano")
                    {
                        ServicioContinuoR1 = DSCB;
                    }
                    if (lbl_tamaño1.Text == "Grande")
                    {
                        ServicioContinuoR1 = DSCC;
                    }

                    if (id_R2.Text != "")
                    {
                        if (lbl_tamaño2.Text == "Chico")
                        {
                            ServicioContinuoR2 = DSCA;
                        }
                        if (lbl_tamaño2.Text == "Mediano")
                        {
                            ServicioContinuoR2 = DSCB;
                        }
                        if (lbl_tamaño2.Text == "Grande")
                        {
                            ServicioContinuoR2 = DSCC;
                        }
                    }

                    if (id_R3.Text != "")
                    {
                        if (lbl_tamaño3.Text == "Chico")
                        {
                            ServicioContinuoR3 = DSCA;
                        }
                        if (lbl_tamaño3.Text == "Mediano")
                        {
                            ServicioContinuoR3 = DSCB;
                        }
                        if (lbl_tamaño3.Text == "Grande")
                        {
                            ServicioContinuoR3 = DSCC;
                        }
                    }

                    if (checkBox2.Checked == true)
                    {
                        cuotabasica = (ServicioContinuoR1 + ServicioContinuoR2 + ServicioContinuoR3) * Convert.ToDecimal(1.5);
                    }
                    else
                    {
                        cuotabasica = ServicioContinuoR1 + ServicioContinuoR2 + ServicioContinuoR3;
                    }

                    costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));

                }
                else
                {


                    if ((trb >= 1501) && (trb <= 4500))
                    {
                        cuotabasica = DCB1;
                    }

                    if ((trb >= 4501) && (trb <= 10000))
                    {
                        cuotabasica = DCB2;
                    }

                    if ((trb >= 10001) && (trb <= 15000))
                    {
                        cuotabasica = DCB3;
                    }

                    if ((trb > 15000))
                    {
                        cuotabasica = DCB4;
                    }


                    if ((trb <= 500) | ((trb >= 501) && (trb <= 1500)))
                    {
                        if (checkBox2.Checked == true)
                        {
                            cuotabasica = Convert.ToDecimal(DCB1 * Convert.ToDecimal(1.5));
                        }
                        else
                        {
                            cuotabasica = DCB1;
                        }

                        ////if ((id_R1.Text != "") && (id_R2.Text == "") && (id_R3.Text == ""))
                        ////{
                        ////    descuentot += " 10% descuento sobre Cuota basica por 1 remolcador";
                        ////    descuento += cuotabasica * Convert.ToDecimal(.10);
                        ////    cuotabasica = cuotabasica * Convert.ToDecimal(.90);

                        ////}
                        //if (trb <= 500)
                        //{
                        //    descuentot += "30% Descuento sobre total por TRB Menor a 500 Ton";
                        //    textBox17.Text = "30% Descuento sobre total por TRB Menor a 500 Ton";
                        //    costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.70);
                        //    descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.30);
                        //    checkBox7.Checked = true;
                        //    textBox16.Text = "30";
                        //}
                        //if ((trb >= 501) && (trb <= 1500))
                        //{
                        //    descuentot += "5% Descuento sobre total por TRB Menor a 1500 Ton";
                        //    textBox17.Text = "5% Descuento sobre total por TRB Menor a 1500 Ton";
                        //    costototal = ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.95);
                        //    descuento += ((cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100))) * Convert.ToDecimal(.05);
                        //    checkBox7.Checked = true;
                        //    textBox16.Text = ".05";

                        //}
                    }
                    else
                    {


                        if (checkBox2.Checked == true)
                        {
                            cuotabasica = cuotabasica * Convert.ToDecimal(1.5);
                        }

                        //if ((id_R1.Text != "") && (id_R2.Text == "") && (id_R3.Text == ""))
                        //{
                        //    descuentot += " 10% descuento sobre Cuota basica por 1 remolcador";
                        //    descuento += cuotabasica * Convert.ToDecimal(.10);
                        //    cuotabasica = cuotabasica * Convert.ToDecimal(.90);
                        //}
                    }

                    if (id_R3.Text == "")
                    {
                        costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
                    }
                    else
                    {
                        if (lbl_tamaño3.Text == "Chico")
                        {
                            cuotabasica = cuotabasica + DREP;
                            costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
                        }
                        if (lbl_tamaño3.Text == "Mediano")
                        {
                            cuotabasica = cuotabasica + DREM;
                            costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
                        }
                        if (lbl_tamaño3.Text == "Grande")
                        {
                            cuotabasica = cuotabasica + DREG;
                            costototal = (cuotabasica * importehoras) + (cuotabasica * (importeminutos / 100));
                        }
                    }


                    
                }

                if (((checkBox7.Checked) | (checkBox8.Checked)) && textBox16.Text != "")
                {
                    if (descuentot != "")
                    {
                        
                    }
                    else
                    {
                        descuentot += textBox17.Text;
                        if (checkBox7.Checked)
                        {
                            descuento += costototal * ((decimal.Parse(textBox16.Text)) / 100);
                            costototal = costototal * ((100 - decimal.Parse(textBox16.Text)) / 100);
                        }
                        else
                        {
                            descuento += ((decimal.Parse(textBox16.Text)));
                            costototal = costototal - ((decimal.Parse(textBox16.Text)));
                        }
                    }
                    
                    
                }

                if (comboBox3.Text == "USD")
                {
                    if (checkBox4.Checked)
                    {
                        return costototal;
                    }
                    else
                    {
                        if (textBox18.Text != "")
                        {
                            descuento = descuento / decimal.Parse(textBox18.Text);
                            return costototal / decimal.Parse(textBox18.Text);
                        }
                        else
                        {
                            MessageBox.Show("Es necesario que especifique el tipo de cambio");
                            return -1;
                        }
                    }
                }
                else
                {
                    return costototal;
                }

                
            }
            catch
            {
                return -1;
            }
        }

        public void actualizagrid()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
            dataGridView1.DataSource = facturasdao.devuelveserviciosf();
        }

        public void insertaviaje()
        {
            try
            {
                DAO.FacturasDAO fac = new FacturasDAO();
                fac.IDFactura = int.Parse(lbl_idfactura.Text);
                fac.viaje = textBox20.Text;
                fac.insertaviaje();
            }
            catch
            {
                MessageBox.Show("Error insertaviaje");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lb_idbarco.Text != "") && (lbl_idCliente.Text != "") && (id_R1.Text != "") && (textBox11.Text != "") && (textBox19.Text != "") && (textBox20.Text != "") && (comboBox1.SelectedIndex != -1) && (((comboBox3.SelectedIndex==1)&&(textBox21.Text!=""))|comboBox3.SelectedIndex!=-1))
                {
                    string resultado = insertaremolcadores();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        lbl_rinsertados.Text = "1";
                        if (idrinsertados.Text == "")
                        {
                            idrinsertados.Text = numeroinsertados().ToString();
                        }
                        if (lbl_idfactura.Text == "")
                        {

                            string resultado2 = insertafacturaparcial();
                            if (resultado2 != "Correcto")
                            {
                                MessageBox.Show(resultado2);
                            }
                            else
                            {
                                lbl_idfactura.Text = numerofactura().ToString();
                                insertaviaje();

                            }
                        }
                        else
                        {
                            
                            bool descuentoresultado;
                            //if (textBox16.Text != "")
                            //{
                            //    descuentoresultado = ((int.Parse(textBox16.Text) < 0) | (int.Parse(textBox16.Text) > 99));
                            //}
                            //else
                            //{
                            //    descuentoresultado = false;
                            //}
                            if (((checkBox7.Checked) | (checkBox8.Checked)) && textBox16.Text != "")
                            {
                                //descuentot += " " + textBox16.Text + "% de descuento";
                                if (checkBox7.Checked)
                                {
                                    descuentoresultado = ((int.Parse(textBox16.Text) < 0) | (int.Parse(textBox16.Text) > 99));
                                }
                                else
                                {
                                    descuentoresultado = false;
                                }

                            }
                            else
                            {
                                descuentoresultado = false;
                            }
                            
                            if((descuentoresultado==false))
                            {
                                //(this.IDFactura, this.Servicio, this.BarcoT, this.TRB, this.Muelles, this.FechaT, this.Horario, this.TiempoTrancurrido, this.Importe);
                                DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
                                facturas.IDFactura = int.Parse(lbl_idfactura.Text);
                                string service;
                                service = textBox11.Text;
                                if (checkBox1.Checked)
                                {
                                    service = service + " SERVICIO CONTINUO";
                                }
                                
                                if (checkBox3.Checked)
                                {
                                    service = service + " Recargo extra 60%";
                                }
                                if (((checkBox9.Checked) | (checkBox10.Checked)) && textBox22.Text != "")
                                {
                                    service += " SobreCuota : " + textBox22.Text;
                                }
                                facturas.Servicio = service;
                                facturas.BarcoT = textBox8.Text;
                                facturas.TRB = textBox9.Text;
                                facturas.Muelles = textBox12.Text;
                                facturas.FechaT = dateTimePicker1.Value.ToShortDateString();
                                if ((checkBox5.Checked) | (checkBox6.Checked))
                                {
                                    facturas.Horario = "Solicitado a " + dateTimePicker2.Text + " Cancelado a " + dateTimePicker3.Text;

                                }
                                else
                                {
                                    facturas.Horario = "De " + dateTimePicker2.Text + " a " + dateTimePicker3.Text;
                                }
                                decimal redondeado = decimal.Truncate(Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60));
                                if (((redondeado < 1) && (redondeado > 0))|(redondeado==0))
                                {
                                    redondeado = 1;
                                }
                                else
                                {
                                    decimal numerominutos = Convert.ToDecimal((dateTimePicker3.Value - dateTimePicker2.Value).Minutes); ;
                                    if ((numerominutos >= 1) && (numerominutos <= 15))
                                    {
                                        redondeado += Convert.ToDecimal(0.25);
                                    }
                                    if ((numerominutos > 15) && (numerominutos <= 30))
                                    {
                                        redondeado += Convert.ToDecimal(.50);
                                    }
                                    if ((numerominutos > 30) && (numerominutos <= 45))
                                    {
                                        redondeado += Convert.ToDecimal(.75);
                                    }
                                    if ((numerominutos > 45) && (numerominutos <= 59))
                                    {

                                        redondeado += 1;
                                    }
                                }


                                facturas.TiempoTrancurrido = redondeado.ToString() + " Hrs.";
                                decimal import;
                                if (checkBox1.Checked)
                                {
                                    double horas = ((dateTimePicker3.Value - dateTimePicker2.Value).TotalMinutes / 60);
                                    if (horas < 2)
                                    {
                                        MessageBox.Show("Para uso Servicio Continuo es un minimo de dos horas");
                                    }
                                    else
                                    {
                                        import = calculaimporte();
                                        if (import == -1)
                                        {
                                            MessageBox.Show("Error en el calculo del importe, verifique sus datos");
                                        }
                                        else
                                        {
                                            if (checkBox6.Checked)
                                            {
                                                
                                                descuento += import * Convert.ToDecimal(0.75);
                                                import = import * Convert.ToDecimal(0.25);
                                            }
                                            if (checkBox5.Checked)
                                            {
                                                
                                                descuento += import * Convert.ToDecimal(0.5);
                                                import = import * Convert.ToDecimal(0.5);
                                            }
                                            if (checkBox3.Checked)
                                            {
                                                import = import * Convert.ToDecimal(1.6);
                                            }
                                            
                                            if (((checkBox9.Checked) | (checkBox10.Checked)) && textBox22.Text != "")
                                            {
                                                //descuentot += " " + textBox16.Text + "% de descuento";
                                                if (checkBox9.Checked)
                                                {
                                                    facturas.Importe = import + (import * ((decimal.Parse(textBox23.Text))/100));
                                                }
                                                else
                                                {
                                                    facturas.Importe = (import + decimal.Parse(textBox23.Text));
                                                }

                                            }
                                            else
                                            {
                                                facturas.Importe = import;
                                            }
                                            resultado = facturas.insertaserviciosfactura();
                                            if (resultado != "Correcto")
                                            {
                                                MessageBox.Show(resultado);
                                            }
                                            else
                                            {
                                                DAO.FacturasDAO facturasdao = new FacturasDAO();
                                                facturasdao.IDFServicios = facturasdao.devuelveiddetallefac();
                                                if (checkBox6.Checked)
                                                {
                                                    descuentot = descuentot + " Cargo total del 25% por cancelacion";
                                                }
                                                if (checkBox5.Checked)
                                                {
                                                    descuentot = descuentot + " Cargo total del 50% por cancelacion";
                                                }
                                                facturasdao.DescuentoT = this.descuentot;
                                                if (descuento == 0)
                                                {
                                                }
                                                else
                                                {
                                                    facturasdao.Importe = this.descuento;
                                                }
                                                
                                                string resultado3 = facturasdao.insertaserviciosdescuento();
                                                if (resultado3 != "Correcto")
                                                {
                                                    MessageBox.Show(resultado3);
                                                }
                                                else
                                                {
                                                    descuento = 0;
                                                    descuentot = "";
                                                    actualizagrid();
                                                    calculatotales();
                                                    textBox18.ReadOnly = true;
                                                    textBox16.ReadOnly = true;
                                                    textBox17.ReadOnly = true;
                                                    textBox20.ReadOnly = true;
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    import = calculaimporte();
                                    if (import == -1)
                                    {
                                        MessageBox.Show("Error en el calculo del importe, verifique sus datos");
                                    }
                                    else
                                    {
                                        if (checkBox6.Checked)
                                        {
                                            descuento += import * Convert.ToDecimal(0.75);
                                            import = import * Convert.ToDecimal(0.25);
                                        }
                                        if (checkBox5.Checked)
                                        {
                                            descuento += import * Convert.ToDecimal(0.5);
                                            import = import * Convert.ToDecimal(0.5);
                                        }
                                        if (checkBox3.Checked)
                                        {
                                            import = import * Convert.ToDecimal(1.6);
                                        }
                                        if (((checkBox9.Checked) | (checkBox10.Checked)) && textBox22.Text != "")
                                        {
                                            //descuentot += " " + textBox16.Text + "% de descuento";
                                            if (checkBox9.Checked)
                                            {
                                                facturas.Importe = import + (import * ((decimal.Parse(textBox23.Text)) / 100));
                                            }
                                            else
                                            {
                                                facturas.Importe = (import + decimal.Parse(textBox23.Text));
                                            }

                                        }
                                        else
                                        {
                                            facturas.Importe = import;
                                        }
                                        resultado = facturas.insertaserviciosfactura();
                                        if (resultado != "Correcto")
                                        {
                                            MessageBox.Show(resultado);
                                        }
                                        else
                                        {
                                                DAO.FacturasDAO facturasdao = new FacturasDAO();
                                                facturasdao.IDFServicios = facturasdao.devuelveiddetallefac();
                                                if (checkBox6.Checked)
                                                {
                                                    descuentot = descuentot + " Descuento del 75% por cancelacion";
                                                }
                                                if (checkBox5.Checked)
                                                {
                                                    descuentot = descuentot + " Descuento del 50% por cancelacion";
                                                }
                                                facturasdao.DescuentoT = this.descuentot;
                                                if (descuento == 0)
                                                {
                                                }
                                                else
                                                {
                                                    facturasdao.Importe = this.descuento;
                                                }
                                                string resultado3 = facturasdao.insertaserviciosdescuento();
                                                if (resultado3 != "Correcto")
                                                {
                                                    MessageBox.Show(resultado3);
                                                }
                                                else
                                                {
                                                    descuento = 0;
                                                    descuentot = "";
                                                    actualizagrid();
                                                    calculatotales();
                                                    textBox18.ReadOnly = true;
                                                    textBox16.ReadOnly = true;
                                                    textBox17.ReadOnly = true;
                                                }

                                        }
                                    }
                                }



                            }
                            else
                            {
                                MessageBox.Show("Descuento fuera de los limites permitidos");
                            }
                            
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario ingresar todos los datos");
                }
            }
            catch
            {
                MessageBox.Show("Ha habido algun error, verifique sus datos");
            }
        }

        

        public void limpiatextos()
        {
            textBox11.Text = "";
            textBox16.Text = "";
            textBox12.Text = "";
            checkBox6.CheckState = CheckState.Unchecked;
            checkBox5.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Unchecked;
            checkBox1.CheckState = CheckState.Unchecked;
        }

        public void calculatotales()
        {
            try
            {
                double resultado = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    resultado += Convert.ToDouble(row.Cells["Importe"].Value);
                }
                if (resultado != 0)
                {
                    textBox13.Text = Convert.ToString(resultado);
                    textBox14.Text = (resultado * .16).ToString();
                    textBox15.Text = (resultado * 1.16).ToString();
                }
                else
                {
                    textBox18.ReadOnly = false;
                    textBox16.ReadOnly = false;
                    textBox17.ReadOnly = false;
                }
            }
            catch
            {
                MessageBox.Show("Error en el calculo de totales");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox5.CheckState = CheckState.Unchecked;
                checkBox3.CheckState = CheckState.Unchecked;
            }
            
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox6.CheckState = CheckState.Unchecked;
                checkBox3.CheckState = CheckState.Unchecked;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DAO.FacturasDAO facturas = new EquimarFac.DAO.FacturasDAO();
            facturas.IDFServicios = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string resultado=facturas.eliminaserviciosfac();
            if (resultado != "Correcto")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                actualizagrid();
                calculatotales();
            }
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            //(this.IDFactura, this.Remolcadores, this.Moneda, this.Subtotal, this.Iva, this.Total, this.TotalLetras);
            try
            {
                DAO.FacturasDAO facturasdao = new FacturasDAO();
                facturasdao.IDFactura = int.Parse(lbl_idfactura.Text);
                if (textBox7.Text != "")
                {
                    facturasdao.Remolcadores = textBox5.Text + "/" + textBox6.Text + "/" + textBox7.Text;
                }
                else
                {
                    if (textBox6.Text != "")
                    {
                        facturasdao.Remolcadores = textBox5.Text + "/" + textBox6.Text;
                    }
                    else
                    {
                        facturasdao.Remolcadores = textBox5.Text;
                    }
                }
                facturasdao.Moneda = comboBox3.Text;
                facturasdao.Subtotal = decimal.Parse(textBox13.Text);
                facturasdao.Iva = decimal.Parse(textBox14.Text);
                facturasdao.Total = decimal.Parse(textBox15.Text);
                Numalet let = new Numalet();
                if (comboBox3.Text == "USD")
                {
                    let.MascaraSalidaDecimal = "00'/100 USD'";
                    let.SeparadorDecimalSalida = "Dolares";
                    //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                    let.ApocoparUnoParteEntera = true;
                    facturasdao.TotalLetras = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                    //Son: un mil ciento veintiún pesos 24/100 M.N.
                }
                else
                {
                    let.MascaraSalidaDecimal = "00'/100 MXN'";
                    let.SeparadorDecimalSalida = "Pesos";
                    //observar que sin esta propiedad queda "veintiuno pesos" en vez de "veintiún pesos":
                    let.ApocoparUnoParteEntera = true;
                    facturasdao.TotalLetras = ("Son: " + let.ToCustomCardinal(textBox15.Text));
                    //Son: un mil ciento veintiún pesos 24/100 M.N.
                }
                //this.ClaveCFDI, this.formaDePago, this.metodoDePago, this.descuento, this.porcentajeDescuento, this.motivodescuento, this.tipodecambio, 
                //this.fechatipodecambio, this.totalImpuestosretenidos, this.totalimpuestostrasladados, this.LugarExpedicion);
                facturasdao.ClaveCFDI = "";
                facturasdao.metodoDePago = comboBox1.Text;
                facturasdao.formaDePago = "Pago en una sola exhibición";
                if (((checkBox7.Checked) | (checkBox8.Checked)) && textBox16.Text != "")
                {
                    if (checkBox7.Checked)
                    {
                        facturasdao.descuento = ((decimal.Parse(textBox13.Text) * decimal.Parse(textBox16.Text)) / (100 - (decimal.Parse(textBox16.Text)))).ToString();
                        facturasdao.porcentajeDescuento = textBox16.Text;
                        facturasdao.motivodescuento = textBox17.Text;
                    }
                    else
                    {
                        decimal descuentosuma = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            descuentosuma += decimal.Parse(row.Cells["Descuento"].Value.ToString());
                        }
                        facturasdao.descuento = descuentosuma.ToString();
                        facturasdao.porcentajeDescuento = ((descuentosuma / 100) * (decimal.Parse(textBox13.Text) + descuentosuma)).ToString();
                        facturasdao.motivodescuento = textBox17.Text;
                    }
                    
                    //foreach (DataGridViewRow row in dataGridView1.Rows)
                    //{
                    //    facturasdao.descuento += decimal.Parse(row.Cells["Descuento"].Value.ToString());
                    //}
                }
                else
                {
                    facturasdao.descuento = "";
                    facturasdao.porcentajeDescuento = "";
                    facturasdao.motivodescuento = "";
                }
                //facturasdao.porcentajeDescuento = textBox16.Text;
                //facturasdao.motivodescuento = textBox17.Text;
                facturasdao.tipodecambio = textBox18.Text;
                facturasdao.fechatipodecambio = dateTimePicker5.Value.ToShortDateString();
                facturasdao.totalImpuestosretenidos = "";
                facturasdao.totalimpuestostrasladados = textBox14.Text;
                facturasdao.LugarExpedicion = "Progreso, Yucatan";
                facturasdao.Agencia = textBox2.Text;
                facturasdao.NumCuenta = textBox21.Text;
                string resultado = facturasdao.actualizafacturatermina();
                if (resultado != "Correcto")
                {
                    MessageBox.Show(resultado);
                }
                else
                {
                    resultado = facturasdao.insertanumfacturaimpresa();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        resultado = facturasdao.creanota();
                        if (resultado != "Correcto")
                        {
                            MessageBox.Show(resultado);
                        }
                        else
                        {
                            MessageBox.Show("Correcto");
                            GUI.CatalogosForms.Facturas facturasgui = new Facturas();
                            facturasgui.MdiParent = this.MdiParent;
                            facturasgui.Show();

                            this.Close();
                        }
                    }
                }
                

            }
            catch
            {
                MessageBox.Show("Hubo algun error en la informacion");
            }
        }
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string.
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH':'mm' Hrs.'";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "HH':'mm' Hrs.'";
        }

        private void FacturasCtrl_Load(object sender, EventArgs e)
        {
            SetMyCustomFormat();
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                if (checkBox6.Checked)
                {
                    checkBox5.CheckState = CheckState.Unchecked;
                }
                if (checkBox5.Checked)
                {
                    checkBox6.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.TarifasBusqueda tarifas = new TarifasBusqueda(this);
            tarifas.MdiParent = this.MdiParent;
            tarifas.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                textBox17.Enabled = false;
                textBox17.Text = "";
            }
            else
            {
                textBox17.Enabled = true;
            }
            if ((textBox17.Text == ""))
            {
                button7.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
            }

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            button7.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex == 0) | (comboBox1.SelectedIndex == 2) | (comboBox1.SelectedIndex == 5))
            {
                textBox21.Enabled = true;
            }
            else
            {
                textBox21.Enabled = false;
                textBox21.Text = "";
            }
        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                textBox16.Enabled = checkBox8.Checked;
                textBox16.Text = "";
                textBox17.Enabled = checkBox8.Checked;
                textBox17.Text = "";
                checkBox7.Checked = false;
            }
            else
            {
                textBox16.Enabled = checkBox8.Checked;
                textBox16.Text = "";
                textBox17.Enabled = checkBox8.Checked;
                textBox17.Text = "";
            }
            
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                textBox16.Enabled = checkBox7.Checked;
                textBox16.Text = "";
                textBox17.Enabled = checkBox7.Checked;
                textBox17.Text = "";
                checkBox8.Checked = false;
            }
            else
            {
                textBox16.Enabled = checkBox7.Checked;
                textBox16.Text = "";
                textBox17.Enabled = checkBox7.Checked;
                textBox17.Text = "";
            }
            
        }

        private void checkBox10_Click(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                textBox22.Enabled = checkBox10.Checked;
                textBox22.Text = "";
                textBox23.Enabled = checkBox10.Checked;
                textBox23.Text = "";
                checkBox9.Checked = false;
            }
            else
            {
                textBox16.Enabled = checkBox10.Checked;
                textBox16.Text = "";
                textBox17.Enabled = checkBox10.Checked;
                textBox17.Text = "";
            }
        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                textBox22.Enabled = checkBox9.Checked;
                textBox22.Text = "";
                textBox23.Enabled = checkBox9.Checked;
                textBox23.Text = "";
                checkBox10.Checked = false;
            }
            else
            {
                textBox22.Enabled = checkBox9.Checked;
                textBox22.Text = "";
                textBox23.Enabled = checkBox9.Checked;
                textBox23.Text = "";
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                textBox22.Enabled = false;
                textBox22.Text = "";
            }
            else
            {
                textBox22.Enabled = true;
            }
            if ((textBox22.Text == ""))
            {
                button7.Enabled = false;
            }
            else
            {
                button7.Enabled = true;
            }
        }
    }
}
