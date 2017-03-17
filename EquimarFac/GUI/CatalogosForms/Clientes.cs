using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rnd = EquimarFac.FelWebService;


namespace EquimarFac.GUI.CatalogosForms
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            actualizagrid();
        }

        public void actualizagrid()
        {
            DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
            dataGridView1.DataSource = catalogosdao.devuelveclientes();
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
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            lbl_id.Text = "";
            lbl_naviera.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox15.Text = "";
            textBox14.Text = "";
            //comboBox2.Text = "";
            //comboBox3.Text = "";
            textBox9.Text = "";
            textBox17.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != "") && (lbl_naviera.Text!=""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.poblacion = textBox13.Text;
                    catalogosdao.direccion = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.nacionalidad = textBox3.Text;
                    catalogosdao.moneda = comboBox1.Text;
                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.NumExt = textBox10.Text;
                    catalogosdao.NumInt = textBox11.Text;
                    catalogosdao.Colonia = textBox12.Text;
                    catalogosdao.Localidad = textBox15.Text;
                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Estado = comboBox2.Text;
                    catalogosdao.Pais = comboBox3.Text;
                    catalogosdao.Email = textBox9.Text;
                    catalogosdao.CodigoPostal = textBox17.Text;
                    catalogosdao.paisextranjero = textBox18.Text;
                    catalogosdao.estadoextranjero = textBox16.Text;
                    if (lbl_naviera.Text != "")
                    {
                        catalogosdao.idnavieras = int.Parse(lbl_naviera.Text);
                    }
                    string resultado = catalogosdao.insertaclientes();
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
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Nombre"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["calle"].Value);
                textBox13.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Municipio"].Value);
                textBox4.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Telefono"].Value);
                textBox5.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["RFC"].Value);
                textBox6.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Contacto"].Value);
                lbl_naviera.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDNaviera"].Value);
                lbl_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["IDCliente"].Value);
                textBox7.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Naviera"].Value);
                textBox10.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NumExt"].Value);
                textBox11.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["NumInt"].Value);
                textBox12.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Colonia"].Value);
                textBox15.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Localidad"].Value);
                textBox14.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ReferenciasDir"].Value);
                comboBox2.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Estado"].Value);
                comboBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Pais"].Value);
                textBox9.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Email"].Value);
                textBox17.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["CodigoPostal"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Razon Social"].Value);
                comboBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["Moneda"].Value);
                textBox16.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["EstadoExtranjero"].Value);
                textBox18.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["PaisExtranjero"].Value);
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((lbl_naviera.Text != "") && (lbl_id.Text != ""))
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idcliente = int.Parse(lbl_id.Text);
                    catalogosdao.nombre = textBox1.Text;
                    catalogosdao.poblacion = textBox13.Text;
                    catalogosdao.direccion = textBox2.Text;
                    catalogosdao.telefono = textBox4.Text;
                    catalogosdao.rfc = textBox5.Text;
                    catalogosdao.contacto = textBox6.Text;
                    catalogosdao.nacionalidad = textBox3.Text;
                    catalogosdao.moneda = comboBox1.Text;

                    catalogosdao.calle = textBox2.Text;
                    catalogosdao.NumExt = textBox10.Text;
                    catalogosdao.NumInt = textBox11.Text;
                    catalogosdao.Colonia = textBox12.Text;
                    catalogosdao.Localidad = textBox15.Text;
                    catalogosdao.ReferenciasDir = textBox14.Text;
                    catalogosdao.Estado = comboBox2.Text;
                    catalogosdao.Pais = comboBox3.Text;
                    catalogosdao.Email = textBox9.Text;
                    catalogosdao.CodigoPostal = textBox17.Text;
                    catalogosdao.idnavieras = int.Parse(lbl_naviera.Text);
                    catalogosdao.paisextranjero = textBox18.Text;
                    catalogosdao.estadoextranjero = textBox16.Text;
                    string resultado = catalogosdao.modifica_clientes();
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
                MessageBox.Show("Es necesario escojer una naviera primero");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿De verdad desea eliminar el cliente seleccionado?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DAO.CatalogosDAO catalogosdao = new EquimarFac.DAO.CatalogosDAO();
                    catalogosdao.idcliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IDCliente"].Value);
                    string resultado = catalogosdao.elimina_clientes();
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
                MessageBox.Show("Es necesario escojer un cliente primero");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.NavierasBusqueda navierasgui = new NavierasBusqueda(this);
            navierasgui.MdiParent = this.MdiParent;
            navierasgui.Show();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 1)
            {
                textBox18.Enabled = true;
            }
            else
            {
                textBox18.Enabled = false;
                textBox18.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 32)
            {
                textBox16.Enabled = true;
            }
            else
            {
                textBox16.Enabled = false;
                textBox16.Text = "";
            }
        }






    }
}
