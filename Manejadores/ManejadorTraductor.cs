using System;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorTraductor
    {
        int delay = 4000;
        public string Traducir(DataGridView dtg, int pinBase1, int pinBase2, int pinBase3, int pinBase4, int pinHombro, int pinCodo, int pinPinza)
        {
            string codigo = "";

            string librerias;
            string variable = "";
            string setup;
            string lup;
            string instrucciones;
            string fin;
            string condicional;

            librerias = inicio(pinBase1, pinBase2, pinBase3, pinBase4);
            variable += variables(dtg);
            setup = Configuracion(pinHombro, pinCodo, pinPinza);
            lup = loop(dtg);
            instrucciones = moverBrazo(dtg);
            fin = Fin(dtg);
            condicional = condicionales(dtg);

            codigo = librerias + variable + setup + lup + instrucciones + condicional + fin + "\n";

            return codigo;
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

        private bool encontrarAtras(DataGridView dtg, int fila, int columna, string descripcion)
        {
            bool r = false;

            for (int i = 0; i < fila; i++)
            {
                if (dtg.Rows[i].Cells[columna].Value.ToString().Equals(descripcion))
                {
                    r = true; break;
                }
            }
            return r;
        }

        private bool comparar(DataGridView dtg, int fila, int columna, string descripcion)
        {
            bool r = false;

            try
            {
                if (dtg.Rows[fila].Cells[columna].Value.ToString().Equals(descripcion))
                {
                    r = true;
                }
            }
            catch (Exception)
            {

            }
            return r;
        }

        private string obtener(DataGridView dtg, int fila, int columna)
        {
            string r = "";

            try
            {
                r = dtg.Rows[fila].Cells[columna].Value.ToString();
            }
            catch (Exception)
            {

            }
            return r;
        }

        private string loop(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 1, "Iniciar"))
                {
                    r += "\nvoid loop()\n{";
                }
                else if (comparar(tabla, i, 2, "Comentario") && encontrar(tabla, i, 1, "Iniciar") && encontrar(tabla, i, 1, "Finalizar") && !encontrarAtras(tabla, i, 1, "Si"))
                {
                    r += "\n" + obtener(tabla, i, 1);
                }
            }
            return r;
        }

        private string Fin(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 1, "Finalizar"))
                {
                    r += "\n}";
                }
                else if (comparar(tabla, i, 2, "Comentario") && encontrarAtras(tabla, i, 1, "Finalizar") && encontrarAtras(tabla, i, 1, "Iniciar"))
                {
                    r += "\n" + obtener(tabla, i, 1);
                }
            }
            return r;
        }

        public string inicio(int pinBase1, int pinBase2, int pinBase3, int pinBase4)
        {
            string r = "#include <Servo.h>\n#include <Stepper.h>\n\nServo extendContract, UpDown, OpenClose;\nStepper" +
                " base(2048, " + pinBase1 + ", " + pinBase2 + ", " + pinBase3 + ", " + pinBase4 + ");\n";
            return r;
        }

        public string variables(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 2, "Tipo de dato"))
                {
                    if (comparar(tabla, i + 1, 2, "Identificador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Signo de asignación"))
                        {
                            if (comparar(tabla, i + 3, 2, "Número"))
                            {
                                if (comparar(tabla, i + 4, 2, "Signo de fin"))
                                {
                                    r += "\n" + obtener(tabla, i, 1) + " " + obtener(tabla, i + 1, 1) + " " + obtener(tabla, i + 2, 1) +
                                        " " + obtener(tabla, i + 3, 1) + " " + obtener(tabla, i + 4, 1);
                                }
                            }
                        }
                    }
                    else if (comparar(tabla, i + 1, 2, "Expresión de asignación"))
                    {
                        if (comparar(tabla, i + 2, 2, "Signo de fin"))
                        {
                            r += "\n" + obtener(tabla, i, 1) + " " + obtener(tabla, i + 1, 1) + " " + obtener(tabla, i + 2, 1);
                        }
                    }
                }
            }
            return r;
        }

        private string Configuracion(int pinHombro, int pinCodo, int pinPinza)
        {
            string r = "\n\nvoid setup()\n{\nextendContract.attach(" + pinHombro + ");\nUpDown.attach(" + pinCodo + ");\nOpenClose.attach(" + pinPinza + ");\n" +
                "base.setSpeed(5);\n}\n";
            return r;
        }

        //Metodo uno para mover el brazo
        private string moverBrazo(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 1, "Subir") || comparar(tabla, i, 1, "Abrir") || comparar(tabla, i, 1, "Extender") || comparar(tabla, i, 1, "Si"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Subir")
                                    {
                                        r += "\nUpDown.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Abrir")
                                    {
                                        r += "\nOpenClose.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Extender")
                                    {
                                        r += "\nextendContract.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Subir")
                                    {
                                        r += "\nUpDown.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Abrir")
                                    {
                                        r += "\nOpenClose.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Extender")
                                    {
                                        r += "\nextendContract.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 1, "Bajar") || comparar(tabla, i, 1, "Cerrar") || comparar(tabla, i, 1, "Contraer"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Bajar")
                                    {
                                        r += "\nUpDown.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Cerrar")
                                    {
                                        r += "\nOpenClose.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Contraer")
                                    {
                                        r += "\nextendContract.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Bajar")
                                    {
                                        r += "\nUpDown.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Cerrar")
                                    {
                                        r += "\nOpenClose.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Contraer")
                                    {
                                        r += "\nextendContract.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 1, "Soltar"))
                {
                    if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                    {
                        r += "\nOpenClose.write(-125);\ndelay(" + delay + ");";
                    }
                }
                else if (comparar(tabla, i, 1, "GirarDerecha") || comparar(tabla, i, 1, "GirarIzquierda"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "GirarDerecha")
                                    {
                                        r += "\nbase.step(" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "GirarIzquierda")
                                    {
                                        r += "\nbase.step(-" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (!encontrarAtras(tabla, i, 1, "Si") || encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "GirarDerecha")
                                    {
                                        r += "\nbase.step(" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "GirarIzquierda")
                                    {
                                        r += "\nbase.step(-" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 2, "Comentario") && !encontrar(tabla, i, 1, "Iniciar") && encontrar(tabla, i, 1, "Finalizar") && 
                    encontrarAtras(tabla, i, 1, "Iniciar") && !encontrarAtras(tabla, i, 1, "Si") || comparar(tabla, i, 2, "Comentario") && 
                    encontrarAtras(tabla, i, 1, "Si") && encontrarAtras(tabla, i, 1, "}") && !encontrarAtras(tabla, i, 1, "Finalizar"))
                {
                    r += "\n" + obtener(tabla, i, 1);
                }
            }
            return r;
        }

        public string condicionales(DataGridView tabla)
        {
            string r = "";

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 1, "Si"))
                {
                    if (comparar(tabla, i + 1, 1, "("))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Signo de comparación"))
                            {
                                if (comparar(tabla, i + 4, 2, "Identificador"))
                                {
                                    if (comparar(tabla, i + 5, 1, ")"))
                                    {
                                        if (comparar(tabla, i + 6, 1, "{"))
                                        {
                                            r += "\nif (" + obtener(tabla, i + 2, 1) + obtener(tabla, i + 3, 1) + obtener(tabla, i + 4, 1) + ")\n{" +
                                                moverBrazo(tabla, i + 7) + decreaumentos(tabla) + "\n}";
                                        }
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Signo de comparación"))
                            {
                                if (comparar(tabla, i + 4, 2, "Número"))
                                {
                                    if (comparar(tabla, i + 5, 1, ")"))
                                    {
                                        if (comparar(tabla, i + 6, 1, "{"))
                                        {
                                            r += "\nif (" + obtener(tabla, i + 2, 1) + obtener(tabla, i + 3, 1) + obtener(tabla, i + 4, 1) + ")\n{" +
                                                moverBrazo(tabla, i + 7) + decreaumentos(tabla) + "\n}";
                                        }
                                    }
                                }
                                else if (comparar(tabla, i + 4, 2, "Identificador"))
                                {
                                    if (comparar(tabla, i + 5, 1, ")"))
                                    {
                                        if (comparar(tabla, i + 6, 1, "{"))
                                        {
                                            r += "\nif (" + obtener(tabla, i + 2, 1) + obtener(tabla, i + 3, 1) + obtener(tabla, i + 4, 1) + ")\n{" 
                                                + moverBrazo(tabla, i + 7) + decreaumentos(tabla) + "\n}";
                                        }
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Expresión de comparación"))
                        {
                            if (comparar(tabla, i + 3, 1, ")"))
                            {
                                if (comparar(tabla, i + 4, 1, "{"))
                                {
                                    r += "\nif (" + obtener(tabla, i + 2, 1) + ")\n{" + moverBrazo(tabla, i + 7) + decreaumentos(tabla) + "\n}";
                                }
                            }
                        }
                    }
                }
            }
            return r;
        }

        public string decreaumentos(DataGridView tabla)
        {
            string r = "";
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 2, "Identificador"))
                {
                    if (comparar(tabla, i + 1, 2, "Incremento") || comparar(tabla, i + 1, 2, "Decremento"))
                    {
                        if (comparar(tabla, i + 2, 2, "Signo de fin"))
                        {
                            r += "\n" + obtener(tabla, i, 1) + obtener(tabla, i + 1, 1) + obtener(tabla, i + 2, 1);
                        }
                    }
                }
            }
            return r;
        }

        //Metodo uno para mover el brazo dentro de la condicional
        private string moverBrazo(DataGridView tabla, int indice)
        {
            string r = "";

            for (int i = indice; i < tabla.Rows.Count; i++)
            {
                if (comparar(tabla, i, 1, "Subir") || comparar(tabla, i, 1, "Abrir") || comparar(tabla, i, 1, "Extender") || comparar(tabla, i, 1, "Si"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Subir")
                                    {
                                        r += "\nUpDown.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Abrir")
                                    {
                                        r += "\nOpenClose.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";//pendiente
                                    }
                                    else if (obtener(tabla, i, 1) == "Extender")
                                    {
                                        r += "\nextendContract.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Subir")
                                    {
                                        r += "\nUpDown.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Abrir")
                                    {
                                        r += "\nOpenClose.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Extender")
                                    {
                                        r += "\nextendContract.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 1, "Bajar") || comparar(tabla, i, 1, "Cerrar") || comparar(tabla, i, 1, "Contraer"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Bajar")
                                    {
                                        r += "\nUpDown.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Cerrar")
                                    {
                                        r += "\nOpenClose.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Contraer")
                                    {
                                        r += "\nextendContract.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "Bajar")
                                    {
                                        r += "\nUpDown.write(-" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Cerrar")
                                    {
                                        r += "\nOpenClose.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "Contraer")
                                    {
                                        r += "\nextendContract.write(" + obtener(tabla, i + 2, 1) + ");\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 1, "Soltar"))
                {
                    if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                    {
                        r += "\nOpenClose.write(-125);\ndelay(" + delay + ");";
                    }
                }
                else if (comparar(tabla, i, 1, "GirarDerecha") || comparar(tabla, i, 1, "GirarIzquierda"))
                {
                    if (comparar(tabla, i + 1, 2, "Delimitador"))
                    {
                        if (comparar(tabla, i + 2, 2, "Número"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "GirarDerecha")
                                    {
                                        r += "\nbase.step(" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "GirarIzquierda")
                                    {
                                        r += "\nbase.step(-" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                        else if (comparar(tabla, i + 2, 2, "Identificador"))
                        {
                            if (comparar(tabla, i + 3, 2, "Delimitador"))
                            {
                                if (encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                                {
                                    if (obtener(tabla, i, 1) == "GirarDerecha")
                                    {
                                        r += "\nbase.step(" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                    else if (obtener(tabla, i, 1) == "GirarIzquierda")
                                    {
                                        r += "\nbase.step(-" + obtener(tabla, i + 2, 1) + "*5.688888889);\ndelay(" + delay + ");";
                                    }
                                }
                            }
                        }
                    }
                }
                else if (comparar(tabla, i, 2, "Comentario") && encontrarAtras(tabla, i, 1, "Si") && encontrar(tabla, i, 1, "}"))
                {
                    r += "\n" + obtener(tabla, i, 1);
                }
            }
            return r;
        }
    }
}
