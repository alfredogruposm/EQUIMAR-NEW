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
    public partial class NavierasBusqueda : Form
    {
        GUI.CatalogosForms.Clientes clientesgui;
        public NavierasBusqueda(GUI.CatalogosForms.Clientes fr1)
        {
            clientesgui = new Clientes();
            clientesgui = fr1;
            InitializeComponent();
        }

        private void NavierasBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelvenavieras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clientesgui.lbl_naviera.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                clientesgui.textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Es necesario agregar una naviera primero");
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
