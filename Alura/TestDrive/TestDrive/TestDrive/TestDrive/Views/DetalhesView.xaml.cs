using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesView : ContentPage
	{

        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1000;
        private const int MP3_PLAYER = 500;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs {
            get
            {
                return string.Format("Freio ABS - R$ {0}", FREIO_ABS);
            } 
        }
        public string ArCondicionado
        {
            get
            {
                return string.Format("Ar-Condicionado - R$ {0}", MP3_PLAYER);
            }
        }
        public string Mp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", FREIO_ABS);
            }
        }

        bool temFreioABS;
        public bool TemFreioABS {
            get
            {
                return temFreioABS;
            }
            set
            {
                temFreioABS = value;
                OnPropertyChanged();//notifica a view
            }
        }

        public string ValorTotal {
            get
            {
                return string.Format("Valor total: R$: {0}", Veiculo.Preco + (TemFreioABS ? FREIO_ABS : 0));
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