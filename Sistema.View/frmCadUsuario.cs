using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Model;
using Sistema.Entidades;

namespace Sistema.View
{
    public partial class frmCadUsuario : Form
    {
        UsuarioEnt objTabela = new UsuarioEnt();

        public frmCadUsuario()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            opc = "Novo";
            iniciarOpc();
        }

        private string opc = "";


        private void iniciarOpc()
        {
            switch (opc)
            {
                case "Novo":
                    HabilitarCampos();
                    LimparCampos();
                    break;
                case "Salvar":
                    try
                    {
                        objTabela.Nome = txtNome.Text;
                        objTabela.Usuario = txtUsuario.Text;
                        objTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Inserir(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} foi inserido!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Inserido");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Salvar" + ex.Message);
                    }
                    break;
                case "Excluir":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);
                        
                        int x = UsuarioModel.Excluir(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} foi excluído!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Excluído");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Excluír" + ex.Message);
                    }
                    break;
                case "Editar":
                    try
                    {
                        objTabela.Id = Convert.ToInt32(txtCodigo.Text);
                        objTabela.Nome = txtNome.Text;
                        objTabela.Usuario = txtUsuario.Text;
                        objTabela.Senha = txtSenha.Text;

                        int x = UsuarioModel.Editar(objTabela);

                        if (x > 0)
                        {
                            MessageBox.Show(string.Format("Usuário {0} foi Alterado!", txtNome.Text));
                        }
                        else
                        {
                            MessageBox.Show("Não Alterado");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao Salvar" + ex.Message);
                    }
                    break;
                case "Buscar":
                    try
                    {
                        objTabela.Nome = txtBuscar.Text;

                        List<UsuarioEnt> lista = new List<UsuarioEnt>();
                        lista = new UsuarioModel().Buscar(objTabela);

                        grid.AutoGenerateColumns = false;
                        grid.DataSource = lista;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao Listar Dados" + ex.Message);
                    }
                    break;
                default:
                    break;
            }
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtCodigo.Text = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            opc = "Salvar";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na tabela para poder excluir");
                return;
            }

            opc = "Excluir";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro na tabela para poder editar");
                return;
            }

            opc = "Editar";
            iniciarOpc();
            ListarGrid();
            DesabilitarCampos();
            LimparCampos();
        }

        private void ListarGrid()
        {
            try
            {
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModel().Lista();
                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar Dados" + ex.Message);
            }
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtSenha.Text = grid.CurrentRow.Cells[3].Value.ToString();
            HabilitarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmCadProdutos form = new frmCadProdutos();
            this.Hide();
            form.Show();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
            {
                ListarGrid();
                return;
            }

            opc = "Buscar";
            iniciarOpc();
        }
    }
}
