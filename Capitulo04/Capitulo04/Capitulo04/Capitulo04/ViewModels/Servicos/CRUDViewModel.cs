using Capitulo04.Models;
using Capitulo04.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Capitulo04.ViewModels.Servicos
{
    public class CRUDViewModel : BaseViewModel
    {
        private IDataStore<Servico> DataStore = new ServicoDataStore();
        private Servico Servico { get; set; }
        public ICommand GravarCommand { get; set; }

        private ObservableCollection<Servico> Servicos;

        public CRUDViewModel(Servico servico, ObservableCollection<Servico> servicos)
        {
            this.Servico = servico;
            RegistrarCommands();

            this.valor = string.Format("{0:N}", servico.Valor);

            this.Servicos = servicos;
        }

        public string Nome
        {
            get { return this.Servico.Nome; }
            set
            {
                this.Servico.Nome = value;
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }

        private string valor;
        public string MyProperty
        {
            get { return valor; }
            set
            {
                valor = value;
                this.Servico.Valor = string.IsNullOrEmpty(value) ? 0 : Convert.ToDouble(valor);
                OnPropertyChanged();
                ((Command)GravarCommand).ChangeCanExecute();
            }
        }


        private void RegistrarCommands()
        {
            GravarCommand = new Command(() =>
            {
                Gravar();
                MessagingCenter.Send<string>("Atualização	realizada  com sucesso.", "InformacaoCRUD");

            }, () =>
            {
                return !string.IsNullOrEmpty(this.Servico.Nome) && this.Servico.Valor > 0;
            });
        }

        private void AtualizarPropriedadesParaVisao()
        {
            var servico = this.Servicos.FirstOrDefault(s => s.ServicoID == Servico.ServicoID);
            int indexOfServico = this.Servicos.IndexOf(servico);
            this.Servicos[indexOfServico] = servico;
        }

        private void Gravar()
        {
            DataStore.Update(this.Servico);
        }
    }
}
