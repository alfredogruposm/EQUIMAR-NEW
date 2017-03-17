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
    public partial class ReporteFactura : Form
    {
        public ReporteFactura()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public int factura { get; set; }

        private void ReporteFactura_Load(object sender, EventArgs e)
        {
            DAO.FacturasDAO facturasdao = new EquimarFac.DAO.FacturasDAO();
            facturasdao.IDFactura = factura;

            GUI.CatalogosForms.Plantillas.Factura_rpt report = new EquimarFac.GUI.CatalogosForms.Plantillas.Factura_rpt();


            report.SetDataSource(facturasdao.reportefacturas());
            report.Subreports["ServiciosSubRpt"].SetDataSource(facturasdao.reporteservicios());
            //report.ParameterFields["Desc", "ServiciosSubRPT"].ToString() = "0.0";
            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.Refresh();
        }
    }
}
