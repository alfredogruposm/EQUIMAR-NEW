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
    public partial class TarifasBusqueda : Form
    {
        GUI.CatalogosForms.FacturasCtrl facturas;
        public TarifasBusqueda(GUI.CatalogosForms.FacturasCtrl fr1)
        {
            facturas = new FacturasCtrl();
            facturas = fr1;
            InitializeComponent();
        }

        private void TarifasBusqueda_Load(object sender, EventArgs e)
        {
            DAO.CatalogosDAO catalogos = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogos.devuelvetarifas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                facturas.CB1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                facturas.CB2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                facturas.CB3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                facturas.CB4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);
                facturas.REP.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value);
                facturas.REM.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value);
                facturas.REG.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value);
                facturas.SCA.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value);
                facturas.SCB.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value);
                facturas.SCC.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[11].Value);
                facturas.textBox19.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Es necesario agregar una tarifa primero");
            }
           
        }
    }
}
