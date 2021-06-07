using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSemantico
    {
        int x = 0;

        private bool encontrar(DataGridView dtg, int fila, int columna, string descripcion)
        {
            bool r = false;

            for (int i = fila; i < dtg.Rows.Count; i++)
            {
                if (dtg.Rows[i].Cells[columna].Value.ToString().Equals(descripcion))
                {
                    r = true; break;
                }
                x++;
            }
            return r;
        }

        public string ReglaUno(DataGridView tabla)
        {
            string r = "";

            if (encontrar(tabla, 0, 1, "Iniciar"))
            {
                for (int i = 0; i < x; i++)
                {
                    if (tabla.Rows[i].Cells[2].Value.ToString().Equals("Comentario"))
                    {
                        r = "";
                    }
                    else
                    {
                        x = 0;
                        r = "Error, No se pueden poner variables o funciones fuera de la estructura principal."; break;
                    }
                }
            }
            else
            {
                r = "Error, el código debe comenzar con la palabra Iniciar.";
            }
            return r;
        }

        public string ReglaDos(DataGridView tabla)
        {
            string r = "";

            if (encontrar(tabla, 0, 1, "Finalizar"))
            {
                if (tabla.RowCount >= x)
                {
                    for (int i = x; i < tabla.RowCount; i++)
                    {
                        if (tabla.Rows[i].Cells[2].Value.ToString().Equals("Comentario") || tabla.Rows[i].Cells[2].Value.ToString().Equals("Fin de programa"))
                        {
                            r = "";
                        }
                        else
                        {
                            x = 0;
                            r = "Error, No se pueden poner variables o funciones fuera de la estructura principal. "; break;
                        }
                    }
                }
            }
            else
            {
                r = "Error, el código debe terminar con la palabra Finalizar.";
            }
            return r;
        }

        public string ReglaTres(DataGridView tabla)
        {
            string r = "";
            int a = 0;
            int b = 0;

            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Iniciar"))
                {
                    a++;
                    if (a > 1)
                    {
                        r = "Error, solo se puede utilizar la palabra Iniciar una vez."; break;
                    }
                }
                else if (tabla.Rows[i].Cells[1].Value.ToString().Equals("Finalizar"))
                {
                    b++;
                    if (b > 1)
                    {
                        r = "Error, solo se puede utilizar la palabra Finalizar una vez."; break;
                    }
                }
            }
            return r;
        }

        public string Semantico(DataGridView tabla)
        {
            string r = "";
            if (tabla.RowCount > 0)
            {
                r = ReglaUno(tabla);
                if (r.Length == 0)
                {
                    r = ReglaDos(tabla);
                    if (r.Length == 0)
                    {
                        r = ReglaTres(tabla);
                        if (r.Length == 0)
                        {
                            r = "";
                            x = 0;
                        }
                    }
                }
            }
            return r;
        }

        //-----------------------R(a)--------------------------------------------

        public string Semanticoa(DataGridView tabla)
        {
            string r = "";
            string x = "";
            int n;

            if (tipoDato(tabla) == "")
            {
                for (int i = 0; i < tabla.RowCount; i++)
                {
                    if (tabla.Rows[i].Cells[2].Value.Equals("Palabra reservada"))
                    {
                        if (tabla.Rows[i + 1].Cells[1].Value.Equals("("))
                        {
                            try
                            {
                                n = int.Parse(tabla.Rows[i + 2].Cells[1].Value.ToString());
                                r = "";
                            }
                            catch (System.Exception)
                            {
                                if (tabla.Rows[i + 2].Cells[2].Value.Equals("Identificador"))
                                {
                                    r = BuscarVariable(tabla, tabla.Rows[i + 2].Cells[1].Value.ToString(), i + 2);
                                    x = BuscarVariableExpresion(tabla, tabla.Rows[i + 2].Cells[1].Value.ToString(), i + 2);

                                    if (r.Equals("existe"))
                                    {
                                        r = "";
                                    }
                                    else if (x.Equals("existe"))
                                    {
                                        r = "";
                                    }
                                    else
                                    {
                                        r = "Error, la variable \"" + tabla.Rows[i + 2].Cells[1].Value.ToString() +
                                            "\" no ha sido declarada." + "\nDeclare la variable antes de usarla o use algun otro valor.";

                                        i = tabla.RowCount;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                r = tipoDato(tabla);
            }
            return r;
        }

        public string BuscarVariable(DataGridView tabla, string variable, int indice)
        {
            string r = "";

            for (int i = 0; i < indice; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.Equals(variable))
                {
                    r = "existe";
                }
            }
            return r;
        }

        public string BuscarVariableExpresion(DataGridView tabla, string variable, int indice)
        {
            string r = "";

            for (int i = 0; i < indice; i++)
            {
                if (tabla.Rows[i].Cells[2].Value.Equals("Expresión de asignación"))
                {
                    string var;
                    string[] vars;
                    vars = tabla.Rows[i].Cells[1].Value.ToString().Split('=');
                    var = vars[0];

                    if (var == variable)
                    {
                        r = "existe";
                    }
                }
            }
            return r;
        }

        public string tipoDato(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[2].Value.Equals("Tipo de dato"))
                {
                    if (tabla.Rows[i + 1].Cells[2].Value.Equals("Identificador"))
                    {
                        if (tabla.Rows[i + 2].Cells[2].Value.Equals("Signo de asignación"))
                        {
                            if (tabla.Rows[i].Cells[1].Value.Equals("int"))
                            {
                                if (tabla.Rows[i + 3].Cells[2].Value.Equals("Número"))
                                {
                                    r = "";
                                }
                                else
                                {
                                    r = "Error, el tipo de dato no corresponde con el valor asignado a la variable \"" + tabla.Rows[i + 1].Cells[1].Value.ToString() +
                                        "\".\nCambie el tipo de dato o el valor asignado.";
                                    break;
                                }
                            }
                            else if (tabla.Rows[i].Cells[1].Value.Equals("double"))
                            {
                                if (tabla.Rows[i + 3].Cells[2].Value.Equals("Número decimal"))
                                {
                                    r = "";
                                }
                                else
                                {
                                    r = "Error, el tipo de dato no corresponde con el valor asignado a la variable \"" + tabla.Rows[i + 1].Cells[1].Value.ToString() +
                                        "\".\nCambie el tipo de dato o el valor asignado.";
                                    break;
                                }
                            }
                            else if (tabla.Rows[i].Cells[1].Value.Equals("byte"))
                            {
                                if (tabla.Rows[i + 3].Cells[2].Value.Equals("Número") && int.Parse(tabla.Rows[i + 3].Cells[1].Value.ToString()) < 256)
                                {
                                    r = "";
                                }
                                else
                                {
                                    r = "Error, el tipo de dato no corresponde con el valor asignado a la variable \"" + tabla.Rows[i + 1].Cells[1].Value.ToString() +
                                        "\".\nCambie el tipo de dato o el valor asignado.";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return r;
        }
    }
}
