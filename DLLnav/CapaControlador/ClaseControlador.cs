﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModelo;
using System.Collections;
namespace CapaControlador
{
    public class ClaseControlador
    {
        string errores = "";
        TextBox[] texts;
        Control control;

        ClaseModelo modelo = new ClaseModelo();

        public TextBox[] ordenandoTextos(Control parent)
        {
            texts = modelo.funTexts(parent);
            control = parent;
            TextBox[] alias = new TextBox[texts.Length];

            int j = 0;
            for (int i = (texts.Length - 1); i >= 0; i--)
            {
                alias[j] = texts[i];
                j++;
            }

            return alias;
        }


        public void funAsignarAliasControl(TextBox[] alias, string tabla, string BD)
        {
            errores = modelo.funAsignarAlias(alias, tabla, BD);
        }

        public void funAsignarSalidadControl(Form menu)
        {
            if (String.IsNullOrEmpty(errores))
            {
                modelo.funSalida(menu);
                modelo.funDeshabilitarTexts(control);
            }
            else
            {
                MessageBox.Show(errores);
                menu.Close();
            }
        }

        public int funUltimoEnteroControl(string tabla)
        {
            int longitud = texts.Length;
            int entero = modelo.funUltimoEntero(tabla, texts[longitud - 1].Tag.ToString());

            return entero;
        }

        public void funLlenarComboControl(ComboBox cbx, string tabla, string value, string display, string estatus)
        {
            modelo.funLlenarCombo(cbx,tabla,value, display, estatus);
        }

        public void funSeleccionarDTControl(DataGridView data)
        {
            modelo.funSeleccionarDT(data);
        }


        public void funSetearRBControl(RadioButton activo, RadioButton inactivo, TextBox estatus)
        {
            modelo.funSetearRB(activo, inactivo, estatus);
        }


        public void funCambioEstatusRBControl(TextBox estado, RadioButton AI, string cadenaEstado)
        {
            modelo.funCambioEstatusRB(estado, AI, cadenaEstado);
        }

        public void funComboTextboxControl(ComboBox combo, TextBox combotexto)
        {
            modelo.funComboTextbox(combo, combotexto);

        }

        public void funTextboxComboControl(ComboBox combo, TextBox combotexto)
        {
            modelo.funTextboxCombo(combo, combotexto);
        }

        public void funDPTextBoxControl(DateTimePicker date, TextBox textoDate)
        {
            modelo.funDPTextBox(date,textoDate);

        }

        public void funTextBoxDPTControl(DateTimePicker date, TextBox textoDate)
        {
            modelo.funTextBoxDPT(date, textoDate);
        }

        public string funReportesControl(string idReporte, string campoRuta, string campoB, string tablaR)
        {
            string ruta = modelo.funReportes(idReporte, campoRuta, campoB, tablaR);
            return ruta;
        }

        //Wilber Segura 0901-18-13952
        public ArrayList consIndividual(string id, string tablas, int cuenta, string referencia)//Metodo necesario para la actualizacion
        {
            var arList = modelo.consIndividual(id, tablas, cuenta, referencia);
            return arList;
        }

        
        public DataTable llenarTbl(string tablaDB)//Jaime López 0901-18-735
        {
            OdbcDataAdapter dt = modelo.llenarTbl(tablaDB);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }
        public bool modificar(TextBox[] campos, string tablas)//Modificar de Wilber Enrique Segura Ramirez 0901-18-13952
        {
          return modelo.modificar(campos, tablas); 
        }

        public bool insertar(TextBox[] campos, string tablas)
        {
            return modelo.insertar(campos, tablas);
        }

        public void funEliminarControl(TextBox[] arreglo, string tabla, string campoEstado)
        {
            modelo.eliminar(arreglo, tabla, campoEstado);
        }

        public void funAyudaControl(string idAyuda, string nombreCampo, string tablaA)
        {
            modelo.funAyuda(idAyuda,nombreCampo,tablaA,control);

            //MessageBox.Show(tablaA);

            

        }


    }

}
