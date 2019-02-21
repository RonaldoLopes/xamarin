using Capitulo04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Capitulo04.ViewModels.Servicos;

namespace Capitulo04.Views.Servicos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage
	{

        private ListagemViewModel viewModel;

        public ListagemView ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ListagemViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.AtualizarServicos();

            if (listView.SelectedItem != null)
                listView.SelectedItem = null;

            MessagingCenter.Subscribe<Servico>(this, "Mostrar", async (servicoSelecionado) => {
                await Navigation.PushAsync(new CRUDView(servicoSelecionado, viewModel.Servicos));
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Servico>(this, "Mostrar");
        }

        /*public void Update(Servico servico)
        {
            var _servico = servicos.Where((Servico s) => s.ServicoID == servico.ServicoID).FirstOrDefault();
            servicos.Remove(_servico);
            servicos.Add(servico);
        }*/

    }
}