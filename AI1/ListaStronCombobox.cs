using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace AI1
{
    class ListaStronCombobox
    {
        public ObservableCollection<string> fonts;
        public ListaStronCombobox()
        {
            //nazwaCombobox.Items.Clear();
            fonts = new ObservableCollection<string>(new string[] { "Algorytm Genetyczny" });//new ObservableCollection<string>(new string[] { "Algorytm Genetyczny" }); //, "Czas na świecie", "Alarmy" });


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
