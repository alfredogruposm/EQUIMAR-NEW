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
    public partial class RemolcadoresBusqueda : Form
    {
        GUI.CatalogosForms.FacturasCtrl facturagui;
        public RemolcadoresBusqueda(GUI.CatalogosForms.FacturasCtrl fr1)
        {
            facturagui = new FacturasCtrl();
            facturagui = fr1;
            InitializeComponent();
        }

        private void RemolcadoresBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelveremolcadores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "1")
                {
                    facturagui.id_R1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    facturagui.textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    facturagui.lbl_tamaño1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    facturagui.button3.Enabled = true;
                }

                if (this.Text == "2")
                {
                    facturagui.id_R2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    facturagui.textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    facturagui.lbl_tamaño2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    facturagui.button4.Enabled = true;
                }

                if (this.Text == "3")
                {
                    facturagui.id_R3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    facturagui.textBox7.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    facturagui.lbl_tamaño3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
                
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tiene que agregar primero al catalogo");
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
