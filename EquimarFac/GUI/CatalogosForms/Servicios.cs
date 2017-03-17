using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquimarFac.GUI.CatalogosForms
{
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveservicios();
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lbl_id.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != ""))
                {
                    int descuento;
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombre = textBox1.Text;
                    if (textBox2.Text != "")
                    {
                        if ((int.TryParse(textBox2.Text, out descuento)) == false)
                        {
                            MessageBox.Show("Verifique su informacion (descuento)");
                        }
                        else
                        {
                            catalogosdao.descuento = int.Parse(textBox2.Text);
                            string resultado = catalogosdao.insertaservicios();
                            if (resultado != "Correcto")
                            {
                                MessageBox.Show(resultado);
                            }
                            else
                            {
                                actualizagrid();
                                limpiatextos();
                            }
                        }
                    }
                    else
                    {
                        catalogosdao.descuento = 0;
                        string resultado = catalogosdao.insertaservicios();
                        if (resultado != "Correcto")
                        {
                            MessageBox.Show(resultado);
                        }
                        else
                        {
                            actualizagrid();
                            limpiatextos();
                        }
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("Es necesario escribir los datos minimos primero");
                }
            }
            catch
            {
                MessageBox.Show("Es necesario escojer un servicio primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_id.Text != ""))
                {
                    int descuento;
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idservicio = int.Parse(lbl_id.Text);
                    catalogosdao.nombre = textBox1.Text;
                    if ((int.TryParse(textBox2.Text, out descuento)) == false)
                    {
                        MessageBox.Show("Verifique su informacion (descuento)");
                    }
                    else
                    {
                        catalogosdao.descuento = int.Parse(textBox2.Text);
                    }

                    string resultado = catalogosdao.modifica_servicios();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        limpiatextos();
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario escribir los datos minimos primero");
                }
            }
            catch
            {
                MessageBox.Show("Es necesario escojer un servicio primero");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el servicio seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idservicio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = catalogosdao.elimina_servicios();
                    if (resultado != "Correcto")
                    {
                        MessageBox.Show(resultado);
                    }
                    else
                    {
                        actualizagrid();
                        limpiatextos();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Es necesario escojer un servicio primero");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Nombre";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
               
                DataView dv = new DataView(catalogosdao.devuelveservicios());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }




    }
}
