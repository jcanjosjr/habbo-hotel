using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Controllers;
using Models;
using System.Data;

namespace Views
{
    public class LancarDespesa : Form
    {

        Label lblTitulo;
        Label lblProdutos;
        Label lblQuantidade;
        Label lblSenha;

        CheckedListBox clbProdutos;
        CheckedListBox clbReserva;
        TextBox txtNome;
        TextBox txtQuantidade;
        TextBox txtSenha;

        Button btConfirmar;
        Button btCancelar;


        public LancarDespesa()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            //LABEL
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Lançar Despesas";
            this.lblTitulo.Location = new Point(190, 20);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Roboto", 15);

            //LABEL
            //PRIMEIRA FILEIRA
            this.lblProdutos = new Label();
            this.lblProdutos.Text = "Produtos";
            this.lblProdutos.Location = new Point(190, 70);
            this.lblProdutos.Size = new Size(100, 30);
            this.lblProdutos.ForeColor = Color.Black;
            this.lblProdutos.Font = new Font("Roboto", 13);


            //SEGUNDA FILEIRA

            this.lblQuantidade = new Label();
            this.lblQuantidade.Text = "Quantidade";
            this.lblQuantidade.Location = new Point(190, 210);
            this.lblQuantidade.Size = new Size(110, 30);
            this.lblQuantidade.ForeColor = Color.Black;
            this.lblQuantidade.Font = new Font("Roboto", 13);

            //INPUT

            this.clbProdutos = new CheckedListBox();
            this.clbProdutos.Location = new Point(190, 100);
            this.clbProdutos.Size = new Size(220, 100);
            clbProdutos.SelectionMode = SelectionMode.One;
            clbProdutos.CheckOnClick = true;

            IEnumerable<Produto> Produtos = Produto.GetProdutos();
            foreach (Produto item in Produto.GetProdutos())
            {
                this.clbProdutos.Items.Add($"{item.Id} - {item.Nome}");
            }


            CheckedListBox clbReserva;
            this.clbProdutos = new CheckedListBox();
            clbProdutos.SelectionMode = SelectionMode.One;
            clbProdutos.CheckOnClick = true;

            IEnumerable<Reserva> Reservas = Reserva.GetReservas();
            foreach (Reserva reserva in Reserva.GetReservas())
            {
                //this.clbProdutos.Items.Add($"{reserva.Id} - {reserva.Nome}");
            }


            //SEGUNDA FILEIRA
            this.txtQuantidade = new TextBox();
            this.txtQuantidade.Location = new Point(190, 240);
            this.txtQuantidade.Size = new Size(220, 30);

            //BOTÕES
            this.btConfirmar = new Button();
            this.btConfirmar.Text = "Confirmar";
            this.btConfirmar.Location = new Point(160, 320);
            this.btConfirmar.Size = new Size(130, 30);
            this.btConfirmar.Click += new EventHandler(this.handleConfirmClickLancarDespesa);

            this.btCancelar = new Button();
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.Location = new Point(310, 320);
            this.btCancelar.Size = new Size(130, 30);
            this.btCancelar.Click += new EventHandler(this.handleVoltarClick);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblProdutos);
            this.Controls.Add(this.lblQuantidade);

            this.Controls.Add(this.clbProdutos);
            this.Controls.Add(this.txtQuantidade);

            this.Controls.Add(this.btConfirmar);
            this.Controls.Add(this.btCancelar);

            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 420);

        }

        private void handleVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void handleConfirmClickLancarDespesa(object sender, EventArgs e)
        {

            //DespesaControllers.CriarDespesa();

            int idProduto;

            foreach (var item in clbProdutos.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                idProduto = row.Field<int>("ID");
            }


            foreach (var item in clbReserva.CheckedItems)
            {
                var row = (item as DataRowView).Row;
                idProduto = row.Field<int>("ID");
            }


        }
    }

}