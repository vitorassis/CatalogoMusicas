using CatalogoMusicas.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmNovaMusica : Form
    {
        int pastaId;
        PastaContexto? dbContexto;
        public frmNovaMusica(int pastaId)
        {
            InitializeComponent();
            this.pastaId = pastaId;

            this.dbContexto = new PastaContexto();
            this.dbContexto.Pastas.Where(p => p.Id == pastaId).Load();

            Pasta pasta = this.dbContexto.Pastas.Local.First();

            this.Text += pasta.Nome.ToUpper();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContexto?.Dispose();
            this.dbContexto = null;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            if (numIndice.Value > 0 && txtNome.Text.Trim().Length > 0 && txtTom.Text.Trim().Length > 0) {
                Musica musica = new Musica();
                musica.PastaId = pastaId;
                musica.Indice = (int)numIndice.Value;
                musica.Nome = txtNome.Text;
                
                this.dbContexto?.Add(musica);
                this.dbContexto.SaveChanges();

                Tom tom = new Tom();
                tom.MusicaId = musica.Id;
                tom.Tonalidade = txtTom.Text;

                this.dbContexto?.Add(tom);

                this.dbContexto?.SaveChanges();

                MessageBox.Show("Sucesso");
                this.Close();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }
    }
}
