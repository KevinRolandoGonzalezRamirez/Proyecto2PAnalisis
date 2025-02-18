﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //TextBox[] alias = { txtID, txtCodigoMarca, txtNombre, txtFecha, txtDescripcion, txtStock, txtPrecio, txtEstatus};
            TextBox[] alias = navegador1.funAsignandoTexts(this);
            navegador1.funAsignarAliasVista(alias, "producto", "pruebas");
            navegador1.funAsignarSalidadVista(this);
            navegador1.funLlenarComboControl(cbxCodMarca, "marca", "idMarca", "nombre","estatus");
            
            //inicio de elementos para dar de baja
            navegador1.campoEstado = "estado";
            //fin de elementos para dar de baja

            //inicio de elementos para ejecutar la ayuda
            navegador1.tablaAyuda = "ayuda";
            navegador1.campoAyuda = "idAyuda";
            navegador1.idAyuda = "1";
            //fin de elementos para ejecutar la ayuda

            // Inicio datos para ejecurar reportes
            navegador1.idReporte = "1";
            reporte formRep = new reporte();
            navegador1.formReporte = formRep;
            formRep.ruta = navegador1.funReportesVista("rutaReporte", "idReporte", "reporte");
            // Final datos para ejecutar reportes

            navegador1.pideGrid(this.dvgConsulta);
            navegador1.llenaTabla();
            navegador1.pedirRef(this);
            //String cadena = txtprueba.Text;
            //navegador1.pruebaMensaje(cadena);



            //cbxCodMarca

        }

       /* public void ayudaR()
        {
            Help.ShowHelp(this, "Ayudas/AyudasSistemaReparto.chm", "ManualSistemaReparto.html");

        }
       */
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String dt = "";
            dt = dtProducto.Value.ToString("yyyy-MM-dd");//lo pasa al formato necesitado por mysql
            txtFecha.Text = dt;
            MessageBox.Show(txtFecha.Text);
        }

        private void navegador1_Load(object sender, EventArgs e)
        {
            //String cbx = cbxCodMarca.Text();
            //cbxCodMarca
            
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            navegador1.funCambioEstatusRBVista(txtEstatus, radioButton1, "A");
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            navegador1.funCambioEstatusRBVista(txtEstatus, radioButton2, "I");
        }

        private void navegador1_Load_1(object sender, EventArgs e)
        {

        }


        private void cbxCodMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            navegador1.funComboTextboxVista(cbxCodMarca, txtCodigoMarca);
            
        }

        private void navegador1_Load_2(object sender, EventArgs e)
        {

        }

        private void dvgConsulta_CurrentCellChanged(object sender, EventArgs e)
        {
            //navegador1.cargaData();
        }

        private void dvgConsulta_SelectionChanged(object sender, EventArgs e)
        {
            navegador1.funSeleccionarDTVista(dvgConsulta);
        }

        private void txtEstatus_TextChanged(object sender, EventArgs e)
        {
            navegador1.funSetearRBVista(radioButton1, radioButton2, txtEstatus);
        }

        private void txtCodigoMarca_TextChanged(object sender, EventArgs e)
        {
            navegador1.funTextboxComboVista(cbxCodMarca, txtCodigoMarca);
        }

        private void dtProducto_ValueChanged(object sender, EventArgs e)
        {
            navegador1.funDPTextBoxVista(dtProducto,txtFecha);
        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {
            navegador1.funTextBoxDPTVista(dtProducto, txtFecha);
        }
    }
}
