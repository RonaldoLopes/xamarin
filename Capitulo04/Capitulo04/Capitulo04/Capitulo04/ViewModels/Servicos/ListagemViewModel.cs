using Capitulo04.Models;
using Capitulo04.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Capitulo04.ViewModels.Servicos
{
    public class ListagemViewModel : BaseViewModel
    {
        public IDataStore<Servico> DataStore = new ServicoDataStore();
        public ObservableCollection<Servico> Servicos { get; set; }

        public ListagemViewModel()
        {
            
        }

        private Servico servicoSelecionado;

        public Servico Servico
        {
            get { return servicoSelecionado; }
            set {
                if(value != null)
                {
                    servicoSelecionado = value;
                    MessagingCenter.Send<Servico>(servicoSelecionado, "Mostrar");
                }
            }
        }

        public void AtualizarServicos()
        {
            if (Servicos == null)
                Servicos = new ObservableCollection<Servico>(DataStore.GetAll().OrderBy(s => s.Nome));
            else
                Servicos = new ObservableCollection<Servico>(Servicos.OrderBy(s => s.Nome));

            OnPropertyChanged(nameof(Servicos));
        }

    }
}
