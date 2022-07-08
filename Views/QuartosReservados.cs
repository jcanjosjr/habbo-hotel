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
    public class QuartosReservados : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblTitulo;

        Button btnLancarDespesa;
        Button btnVoltar;

        ListView listView;
        ListViewItem newLine;
        public QuartosReservados()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.lblTitulo = new Label();
            this.lblTitulo.Text = "Quartos Reservados";
            this.lblTitulo.Location = new Point(190, 20);
            this.lblTitulo.Size = new Size(230, 30);
            this.lblTitulo.ForeColor = Color.Green;
            this.lblTitulo.Font = new Font("Roboto", 15);       

            listView = new ListView();
            listView.Location = new Point(45, 25);
            listView.Size = new Size(410, 500);
            listView.View = View.Details;

            listView.Columns.Add("Andar", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Nº do Quarto", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Valor", -2, HorizontalAlignment.Left);
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.AllowColumnReorder = true;
            listView.Sorting = SortOrder.Ascending;

            /*foreach (Quarto item in ControllerQuarto.VisualizarQuarto())
            {
                newLine = new ListViewItem(item.Id.ToString());
                newLine.SubItems.Add(item.Andar);
                newLine.SubItems.Add(item.NroQuarto);
                newLine.SubItems.Add(item.ValorQuarto);

                listView.Items.Add(newLine);
            }*/

            this.btnLancarDespesa = new Button();
            this.btnLancarDespesa.Text = "Lançar Despesa";
            this.btnLancarDespesa.Location = new Point(150, 546);
            this.btnLancarDespesa.Size = new Size(100, 30);
            this.btnLancarDespesa.Click += new EventHandler(this.handleConfirmClickLancarDespesa);

            this.btnVoltar = new Button();
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.Location = new Point(270, 546);
            this.btnVoltar.Size = new Size(100, 30);
            this.btnVoltar.Click += new EventHandler(this.handleVoltarClick);          


            this.Controls.Add(listView);

            this.Controls.Add(this.btnLancarDespesa);
            this.Controls.Add(this.btnVoltar);


            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Text = "Usuário";
        }

        private void handleConfirmClickLancarDespesa(object sender, EventArgs e)
        {
            LancarDespesa menu = new LancarDespesa();
            menu.ShowDialog();
        }

        private void handleVoltarClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}