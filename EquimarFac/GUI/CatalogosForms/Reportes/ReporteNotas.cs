using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquimarFac.GUI.CatalogosForms.Reportes
{
    public partial class ReporteNotas : Form
    {
        public ReporteNotas()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public int idfactura { get; set; }

        private void ReporteNotas_Load(object sender, EventArgs e)
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = idfactura;

            GUI.CatalogosForms.Plantillas.NotaCredito report = new EquimarFac.GUI.CatalogosForms.Plantillas.NotaCredito();


            report.SetDataSource(facturasdao.notacreditoimpresion());
            report.Subreports["NotaDetalleSubRPT"].SetDataSource(facturasdao.notacreditoimpresiondetalle());

            crystalReportViewer1.ReportSource = report;
            
            crystalReportViewer1.Refresh();
        }
    }
}
