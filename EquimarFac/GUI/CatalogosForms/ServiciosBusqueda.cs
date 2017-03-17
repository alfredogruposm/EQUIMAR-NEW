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
    public partial class ServiciosBusqueda : Form
    {
        GUI.CatalogosForms.FacturasCtrl facturagui;
        public ServiciosBusqueda(GUI.CatalogosForms.FacturasCtrl fr1)
        {
            facturagui = new FacturasCtrl();
            facturagui = fr1;
            InitializeComponent();
        }

        private void ServiciosBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelveservicios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                facturagui.textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "0")
                {
                    if (facturagui.textBox16.Text != "")
                    {
                        facturagui.textBox16.Text = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value) + Convert.ToDouble(facturagui.textBox16.Text)).ToString();
                    }
                    else
                    {
                        facturagui.textBox16.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    }
                    
                    if (facturagui.textBox17.Text != "")
                    {
                        facturagui.textBox17.Text += " mas " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "% descuento de " + dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    else
                    {
                        facturagui.textBox17.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    
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
