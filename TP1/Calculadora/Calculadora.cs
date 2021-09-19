using System;
using System.Collections.Generic;

namespace Entidades
{
    public static class Calculadora
    {
        private const char MAS = '+';
        private const char MENOS = '-';
        private const char MULTIPLICAR = '*';
        private const char DIVIDIR = '/';

        public static double Operar(Operando num1, Operando num2, char operador) 
        {
            double resultado = 0;

            switch (ValidarOperador(operador)) 
            {
                case MAS:
                   resultado = num1 + num2;
                    break;
                case MENOS:
                    resultado = num1 - num2;
                    break;
                case MULTIPLICAR:
                    resultado = num1 * num2;
                    break;
                case DIVIDIR:
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        private static char ValidarOperador(char operador)
        {
            List<char> listaDeOperadores = new() { MAS, MENOS, DIVIDIR, MULTIPLICAR };
            return listaDeOperadores.Contains(operador) ? operador : MAS;
        }
    }
}
