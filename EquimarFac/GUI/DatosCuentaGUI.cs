using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquimarFac.GUI
{
    public partial class DatosCuentaGUI : Form
    {
        public DatosCuentaGUI()
        {
            InitializeComponent();
        }
        public void cargacuentas()
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            dataGridView1.DataSource = facturasdao.devuelvedatospac();
        }
        public void limpiatextos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            lblid.Text = "";
            button1.Text = "Nuevo";
        }
        private void DatosCuentaGUI_Load(object sender, EventArgs e)
        {
            cargacuentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (button1.Text == "Nuevo")
                {
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    facturasdao.Nombre = textBox1.Text;
                    facturasdao.Usuario = textBox3.Text;
                    facturasdao.Cuenta = textBox2.Text;
                    facturasdao.Password = textBox4.Text;
                    string resultado = facturasdao.insertadatospac();
                    if (resultado == "Correcto")
                    {
                        cargacuentas();
                        limpiatextos();
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                }
                else
                {
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    facturasdao.Nombre = textBox1.Text;
                    facturasdao.Usuario = textBox3.Text;
                    facturasdao.Cuenta = textBox2.Text;
                    facturasdao.Password = textBox4.Text;
                    facturasdao.IDCuentaPac = int.Parse(lblid.Text);
                    string resultado = facturasdao.modificadatospac();
                    if (resultado == "Correcto")
                    {
                        cargacuentas();
                        limpiatextos();
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                lblid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                button1.Text = "Modificar";
            }
            catch
            {
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("De verdad desea eliminar los datos de la cuenta seleccionada", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result==DialogResult.Yes)
                {
                    DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
                    facturasdao.IDCuentaPac = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string resultado = facturasdao.eliminadatospac();
                    if (resultado == "Correcto")
                    {
                        cargacuentas();
                        limpiatextos();
                    }
                    else
                    {
                        MessageBox.Show(resultado);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
