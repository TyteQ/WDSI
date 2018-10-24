﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AI1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ListaStronCombobox ObslugaCombo;
        public MainPage()
        {
            ObslugaCombo = new ListaStronCombobox(listaStronCombo);
            listaStronCombo.SelectedIndex = 0;
            this.InitializeComponent();
        }

        private void listaStronCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listaStronCombo.SelectedIndex == 0)
                return;
            ObslugaCombo.ZmianaStrony(listaStronCombo.SelectedIndex, this);
        }
    }
}
