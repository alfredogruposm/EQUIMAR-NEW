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
    public partial class BarcosBusqueda : Form
    {
        GUI.CatalogosForms.FacturasCtrl facturagui;
        public BarcosBusqueda(GUI.CatalogosForms.FacturasCtrl fr1)
        {
            facturagui = new FacturasCtrl();
            facturagui = fr1;
            InitializeComponent();
        }

        private void BarcosBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelvebarcos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                facturagui.lb_idbarco.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                facturagui.textBox8.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                facturagui.textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                facturagui.textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                facturagui.checartrb();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Tiene que agregar primero al catalogo");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = "Nombre";
                DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();

                DataView dv = new DataView(catalogosdao.devuelvebarcos());
                dv.RowFilter = campo + " like '%" + textBox3.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
