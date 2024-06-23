using CatalogoMusicas.Helper;
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
    public partial class frmExportacao : Form
    {

        int idSelecionado;
        Form anterior;
        public frmExportacao(Form anterior)
        {
            InitializeComponent();
            this.anterior = anterior;

            PastaContexto db = new PastaContexto();
            dgvPastas.DataSource = db.Pastas.ToList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            anterior.Show();
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            PastaContexto db = new PastaContexto();
            Pasta pasta = db.Pastas.Where(p => p.Id == idSelecionado).First();
            
            if (pasta != null)
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Pasta - {pasta.Nome}.pdf");
                PdfExporter.ExportMusicalIndex(filePath, pasta);
            }

            db.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btExportar.Enabled = true;
            int linha = dgvPastas.SelectedCells[0].RowIndex;
            idSelecionado = (int)dgvPastas.Rows[linha].Cells[0].Value;
        }
    }
}
