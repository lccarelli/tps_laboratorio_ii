using System;

namespace Entidades
{
    public static class Calculadora
    {
        #region Atributos

        private const char MAS = '+';
        private const char MENOS = '-';
        private const char MULTIPLICAR = '*';
        private const char DIVIDIR = '/';

        #endregion

        #region Métodos

        /// <summary>
        /// Valida y realiza la operacion requerida entre ambos numeros ingresados.
        /// </summary>
        /// <param name="num1">Primer numero de tipo Operando utilizado para la operacion</param>
        /// <param name="num2">Segundo numero de tipo Operando utilizado para la operacion</param>
        /// <param name="operador"> Operador a ser utilizado en el calculo </param>
        /// <returns></returns>
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

        /// <summary>
        ///  Valida si el operador ingreado se encuentra dentro de una lista de operadores disponibles.
        /// </summary>
        /// <param name="operador">de tipo char operador seleccionado.</param>
        /// <returns>Operador seleccionado si lo encuentra, si no devuelve operador de suma</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == MAS || operador == MENOS || operador == MULTIPLICAR || operador == DIVIDIR)
            {
                return operador;
            }
            return MAS;
        }

        #endregion
    }
}
