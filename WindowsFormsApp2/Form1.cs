using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public struct Prodotto
        {
            public string nome;
            public float prezzo;
        }

        public Prodotto [] prodotto;
        public int dim;

        public Form1()
        {
            InitializeComponent();
            prodotto = new Prodotto[100];
            dim = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salva_Click(object sender, EventArgs e)
        {
            
            prodotto[dim].nome = nome.Text;
            prodotto[dim].prezzo = float.Parse(prezzo.Text);
            dim++;
            Visualizza(prodotto);
        }

        public void Visualizza(Prodotto[] prodotto)
        {
            listView1.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                listView1.Items.Add(ProdString(prodotto[i]));
            }
            
        }

        public string ProdString(Prodotto prodotto)
        {
            return "Nome: " + prodotto.nome + " Prezzo: " + prodotto.prezzo.ToString();
        }
    }
}
