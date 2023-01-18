using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc_Binaire_Objet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nbr1.PreviewTextInput += new TextCompositionEventHandler(PreviewNbr);
            nbr2.PreviewTextInput += new TextCompositionEventHandler(PreviewNbr);
            addition.Checked += new RoutedEventHandler(CheckAdd);
            soustraction.Checked += new RoutedEventHandler(CheckSoustra);
            calculer.Click += new RoutedEventHandler(ClickCalc);
        }

        int typeCalc;

        private void PreviewNbr(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "0" && e.Text != "1")
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void CheckAdd(object sender, RoutedEventArgs e)
        {
            typeCalc = 0;
        }

        private void CheckSoustra(object sender, RoutedEventArgs e)
        {
            typeCalc = 1;
        }

        private void ClickCalc(object sender, RoutedEventArgs e)
        {
            NombreBinaire nombre1 = new NombreBinaire(nbr1.Text);
            NombreBinaire nombre2 = new NombreBinaire(nbr2.Text);
            NombreBinaire tRes;
            bool ok;

            if(typeCalc == 0)
            {
                nombre1.Additionne(nombre2,out tRes,out ok);
                if (ok)
                {
                    MessageBox.Show(tRes.AffichageResultat());
                }
            }else if(typeCalc == 1)
            {
                ok = nombre1.Soustrait(nombre2, out tRes);
                if (ok)
                {
                    MessageBox.Show(tRes.AffichageResultat());
                }
            }
        }
    }
}
