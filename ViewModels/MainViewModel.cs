using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogio.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private BackgroundWorker _relogioWorker;


        private string _horaCompleta;

        public string HoraCompleta
        {
            get { return _horaCompleta; }
            set { _horaCompleta = value;  OnPropertyChanged(); }
        }

        private double _hora;

        public double Hora
        {
            get { return _hora; }
            set { _hora = value; OnPropertyChanged(); }
        }

        private int _minuto;

        public int Minuto
        {
            get { return _minuto; }
            set { _minuto = value; OnPropertyChanged(); }
        }

        private int _segundo;

        public int Segundo
        {
            get { return _segundo; }
            set { _segundo = value; OnPropertyChanged(); }
        }

        private int _decimalHora;

        public int DecimalHora
        {
            get { return _decimalHora; }
            set { _decimalHora = value; OnPropertyChanged(); }
        }

        private int _unidadeHora;

        public int UnidadeHora
        {
            get { return _unidadeHora; }
            set { _unidadeHora = value; OnPropertyChanged(); }
        }

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


        public MainViewModel()
        {
            _relogioWorker = new BackgroundWorker();
            _relogioWorker.DoWork += _relogioWorker_DoWork;
            _relogioWorker.RunWorkerAsync();
        }

        private async void _relogioWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                DateTime agora = DateTime.Now;

                HoraCompleta = agora.ToLongTimeString();
                
                
                Minuto = agora.Minute;
                Hora = agora.Hour + ((double)Minuto / 60);
                Segundo = agora.Second;

                DecimalHora = (int)Hora / 10;
                UnidadeHora = (int)Hora % 10;
                DecimalMinuto = Minuto / 10;
                UnidadeMinuto = Minuto % 10;
                DecimalSegundo = Segundo / 10;
                UnidadeSegundo = Segundo % 10;

                await Task.Delay(1000);
            }
        }
    }
}
