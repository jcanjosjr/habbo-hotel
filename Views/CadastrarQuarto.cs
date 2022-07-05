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
  public class CadastrarQuarto : Form
  {

    Label lblTitulo;
    Label lblNumeroQuarto;
    Label lblAndar;
    Label lblDescricao;
    Label lblValor;

    TextBox txtNumeroQuarto;
    TextBox txtAndar;
    TextBox txtDescricao;
    TextBox txtValor;

    Button btCadastrarQuarto;
    Button btVoltar;


    public CadastrarQuarto()
    {
      this.MinimizeBox = false;
      this.MaximizeBox = false;

      //LABEL
      this.lblTitulo = new Label();
      this.lblTitulo.Text = "Cadastro de Quarto";
      this.lblTitulo.Location = new Point(110, 50);
      this.lblTitulo.Size = new Size(200, 30);
      this.lblTitulo.ForeColor = Color.Green;
      this.lblTitulo.Font = new Font("Calibri", 15);

      //LABEL
      //PRIMEIRA FILEIRA

      this.lblNumeroQuarto = new Label();
      this.lblNumeroQuarto.Text = "Nº do Quarto";
      this.lblNumeroQuarto.Location = new Point(110, 120);
      this.lblNumeroQuarto.Size = new Size(140, 30);
      this.lblNumeroQuarto.ForeColor = Color.Black;
      this.lblNumeroQuarto.Font = new Font("Calibri", 15);


      this.lblAndar = new Label();
      this.lblAndar.Text = "Andar";
      this.lblAndar.Location = new Point(330, 120);
      this.lblAndar.Size = new Size(130, 30);
      this.lblAndar.ForeColor = Color.Black;
      this.lblAndar.Font = new Font("Calibri", 15);

      //SEGUNDA FILEIRA

      this.lblDescricao = new Label();
      this.lblDescricao.Text = "Descrição";
      this.lblDescricao.Location = new Point(110, 200);
      this.lblDescricao.Size = new Size(100, 30);
      this.lblDescricao.ForeColor = Color.Black;
      this.lblDescricao.Font = new Font("Calibri", 15);

      this.lblValor = new Label();
      this.lblValor.Text = "Valor";
      this.lblValor.Location = new Point(360, 200);
      this.lblValor.Size = new Size(60, 30);
      this.lblValor.ForeColor = Color.Black;
      this.lblValor.Font = new Font("Calibri", 15);

      //INPUT

      //PRIMEIRA FILEIRA
      this.txtNumeroQuarto = new TextBox();
      this.txtNumeroQuarto.Location = new Point(110, 150);
      this.txtNumeroQuarto.Size = new Size(150, 30);
      this.txtNumeroQuarto.Text = "Digite um número válido";
      this.txtNumeroQuarto.ForeColor = Color.Black;

      this.txtAndar = new TextBox();
      this.txtAndar.Location = new Point(330, 150);
      this.txtAndar.Size = new Size(150, 30);
      this.txtAndar.Text = "Digite um andar válido";
      this.txtAndar.ForeColor = Color.Black;


      //SEGUNDA FILEIRA
      this.txtDescricao = new TextBox();
      this.txtDescricao.Location = new Point(110, 230);
      this.txtDescricao.Size = new Size(220, 30);
      this.txtDescricao.Text = "Digite uma descrição para o quarto";
      this.txtDescricao.ForeColor = Color.Black;

      this.txtValor = new TextBox();
      this.txtValor.Location = new Point(360, 230);
      this.txtValor.Size = new Size(120, 30);
      this.txtValor.Text = "Digite o valor";
      this.txtValor.ForeColor = Color.Black;

      //BOTÕES
      this.btCadastrarQuarto = new Button();
      this.btCadastrarQuarto.Text = "Cadastrar Quarto";
      this.btCadastrarQuarto.Location = new Point(170, 300);
      this.btCadastrarQuarto.Size = new Size(120, 30);
      //this.btCadastrarQuarto.Click += new EventHandler(this.handleConfirmClickInserirQuarto);

      this.btVoltar = new Button();
      this.btVoltar.Text = "Voltar";
      this.btVoltar.Location = new Point(300, 300);
      this.btVoltar.Size = new Size(120, 30);
      this.btVoltar.Click += new EventHandler(this.handleVoltarClick);

      this.Controls.Add(this.lblTitulo);
      this.Controls.Add(this.lblNumeroQuarto);
      this.Controls.Add(this.lblAndar);
      this.Controls.Add(this.lblDescricao);
      this.Controls.Add(this.lblValor);

      this.Controls.Add(this.txtNumeroQuarto);
      this.Controls.Add(this.txtAndar);
      this.Controls.Add(this.txtDescricao);
      this.Controls.Add(this.txtValor);

      this.Controls.Add(this.btCadastrarQuarto);
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
