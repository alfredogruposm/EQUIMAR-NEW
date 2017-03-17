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
    public partial class Remolcadores : Form
    {
        public Remolcadores()
        {
            InitializeComponent();
        }

        private void Remolcadores_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveremolcadores();
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            lbl_id.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (comboBox1.SelectedIndex!=-1))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.Caballaje = textBox2.Text;
                    catalogosdao.tamaño = comboBox1.Text;
                    string resultado = catalogosdao.insertaremolcadores();
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
                MessageBox.Show("Es necesario escojer un remolcador primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_id.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idremolcador = int.Parse(lbl_id.Text);
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.Caballaje = textBox2.Text;
                    catalogosdao.tamaño = comboBox1.Text;
                    string resultado = catalogosdao.modifica_remolques();
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
                MessageBox.Show("Es necesario escojer un remolcador primero");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                string tamaño = (Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value));
                if (tamaño == "Chico")
                {
                    comboBox1.SelectedIndex = 0;
                }
                if (tamaño == "Mediano")
                {
                    comboBox1.SelectedIndex = 1;
                }
                if (tamaño == "Grande")
                {
                    comboBox1.SelectedIndex = 2;
                }
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el remolque seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idremolcador = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = catalogosdao.elimina_remolcadores();
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
                
                DataView dv = new DataView(catalogosdao.devuelveremolcadores());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
