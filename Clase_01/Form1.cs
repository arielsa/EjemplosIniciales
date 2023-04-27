using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Clase_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Alumno a1,a2;
        private void button1_Click(object sender, EventArgs e)
        {
            a1 = new Alumno();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string l = Interaction.InputBox("Ingrese el legajo: ");
                if (Information.IsNumeric(l)) { a1.Legajo=int.Parse(l); }
                else { throw new Exception("Debe cargar un valor numérico !!!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show($"Legajo: {a1.Legajo}");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                a1.Nombre=Interaction.InputBox("Ingrese el nombre: ");
                a1.Apellido=Interaction.InputBox("Ingrese el apellido: ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(a1.Mostar());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(a2.Mostar());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            a1=null;
            a2=null;
            GC.Collect();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string l = Interaction.InputBox("Ingrese el legajo: ");//comentario
                if (Information.IsNumeric(l)) 
                { 
                    a2 = new Alumno(int.Parse(l),
                                    Interaction.InputBox("Nombre: "),
                                    Interaction.InputBox("Apellido: ")); 
                }
                else { throw new Exception("Debe cargar un valor numérico !!!"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class Alumno
    {
        #region Campos
        private int legajo;
        #endregion
        #region Contructor

        public Alumno()
        {
                
        }
        public Alumno(int pLegajo) : this()
        {
            Legajo = pLegajo;
        }
        public Alumno(int pLegajo,string pNombre, string pApellido) : this(pLegajo)
        {
            Nombre=pNombre;
            Apellido=pApellido;
        }
        #endregion
        #region Propiedades
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }

        #endregion
        #region Métodos
        public string Mostar()
        { return $"Legajo: {Legajo}{Environment.NewLine}" +
                 $"Nombre: {Nombre}{Environment.NewLine}" +
                 $"Apellido: {Apellido}"; }
        #endregion
        #region Destructor
        ~Alumno()
        {
            MessageBox.Show($"Se ejecutó el destructor de {Legajo} {Nombre} {Apellido} !!!"); 
        }
        #endregion

    }
}
