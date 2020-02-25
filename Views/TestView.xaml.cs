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
using System.Windows.Shapes;

namespace Relogio.Views
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BackgroundWorker _relogioWorker;


        private int _decimalMinuto;

        public int DecimalMinuto
        {
            get { return _decimalMinuto; }
            set { _decimalMinuto = value; OnPropertyChanged(); }
        }


        private int _unidadeMinuto;

        public int UnidadeMinuto
        {
            get { return _unidadeMinuto; }
            set { _unidadeMinuto = value; OnPropertyChanged(); }
        }


        private int _decimalSegundo;

        public int DecimalSegundo
        {
            get { return _decimalSegundo; }
            set { _decimalSegundo = value; OnPropertyChanged(); }
        }


        private int _unidadeSegundo;

        public int UnidadeSegundo
        {
            get { return _unidadeSegundo; }
            set { _unidadeSegundo = value; OnPropertyChanged(); }
        }



        public TestView()
        {
            InitializeComponent();

            this.DataContext = this;

            _relogioWorker = new BackgroundWorker();
            _relogioWorker.DoWork += _relogioWorker_DoWork;
            _relogioWorker.RunWorkerAsync();
        }




        private async void _relogioWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                DateTime agora = DateTime.Now;
                //Hora = agora.Hour;
                //Minuto = agora.Minute;

                int minuto = agora.Minute;
                int segundo = agora.Second;

                DecimalMinuto = minuto / 10;
                UnidadeMinuto = minuto % 10;
                DecimalSegundo = segundo / 10;
                UnidadeSegundo = segundo % 10;

                await Task.Delay(1000);
            }
        }

    }
}
