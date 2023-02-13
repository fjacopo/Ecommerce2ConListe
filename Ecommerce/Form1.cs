using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ecommerce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            carica();
            domainUpDown1.SelectedItem = Carne.Nome;
        }
        Carrello carrello1 = new Carrello("123");
        Prodotto Carne = new Prodotto("P1", "Carne", "Macelleria", "Carne di vacca", 1);
        Prodotto Latte = new Prodotto("P2", "Latte", "Latteria", "Latte di vacca", 2);
        Prodotto Acqua = new Prodotto("P3", "Acqua", "Stabilimento", "Acqua di fonte");
        Prodotto Pane = new Prodotto("P4", "Pane", "Panettiere", "Pane arabo,poco nemica di marocco", 3);
        Prodotto Olio = new Prodotto("P5", "Olio", "Frantoio", "Olio Extra-vergine d'oliva", 4);
        Prodotto Uova = new Prodotto("P6", "Uova", "Pollaio", "Ouva di gallina ovaiola", 5);
        Prodotto Formaggio = new Prodotto("P7", "Formaggio", "Fomraggificio", "Formaggio di capra", 6);
        Prodotto Lego = new Prodotto("P8", "cereali", "Supermercato", "cereali integrali", 7);
        Prodotto Computer = new Prodotto("P9", "Computer", "AKinformatica", "pc potente e bello", 8);
        List<Prodotto> lista = new List<Prodotto>();

        public void carica()
        {
            lista.Add(Carne);
            lista.Add(Latte);
            lista.Add(Acqua);
            lista.Add(Pane);
            lista.Add(Olio);
            lista.Add(Uova);
            lista.Add(Formaggio);
            lista.Add(Lego);
            lista.Add(Computer);
            domainUpDown1.Items.Add(Carne.Nome);
            domainUpDown1.Items.Add(Latte.Nome);
            domainUpDown1.Items.Add(Acqua.Nome);
            domainUpDown1.Items.Add(Pane.Nome);
            domainUpDown1.Items.Add(Olio.Nome);
            domainUpDown1.Items.Add(Uova.Nome);
            domainUpDown1.Items.Add(Formaggio.Nome);
            domainUpDown1.Items.Add(Lego.Nome);
            domainUpDown1.Items.Add(Computer.Nome);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = Convert.ToString(domainUpDown1.SelectedItem);
                carrello1.Aggiungi(prod(a));
                aggiorna();
            }
            catch (Exception eccezione)
            {
                MessageBox.Show(eccezione.Message);
            }
        }
        public Prodotto prod(string a)
        {
            Prodotto p;
            for (int i = 0; i < 99; i++)
            {
                if (lista[i].Nome == a)
                {
                    p = lista[i];
                    return p;
                }
            }
            return null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = Convert.ToString(domainUpDown1.SelectedItem);
                lista.Remove(prod(a));
                aggiorna();
            }
            catch (Exception eccezione)
            {
                MessageBox.Show(eccezione.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sicuro di voler eliminare?", "Attenzione", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                lista.Clear();
                aggiorna();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            aggiorna();
        }
        public void aggiorna()
        {
            foreach (Prodotto p in lista)
            {
                Console.WriteLine(p.Nome);
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}