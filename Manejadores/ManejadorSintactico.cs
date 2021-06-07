using System;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSintactico
    {
        public bool sintactico(DataGridView tabla)
        {
            bool r = true;
            if (estructuraGeneral(tabla) != "Correcto" && estructuraGeneral(tabla) != "")
            {
                MessageBox.Show(estructuraGeneral(tabla));
                r = false;
            }
            else if (funciones(tabla) != "Correcto" && funciones(tabla) != "")
            {
                MessageBox.Show("Error de sintaxis " + funciones(tabla));
                r = false;
            }
            else if (asignaciones(tabla) != "Correcto" && asignaciones(tabla) != "")
            {
                MessageBox.Show("Error de sintaxis " + asignaciones(tabla));
                r = false;
            }
            else if (variables(tabla) != "Correcto" && variables(tabla) != "")
            {
                MessageBox.Show("Error de sintaxis " + variables(tabla));
                r = false;
            }
            else if (condicionales(tabla) != "Correcto" && condicionales(tabla) != "")
            {
                MessageBox.Show("Error de sintaxis " + condicionales(tabla));
                r = false;
            }
            else if (incrementoDecremento(tabla) != "Correcto" && incrementoDecremento(tabla) != "")
            {
                MessageBox.Show("Error de sintaxis " + incrementoDecremento(tabla));
                r = false;
            }
            return r;
        }

        private bool comparar(DataGridView dtg, int fila, int columna, string descripcion)
        {
            bool x = false;

            try
            {
                if (dtg.Rows[fila].Cells[columna].Value.ToString().Equals(descripcion))
                {
                    x = true;
                }
            }
            catch (Exception)
            {

            }
            return x;
        }

        private string linea(DataGridView dtg, int fila, int columna)
        {
            try
            {
                return dtg.Rows[fila].Cells[columna].Value.ToString();
            }
            catch (Exception)
            {
                return dtg.Rows[fila - 1].Cells[columna].Value.ToString();
            }
        }

        private bool encontrar(DataGridView dtg, int fila, int columna, string descripcion)
        {
            bool r = false;

            for (int i = fila; i < dtg.Rows.Count; i++)
            {
                if (dtg.Rows[i].Cells[columna].Value.ToString().Equals(descripcion))
                {
                    r = true; break;
                }
            }
            return r;
        }

        public string estructuraGeneral(DataGridView dtg)
        {
            string r = "";

            if (encontrar(dtg, 0, 1, "Iniciar"))
            {
                if (encontrar(dtg, 1, 1, "Finalizar"))
                {
                    r = "Correcto";
                }
                else
                {
                    r = "Se esperaba la palabra Finalizar al final del programa"; 
                }
            }
            else
            {
                r = "Se esperaba la palabra Iniciar al inicio del programa";
            }
            return r;
        }

        public string funciones(DataGridView dtg)
        {
            string r = "";

            for (int i = 0; i < dtg.RowCount; i++)
            {
                if (comparar(dtg, i, 1, "GirarDerecha") || comparar(dtg, i, 1, "GirarIzquierda") || comparar(dtg, i, 1, "Subir") || comparar(dtg, i, 1, "Bajar") || comparar(dtg, i, 1, "Abrir") || comparar(dtg, i, 1, "Cerrar") || comparar(dtg, i, 1, "Extender") || comparar(dtg, i, 1, "Contraer"))
                {
                    if (comparar(dtg, i + 1, 2, "Delimitador") && comparar(dtg, i + 1, 1, "("))
                    {
                        if (comparar(dtg, i + 2, 2, "Número"))
                        {
                            if (comparar(dtg, i + 3, 2, "Delimitador") && comparar(dtg, i + 3, 1, ")"))
                            {
                                r = "Correcto";
                            }
                            else
                            {
                                r = "2,  expresión incompleta en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else if (comparar(dtg, i + 2, 2, "Identificador"))
                        {
                            if (comparar(dtg, i + 3, 2, "Delimitador") && comparar(dtg, i + 3, 1, ")"))
                            {
                                r = "Correcto";
                            }
                            else
                            {
                                r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else
                        {
                            r = "1, se esperaba recibir algún valor de tipo entero como parametro en la línea " + linea(dtg, i, 3);
                            break;
                        }
                    }
                    else
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }
                }
            }
            return r;
        }

        public string asignaciones(DataGridView dtg)
        {
            string r = "";

            for (int i = 0; i < dtg.RowCount; i++)
            {
                if (comparar(dtg, i, 2, "Identificador"))
                {
                    if (comparar(dtg, i + 1, 2, "Signo de asignación"))
                    {
                        if (comparar(dtg, i + 2, 2, "Número") || comparar(dtg, i + 2, 2, "Número decimal"))
                        {
                            r = "Correcto";
                        }
                        else
                        {
                            r = "3, se esperaba un número despues del signo de asignación en la línea " + linea(dtg, i, 3); break;
                        }
                    }
                    else if (!comparar(dtg, i + 1, 2, "Signo de comparación") && !comparar(dtg, i + 1, 2, "Delimitador") && !comparar(dtg, i + 1, 2, "Incremento") && !comparar(dtg, i + 1, 2, "Decremento") && !comparar(dtg, i + 2, 2, "Delimitador"))
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }
                    /*else if (comparar(dtg, i + 1, 2, "Signo de comparación") && !comparar(dtg, i + 3, 2, "Delimitador"))
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }*/
                }
            }
            return r;
        }

        public string variables(DataGridView dtg)
        {
            string r = "";

            for (int i = 0; i < dtg.RowCount; i++)
            {
                if (comparar(dtg, i, 2, "Tipo de dato") /*&& comparar(dtg, i, 1, "int")*/)
                {
                    if (comparar(dtg, i + 1, 2, "Identificador"))
                    {
                        if (comparar(dtg, i + 2, 2, "Signo de asignación"))
                        {
                            if (comparar(dtg, i + 3, 2, "Número"))
                            {
                                if (comparar(dtg, i + 4, 2, "Signo de fin"))
                                {
                                    r = "Correcto";
                                }
                                else
                                {
                                    r = "6, se esperaba un ; al final de la expresión en la línea " + linea(dtg, i, 3); break;
                                }
                            }
                            else if (comparar(dtg, i + 3, 2, "Número decimal"))
                            {
                                if (comparar(dtg, i + 4, 2, "Signo de fin"))
                                {
                                    r = "Correcto";
                                }
                                else
                                {
                                    r = "6, se esperaba un ; al final de la expresión en la línea " + linea(dtg, i, 3); break;
                                }
                            }
                            else
                            {
                                r = "3, se esperaba un número despues del signo de asignación en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else if (!comparar(dtg, i + 2, 2, "Signo de comparación") && !comparar(dtg, i + 2, 2, "Delimitador"))
                        {
                            r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                        }
                        else if (comparar(dtg, i + 2, 2, "Signo de comparación") && !comparar(dtg, i + 4, 2, "Delimitador"))
                        {
                            r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                        }
                    }
                    else if (comparar(dtg, i + 1, 2, "Expresión de asignación"))
                    {
                        if (comparar(dtg, i + 2, 2, "Signo de fin"))
                        {
                            r = "Correcto";
                        }
                    }
                    else
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }
                }
            }
            return r;
        }

        public string condicionales(DataGridView dtg)
        {
            string r = "";

            for (int i = 0; i < dtg.RowCount; i++)
            {
                if (comparar(dtg, i, 2, "Palabra reservada") && comparar(dtg, i, 1, "Si"))
                {
                    if (comparar(dtg, i + 1, 2, "Delimitador") && comparar(dtg, i + 1, 1, "("))
                    {
                        if (comparar(dtg, i + 2, 2, "Número"))
                        {
                            if (comparar(dtg, i + 3, 2, "Signo de comparación"))
                            {
                                if (comparar(dtg, i + 4, 2, "Identificador"))
                                {
                                    if (comparar(dtg, i + 5, 2, "Delimitador") && comparar(dtg, i + 5, 1, ")"))
                                    {
                                        if (comparar(dtg, i + 6, 2, "Delimitador") && comparar(dtg, i + 6, 1, "{"))
                                        {
                                            if (encontrar(dtg, i + 7, 1, "}"))
                                            {
                                                r = "Correcto";
                                            }
                                            else
                                            {
                                                r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                            }
                                        }
                                        else
                                        {
                                            r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                        }
                                    }
                                    else
                                    {
                                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                    }
                                }
                                else
                                {
                                    r = "4, se esperaba un valor de tipo entero en la línea " + linea(dtg, i, 3); break;
                                }
                            }
                            else
                            {
                                r = "5, se esperaba una expresión de comparación en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else if (comparar(dtg, i + 2, 2, "Identificador"))
                        {
                            if (comparar(dtg, i + 3, 2, "Signo de comparación"))
                            {
                                if (comparar(dtg, i + 4, 2, "Número"))
                                {
                                    if (comparar(dtg, i + 5, 2, "Delimitador") && comparar(dtg, i + 5, 1, ")"))
                                    {
                                        if (comparar(dtg, i + 6, 2, "Delimitador") && comparar(dtg, i + 6, 1, "{"))
                                        {
                                            if (encontrar(dtg, i + 7, 1, "}"))
                                            {
                                                r = "Correcto";
                                            }
                                            else
                                            {
                                                r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                            }
                                        }
                                        else
                                        {
                                            r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                        }
                                    }
                                    else
                                    {
                                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                    }
                                }
                                else if (comparar(dtg, i + 4, 2, "Identificador"))
                                {
                                    if (comparar(dtg, i + 5, 2, "Delimitador") && comparar(dtg, i + 5, 1, ")"))
                                    {
                                        if (comparar(dtg, i + 6, 2, "Delimitador") && comparar(dtg, i + 6, 1, "{"))
                                        {
                                            if (encontrar(dtg, i + 7, 1, "}"))
                                            {
                                                r = "Correcto";
                                            }
                                            else
                                            {
                                                r = "2, sexpresión incompleta en la línea " + linea(dtg, i, 3); break;
                                            }
                                        }
                                        else
                                        {
                                            r = "2, sexpresión incompleta en la línea " + linea(dtg, i, 3); break;
                                        }
                                    }
                                    else
                                    {
                                        r = "2, sexpresión incompleta en la línea " + linea(dtg, i, 3); break;
                                    }
                                }
                                else
                                {
                                    r = "4, se esperaba un valor de tipo entero en la línea " + linea(dtg, i, 3); break;
                                }
                            }
                            else
                            {
                                r = "5, se esperaba una expresión de comparación en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else if (comparar(dtg, i + 2, 2, "Expresión de comparación"))
                        {
                            if (comparar(dtg, i + 3, 2, "Delimitador") && comparar(dtg, i + 3, 1, ")"))
                            {
                                if (comparar(dtg, i + 4, 2, "Delimitador") && comparar(dtg, i + 4, 1, "{"))
                                {
                                    if (encontrar(dtg, i + 5, 1, "}"))
                                    {
                                        r = "Correcto";
                                    }
                                    else
                                    {
                                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                    }
                                }
                                else
                                {
                                    r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                                }
                            }
                            else
                            {
                                r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                            }
                        }
                        else
                        {
                            r = "5, se esperaba una expresión de comparación en la línea " + linea(dtg, i, 3); break;
                        }
                    }
                    else
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }
                }
            }
            return r;
        }

        public string incrementoDecremento(DataGridView dtg)
        {
            string r = "";

            for (int i = 0; i < dtg.RowCount; i++)
            {
                if (comparar(dtg, i, 2, "Identificador"))
                {
                    if (comparar(dtg, i + 1, 2, "Incremento") || comparar(dtg, i + 1, 2, "Decremento"))
                    {
                        if (comparar(dtg, i + 2, 2, "Signo de fin"))
                        {
                            r = "Correcto";
                        }
                        else if (!comparar(dtg, i + 2, 1, ")"))
                        {
                            r = "6, se esperaba un ; al final de la expresión en la línea " + linea(dtg, i, 3); break;
                        }
                    }
                    else if (!comparar(dtg, i + 1, 2, "Signo de asignación") && !comparar(dtg, i + 1, 2, "Signo de comparación") && !comparar(dtg, i + 1, 1, ")"))
                    {
                        r = "2, expresión incompleta en la línea " + linea(dtg, i, 3); break;
                    }
                }
            }
            return r;
        }
    }
}