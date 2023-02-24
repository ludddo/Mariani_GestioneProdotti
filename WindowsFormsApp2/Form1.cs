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

        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void salva_Click(object sender, EventArgs e)
        {
            prodotto[dim].nome = nome.Text;
            prodotto[dim].prezzo = float.Parse(prezzo.Text);
            dim++;
            listView1.Clear();
            Visualizza(prodotto);
            nome.Clear();
            prezzo.Clear();
        }

        public void Visualizza(Prodotto[] prodotto)
        {
            listView1.Items.Clear();
            for (int i = 0; i < dim; i++)
            {
                listView1.Items.Add(ProdString(prodotto[i]));
            }
            
        }

        private static int Cancellazione(Prodotto[] prodotto, string parola, ref int dim)
        {
            for (int i = 0; i < prodotto.Length; i++)
            {
                if (prodotto[i].nome == parola)
                {
                    int b = i;
                    while (b < prodotto.Length - 1)
                    {
                        prodotto[b].nome = prodotto[b + 1].nome;
                        b++;
                    }
                    dim--;
                    return 1;
                }
            }
            for (int i = 0; i < dim; i++)
            {
                if (prodotto[i].nome != parola)
                {
                    return 0;
                }
            }
            return -1;
        }

        public string ProdString(Prodotto prodotto)
        {
            return "Nome: " + prodotto.nome + " Prezzo: " + prodotto.prezzo.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            const string message = "Sei sicuro di voler cancellare il Prodotto?";
            const string caption = "Cancellazione Prodotto";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int o = Cancellazione(prodotto, nome.Text, ref dim);
                Visualizza(prodotto);
                if (o == 1)
                {
                    MessageBox.Show("La cancellazione è avvenuta correttamente");
                }
                else
                {
                    MessageBox.Show("C'è stato un problema nella cancellazione");
                }
                nome.Clear();
                prezzo.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificaNome(ref prodotto, nome.Text, textBox2.Text);
            listView1.Clear();
            Visualizza(prodotto);
            nome.Clear();
            prezzo.Clear();
            textBox2.Clear();
        }

        private static void ModificaNome(ref Prodotto[] prodotto, string parola, string parolaGiusta)
        {
            for (int i = 0; i < prodotto.Length; i++)
            {
                if (prodotto[i].nome.Equals(parola))
                {
                    prodotto[i].nome = parolaGiusta;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                label3.Visible = true;
                textBox2.Visible = true;

            }
            else
            {
                label3.Visible = false;
                textBox2.Visible = false;
            }
        }
    }
}
