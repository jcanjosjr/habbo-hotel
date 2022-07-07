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
    public class Login : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblUser;
        Label lblPass;
        Label lblCriarConta;
        MaskedTextBox txtUser;
        TextBox txtPass;
        Button btnConfirm;
        PictureBox pbLogo;
        Button btnCriarConta;
        
        public Login()
        {
            this.lblUser = new Label();
            this.lblUser.Text = "Usuário";
            this.lblUser.Location = new Point(800, 350);
            this.lblUser.Size = new Size(100, 30);
            this.lblUser.ForeColor = Color.Black;
            this.lblUser.Font = new Font("Roboto", 13, FontStyle.Bold);

            this.lblPass = new Label();
            this.lblPass.Text = "Senha";
            this.lblPass.Location = new Point(800, 415);
            this.lblPass.ForeColor = Color.Black;
            this.lblPass.Font = new Font("Roboto", 13, FontStyle.Bold);

            this.lblCriarConta = new Label();
            this.lblCriarConta.Text = "Ainda não tem conta?";
            this.lblCriarConta.Location = new Point(800, 550);
            this.lblCriarConta.Size = new Size(190, 30);
            this.lblCriarConta.ForeColor = Color.DarkGreen;
            this.lblCriarConta.Font = new Font("Roboto", 10);

            this.txtUser = new MaskedTextBox();
            this.txtUser.Location = new Point(800, 380);
            this.txtUser.Size = new Size(280, 30);

            this.txtPass = new TextBox();
            this.txtPass.Location = new Point(800, 445);
            this.txtPass.Size = new Size(280, 30);
            this.txtPass.PasswordChar = '*';

            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.Font = new Font("Roboto", 13);
            this.btnConfirm.Location = new Point(800, 500);
            this.btnConfirm.Size = new Size(280, 30);
            this.btnConfirm.Click += new EventHandler(this.handleConfirmClick);

            this.pbLogo = new PictureBox();
            this.pbLogo.Size = new Size(150, 150);
            this.pbLogo.Location = new Point(860, 180);
            this.pbLogo.ClientSize = new Size(150, 150);
            this.pbLogo.Load("images/logo.png");
            this.pbLogo.SizeMode = PictureBoxSizeMode.Zoom;

            this.btnCriarConta = new Button();
            this.btnCriarConta.Text = "Cadastrar-se";
            this.btnCriarConta.Font = new Font("Roboto", 9);
            this.btnCriarConta.Location = new Point(990, 545);
            this.btnCriarConta.Size = new Size(90, 30);
            this.btnCriarConta.Click += new EventHandler(this.handleCadastro);

            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblCriarConta);

            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCriarConta);
            this.Controls.Add(pbLogo);
            
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.FromArgb(213, 255, 222);
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void handleCadastro(object sender, EventArgs e)
        {
            //CadastrarHospede form = new CadastrarHospede();
            //form.Show();

            CadastrarFuncionario form = new CadastrarFuncionario();
            form.Show();
        }
        private void handleConfirmClick(object sender, EventArgs e)
        {
            try
            {
                Models.Auth.HospedeLogado(txtUser.Text,txtPass.Text);
                if (Models.Auth.HospedeAuth != null)
                {
                    //CadastrarQuarto menu = new CadastrarQuarto();
                    //menu.ShowDialog();
                    CadastrarQuarto menu = new CadastrarQuarto();
                    menu.ShowDialog();
                }
                
                /*Models.Auth.ColaboradorLogado(txtUser.Text,txtPass.Text);
                if (Models.Auth.ColaboradorAuth != null)
                {
                    CadastrarFuncionario menu = new CadastrarFuncionario();
                    menu.ShowDialog();
                }

                if (Models.Auth.HospedeAuth  == null && Models.Auth.ColaboradorAuth == null) 
                {
                    throw new Exception("Usuário não cadastrado.");
                }
                */
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        
    }
}
