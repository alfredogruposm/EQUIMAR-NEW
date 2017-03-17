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
    public partial class IngresaFac : Form
    {
        GUI.CatalogosForms.Facturas facturasgui;
        public IngresaFac(GUI.CatalogosForms.Facturas fr1)
        {
            facturasgui = new Facturas();
            facturasgui = fr1;
            InitializeComponent();
        }

        private void IngresaFac_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                facturasdao.IDFactura = int.Parse(this.Text);
                facturasdao.facturaimpresa = textBox1.Text;
                string resultado = facturasdao.insertanumfacturaimpresa();
                if (resultado != "Correcto")
                {
                    MessageBox.Show(resultado);
                }
                else
                {
                    this.Close();
                    facturasgui.actualizagrid();
                }
            }
            catch
            {
                MessageBox.Show("Algun tipo de error");
            }
        }
    }
}
