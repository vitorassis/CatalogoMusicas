using CatalogoMusicas.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmPastas : Form
    {
        Form anterior;
        private PastaContexto? dbContext;

        int idSelecionado;

        public frmPastas(Form anterior)
        {
            InitializeComponent();

            this.anterior = anterior;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext = new PastaContexto();

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            this.dbContext.Database.EnsureCreated();

            Atualizar();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;

            anterior.Show();
        }

        private void dgvPastas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btMusicas.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            int linha = dgvPastas.SelectedCells[0].RowIndex;
            idSelecionado = (int)dgvPastas.Rows[linha].Cells[0].Value;
        }

        private void btMusicas_Click(object sender, EventArgs e)
        {
            (new frmMusicas(this, idSelecionado)).Show();
            this.Hide();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            Pasta? pasta = dbContext?.Pastas.Where(p => p.Id == idSelecionado).First();
            if (pasta != null)
            {
                DialogResult r = MessageBox.Show($"Deseja excluir a pasta {pasta.Nome.ToUpper()} junto com todas as suas músicas e seus respectivos tons?", "Catálogo - Confirmação", MessageBoxButtons.YesNo);
                if (r == DialogResult.Yes)
                {
                    dbContext?.Pastas.Remove(pasta);
                    dbContext?.SaveChanges();

                    MessageBox.Show("Sucesso");
                    Atualizar();

                    idSelecionado = 0;
                    btMusicas.Enabled = false;
                    btEditar.Enabled = false;
                    btExcluir.Enabled = false;
                }
            }
        }

        public void Atualizar()
        {
            try
            {
                // Filter musicas based on pastaId and Nome (if txtBuscar is not empty)
                var pastas = dbContext?.Pastas
                    .ToList(); // Use ToList() to retrieve filtered collection

                // Bind filtered musicas to the BindingSource
                var source = new SortableBindingList<Pasta>(pastas);
                this.dgvPastas.DataSource = source;
                this.dgvPastas.Sort(dgvPastas.Columns[1], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
                MessageBox.Show($"Error fetching pastas: {ex.Message}");
            }
        }

        private void btNova_Click(object sender, EventArgs e)
        {
            (new frmNovaPasta()).ShowDialog();
            Atualizar();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            (new frmEditarPasta(idSelecionado)).ShowDialog();
            Atualizar();
        }
    }
}
