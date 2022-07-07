using System.Windows.Forms;
using System.Drawing;

namespace Views
{
public class ReservarQuarto : Form
{
    private System.ComponentModel.IContainer components = null;
    Label lblTitulo;
    Button btnCancel;
    Button btnInsert;
    public ListView listView;
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

        this.btnCancel = new Button();
        this.btnCancel.Text = "Cancelar";
        this.btnCancel.Location = new Point(280, 500);
        this.btnCancel.Size = new Size(80, 30);
        //this.btnCancel.Click += new EventHandler(this.handleCancelClick);

        this.btnInsert = new Button();
        this.btnInsert.Text = "Selecionar quarto";
        this.btnInsert.Location = new Point(100, 500);
        this.btnInsert.Size = new Size(140, 30);
        //this.btnInsert.Click += new EventHandler(this.handleConfirmClickCategoriaInserir);

        //this.updateList();

        this.Controls.Add(listView);

        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnInsert);
        this.ClientSize = new System.Drawing.Size(500, 600);
    }

/*
    private void handleConfirmClickCategoriaAtualizar(object sender, EventArgs e)
    {
        if (listView.SelectedItems.Count > 0)
        {
            AtualizarCategoria menu = new AtualizarCategoria(this);
            menu.Size = new Size(325, 300);
            menu.ShowDialog();
        }
        else
        {
            MessageBox.Show("Não há itens selecionados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void handleConfirmClickCategoriaDeletar(object sender, EventArgs e)
    {
        ListViewItem selectedItem = listView.SelectedItems[0];
        DeletarCategoria menu = new DeletarCategoria(Convert.ToInt32(selectedItem.Text));
        menu.Size = new Size(222, 200);
        menu.ShowDialog();
    }
    private void handleConfirmClickCategoriaInserir(object sender, EventArgs e)
    {
        InserirCategoria menu = new InserirCategoria(this);
        menu.Size = new Size(325, 300);
        menu.ShowDialog();
    }
    
    private void handleCancelClick(object sender, EventArgs e)
    {
        this.Close();
    }
    public void updateList()
    {
        IEnumerable<Categoria> categorias = CategoriaController.VisualizarCategoria();
        this.listView.Items.Clear();
        foreach (Categoria categoria in categorias)
        {
            ListViewItem item = new ListViewItem(categoria.Id.ToString());
            item.SubItems.Add(categoria.Nome);
            item.SubItems.Add(categoria.Descricao);
            listView.Items.Add(item);
        }
    }
    */
}
}