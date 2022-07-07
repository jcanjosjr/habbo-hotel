using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Views
{
    public class CadastrarFuncionario : Form
    {
        Label lblTitulo;
        Label lblNome;
        Label lblSenha;
        Label lblMatricula;
        TextBox txtNome;
        TextBox txtMatricula;
        TextBox txtSenha;
        Button btCadastrarFuncionario;
        Button btVoltar;

        public CadastrarFuncionario()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Cadastro de Funcionário";
            this.lblTitulo.Location = new Point(20, 5);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Calibri", 15);

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(190, 50);
            this.lblNome.Size = new Size(100, 30);
            this.lblNome.ForeColor = Color.Black;
            this.lblNome.Font = new Font("Calibri", 15);

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(190, 200);
            this.lblSenha.Size = new Size(100, 30);
            this.lblSenha.ForeColor = Color.Black;
            this.lblSenha.Font = new Font("Calibri", 15);

            this.lblMatricula = new Label();
            this.lblMatricula.Text = "Matrícula";
            this.lblMatricula.Location = new Point(190, 120);
            this.lblMatricula.Size = new Size(100, 30);
            this.lblMatricula.ForeColor = Color.Black;
            this.lblMatricula.Font = new Font("Calibri", 15);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(190, 80);
            this.txtNome.Size = new Size(220, 30);
            this.txtNome.Text = "Digite o nome do funcionário";
            this.txtNome.ForeColor = Color.Black;

            this.txtMatricula = new TextBox();
            this.txtMatricula.Location = new Point(190, 150);
            this.txtMatricula.Size = new Size(220, 30);
            this.txtMatricula.Text = "Digite a matrícula do funcionário";
            this.txtMatricula.ForeColor = Color.Black;

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(190, 230);
            this.txtSenha.Size = new Size(220, 30);
            this.txtSenha.Text = "Crie uma senha";
            this.txtSenha.ForeColor = Color.Black;

            this.btCadastrarFuncionario = new Button();
            this.btCadastrarFuncionario.Text = "Cadastrar Funcionario";
            this.btCadastrarFuncionario.Location = new Point(160, 300);
            this.btCadastrarFuncionario.Size = new Size(140, 30);
            this.btCadastrarFuncionario.Click += new EventHandler(this.handleConfirmClickInserirFuncionario);

            this.btVoltar = new Button();
            this.btVoltar.Text = "Voltar";
            this.btVoltar.Location = new Point(310, 300);
            this.btVoltar.Size = new Size(130, 30);
            this.btVoltar.Click += new EventHandler(this.handleVoltarClick);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblSenha);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtSenha);

            this.Controls.Add(this.btCadastrarFuncionario);
            this.Controls.Add(this.btVoltar);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void handleVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

         private void handleConfirmClickInserirFuncionario(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Confirma a operação?", "Atenção", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Controllers.ColaboradorController.CriarColaborador(txtNome.Text, txtSenha.Text,txtMatricula.Text);
                    MessageBox.Show("Usuário cadastrado com sucesso.");
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

    }
}
