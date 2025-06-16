using CatalogoMusicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoMusicas
{
    public partial class frmNovaPasta : Form
    {
        public frmNovaPasta()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            PastaContexto dbContexto = new PastaContexto();

            if(txtNome.Text.Trim().Length > 0 )
            {
                Pasta pasta = new Pasta();
                pasta.Nome = txtNome.Text;
                dbContexto.Pastas.Add(pasta);
                dbContexto.SaveChanges();

                MessageBox.Show("Sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Preencha o nome corretamente");
            }

            dbContexto.Dispose();
        }
    }
}
