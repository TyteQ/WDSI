using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace AI1
{
    class ListaStronCombobox
    {
        public ListaStronCombobox(ComboBox nazwaCombobox)
        {
            //nazwaCombobox.Items.Clear();
            List<string> listaStron = new List<string>(new string[] { "Algorytm Genetyczny" }); //, "Czas na świecie", "Alarmy" });
            for (int i = 0; i < listaStron.Count; i++)
            {
                nazwaCombobox.Items.Add(listaStron[i]);
                
            }
        }
        public void ZmianaStrony(int nrIndexu, Page zStrony)
        {
            switch (nrIndexu)
            {
                case 0:
                    zStrony.Frame.Navigate(typeof(AlgorytmGenetyczny));
                    break;
            }
        }
    }
}

