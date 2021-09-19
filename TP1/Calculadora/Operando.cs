using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando():this(0)
        {
        }

        public Operando(double numero) 
        {
            this.numero = numero;
        }

        public Operando(string numero) 
        {
            Numero = numero;
        }

        public string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Valida que el string ingresado sea un numero, y lo transforma
        /// </summary>
        /// <param name="strNumero">Parametro de tipo string</param>
        /// <returns>
        /// Caso OK     -> strNumero:double
        /// Caso ERROR  -> 0:double
        /// </returns>
        private double ValidarOperando(string strNumero) 
        {
            return !double.TryParse(strNumero, out double numero) || strNumero is null ? 0 : numero;

        }

        /// <summary>
        /// Valida que el string ingresado sea '0' o '1'
        /// </summary>
        /// <param name="binario">Parametro de tipo string</param>
        /// <returns>
        /// Caso OK     -> true
        /// Caso ERROR  -> false
        /// </returns>
        private static bool EsBinario(string binario) 
        {
            foreach (char item in binario)
            {
                if (item != '0' && item != '1') 
                {
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Transforma un string binario a un string decimal
        /// </summary>
        /// <param name="binario">Parametro de tipo string</param>
        /// <returns>
        /// Caso OK     -> numero decimal:string 
        /// Caso ERROR  -> 'Valor inválido':string
        /// </returns>
        public static string BinarioDecimal(string binario) 
        {
            double numeroDecimal = 0;

            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    _ = double.TryParse(binario[i].ToString(), out double numero);
                    numeroDecimal += numero * Math.Pow(2, binario.Length - i - 1);
                }
            }
            else 
            {
                return "Valor inválido";
            }

            return numeroDecimal.ToString();
        }

        /// <summary>
        /// Transforma un decimal a binario
        /// </summary>
        /// <param name="numero">Parametro de tipo double</param>
        /// <returns>
        /// Caso OK     -> numero binario:string 
        /// Caso ERROR  -> 'Valor inválido':string
        /// </returns>
        public static string DecimalBinario(double numero) 
        {
            const int BITS = 4;
            const int CERO = 0;
            string numeroBinario = string.Empty;
            long cociente = (long)numero;
            long resto;

            if (cociente == CERO) 
            {
                numeroBinario = "0";
            }

            while (cociente > CERO)
            {
                resto = cociente % 2;
                cociente /= 2;

                if (resto != CERO)
                {
                    numeroBinario = "1" + numeroBinario;
                }
                else
                {
                    numeroBinario = "0" + numeroBinario;
                }
            }

            int bitsFaltantes = numeroBinario.Length < BITS ? BITS - numeroBinario.Length : CERO;
            while (bitsFaltantes > CERO) 
            {     
                numeroBinario = "0" + numeroBinario;
                bitsFaltantes--;
            }



            return numeroBinario;
        }

        /// <summary>
        /// Transforma un decimal a binario
        /// </summary>
        /// <param name="numero">Parametro de tipo string</param>
        /// <returns>
        /// Caso OK     -> numero binario:string 
        /// Caso ERROR  -> 'Valor inválido':string
        /// </returns>
        public static string DecimalBinario(string numero) 
        {
            string resultado = "Valor inválido";

            if (double.TryParse(numero, out double numeroDecimal) && numeroDecimal > -1) 
            {
                resultado = DecimalBinario(numeroDecimal);
            }

            return resultado;
        }

        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="n1">Parametro de tipo Operando</param>
        /// <param name="m2">Parametro de tipo Operando</param>
        /// <returns>
        /// resultado de la resta:double 
        /// </returns>
        public static double operator -(Operando n1, Operando n2) 
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="n1">Parametro de tipo Operando</param>
        /// <param name="m2">Parametro de tipo Operando</param>
        /// <returns>
        /// resultado de la multiplicación:double 
        /// </returns>
        public static double operator *(Operando n1, Operando n2) 
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Divide dos numeros
        /// </summary>
        /// <param name="n1">Parametro de tipo Operando</param>
        /// <param name="m2">Parametro de tipo Operando</param>
        /// <returns>
        /// Si divisor es cero      -> double.MinValue;
        /// Si divisor no es cero   -> resultado de la division:double 
        /// </returns>
        public static double operator /(Operando n1, Operando n2) 
        {
            return n2.numero == 0 ?  double.MinValue : n1.numero / n2.numero;
        }

        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="n1">Parametro de tipo Operando</param>
        /// <param name="m2">Parametro de tipo Operando</param>
        /// <returns>
        /// resultado de la suma:double 
        /// </returns>
        public static double operator +(Operando n1, Operando n2) 
        {
            return n1.numero + n2.numero;
        }
    }
}
