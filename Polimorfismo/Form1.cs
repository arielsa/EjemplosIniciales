using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polimorfismo
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
        private void EjecutaPolimorfismo(Operacion pOperacion)
        {

            try
            {
                textBox3.Text=pOperacion.Ejecutar(Convert.ToDecimal(textBox1.Text), Convert.ToDecimal(textBox2.Text)).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EjecutaPolimorfismo(new Suma());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EjecutaPolimorfismo(new Resta());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EjecutaPolimorfismo(new Producto());
        }
    }

    public abstract class Operacion
    {
        public abstract decimal Ejecutar(decimal n1, decimal n2);

    }

    public class Suma : Operacion
    {
        public override decimal Ejecutar(decimal n1, decimal n2)
        {
            return n1+n2;
        }
    }
    public class Resta : Operacion
    {
        public override decimal Ejecutar(decimal n1, decimal n2)
        {
            return n1-n2;
        }
    }
    public class Producto : Operacion
    {
        public override decimal Ejecutar(decimal n1, decimal n2)
        {
            return n1*n2;
        }
    }
}
