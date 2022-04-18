using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region Atributos

        private List<string> listOperadores = new() { "+", "-", "*", "/" };
        private const string MESSAGE_INVALID_VALUE = "Valor inválido";

        #endregion

        #region Constructores

        /// <summary>
        ///  Constructor clase FormCalculadora. Inicializa 
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        public FormCalculadora()
        {
            InitializeComponent();
            lblResultado.Text = string.Empty;

            foreach (string operador in listOperadores)
            {
                this.cmbOperador.Items.Add(operador);
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        ///  Boton de cerrar aplicación.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///  Boton convierte un numero de decimal a binario.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
            MostrarOperaciones($"Convertido a binario -> {lblResultado.Text}");
        }

        /// <summary>
        ///  Boton convierte de binario a decimal.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            MostrarOperaciones($"Convertido a decimal -> {lblResultado.Text}");
        }

        /// <summary>
        ///  Boton limpia los textBox de la pantalla.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        ///  Metodo llamado para limpiar objetos del formulario.
        /// </summary>
        private void Limpiar() 
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
            this.cmbOperador.Text = string.Empty;
        }

        /// <summary>
        ///  Boton de operar llama al metodo Operar Calculo.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operadorSeleccionado = (string)cmbOperador.SelectedItem;
            string result = Operar(txtNumero1.Text, txtNumero2.Text, operadorSeleccionado).ToString();

            if (result != double.MinValue.ToString())
            {
                lblResultado.Text = result;
            }else 
            {
                lblResultado.Text = MESSAGE_INVALID_VALUE;
            };
        
            MostrarOperaciones($"{txtNumero1.Text} {operadorSeleccionado} {txtNumero2.Text} = {lblResultado.Text}");
        }

        /// <summary>
        ///  Metodo que opera calculo pasado por el boton Operar.
        /// </summary>
        /// <param name="numero1">String contiene numero operando 1.</param>
        /// <param name="numero2">String contiene numero operando 2.</param>
        /// <param name="operador">string contiene el operador del calculo.</param>
        private static double Operar(string numero1, string numero2, string operador) 
        {
            char operadorChar;

            if (operador is null)
            {
                operadorChar = '+';
            }
            else 
            {
                operadorChar = char.Parse(operador);
            }

            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operadorChar);
        }

        /// <summary>
        ///  Metodo que muestra las operaciones en el listBox.
        /// </summary>
        /// <param name="operacion">String con la operacion completa.</param>
        private void MostrarOperaciones(string operacion) 
        {
            lstOperaciones.Items.Add(operacion);
        }

        /// <summary>
        ///  Metodo que limpia pantalla cuando se termina de iniciar el formulario y antes de que se dibuje.
        /// </summary>
        /// <param name="sender">Instancia del boton.</param>
        /// <param name="e">Informacion del evento.</param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Metodo que abre una ventada y pregunta si se quiere salir de la aplicacion.
        /// </summary>
        /// <returns>
        /// DialogResult -> DialogResult.Yes || Dialog.Result.NO
        /// </returns>
        private DialogResult QuererSalir() 
        {
            return MessageBox.Show("¿Está seguro que desea salir?","Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);       
        }

        /// <summary>
        ///  Metodo que cierra el formulario desde la 'x'.
        /// </summary>
        /// <param name="sender">Instancia del form.</param>
        /// <param name="e">Informacion del evento.</param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.QuererSalir() == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion
    }
}
