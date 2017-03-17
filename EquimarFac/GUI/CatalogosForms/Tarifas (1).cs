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
    public partial class Tarifas : Form
    {
        public Tarifas()
        {
            InitializeComponent();
        }

        private void Tarifas_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelvetarifas();
        }

        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            lbl_id.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != "") && (textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != "") && (textBox10.Text != "") && (textBox11.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombre = textBox11.Text;
                    catalogosdao.Cuota_Basica1 = decimal.Parse(textBox1.Text);
                    catalogosdao.Cuotabasica2 = decimal.Parse(textBox2.Text);
                    catalogosdao.CuotaBasica3 = decimal.Parse(textBox3.Text);
                    catalogosdao.CuotaBasica4 = decimal.Parse(textBox4.Text);
                    catalogosdao.RemolcadorExtraP = decimal.Parse(textBox5.Text);
                    catalogosdao.RemolcadorExtraM = decimal.Parse(textBox6.Text);
                    catalogosdao.RemolcadorExtraG = decimal.Parse(textBox7.Text);
                    catalogosdao.ServicioContinuoA = decimal.Parse(textBox8.Text);
                    catalogosdao.ServicioContinuoB = decimal.Parse(textBox9.Text);
                    catalogosdao.ServicioContinuoC = decimal.Parse(textBox10.Text);
                    string resultado = catalogosdao.insertatarifas();
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
                MessageBox.Show("Es necesario escojer una tarifa primero");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbl_id.Text!="")
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.IDTarifas = int.Parse(lbl_id.Text);
                    catalogosdao.nombre = textBox11.Text;
                    catalogosdao.Cuota_Basica1 = decimal.Parse(textBox1.Text);
                    catalogosdao.Cuotabasica2 = decimal.Parse(textBox2.Text);
                    catalogosdao.CuotaBasica3 = decimal.Parse(textBox3.Text);
                    catalogosdao.CuotaBasica4 = decimal.Parse(textBox4.Text);
                    catalogosdao.RemolcadorExtraP = decimal.Parse(textBox5.Text);
                    catalogosdao.RemolcadorExtraM = decimal.Parse(textBox6.Text);
                    catalogosdao.RemolcadorExtraG = decimal.Parse(textBox7.Text);
                    catalogosdao.ServicioContinuoA = decimal.Parse(textBox8.Text);
                    catalogosdao.ServicioContinuoB = decimal.Parse(textBox9.Text);
                    catalogosdao.ServicioContinuoC = decimal.Parse(textBox10.Text);
                    string resultado = catalogosdao.modifica_tarifas();
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
                MessageBox.Show("Es necesario escojer una tarifa primero");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar la tarifa seleccionada?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.IDTarifas = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    string resultado = catalogosdao.elimina_tarifas();
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
                MessageBox.Show("Es necesario escojer una tarifa primero");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                textBox8.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
                textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value);
                textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[11].Value);
                textBox11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch
            {

            }
        }
    }
}
