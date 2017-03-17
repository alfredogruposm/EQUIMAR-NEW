using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EquimarFac
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //if(DateTime.Now.Date>=Convert.ToDateTime("21/02/2013"))
            //{
            //    DialogResult result= MessageBox.Show("Es necesario haber pagado para usar el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        if(result==DialogResult.OK)
            //        {
            //    Application.Exit();
            //        }
            //        else
            //        {
            //            Application.Exit();
            //        }

            //}
            //else
            //{

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.MDIParent1());
            //}
        }
    }
}
