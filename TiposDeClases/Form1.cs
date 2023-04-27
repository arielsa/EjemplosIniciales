using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiposDeClases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Las clases abstractas no se pueden instanciar
            //Mamifero m = new Mamifero();
            Vaca v = new Vaca();
            Persona per = new Persona();
            Perro p = new Perro();

            MessageBox.Show($"VACA --> {v.Comer()}");
            MessageBox.Show($"VACA --> {v.QueSoy()}");
            MessageBox.Show($"PERSONA --> {per.Comer()}");
            MessageBox.Show($"PERSONA --> {per.QueSoy()}");
            MessageBox.Show($"PERRO --> {p.Comer()}");
            MessageBox.Show($"PERRO --> {p.QueSoy()}");

        }
    }

    public abstract class Mamifero
    {
        public abstract string Comer();
        public virtual string QueSoy() { return "Soy un Mamífero !!!"; }
    }

    public class Vaca : Mamifero
    {
        public override string Comer()
        {
           return "Come como un rumiante";
        }

        public override string QueSoy()
        {
            return "Soy una Vaca !!!";
        }
    }
    public class Persona : Mamifero
    {
        public override string Comer()
        {
            return "Come como una Persona";
        }
    }
    public sealed class Perro : Mamifero
    {
        public override string Comer()
        {
            return "Come como un Perro";
        }
    }

    public abstract class Cetaceo : Mamifero
    {

    }
    // Una clase sellada no puede seguir especializándose
    //public class Labrador : Perro { }
}
