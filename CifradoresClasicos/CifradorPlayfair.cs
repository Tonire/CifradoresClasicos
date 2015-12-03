using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoresClasicos
{
    class CifradorPlayfair
    {
        static string alfabeto = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        public string clave, claro, cifrado;
        public char[,] matriz = new char[5, 5];

        public CifradorPlayfair()
        {
            this.clave = "";
            this.claro = "";
            this.cifrado = "";
        }

        public string arreglar(string texto)
        {
            texto.ToUpper();
            texto.Replace('I', 'J'); //Quito las Js
            texto.Replace('N', 'Ñ');  //Quito las Ñs
            string arreglado = "";
            string texto2 = "";
            for (int x = 0; x < texto.Length; x++)
            { //Elimino los espacios
                if (texto[x] != ' ')
                    texto2 += texto[x];
            }
            for (int i = 0; i < texto2.Length; i++)
            {
                if ((i + 1) != texto2.Length)
                {
                    if (texto2[i] != texto2[i + 1])
                    {
                        arreglado = arreglado + texto2[i] + texto2[i + 1]; //Compruebo que no haya digramas igules
                        i++;
                    }
                    else
                    {
                        arreglado = arreglado + texto2[i] + 'Z';  //Si los hay meto x entre medio
                    }
                }
                else
                    arreglado = arreglado + texto2[i] + 'Z';  //Si la longitud del texto es impar incluyo una X

            }
            if (arreglado.Length % 2 == 1) arreglado += 'Z';
            return arreglado;
        }


        public void generarMatriz(string clave)
        {
            //Aquí genero la matriz de playfair
            clave.ToUpper();
            string texto = "";
            for (int i = 0; i < clave.Length; i++)
            {
                if (texto.IndexOf(clave[i]) == -1 && clave[i] != ' ')
                    texto += clave[i];
            }
            for (int i = 0; i < alfabeto.Length; i++)
            {
                if (texto.IndexOf(alfabeto[i]) == -1)
                    texto += alfabeto[i];
            }
            for (int j = 0, k = 0; j < 5; j++)
                for (int i = 0; i < 5; i++)
                {
                    //System.out.print(texto[k]);
                    matriz[j, i] = texto[k];
                    k++;
                }
            this.clave = texto;
        }

        public string descifrarDigrama(char a, char b)
        {
            string digrama = "";
            Par par1 = new Par();
            Par par2 = new Par();

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matriz[j, i] == a)
                    {
                        par1.i = i;
                        par1.j = j;
                    }
                    if (matriz[j, i] == b)
                    {
                        par2.i = i;
                        par2.j = j;
                    }
                    //System.out.print(matriz[j][i]);
                }
                // System.out.println("\n");
            }
            //CASO J
            if (par1.j == par2.j)
            {
                //System.out.println("Entro fil");
                int J, IA, IB;
                J = par1.getJ();
                IA = ((par1.getI() - 1));
                IB = ((par2.getI() - 1));
                if (IA < 0) IA += 5;
                if (IB < 0) IB += 5;
                a = matriz[J, IA];
                b = matriz[J, IB];
            }
            //CASO I
            else if (par1.i == par2.i)
            {
                //System.out.println("entro col");
                int I, JA, JB;
                JA = ((par1.getJ() - 1));
                JB = ((par2.getJ() - 1));
                if (JA < 0) JA += 5;
                if (JB < 0) JB += 5;
                I = par1.getI();
                a = matriz[JA, I];
                b = matriz[JB, I];
                // System.out.println(a + "," + b);
            }

            else
            {
                a = matriz[par1.j, par2.i];
                b = matriz[par2.j, par1.i];
            }
            digrama += a;
            digrama += b;

            return digrama;
        }

        public string cifrarDigrama(char a, char b)
        {
            string digrama = "";
            Par par1 = new Par();
            Par par2 = new Par();

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (matriz[j, i] == a)
                    {
                        par1.i = i;
                        par1.j = j;
                        // System.out.println("ENCUENTRO A" + j + i);
                    }
                    if (matriz[j, i] == b)
                    {
                        par2.i = i;
                        par2.j = j;
                        //  System.out.println("ENCUENTRO B" + j + i);
                    }
                }
            }
            //CASO J
            if (par1.j == par2.j)
            {
                //System.out.println("Entro fil");
                int J, IA, IB;
                J = par1.getJ();
                IA = ((par1.getI() + 1) % 5);
                IB = ((par2.getI() + 1) % 5);
                a = matriz[J, IA];
                b = matriz[J, IB];
            }
            //CASO I
            else if (par1.i == par2.i)
            {
                //System.out.println("entro col");
                int I, JA, JB;
                JA = ((par1.getJ() + 1) % 5);
                JB = ((par2.getJ() + 1) % 5);
                I = par1.getI();
                a = matriz[JA, I];
                b = matriz[JB, I];
                // System.out.println(a + "," + b);
            }
            else
            {
                b = matriz[par2.j, par1.i];
                a = matriz[par1.j, par2.i];
            }
            digrama += a;
            digrama += b;

            return digrama;
        }

        public string cifrar(string claro, string clave)
        {
            claro = arreglar(claro);
            generarMatriz(clave);
            cifrado = "";
            for (int i = 0; i < claro.Length; i = i + 2)
                cifrado += cifrarDigrama(claro[i], claro[i + 1]);

            return cifrado;
        }

        public string descifrar(string cifrado, string clave)
        {
            generarMatriz(clave);
            claro = "";
            for (int i = 0; i < cifrado.Length; i = i + 2)
                claro += descifrarDigrama(cifrado[i], cifrado[i + 1]);
            //System.out.println("texto en claro: " + claro);
            return claro;

        }
        public char[,] getMatriz()
        {
            return matriz;
        }

    }

    //Par.java

    public class Par
    {
        public int i, j;

        public Par()
        {
            i = -1;
            j = -1;
        }

        public int getI()
        {
            return i;
        }

        public void setI(int i)
        {
            this.i = i;
        }
        public int getJ()
        {
            return j;
        }
        public void setJ(int j)
        {
            this.j = j;
        }
    }
}
