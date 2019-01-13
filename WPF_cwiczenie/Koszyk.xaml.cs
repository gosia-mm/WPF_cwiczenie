﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_cwiczenie
{
    /// <summary>
    /// Logika interakcji dla klasy Koszyk.xaml
    /// </summary>
    public partial class Koszyk : Window
    {
        public Koszyk(List<String> zawartosc)
        {
            InitializeComponent();

            if (!zawartosc.Equals(null))
            {
                foreach (var elem in zawartosc)
                {
                    ElementyKoszyka.Text += elem + " ";
                }
            }
                
            else
                ElementyKoszyka.Text = "Koszyk jest pusty";
        }
    }
}
