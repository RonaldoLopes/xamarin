using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel
    {
        const string URL_GET_VEICULOS = "http://aluracar.herokuapp.com/";

        public List<Veiculo> Veiculos { get; set; }

        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado {
            get {
                return veiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if(value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSecionado");
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new List<Veiculo>();
        }

        public async Task GetVeiculosAsync()
        {
            HttpClient cliente = new HttpClient();
            var resultao = await cliente.GetStringAsync(URL_GET_VEICULOS);

        }

    }
}
