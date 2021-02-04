using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aula_15
{
    public partial class frmAula15 : Form
    {
        private SqlConnection sqlCon;
        private SqlCommand sqlCom;
        private SqlDataReader dr;
        private string conectionString = "Data Source =.\\SQLEXPRESS;" +
                                         "Initial Catalog=Aula_15;" +
                                         "User ID=sa;" +
                                         "Password=alexandre051104";

        public frmAula15()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Conectar();
               
                SqlCommand sqlComd = new SqlCommand(@"INSERT INTO Contatos(Nome,Endereco,Telefone)"+
                                                    "VALUES(@nome,@endereco,@telefone)",sqlCon);
                sqlComd.Parameters.AddWithValue("@nome", txtNome.Text);
                sqlComd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                sqlComd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                sqlComd.ExecuteNonQuery();

                MessageBox.Show("Informações Salvas!");
                Limpar();
                Exibir();
                sqlCon.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }         


        }
        private void Conectar()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(conectionString);
                sqlCon.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Exibir()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from Contatos", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lstDados.Items.Add(dr[0] + " - " + dr[1] + "-" + dr[2] + " - " + dr[3]);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Limpar()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
            txtNome.Focus();

        }

        private void frmAula15_Load(object sender, EventArgs e)
        {
            Conectar();
            Exibir();
            sqlCon.Close();
        }
    }
}
