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
    public partial class ClientesBusqueda : Form
    {
        GUI.CatalogosForms.FacturasCtrl facturagui;
        public ClientesBusqueda(GUI.CatalogosForms.FacturasCtrl fr1)
        {
            facturagui = new FacturasCtrl();
            facturagui = fr1;
            InitializeComponent();
        }

        private void ClientesBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelveclientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                facturagui.lbl_idCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString() ;
                facturagui.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                //facturagui.textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                facturagui.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                facturagui.textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                //facturagui.textBox17.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
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

                DataView dv = new DataView(catalogosdao.devuelveclientes());
                dv.RowFilter = campo + " like '%" + textBox8.Text + "%'";

                dataGridView1.DataSource = dv;
            }
            catch
            {
            }
        }
    }
}
