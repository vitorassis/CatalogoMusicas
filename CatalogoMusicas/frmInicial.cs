namespace CatalogoMusicas
{
    public partial class frmInicial : Form
    {
        public frmInicial()
        {
            InitializeComponent();
        }

        private void btGerenciar_Click(object sender, EventArgs e)
        {
            (new frmPastas(this)).Show();
            this.Hide();
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            (new frmExportacao(this)).Show();
            this.Hide();
        }
    }
}
