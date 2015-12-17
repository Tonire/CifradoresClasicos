using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoresClasicos
{
    class CifradorVigenere
    {
        static string abecedario = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

        public static string Vigenerecifrado(string s, string cadena, string alfabeto)
        {
            s = s.ToUpper();
            cadena = cadena.ToUpper();
            int j = 0;
            StringBuilder r = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (alfabeto.Contains(s[i]))

                    r.Append(alfabeto[(alfabeto.IndexOf(s[i]) + alfabeto.IndexOf(cadena[j])) % alfabeto.Length]);
                else
                    r.Append(s[i]); 
                    j = (j + 1) % cadena.Length;       
            }
            return r.ToString();
        }



        public static string Vigenerdescifrado(string s, string cadena, string alfabeto)
        {
            s = s.ToUpper();
            cadena = cadena.ToUpper();
            int j = 0;
            StringBuilder r = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (alfabeto.Contains(s[i]))

                    r.Append(alfabeto[(alfabeto.IndexOf(s[i]) - alfabeto.IndexOf(cadena[j]) + alfabeto.Length) % alfabeto.Length]);
                else
                    r.Append(s[i]);
                j = (j + 1) % cadena.Length;
            }
            return r.ToString();
        }
    }

}
