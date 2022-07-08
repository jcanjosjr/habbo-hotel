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
        TextBox txtNome;
        TextBox txtQuantidade;
        TextBox txtSenha;

        Button btConfirmar;
        Button btCancelar;
        ListView listView;

        ListViewItem newLine;
        String IdQuarto;
        public LancarDespesa(String IdQuarto)
        {
            this.IdQuarto = IdQuarto;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Lançar Despesas";
            this.lblTitulo.Location = new Point(190, 20);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Roboto", 15);

            this.lblProdutos = new Label();
            this.lblProdutos.Text = "Produtos";
            this.lblProdutos.Location = new Point(190, 70);
            this.lblProdutos.Size = new Size(100, 30);
            this.lblProdutos.ForeColor = Color.Black;
            this.lblProdutos.Font = new Font("Roboto", 13);

            this.lblQuantidade = new Label();
            this.lblQuantidade.Text = "Quantidade";
            this.lblQuantidade.Location = new Point(190, 210);
            this.lblQuantidade.Size = new Size(110, 30);
            this.lblQuantidade.ForeColor = Color.Black;
            this.lblQuantidade.Font = new Font("Roboto", 13);


            listView = new ListView();
            listView.Location = new Point(190, 100);
            listView.Size = new Size(220, 100);
            listView.View = View.Details;
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            //listView.Columns.Add("Andar", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            //listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            // this.clbProdutos = new CheckedListBox();
            // this.clbProdutos.Location = new Point(190, 100);
            // this.clbProdutos.Size = new Size(220, 100);
            // clbProdutos.SelectionMode = SelectionMode.One;
            // clbProdutos.CheckOnClick = true;



            foreach (Produto item in Produto.GetProdutos())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Nome);
                newLine.SubItems.Add(item.ValorProduto.ToString());
                // newLine.SubItems.Add("R$" + item.ValorQuarto.ToString());
                listView.Items.Add(newLine);
            }

            // IEnumerable<Produto> produtos = Produto.GetProdutos();
            // foreach (Produto item in Produto.GetProdutos())
            // {
            //     this.clbProdutos.Items.Add($"{item.Nome} - R$ {item.ValorProduto}");
            // }

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(190, 100);
            this.txtNome.Size = new Size(220, 30);
            this.txtNome.Text = "Digite o nome do funcionário";
            this.txtNome.ForeColor = Color.Black;

            this.txtQuantidade = new TextBox();
            this.txtQuantidade.Location = new Point(190, 240);
            this.txtQuantidade.Size = new Size(220, 30);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(190, 220);
            this.txtSenha.Size = new Size(220, 30);
            this.txtSenha.Text = "Digite a senha do funcionário";
            this.txtSenha.ForeColor = Color.Black;

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

            this.Controls.Add(listView);

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


            try
            {
                DialogResult dialogResult = MessageBox.Show("Confirma a operação?", "Atenção", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {

                    ListViewItem selectedItem = listView.SelectedItems[0];
                    int IdProduto = Convert.ToInt32(selectedItem.Text);

                    int idReserva = Reserva.GetReservasAtivasPorQuarto(Convert.ToInt32(this.IdQuarto)).Id;

                    DespesaControllers.CriarDespesa(Convert.ToInt32(idReserva), IdProduto, Convert.ToInt32(this.txtQuantidade.Text));
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