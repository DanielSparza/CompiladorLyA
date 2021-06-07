using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace Presentacion
{
    public partial class FrmCompilador : Form
    {
        ManejadorLexico ml;
        ManejadorSintactico ms;
        ManejadorSemantico msem;
        ManejadorTraductor mt;
        List<EntidadExpresion> ls;
        string[] puertos;

        public FrmCompilador()
        {
            InitializeComponent();
            ml = new ManejadorLexico();
            ms = new ManejadorSintactico();
            msem = new ManejadorSemantico();
            mt = new ManejadorTraductor();
            ls = new List<EntidadExpresion>();
            rtxtEntrada.Focus();
            puertos = SerialPort.GetPortNames();
        }

        private void FrmLexico_Load(object sender, EventArgs e)
        {
            dtgTokens.DataSource = ls.ToList();
            dtgTokens.AutoResizeColumns();
            rtxtEntrada.Text = "Iniciar\n\n\n\nFinalizar";
            ObtenerPuertos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ml.limpiarLista(ls, rtxtEntrada);
            dtgTokens.DataSource = ls.ToList();
            dtgTokens.AutoResizeColumns();
            rtxtEntrada.Focus();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (ml.lexico(dtgTokens, rtxtEntrada, ls))
            {
                if (ms.sintactico(dtgTokens))
                {
                    string r = msem.Semantico(dtgTokens);
                    if (r.Length > 0)
                    {
                        MessageBox.Show(r);
                    }
                    else
                    {
                        r = msem.Semanticoa(dtgTokens);
                        if (r.Length > 0)
                        {
                            MessageBox.Show(r);
                        }
                        else
                        {
                            try
                            {
                                string codigo;
                                codigo = mt.Traducir(dtgTokens, int.Parse(cmbPinBase1.Text), int.Parse(cmbPinBase2.Text), int.Parse(cmbPinBase3.Text), 
                                    int.Parse(cmbPinBase4.Text), int.Parse(cmbPinHombro.Text), int.Parse(cmbPinCodo.Text), int.Parse(cmbPinPinza.Text));
                                
                                if (codigo != "" && codigo.Length > 0)
                                {
                                    cargarCodigo(codigo);
                                }
                                else
                                {
                                    MessageBox.Show("Error de generación de código");
                                }
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Seleccione los pines a utilizar.", "¡ERROR!");
                            }
                        }
                    }
                }
            }
        }

        public void cargarCodigo(string codigo)
        {
            bool sketch = false;
            bool bat = false;
            try
            {
                
                //Crear archivo .ino
                TextWriter archivo = new StreamWriter("Sketch.ino");
                archivo.WriteLine(codigo);
                archivo.Close();
                sketch = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Seleccione los pines a utilizar.", "¡ERROR!");
            }

            try
            {
                if (ObtenerPlaca() > 0 && cmbPuerto.Text != "" && cmbPuerto.Text.Length > 1 && sketch)
                {
                    //Crear archivo .bat
                    TextWriter archivobat = new StreamWriter("archivo.bat");
                    archivobat.WriteLine("arduinouploader Sketch.ino " + ObtenerPlaca() + " " + cmbPuerto.Text + "\npause");
                    archivobat.Close();
                    bat = true;
                }
                else if (ObtenerPlaca() < 1)
                {
                    MessageBox.Show("Seleccione una placa de arduino.", "¡Error!");
                }
                else if (cmbPuerto.Text == "" || cmbPuerto.Text.Length < 1)
                {
                    MessageBox.Show("Seleccione un puerto.", "¡Error!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("No se pudo cargar el Sketch a arduino.", "¡Error de creación de archivo .bat!");
            }

            try
            {
                if (bat)
                {
                    //Ejecuta el archivo .bat
                    Process.Start("archivo.bat"); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar el sketch a arduino.", "¡Error de ejecución de archivo .bat!");
            }
        }

        public void ObtenerPuertos()
        {
            cmbPuerto.Items.Clear();
            for (int i = 0; i < puertos.Length; i++)
            {
                cmbPuerto.Items.Add(puertos[i].ToString());
            }
        }

        public int ObtenerPlaca()
        {
            int placa = 0;
            if (cmbPlaca.Text != "" && cmbPlaca.Text.Length > 0)
            {
                placa = cmbPlaca.SelectedIndex + 1;
            }
            return placa;
        }
    }
}
