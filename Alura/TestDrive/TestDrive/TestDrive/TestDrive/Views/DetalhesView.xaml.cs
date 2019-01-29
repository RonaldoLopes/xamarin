using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesView : ContentPage
	{
        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            } 
        }
        public string ArCondicionado
        {
            get
            {
                return string.Format("Ar-Condicionado - R$ {0}", Veiculo.MP3_PLAYER);
            }
        }
        public string Mp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.FREIO_ABS);
            }
        }

       
        public bool TemFreioABS {
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();//notifica a view
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        
        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();//notifica a view
                OnPropertyChanged(nameof(ValorTotal));
            }
        }
        
        public bool TemMp3Player
        {
            get
            {
                return Veiculo.TemMp3Player;
            }
            set
            {
                Veiculo.TemMp3Player = value;
                OnPropertyChanged();//notifica a view
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal {
            get
            {
                return Veiculo.PrecoTotalFormatado;
                
            }
        }

        public DetalhesView (Veiculo veiculo)
		{
			InitializeComponent ();
            this.Veiculo = veiculo;
            this.BindingContext = this;
		}

        private void ButtonProximo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}