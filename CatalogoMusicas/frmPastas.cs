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

            this.dbContext.Pastas.Load();

            this.dgvPastas.DataSource = dbContext.Pastas.Local.ToBindingList();
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
            int linha = dgvPastas.SelectedCells[0].RowIndex;
            idSelecionado = (int)dgvPastas.Rows[linha].Cells[0].Value;
        }

        private void btMusicas_Click(object sender, EventArgs e)
        {
            (new frmMusicas(this, idSelecionado)).Show();
            this.Hide();
        }
    }
}
