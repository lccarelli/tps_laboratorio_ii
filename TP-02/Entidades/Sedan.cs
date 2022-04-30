using System;
using System.Text;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        /// <summary>
        /// Atributos de la clase.
        /// </summary>
        ETipo tipo;

        /// <summary>
        /// Propiedad sobreescrita de la clase heredada retornará el tamaño del Sedan
        /// Return ETamanio -> Mediano
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            :this(marca, chasis, color, ETipo.CuatroPuertas)
        { 
        }

        /// <summary>
        /// Constructor de clase que asigna chasis, marca y color a la clase vehiculo, y tipo a la clase actual.
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Devuelve todos los datos del Sedan en formato string
        /// </summary>
        /// <returns>Datos del automóvil</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Tipos disponibles para Sedan
        /// </summary>
        public enum ETipo { CuatroPuertas, CincoPuertas }
    }
}
