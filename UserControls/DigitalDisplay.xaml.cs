using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Relogio.UserControls
{
    [Flags]
    public enum Ligados
    {
        Nenhum = 0,
        P0 = 1 << 0,
        P1 = 1 << 1,
        P2 = 1 << 2,
        P3 = 1 << 3,
        P4 = 1 << 4,
        P5 = 1 << 5,
        P6 = 1 << 6,
        P7 = 1 << 7,
        P8 = 1 << 8,
        P9 = 1 << 9,
        P10 = 1 << 10,
        P11 = 1 << 11,
        P12 = 1 << 12,
        P13 = 1 << 13

    }

    /// <summary>
    /// Interaction logic for DigitalDisplay.xaml
    /// </summary>
    public partial class DigitalDisplay : UserControl , INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private Ligados _partesLigadas;

        public Ligados PartesLigadas
        {
            get { return _partesLigadas; }
            set { _partesLigadas = value; OnPropertyChanged(); }
        }

        public int Valor
        {
            get { return (int)this.GetValue(ValorProperty); }
            set { this.SetValue(ValorProperty, value); MontarNumero(value); }
        }

        // Using a DependencyProperty as the backing store for Valor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorProperty =
            DependencyProperty.Register("Valor", typeof(int), typeof(DigitalDisplay),new UIPropertyMetadata(-1,OnValorChanged));

        private static void OnValorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DigitalDisplay sender = (DigitalDisplay)d;
            sender.Valor = Convert.ToInt16(e.NewValue);
        }


        public Color CorLigada
        {
            get { return (Color)GetValue(CorLigadaProperty); }
            set { SetValue(CorLigadaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CorLigada.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CorLigadaProperty =
            DependencyProperty.Register("CorLigada", typeof(Color), typeof(DigitalDisplay), new PropertyMetadata(Colors.Black));



        public Color CorDesligada
        {
            get { return (Color)GetValue(CorDesligadaProperty); }
            set { SetValue(CorDesligadaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CorDesligada.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CorDesligadaProperty =
            DependencyProperty.Register("CorDesligada", typeof(Color), typeof(DigitalDisplay), new PropertyMetadata(Colors.Transparent));



        public DigitalDisplay()
        {
            InitializeComponent();

        }


        private void MontarNumero(int numero)
        {
            switch (numero)
            {
                case 0:
                    PartesLigadas = Ligados.P0 | Ligados.P1 | Ligados.P2 | Ligados.P3 | Ligados.P4 | Ligados.P5;
                    break;
                case 1:
                    PartesLigadas = Ligados.P3 | Ligados.P4;
                    break;
                case 2:
                    PartesLigadas = Ligados.P2 | Ligados.P3 | Ligados.P11 | Ligados.P7 | Ligados.P0 | Ligados.P5;
                    break;
                case 3:
                    PartesLigadas = Ligados.P2 | Ligados.P3 | Ligados.P4 | Ligados.P5 | Ligados.P11 | Ligados.P7;
                    break;
                case 4:
                    PartesLigadas = Ligados.P1 | Ligados.P1 | Ligados.P7 | Ligados.P11 | Ligados.P3 | Ligados.P4;
                    break;
                case 5:
                    PartesLigadas = Ligados.P2 | Ligados.P1 | Ligados.P7 | Ligados.P11 | Ligados.P4 | Ligados.P5;
                    break;
                case 6:
                    PartesLigadas = Ligados.P2 | Ligados.P1 | Ligados.P0 | Ligados.P5 | Ligados.P4 | Ligados.P11 | Ligados.P7;
                    break;
                case 7:
                    PartesLigadas = Ligados.P2 | Ligados.P3 | Ligados.P4;
                    break;
                case 8:
                    PartesLigadas = Ligados.P0 | Ligados.P1 | Ligados.P2 | Ligados.P3 | Ligados.P4 | Ligados.P5 | Ligados.P11 | Ligados.P7;
                    break;
                case 9:
                    PartesLigadas = Ligados.P1 | Ligados.P2 | Ligados.P3 | Ligados.P4 | Ligados.P5 | Ligados.P11 | Ligados.P7;
                    break;
                default:
                    PartesLigadas = Ligados.Nenhum;
                    break;
            }
        }

    }
}
