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
    public partial class frmEditarMusica : Form
    {
        int pastaId;
        int musicaId;
        PastaContexto? dbContexto;
        Musica? musica;
        int idSelecionado;
        public frmEditarMusica(int pastaId, int musicaId)
        {
            InitializeComponent();
            this.pastaId = pastaId;
            this.musicaId = musicaId;

            this.dbContexto = new PastaContexto();
            this.dbContexto.Pastas.Where(p => p.Id == pastaId).Load();

            Pasta pasta = this.dbContexto.Pastas.Local.First();

            this.dbContexto?.Musicas.Where(m => m.Id == musicaId).Load();
            musica = this.dbContexto?.Musicas.Local.First();

            if (musica != null)
            {
                txtNome.Text = musica.Nome;
                numIndice.Value = musica.Indice;

                RecarregarTons();
            }

            this.Text += pasta.Nome.ToUpper();
        }

        public void RecarregarTons()
        {
            this.dbContexto?.Tons.Where(t => t.MusicaId == musicaId).Load();
            this.dgvTons.DataSource = this.dbContexto?.Tons.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContexto?.Dispose();
            this.dbContexto = null;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (numIndice.Value > 0 && txtNome.Text.Trim().Length > 0)
            {
                if (musica != null)
                {
                    musica.PastaId = pastaId;
                    musica.Indice = (int)numIndice.Value;
                    musica.Nome = txtNome.Text;

                    this.dbContexto?.Update(musica);

                    this.dbContexto?.SaveChanges();

                    MessageBox.Show("Sucesso");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos");
            }
        }

        private void dgvTons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btExcluirTom.Enabled = true;

            int linha = dgvTons.SelectedCells[0].RowIndex;
            idSelecionado = (int)dgvTons.Rows[linha].Cells[0].Value;
        }

        private void btExcluirTom_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseja mesmo excluir esse tom?", "Catálogo - Confirmação", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                this.dbContexto?.Tons.Where(t => t.Id == idSelecionado);
                Tom? tom = this.dbContexto?.Tons.Local.First();
                if (tom != null)
                {
                    this.dbContexto?.Remove(tom);
                    this.dbContexto?.SaveChanges();

                    RecarregarTons();

                    idSelecionado = 0;
                    btExcluirTom.Enabled = false;
                }
            }
        }

        private void btNovoTom_Click(object sender, EventArgs e)
        {
            (new frmNovoTom(musicaId)).ShowDialog();
            RecarregarTons();
        }
    }
}
