using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoresClasicos {
    class CifradorAlberti {
        public CifradorAlberti() {

        }
        public string gira(int desp) {
            string alfa = "c&bmdgpfznxyvtoskerlhaiqc&bmdgpfznxyvtoskerlhaiq";
            desp = desp % 24;
            desp--;
            string alfcifra = "";
            for (int i = 1; i < 25; i++) {
                alfcifra += alfa[i + desp];
            }

            return alfcifra;
        }
        public string limpiaTexto(string texto) {
            texto = texto.ToUpper();
            return texto;
        }
        public string alberti(string plano, string movil, int despl, bool tipo) {
            string alfabeto = "ABCDEFGILMNOPQRSTVXZ1234";
            string res = "";
            int idx;
            char chr;
            plano = limpiaTexto(plano);
            for (int i = 0; i < plano.Length; i++) {
                if (tipo == true) {
                    idx = alfabeto.IndexOf(plano[i]);
                    chr = movil[idx];
                }else {
                    idx = movil.IndexOf(Char.ToLower(plano[i]));
                    chr = alfabeto[idx];
                }
                if (idx < 0) {
                    res += plano[i];
                }
                else {
                    res += chr;
                }
            }
            return res;
        }
    }
}
