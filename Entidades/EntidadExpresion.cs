namespace Entidades
{
    public class EntidadExpresion
    {
        public int Numero { get; set; }
        public string Token { get; set; }
        public string Descripcion { get; set; }
        public int Linea { get; set; }

        public EntidadExpresion(int numero, string token, string descripcion, int linea)
        {
            Numero = numero;
            Token = token;
            Descripcion = descripcion;
            Linea = linea;
        }
    }
}
