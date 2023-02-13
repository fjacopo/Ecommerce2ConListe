using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Carrello
    {
        private string _id;
        List<Prodotto> _prodotti = new List<Prodotto>();

        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Inserire un id correggiuto");
            }
        }
        public Prodotto getProdotto(int i)
        {
            return _prodotti[i];
        }

        public Carrello(string id)
        {
            this.Id = id;
            Svuota();
        }
       
        public void Aggiungi(Prodotto p)
        {
            if (p != null)
            {
                p.CalcolaPrezzoScontato();
                _prodotti.Add(p);
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }
        public Prodotto Rimuovi(Prodotto p)
        {
            
            if (_prodotti.Remove(p))
            { 
              
                return p;
            }   
            else
                throw new Exception("Prodotto non esistente!");
        }
        public int Cerca(Prodotto p)
        {
            return _prodotti.IndexOf(p);
        }
        public void Svuota()
        {
           _prodotti.Clear();
        }
        public decimal Calctot()
        {
            decimal tot = 0;
            for (int i = 0; i < 99; i++)
            {
                if (_prodotti[i] != null)
                {
                    tot += _prodotti[i].Prezzo;
                }
            }
            return tot;
        }
        public decimal Calctots()
        {
            decimal tot = 0;
            for (int i = 0; i < 99; i++)
            {
                if (_prodotti[i] != null)
                {
                    tot += _prodotti[i].Scontato;
                }
            }
            int c = 0;
            for (int i = 0; i < 99; i++)
            {
                if (_prodotti[i] != null)
                {
                    if (_prodotti[i].GetType() == typeof(Elettronico))
                    {
                        c = 1;
                    }
                }
            }
            if (c == 1)
            {
                tot -= tot * (5 / 100);
            }
            return tot;
        }
    }
}

