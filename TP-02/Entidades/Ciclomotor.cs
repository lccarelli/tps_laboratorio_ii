using System;
using System.Text;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        /// <summary>
        /// Propiedad sobreescrita de la clase heredada retornará el tamaño del Ciclomotor
        /// Return ETamanio -> Chico
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Constructor de clase que asigna chasis, marca y color a la clase vehiculo.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            :base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Devuelve todos los datos del ciclomotor en formato string
        /// </summary>
        /// <returns>Datos del automóvil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
