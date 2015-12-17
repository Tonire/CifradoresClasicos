using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoresClasicos
{
    class CifradorVigenere
    {
        static string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Vigenerecifrado(string s, string cadena)
        {
            s = s.ToUpper();
            cadena = cadena.ToUpper();
            int j = 0;
            StringBuilder r = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (abecedario.Contains(s[i])){
                    r.Append(abecedario[(abecedario.IndexOf(s[i]) + abecedario.IndexOf(cadena[j])) % abecedario.Length]);
                }else{
                    r.Append(s[i]); 
                    j = (j + 1) % cadena.Length; 
                }
                          
            }
            return r.ToString();
        }



        public static string Vigenerdescifrado(string s, string cadena)
        {
            s = s.ToUpper();
            cadena = cadena.ToUpper();
            int j = 0;
            StringBuilder r = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (abecedario.Contains(s[i])){
                    r.Append(abecedario[(abecedario.IndexOf(s[i]) - abecedario.IndexOf(cadena[j]) + abecedario.Length) % abecedario.Length]);
                }else{
                    r.Append(s[i]);
                    j = (j + 1) % cadena.Length;
                }
                
            }
            return r.ToString();
        }
    }

}
