﻿using System;
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
        public frmAula15()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                string conectionString = "Data Source =.\\SQLEXPRESS;" +
                    "Initial Catalog=Aula 15;" +
                    "User ID=sa;" +
                    "Password=3121";
                SqlConnection sqlCon = new SqlConnection(conectionString);
                sqlCon.Open();
                SqlCommand sqlComd = new SqlCommand(@"INSERT INTO Contatos(Nome,Endereco,Telefone)"+
                                                    "VALUES(@nome,@endereco,@telefone)",sqlCon);
                sqlComd.Parameters.AddWithValue("@nome", txtNome.Text);
                sqlComd.Parameters.AddWithValue("@endereco", txtEndereco.Text);
                sqlComd.Parameters.AddWithValue("@telefone", txtTelefone.Text);
                sqlComd.ExecuteNonQuery();
                sqlCon.Close();
                MessageBox.Show("Informações Salvas!");
                txtNome.Text = "";
                txtEndereco.Text = "";
                txtTelefone.Text = "";
                txtNome.Focus();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());

            }



















        }
        
        
          
            
        

    }
}