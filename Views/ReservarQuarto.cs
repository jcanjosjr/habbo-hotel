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


namespace Views
{
    public class ReservarQuarto : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblTitulo;
        Button btnCancel;
        Button btnInsert;
        public ListView listView;
        ListViewItem newLine;
        public ReservarQuarto()
        {
            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Reservar quarto";
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

            foreach (Quarto item in Quarto.GetQuartos())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Andar);
                newLine.SubItems.Add(item.NroQuarto);
                newLine.SubItems.Add(item.Descricao);
                newLine.SubItems.Add("R$" + item.ValorQuarto.ToString());
                listView.Items.Add(newLine);

            }

            this.btnCancel = new Button();
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new Point(280, 500);
            this.btnCancel.Size = new Size(80, 30);
            //this.btnCancel.Click += new EventHandler(this.handleCancelClick);

            this.btnInsert = new Button();
            this.btnInsert.Text = "CHECK-IN";
            this.btnInsert.Location = new Point(100, 500);
            this.btnInsert.Size = new Size(140, 30);
            this.btnInsert.Click += new EventHandler(this.handleConfirmClickCheckin);

            this.Controls.Add(listView);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInsert);
            this.ClientSize = new System.Drawing.Size(500, 600);
        }

        private void handleConfirmClickCheckin(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                 MessageBox.Show("Parabens, seu check-in foi realizado com sucesso");
            }
            else
            {
                MessageBox.Show("Não há itens selecionados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}