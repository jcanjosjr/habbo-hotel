using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Models;
using Controllers;

namespace Views
{
    public class CheckOut : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblTitulo;
        Button btnCancel;
        Button btnInsert;
        public ListView listView;
        public ListViewItem newLine;

        int IdQuarto;
        public CheckOut(int IdQuarto)
        {
            this.IdQuarto = IdQuarto;
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Quarto Reservado";
            this.lblTitulo.Location = new Point(180, 10);
            this.lblTitulo.Font = new Font("Calibri", 15);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;

            this.Controls.Add(this.lblTitulo);

            listView = new ListView();
            listView.Location = new Point(50, 70);
            listView.Size = new Size(400, 400);
            listView.View = View.Details;
            listView.Columns.Add("ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Andar", -2, HorizontalAlignment.Left);
            listView.Columns.Add("N° Quarto", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Valor do quarto", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            Quarto quarto = Quarto.GetQuartoById(IdQuarto);
            {
                newLine = new ListViewItem(quarto.Id.ToString());
                newLine.SubItems.Add(quarto.Andar);
                newLine.SubItems.Add(quarto.NroQuarto);
                newLine.SubItems.Add(quarto.Descricao);
                newLine.SubItems.Add("R$" + quarto.ValorQuarto.ToString());
                listView.Items.Add(newLine);
            }

            // this.btnCancel = new Button();
            // this.btnCancel.Text = "Cancelar";
            // this.btnCancel.Location = new Point(280, 500);
            // this.btnCancel.Size = new Size(80, 30);
            // this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.btnInsert = new Button();
            this.btnInsert.Text = "CHECK-OUT";
            this.btnInsert.Location = new Point(100, 500);
            this.btnInsert.Size = new Size(140, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickCheckOut);

            //this.updateList();

            this.Controls.Add(listView);

            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.ClientSize = new System.Drawing.Size(500, 600);
        }


        private void handleConfirmClickCheckOut(object sender, EventArgs e)
        {
            int idReserva = Reserva.GetReservasAtivasPorQuarto(IdQuarto).Id;

            Pagamento form = new Pagamento(Reserva.GetReservasAtivasPorQuarto(Convert.ToInt32(this.IdQuarto)));
            form.Show();
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}