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

namespace Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Termostato t;
        private void Form1_Load(object sender, EventArgs e)
        {
            t=new Termostato();
            button2_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                t.Temperatura=int.Parse(Interaction.InputBox("Temperatura: "));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void FuncionSuscriptaATemperaturaPeligrosa(object sender, TemperaturaPeligrosaEventArgs e)
        {
           
            MessageBox.Show($"Se cargó una temperatura Peligrosa !!!{Environment.NewLine}" +
                            $"Temperatura ingresada: {e.ValorIngresado}{Environment.NewLine}" +
                            $"Delta: {e.Delta}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.TemperaturaPeligrosa+=FuncionSuscriptaATemperaturaPeligrosa;
            label1.Text= (int.Parse(label1.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t.TemperaturaPeligrosa-=FuncionSuscriptaATemperaturaPeligrosa;
            if(int.Parse(label1.Text)>0) label1.Text= (int.Parse(label1.Text) - 1).ToString();
        }
    }
    public class Termostato
    {
        private int temperatura;
        //Declaración del evento
        public event EventHandler<TemperaturaPeligrosaEventArgs> TemperaturaPeligrosa;
        public int Temperatura
        {
            get { return temperatura; }
            //Desencadenamiento del evento
            set { temperatura = value; if (value>100) TemperaturaPeligrosa?.Invoke(this, new TemperaturaPeligrosaEventArgs(100,value)); }
            // if(TemperaturaPeligrosa!=null) TemperaturaPeligrosa(null,null);
        }
    }

    public class TemperaturaPeligrosaEventArgs : EventArgs
    {
        int temperaturaCorte,temperaturaIngresada;

        public TemperaturaPeligrosaEventArgs(int pTemperaturaCorte,int pTemperaturaIngresada)
        {
            temperaturaCorte=pTemperaturaCorte;temperaturaIngresada=pTemperaturaIngresada;
        }
        public int ValorIngresado { get { return temperaturaIngresada; } }
        public int Delta { get { return temperaturaIngresada-temperaturaCorte; } }

    }
}
