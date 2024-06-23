using CatalogoMusicas.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
    public partial class frmMusicas : Form
    {
        Form anterior;
        int pastaId;
        PastaContexto? dbContexto;
        int idSelecionado;
        public frmMusicas(Form anterior, int pastaId)
        {
            InitializeComponent();
            this.anterior = anterior;
            this.pastaId = pastaId;

            this.dbContexto = new PastaContexto();
            this.dbContexto.Pastas.Where(p => p.Id == pastaId).Load();

            Pasta pasta = this.dbContexto.Pastas.Local.First();

            this.Text += pasta.Nome.ToUpper();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContexto?.Musicas.Where(m => m.PastaId == pastaId).Load();

            Atualizar();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContexto?.Dispose();
            this.dbContexto = null;

            anterior.Show();
        }

        private void dgvMusicas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btEditar.Enabled = true;
            int linha = dgvMusicas.SelectedCells[0].RowIndex;
            idSelecionado = (int)dgvMusicas.Rows[linha].Cells[0].Value;
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            (new frmNovaMusica(pastaId)).ShowDialog();
            Atualizar();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            (new frmEditarMusica(pastaId, idSelecionado)).ShowDialog();
            Atualizar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        public void Atualizar()
        {
            try
            {
                // Filter musicas based on pastaId and Nome (if txtBuscar is not empty)
                var filteredMusicas = dbContexto.Musicas
                    .Where(m => m.PastaId == pastaId)
                    .ToList(); // Use ToList() to retrieve filtered collection

                if (txtBuscar.Text.Length > 0)
                {
                    filteredMusicas = filteredMusicas.Where(m => m.Nome.ToUpper().Contains(txtBuscar.Text.ToUpper())).ToList();
                }

                // Bind filtered musicas to the BindingSource
                var source = new SortableBindingList<Musica>(filteredMusicas);
                this.dgvMusicas.DataSource = source;
                this.dgvMusicas.Sort(dgvMusicas.Columns[2], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                MessageBox.Show($"Error fetching musicas: {ex.Message}");
            }
        }
    }
}
