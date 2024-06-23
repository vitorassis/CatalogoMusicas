using CatalogoMusicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoMusicas
{
    public partial class frmEditarPasta : Form
    {
        PastaContexto dbContexto;
        Pasta? pasta;
        public frmEditarPasta(int idPasta)
        {
            InitializeComponent();

            dbContexto = new PastaContexto();
            pasta = dbContexto.Pastas.Where(p => p.Id == idPasta).First();
            if (pasta != null)
            {
                this.Text += pasta.Nome.ToUpper();
                txtNome.Text = pasta.Nome;
            }

        }



        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            dbContexto.Dispose();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            pasta.Nome = txtNome.Text;
            dbContexto.Pastas.Update(pasta);
            dbContexto.SaveChanges();

            MessageBox.Show("Sucesso!");
            this.Close();
        }
    }
}
