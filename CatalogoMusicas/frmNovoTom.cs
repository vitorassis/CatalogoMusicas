using CatalogoMusicas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoMusicas
{
    public partial class frmNovoTom : Form
    {
        int musicaId;
        PastaContexto? dbContexto;
        public frmNovoTom(int musicaId)
        {
            InitializeComponent();
            this.musicaId = musicaId;

            this.dbContexto = new PastaContexto();
            dbContexto?.Musicas.Where(m => m.Id == musicaId).Load();

            Musica? musica = dbContexto?.Musicas.Local.First();
            if (musica != null)
                this.Text += musica.Nome.ToUpper();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContexto?.Dispose();
            this.dbContexto = null;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            if(txtTom.Text.Trim().Length > 0)
            {
                Tom tom = new Tom();
                tom.MusicaId = musicaId;
                tom.Tonalidade = txtTom.Text;

                this.dbContexto?.Add(tom);
                this.dbContexto?.SaveChanges();

                MessageBox.Show("Sucesso");
            }
            else
            {
                MessageBox.Show("Informe o tom");
            }
        }
    }
}
