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

        TextBox txtNome;
        TextBox txtMatricula;

        Button btCadastrarFuncionario;
        Button btVoltar;


        public CadastrarFuncionario()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            //LABEL
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Cadastro de Funcionário";
            this.lblTitulo.Location = new Point(190, 50);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Calibri", 15);

            //LABEL
            //PRIMEIRA FILEIRA

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(190, 120);
            this.lblNome.Size = new Size(100, 30);
            this.lblNome.ForeColor = Color.Black;
            this.lblNome.Font = new Font("Calibri", 15);


            //SEGUNDA FILEIRA

            this.lblMatricula = new Label();
            this.lblMatricula.Text = "Matrícula";
            this.lblMatricula.Location = new Point(190, 200);
            this.lblMatricula.Size = new Size(100, 30);
            this.lblMatricula.ForeColor = Color.Black;
            this.lblMatricula.Font = new Font("Calibri", 15);

            //INPUT

            //PRIMEIRA FILEIRA
            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(190, 150);
            this.txtNome.Size = new Size(220, 30);
            this.txtNome.Text = "Digite o nome do funcionário";
            this.txtNome.ForeColor = Color.Black;


            //SEGUNDA FILEIRA
            this.txtMatricula = new TextBox();
            this.txtMatricula.Location = new Point(190, 230);
            this.txtMatricula.Size = new Size(220, 30);
            this.txtMatricula.Text = "Digite a matrícula do funcionário";
            this.txtMatricula.ForeColor = Color.Black;


            //BOTÕES
            this.btCadastrarFuncionario = new Button();
            this.btCadastrarFuncionario.Text = "Cadastrar Funcionario";
            this.btCadastrarFuncionario.Location = new Point(160, 300);
            this.btCadastrarFuncionario.Size = new Size(140, 30);
            //this.btCadastrarFuncionario.Click += new EventHandler(this.handleConfirmClickInserirFuncionario);

            this.btVoltar = new Button();
            this.btVoltar.Text = "Voltar";
            this.btVoltar.Location = new Point(310, 300);
            this.btVoltar.Size = new Size(130, 30);
            this.btVoltar.Click += new EventHandler(this.handleVoltarClick);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblMatricula);

            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtMatricula);

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

    }
}
