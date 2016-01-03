using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifradoresClasicos {
    class CifradorVigenere {
        static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Alfabeto alfabeto = new Alfabeto();
        public CifradorVigenere() {
            Alfabeto alfabeto = new Alfabeto();
        }
        public string Cifrado(string plaintext, string key, bool cifrar) {
            int textSize = plaintext.Length;
            int keySize = key.Length;

            int groupSize1 = 'Z' - 'A' + 1;
            int groupSize2 = 'z' - 'a' + 1;
            int totalGroupSize = groupSize1 + groupSize2;

            StringBuilder encryptedText = new StringBuilder(textSize);
            for (int i = 0; i < textSize; i++) {
                char plainChar = plaintext[i];

                // this should be a method, called for both the plain text as well as the key
                int plainGroupNumber;
                if (plainChar >= 'A' && plainChar <= 'Z') {
                    plainGroupNumber = plainChar - 'A';
                } else if (plainChar >= 'a' && plainChar <= 'z') {
                    plainGroupNumber = groupSize1 + plainChar - 'a';
                } else {
                    // simply leave spaces and other characters

                    encryptedText.Append(plainChar);
                    continue;
                }

                char keyChar = key[i % keySize];
                int keyGroupNumber = 0;
                if (keyChar >= 'A' && keyChar <= 'Z') {
                    keyGroupNumber = keyChar - 'A';
                } else if (keyChar >= 'a' && keyChar <= 'z') {
                    keyGroupNumber = groupSize1 + keyChar - 'a';
                } else {
                    throw new Exception();
                }

                // this should be a separate method
                int cipherGroupNumber;
                if (cifrar) {
                    cipherGroupNumber = (plainGroupNumber + keyGroupNumber) % totalGroupSize;
                } else {
                    // some code to go around the awkward way of handling % in Java for negative numbers
                    int someCipherGroupNumber = (plainGroupNumber - keyGroupNumber) % totalGroupSize;
                    if (someCipherGroupNumber < 0) {
                        cipherGroupNumber = (someCipherGroupNumber + totalGroupSize);
                    } else {
                        cipherGroupNumber = someCipherGroupNumber;
                    }
                }

                // this should be a separate method
                char cipherChar;
                if (cipherGroupNumber < groupSize1) {
                    cipherChar = (char)('A' + cipherGroupNumber);
                } else {
                    cipherChar = (char)('a' + cipherGroupNumber - groupSize1);
                }
                encryptedText.Append(cipherChar);
            }

            return encryptedText.ToString();
        }



        public string VigenereDecrypt(string s, string key) {
            s = s.ToUpper();
            key = key.ToUpper();
            int j = 0;
            StringBuilder ret = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++) {
                if (alphabet.Contains(s[i]))
                    ret.Append(alphabet[(alphabet.IndexOf(s[i]) - alphabet.IndexOf(key[j]) + alphabet.Length) % alphabet.Length]);
                else
                    ret.Append(s[i]);
                j = (j + 1) % key.Length;
            }
            return ret.ToString();
        }
    }

}
public class Alfabeto {
    public Alfabeto() { }
    public int numero(String a) {
        int C = -666;
        if (a.Equals(" ")) {
            C = -555;
        } else if (a.Equals("a")) {
            C = 0;
        } else if (a.Equals("b")) {
            C = 1;
        } else if (a.Equals("c")) {
            C = 2;
        } else if (a.Equals("d")) {
            C = 3;
        } else if (a.Equals("e")) {
            C = 4;
        } else if (a.Equals("f")) {
            C = 5;
        } else if (a.Equals("g")) {
            C = 6;
        } else if (a.Equals("h")) {
            C = 7;
        } else if (a.Equals("i")) {
            C = 8;
        } else if (a.Equals("j")) {
            C = 9;
        } else if (a.Equals("k")) {
            C = 10;
        } else if (a.Equals("l")) {
            C = 11;
        } else if (a.Equals("m")) {
            C = 12;
        } else if (a.Equals("n")) {
            C = 13;
        } else if (a.Equals("o")) {
            C = 14;
        } else if (a.Equals("p")) {
            C = 15;
        } else if (a.Equals("q")) {
            C = 16;
        } else if (a.Equals("r")) {
            C = 17;
        } else if (a.Equals("s")) {
            C = 18;
        } else if (a.Equals("t")) {
            C = 19;
        } else if (a.Equals("u")) {
            C = 20;
        } else if (a.Equals("v")) {
            C = 21;
        } else if (a.Equals("w")) {
            C = 22;
        } else if (a.Equals("x")) {
            C = 23;
        } else if (a.Equals("y")) {
            C = 24;
        } else if (a.Equals("z")) {
            C = 25;
        }
        return C;
    }

    public String letra(int a) {
        String C = null;
        if (a == -555) {
            C = " ";
        } else if (a == 0) {
            C = "a";
        } else if (a == 1) {
            C = "b";
        } else if (a == 2) {
            C = "c";
        } else if (a == 3) {
            C = "d";
        } else if (a == 4) {
            C = "e";
        } else if (a == 5) {
            C = "f";
        } else if (a == 6) {
            C = "g";
        } else if (a == 7) {
            C = "h";
        } else if (a == 8) {
            C = "i";
        } else if (a == 9) {
            C = "j";
        } else if (a == 10) {
            C = "k";
        } else if (a == 11) {
            C = "l";
        } else if (a == 12) {
            C = "m";
        } else if (a == 13) {
            C = "n";
        } else if (a == 14) {
            C = "o";
        } else if (a == 15) {
            C = "p";
        } else if (a == 16) {
            C = "q";
        } else if (a == 17) {
            C = "r";
        } else if (a == 18) {
            C = "s";
        } else if (a == 19) {
            C = "t";
        } else if (a == 20) {
            C = "u";
        } else if (a == 21) {
            C = "v";
        } else if (a == 22) {
            C = "w";
        } else if (a == 23) {
            C = "x";
        } else if (a == 24) {
            C = "y";
        } else if (a == 25) {
            C = "z";
        }
        return C;
    }

}
