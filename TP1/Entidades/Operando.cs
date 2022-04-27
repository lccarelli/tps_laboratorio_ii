using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Atributos

        private double numero;

        #endregion

        #region Constructores

        /// <summary>
        /// Asigna el valor 0 al atributo numero.
        /// </summary>
        public Operando() : this(0)
        {
        }

        /// <summary>
        /// Asigna un valor double pasado por parametro al atributo numero
        /// </summary>
        /// <param name="numero"></param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Asigna un valor string pasado por parametro a la propiedad Numero
        /// </summary>
        /// <param name="strNumero"></param>
        public Operando(string numero)
        {
            Numero = numero;
        }

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad que asigna un valor al atributo numero previamente validado
        /// </summary>
        public string Numero
        {
            set
            {
                numero = ValidarOperando(value);
            }
        }

        #endregion

        #region Métodos

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
            if (!double.TryParse(strNumero, out double numero))
            {  
                numero = 0; 
            }
            return numero;

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
            string resultado = "Valor inválido";
            int aux;
            aux = (int)numero;

            if (aux > -1)
            {
                resultado = string.Empty;
                while (aux > 0)
                {
                    resultado = (aux % 2).ToString() + resultado;
                    aux = (int)aux / 2;
                }
            }

            return resultado;
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

            if (double.TryParse(numero, out double numeroDecimal))
            {
                resultado = DecimalBinario(numeroDecimal);
            }

            return resultado;
        }

        #endregion

        #region Sobrecargas

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
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            else
            { 
                return n1.numero / n2.numero;
            }
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

        #endregion
    }
}
