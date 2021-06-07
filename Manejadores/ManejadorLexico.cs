using System.Collections.Generic;
using Entidades;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;
using System.Diagnostics;

namespace Manejadores
{
    public class ManejadorLexico
    {
        //string tp, rsv, sg, da = "";
        //List<EntidadExpresion> ls = new List<EntidadExpresion>();

        public bool lexico(DataGridView dtg, RichTextBox codigo, List<EntidadExpresion> ls)  //5n+(N(n)+n)
        {
            //Stopwatch tiempo = new Stopwatch();
            
            dtg.Columns.Clear();  //n

            //tiempo.Start();
            ls = LlenarLista(codigo);  //n
            dtg.DataSource = ls.ToList();  //n
            //tiempo.Stop();
            //MessageBox.Show("Tiempo de ejecución: " + tiempo.ElapsedMilliseconds.ToString());

            dtg.AutoResizeColumns();  //n
            codigo.Focus();  //n
            if (dtg.RowCount > 0)  //N
            {
                return true;  //n
            }
            else
            {
                return false;  //n
            }
        }

        public List<EntidadExpresion> LlenarLista(RichTextBox rtb)  //3n+(N(L*(N(n)+8n))+n)
        {
            List<EntidadExpresion> ls = new List<EntidadExpresion>();  //n
            string[] token = rtb.Text.Split(' ', '\r', '\n');  //n

            if (rtb.Text != "")  //N
            {
                for (int i = 0; i < token.Length; i++)  //N->L=token.Lenght
                {
                    if (comprobarAsignacion(token[i]) != "")  //N
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarAsignacion(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarTipoDato(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarTipoDato(token[i]), comprobarPosicion(rtb, token[i]))); //n
                    }
                    else if (comprobarReservadas(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarReservadas(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarComentarios(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarComentarios(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarNumeros(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarNumeros(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarDelimitadores(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarDelimitadores(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarIdentificadores(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarIdentificadores(token[i]), comprobarPosicion(rtb, token[i])));  //n
                    }
                    else if (comprobarDecreaumento(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarDecreaumento(token[i]), comprobarPosicion(rtb, token[i]))); //n
                    }
                    else if (comprobarComparacion(token[i]) != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], comprobarComparacion(token[i]), comprobarPosicion(rtb, token[i]))); //n
                    }
                    else if (token[i] != "")
                    {
                        ls.Add(new EntidadExpresion(i + 1, token[i], "No identificado", comprobarPosicion(rtb, token[i])));   //n
                    }
                }

            }
            else
            {
                MessageBox.Show("No hay nada para analizar.");  //n
            }
            return ls;   //n
        }

        public void limpiarLista(List<EntidadExpresion> ls, RichTextBox rtb) //3n
        {
            ls.Clear();                              //n
            rtb.Text = "Iniciar\n\n\n\nFinalizar";   //n
            rtb.Focus();                             //n
        }

        public string comprobarAsignacion(string t)  //5n+(N(n)+n)
        {
            string asig = "";   //n
            Match m;            //n

            string asignacion = @"\b^[A-Z]*[a-z]*=[0-9][0-9]*$|^[A-Z]*[a-z]*=[A-Z]*[a-z][a-z]*$\b";  //n

            m = Regex.Match(t, asignacion);  //n
            if (/*m.Success &&*/ t == "=")   //N=1
            {
                asig = "Signo de asignación";  //n
            }
            else if (m.Success)
            {
                asig = "Expresión de asignación";  //n
            }
            return asig;  //n
        }

        public string comprobarTipoDato(string t)       //3n+(L*N(n))
        {
            string[] tipodato = { "int", "double", "byte" };  //n
            string td = "";                                  //n

            for (int i = 0; i < tipodato.Length; i++)    //N->L=tipodato.Lenght
            {
                if (t == tipodato[i])   //N
                {
                    td = "Tipo de dato"; break;  //n
                }
            }
            return td;   //n
        }

        public string comprobarComparacion(string t)   //6n+(N(n)+n)
        {
            string comp = "";  //n
            Match m;  //n
            Match n;  //n
                                                                //n
            string comparacion = @"\b^[A-Z]*[a-z]*==[0-9][0-9]*$|^[A-Z]*[a-z]*==[A-Z]*[a-z][a-z]*$|^[A-Z]*[a-z]*>[0-9][0-9]*$|^[A-Z]*[a-z]*>[A-Z]*[a-z][a-z]*$|^[A-Z]*[a-z]*<[0-9][0-9]*$|^[A-Z]*[a-z]*<[A-Z]*[a-z][a-z]*$|^[A-Z]*[a-z]*!=[0-9][0-9]*$|^[A-Z]*[a-z]*!=[A-Z]*[a-z][a-z]*$|^[A-Z]*[a-z]*>=[0-9][0-9]*$|^[A-Z]*[a-z]*>=[A-Z]*[a-z][a-z]*$|^[A-Z]*[a-z]*<=[0-9][0-9]*$|^[A-Z]*[a-z]*<=[A-Z]*[a-z][a-z]*$\b";
            string signoscomp = "^==$|^>$|^<$|^!=$|^>=$|^<=$";  //n

            m = Regex.Match(t, comparacion);  //n
            n = Regex.Match(t, signoscomp);   //n
            if (m.Success)  //N
            {
                comp = "Expresión de comparación";  //n
            }
            else if (n.Success)
            {
                comp = "Signo de comparación";  //n
            }
            return comp;  //n
        }

        public string comprobarReservadas(string t)  //4n+(L*(N(n)+(N(n)+n)))
        {
            string[] reservadas = { "GirarDerecha", "GirarIzquierda", "Subir", "Bajar", "Abrir", "Cerrar", "Soltar", "Extender", "Contraer", "Si" };  //n
            string[] begend = { "Iniciar", "Finalizar" };    //n
            string rsv = "";                                 //n

            for (int i = 0; i < reservadas.Length; i++)      //N->L=reservadas.Lenght
            {
                if (t == reservadas[i])                      //N
                {
                    rsv = "Palabra reservada"; break;        //n
                }
                else
                {
                    if (t == begend[0])                      //N
                    {
                        rsv = "Inicio de programa"; break;   //n
                    }
                    else if (t == begend[1])
                    {
                        rsv = "Fin de programa"; break;     //n
                    }
                }
            }
            return rsv;                                     //n
        }

        public string comprobarComentarios(string t)   //5n+N(n)
        {
            string cm = "";   //n
            Match m;          //n

            string comentarios = "^//[A-Z]*[a-z][a-z]*[0-9]*";  //n

            m = Regex.Match(t, comentarios);   //n
            if (m.Success)  //N
            {
                cm = "Comentario";  //n
            }
            return cm;   //n
        }

        public string comprobarNumeros(string t)   //7n+(N(n)+n)
        {
            string nm = "";  //n
            Match m, n;      //n

            string numeros = @"\b^[0-9][0-9]*$\b";   //n
            string decimales = @"\b^[0-9][0-9]*.[0-9][0-9]*$\b";   //n

            m = Regex.Match(t, numeros);   //n
            n = Regex.Match(t, decimales); //n
            if (m.Success)  //N
            {
                nm = "Número";  //n
            }
            else if (n.Success)
            {
                nm = "Número decimal";  //n
            }
            return nm;   //n
        }

        public string comprobarIdentificadores(string t)  //5n+N(n)
        {
            string id = "";  //n
            Match m;         //n

            string identificador = @"\b^[A-Z][A-Z]*[a-z]*[0-9]*$|^[a-z][a-z]*[A-Z]*[0-9]*$\b";   //n

            m = Regex.Match(t, identificador);  //n
            if (m.Success)  //N
            {
                id = "Identificador";   //n
            }
            return id;  //n
        }

        public string comprobarDelimitadores(string t)   //3n+L*(N(n)+n)
        {
            string[] signos = { "(", ")", "{", "}", ";" };   //n
            string sg = "";  //n

            for (int i = 0; i < signos.Length; i++)   //N->L=signos-Lenght
            {
                if (t == signos[i] && signos[i] == ";")  //N
                {
                    sg = "Signo de fin"; break;  //n
                }
                else if (t == signos[i])
                {
                    sg = "Delimitador"; break;   //n
                }
            }
            return sg;   //n
        }

        public string comprobarDecreaumento(string t)  //3n+L*(N(n)+n)
        {
            string[] decreaumento = { "++", "--" };  //n
            string da = "";  //n

            for (int i = 0; i < decreaumento.Length; i++)  //N ->L=decreaumento.Lenght
            {
                if (t == decreaumento[i] && decreaumento[i] == "++")  //N
                {
                    da = "Incremento"; break;  //n
                }
                else if (t == decreaumento[i])
                {
                    da = "Decremento"; break;  //n
                }
            }
            return da;  //n
        }

        public int comprobarPosicion(RichTextBox rtxt, string token)  //2n
        {
            int posicion = rtxt.Find(token);  //n
            return rtxt.GetLineFromCharIndex(posicion) + 1;   //n
        }

        //////////////////////////////////////////////METODOS RECURSIVOS/////////////////////////////////////////////////////////////

        //public List<EntidadExpresion> LlenarLista(RichTextBox rtb, int i)  //NUEVO METODO PARA LLENAR LISTA
        //{
        //    string[] token = rtb.Text.Split(' ', '\r', '\n');  //n

        //    if (rtb.Text != "")  //N
        //    {
        //        if (i < token.Length)  //N
        //        {
        //            if (comprobarAsignacion(token[i]) != "")  //N
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarAsignacion(token[i]), comprobarPosicion(rtb, token[i])));  //n
        //            }
        //            else if (comprobarTipoDato(token[i], 0) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarTipoDato(token[i], 0), comprobarPosicion(rtb, token[i]))); //n
        //            }
        //            else if (comprobarReservadas(token[i], 0) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarReservadas(token[i], 0), comprobarPosicion(rtb, token[i])));  //n
        //            }
        //            else if (comprobarComentarios(token[i]) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarComentarios(token[i]), comprobarPosicion(rtb, token[i])));  //n
        //            }
        //            else if (comprobarNumeros(token[i]) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarNumeros(token[i]), comprobarPosicion(rtb, token[i])));  //n
        //            }
        //            else if (comprobarDelimitadores(token[i], 0) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarDelimitadores(token[i], 0), comprobarPosicion(rtb, token[i]))); //n
        //            }
        //            else if (comprobarIdentificadores(token[i]) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarIdentificadores(token[i]), comprobarPosicion(rtb, token[i])));  //n
        //            }
        //            else if (comprobarDecreaumento(token[i], 0) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarDecreaumento(token[i], 0), comprobarPosicion(rtb, token[i]))); //n
        //            }
        //            else if (comprobarComparacion(token[i]) != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], comprobarComparacion(token[i]), comprobarPosicion(rtb, token[i]))); //n
        //            }
        //            else if (token[i] != "")
        //            {
        //                ls.Add(new EntidadExpresion(i + 1, token[i], "No identificado", comprobarPosicion(rtb, token[i])));    //n
        //            }
        //            i++;  //n
        //            LlenarLista(rtb, i); //n
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay nada para analizar.");  //n
        //    }
        //    return ls;   //n
        //} 


        //public string comprobarTipoDato(string t, int i) ////NUEVO METODO PARA TIPOS DE DATO
        //{
        //    string[] tipodato = { "int", "double", "byte" };  //n

        //    if (i < tipodato.Length)  //N
        //    {
        //        if (t == tipodato[i])  //N
        //        {
        //            i = tipodato.Length;  //n
        //            tp = "Tipo de dato";  //n
        //        }
        //        else
        //        {
        //            tp = "";  //n
        //        }
        //        i++;   //n
        //        if (i < tipodato.Length)  //N
        //        {
        //            comprobarTipoDato(t, i);  //n
        //        }
        //    }
        //    return tp;  //n
        //}


        //public string comprobarReservadas(string t, int i) ////NUEVO METODO PARA PALABRAS RESERVADAS
        //{
        //    string[] reservadas = { "GirarDerecha", "GirarIzquierda", "Subir", "Bajar", "Abrir", "Cerrar", "Soltar", "Extender", "Contraer", "Si" };
        //    string[] begend = { "Iniciar", "Finalizar" };  //2n

        //    if (i < reservadas.Length)  //N
        //    {
        //        if (t == reservadas[i])  //N
        //        {
        //            i = reservadas.Length;  //n
        //            rsv = "Palabra reservada";  //n
        //        }
        //        else
        //        {
        //            if (t == begend[0])  //N
        //            {
        //                i = reservadas.Length;  //n
        //                rsv = "Inicio de programa";  //n
        //            }
        //            else if (t == begend[1])
        //            {
        //                i = reservadas.Length;  //n
        //                rsv = "Fin de programa";  //n
        //            }
        //            else
        //            {
        //                rsv = "";  //n
        //                i++;   //n
        //                if (i < reservadas.Length)   //N
        //                {
        //                    comprobarReservadas(t, i);  //n
        //                }
        //            }
        //        }
        //    }
        //    return rsv;   //n
        //}


        //public string comprobarDelimitadores(string t, int i)   ////NUEVO METODO PARA COMPROBAR DELIMITADORES
        //{
        //    string[] signos = { "(", ")", "{", "}", ";" };  //n

        //    if (i < signos.Length)  //N
        //    {
        //        if (t == signos[i] && signos[i] == ";")  //N
        //        {
        //            i = signos.Length;  //n
        //            sg = "Signo de fin";  //n
        //        }
        //        else if (t == signos[i])
        //        {
        //            i = signos.Length;  //n
        //            sg = "Delimitador";  //n
        //        }
        //        else
        //        {
        //            sg = "";  //n
        //            i++;      //n
        //            if (i < signos.Length)   //N
        //            {
        //                comprobarDelimitadores(t, i);   //n
        //            }
        //        }
        //    }
        //    return sg;  //n
        //}

        //public string comprobarDecreaumento(string t, int i) ////NUEVO METODO PARA COMPROBAR INCREMENTOS Y DECREMENTOS
        //{
        //    string[] decreaumento = { "++", "--" };  //n

        //    if (i < decreaumento.Length)  //N
        //    {
        //        if (t == decreaumento[i] && decreaumento[i] == "++")  //N
        //        {
        //            i = decreaumento.Length;  //n
        //            da = "Incremento";  //n
        //        }
        //        else if (t == decreaumento[i])  
        //        {
        //            i = decreaumento.Length;  //n
        //            da = "Decremento";        //n
        //        }
        //        else
        //        {
        //            da = "";   //n
        //            i++;   //n
        //            comprobarDecreaumento(t, i);   //n
        //        }
        //    }
        //    return da;  //n
        //}
    }
}
