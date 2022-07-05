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
        Label lblMatricula;
        Label lblSenha;

        TextBox txtNome;
        TextBox txtMatricula;
        TextBox txtSenha;

        Button btCadastrarFuncionario;
        Button btVoltar;


        public CadastrarFuncionario()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            //LABEL
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Cadastro de Funcionário";
            this.lblTitulo.Location = new Point(190, 20);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Calibri", 15);

            //LABEL
            //PRIMEIRA FILEIRA
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(190, 50);
            this.lblNome.Size = new Size(100, 30);
            this.lblNome.ForeColor = Color.Black;
            this.lblNome.Font = new Font("Calibri", 13);


            //SEGUNDA FILEIRA

            this.lblMatricula = new Label();
            this.lblMatricula.Text = "Matrícula";
            this.lblMatricula.Location = new Point(190, 110);
            this.lblMatricula.Size = new Size(100, 30);
            this.lblMatricula.ForeColor = Color.Black;
            this.lblMatricula.Font = new Font("Calibri", 13);

            
            //Terceira FILEIRA

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha";
            this.lblSenha.Location = new Point(190, 170);
            this.lblSenha.Size = new Size(100, 30);
            this.lblSenha.ForeColor = Color.Black;
            this.lblSenha.Font = new Font("Calibri", 13);

            //INPUT

            //PRIMEIRA FILEIRA
            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(190, 80);
            this.txtNome.Size = new Size(220, 30);
            this.txtNome.Text = "Digite o nome do funcionário";
            this.txtNome.ForeColor = Color.Black;


            //SEGUNDA FILEIRA
            this.txtMatricula = new TextBox();
            this.txtMatricula.Location = new Point(190, 140);
            this.txtMatricula.Size = new Size(220, 30);
            this.txtMatricula.Text = "Digite a matrícula do funcionário";
            this.txtMatricula.ForeColor = Color.Black;

            //TERCEIRA FILEIRA
            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(190, 200);
            this.txtSenha.Size = new Size(220, 30);
            this.txtSenha.Text = "Digite a senha do funcionário";
            this.txtSenha.ForeColor = Color.Black;


            //BOTÕES
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
                      Controllers.ColaboradorController.CriarColaborador(this.txtNome.Text, this.txtSenha.Text, this.txtMatricula.Text);
                    MessageBox.Show("Usuário cadastrado com sucesso.");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
