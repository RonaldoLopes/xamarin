﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{

    public partial class AgendamentoView : ContentPage
    {

        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get { return Agendamento.Veiculo; }
            set { Agendamento.Veiculo = value; }
        }
        public string Nome
        {
            get { return Agendamento.Nome; }
            set { Agendamento.Nome = value; }
        }
        public string Fone
        {
            get { return Agendamento.Fone; }
            set { Agendamento.Fone = value; }
        }
        public string Email
        {
            get { return Agendamento.Email; }
            set { Agendamento.Email = value; }
        }


        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }

        }
        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento",
            string.Format(
            @"Veiculo: {0}
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}",
            Nome,
            Fone,
            Email,
            DataAgendamento.ToString("dd/MM/yyyy"),
            HoraAgendamento), "OK");
        }
    }
}