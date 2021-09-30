using System;
using System.Text;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Propiedad sobreescrita de la clase heredada retornará el tamaño del Suv
        /// Return ETamanio -> Grande
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Constructor de clase que asigna chasis, marca y color al vehiculo.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Devuelve todos los datos del Suv en formato string
        /// </summary>
        /// <returns>Datos del automóvil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
