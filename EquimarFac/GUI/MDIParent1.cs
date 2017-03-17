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
    public partial class MDIParent1 : Form
    {
       //private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            //Form childForm = new Form();
            //childForm.MdiParent = this;
            //childForm.Text = "Ventana " + childFormNumber++;
            //childForm.Show();
            GUI.CatalogosForms.Facturas facturasgui = new EquimarFac.GUI.CatalogosForms.Facturas();
            facturasgui.MdiParent = this;
            facturasgui.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {

        }

        private void navierasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Navieras navierasgui = new EquimarFac.GUI.CatalogosForms.Navieras();
            navierasgui.MdiParent = this;
            navierasgui.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Clientes clientesgui = new EquimarFac.GUI.CatalogosForms.Clientes();
            clientesgui.MdiParent = this;
            clientesgui.Show();
        }

        private void remolcadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Remolcadores remolcadores = new EquimarFac.GUI.CatalogosForms.Remolcadores();
            remolcadores.MdiParent = this;
            remolcadores.Show();
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Servicios servicios = new EquimarFac.GUI.CatalogosForms.Servicios();
            servicios.MdiParent = this;
            servicios.Show();
        }

        private void barcosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Barcos barcos = new EquimarFac.GUI.CatalogosForms.Barcos();
            barcos.MdiParent = this;
            barcos.Show();
        }

        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.CatalogosForms.Tarifas tarifasgui = new EquimarFac.GUI.CatalogosForms.Tarifas();
            tarifasgui.MdiParent = this;
            tarifasgui.Show();

        }

        private void daToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUI.DatosCuentaGUI cuentagui = new DatosCuentaGUI();
            cuentagui.MdiParent = this;
            cuentagui.Show();
        }
    }
}
