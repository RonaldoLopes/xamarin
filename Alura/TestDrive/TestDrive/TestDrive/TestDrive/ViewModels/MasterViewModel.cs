using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class MasterViewModel
    {
        private readonly Usuario usuario;

        public string Nome
        {
            get { return this.usuario.nome; }
            set { this.usuario.nome = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;
        }

    }
}
