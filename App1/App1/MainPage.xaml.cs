using App1.Service;
using App1.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Button.Clicked += BuscarCEP;
        }
        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco endereco = ViaCepService.BuscarEnderecoViaCep(cep);

                    if (endereco == null)
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado", "Ok");
                    else
                        Result.Text = string.Format("Endereco: {2} de {3} {0}, {1} ", endereco.localidade, endereco.uf, endereco.logradouro, endereco.bairro);

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
            else
            {
                DisplayAlert("CEP INVÁLIDO", "A quantidade de dígitos do CEP é inválida", "OK");

            }

        }
        private bool IsValidCEP(string cep)
        {
            bool valid = false;
            if (cep.Length != 8)
                return valid;
            return valid = true;
        }
    }
}
