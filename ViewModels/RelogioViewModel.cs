using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relogio.ViewModels
{
    class RelogioViewModel : BaseViewModel
    {
        private BackgroundWorker _relogioWorker;

        private int _hora;

        public int Hora
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


        public RelogioViewModel()
        {
            _relogioWorker = new BackgroundWorker();
            _relogioWorker.DoWork += _relogioWorker_DoWork;
            _relogioWorker.RunWorkerAsync();
        }

        private async void _relogioWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                DateTime agora = DateTime.Now;
                Hora = agora.Hour;
                Minuto = agora.Minute;
                Segundo = agora.Second;

                await Task.Delay(1000);
            }
        }
    }
}
