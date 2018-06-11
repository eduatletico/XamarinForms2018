using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico.Modelo;
using App01_ConsultaCEP.Servico;

namespace App01_ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //Botao.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereco: {0} de {1} {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Endereço não encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool isValidCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP deve ter 8 números", "OK");
                return false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP deve ser composto apenas de números", "OK");
                return false;
            }

            return true;
        }

    }
}
