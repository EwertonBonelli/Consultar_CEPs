using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCEPs
{
    public partial class FmrConsultarCEPs : Form
    {
        public FmrConsultarCEPs()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text)) // Se o campo txtCEP.Text nao estiver vazio, entao faca...
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try // Tratamento de erro retornando mensagem na tela.
                    {
                        var endereco = ws.consultaCEP(txtCEP.Text.Trim());// Trim, remove caracteres em branco do inicio ou no fim.

                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtBairro.Text = endereco.bairro;
                        txtRua.Text = endereco.end;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP válido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            /*Empty, tem a funcao de limpar o campo textLine.
             os campos a baixos sao os campos de preencimento de dados
             apos preencidos e apertando o butom Limpar ira fazer a 
             limpeza de todos os campos.*/
            txtCEP.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
