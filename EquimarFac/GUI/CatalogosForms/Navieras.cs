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
    public partial class Navieras : Form
    {
        public Navieras()
        {
            InitializeComponent();
        }

        private void Navieras_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelvenavieras();
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            lbl_id.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.poblacion = textBox3.Text;
                    catalogosdao.direccion = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    string resultado = catalogosdao.insertanavieras();
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
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_id.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idnavieras = int.Parse(lbl_id.Text);
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.poblacion = textBox3.Text;
                    catalogosdao.direccion = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    string resultado = catalogosdao.modifica_navieras();
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
                    MessageBox.Show("Es necesario escoger una naviera primero");
                }
            }
            catch
            {
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Direccion"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Poblacion"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RFC"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Contacto"].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDNaviera"].Value);
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar la naviera seleccionada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idnavieras = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDNaviera"].Value);
                    string resultado = catalogosdao.elimina_navieras();
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
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Nombre";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                

                DataView dv = new DataView(catalogosdao.devuelvenavieras());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
