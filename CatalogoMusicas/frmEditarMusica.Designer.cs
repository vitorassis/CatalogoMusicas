namespace CatalogoMusicas
{
    partial class frmEditarMusica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            numIndice = new NumericUpDown();
            btSalvar = new Button();
            dgvTons = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            tonalidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tomBindingSource = new BindingSource(components);
            btNovoTom = new Button();
            btExcluirTom = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)numIndice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTons).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tomBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 63);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 91);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Índice:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(145, 60);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(179, 23);
            txtNome.TabIndex = 3;
            // 
            // numIndice
            // 
            numIndice.Location = new Point(145, 89);
            numIndice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numIndice.Name = "numIndice";
            numIndice.Size = new Size(179, 23);
            numIndice.TabIndex = 5;
            // 
            // btSalvar
            // 
            btSalvar.Location = new Point(167, 127);
            btSalvar.Name = "btSalvar";
            btSalvar.Size = new Size(75, 23);
            btSalvar.TabIndex = 6;
            btSalvar.Text = "Salvar";
            btSalvar.UseVisualStyleBackColor = true;
            btSalvar.Click += btSalvar_Click;
            // 
            // dgvTons
            // 
            dgvTons.AutoGenerateColumns = false;
            dgvTons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTons.Columns.AddRange(new DataGridViewColumn[] { Id, tonalidadeDataGridViewTextBoxColumn });
            dgvTons.DataSource = tomBindingSource;
            dgvTons.Location = new Point(24, 192);
            dgvTons.Name = "dgvTons";
            dgvTons.Size = new Size(377, 136);
            dgvTons.TabIndex = 7;
            dgvTons.CellClick += dgvTons_CellClick;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            // 
            // tonalidadeDataGridViewTextBoxColumn
            // 
            tonalidadeDataGridViewTextBoxColumn.DataPropertyName = "Tonalidade";
            tonalidadeDataGridViewTextBoxColumn.HeaderText = "Tonalidade";
            tonalidadeDataGridViewTextBoxColumn.Name = "tonalidadeDataGridViewTextBoxColumn";
            // 
            // tomBindingSource
            // 
            tomBindingSource.DataSource = typeof(Models.Tom);
            // 
            // btNovoTom
            // 
            btNovoTom.Location = new Point(24, 337);
            btNovoTom.Name = "btNovoTom";
            btNovoTom.Size = new Size(75, 23);
            btNovoTom.TabIndex = 8;
            btNovoTom.Text = "Novo Tom";
            btNovoTom.UseVisualStyleBackColor = true;
            btNovoTom.Click += btNovoTom_Click;
            // 
            // btExcluirTom
            // 
            btExcluirTom.Enabled = false;
            btExcluirTom.Location = new Point(300, 337);
            btExcluirTom.Name = "btExcluirTom";
            btExcluirTom.Size = new Size(101, 23);
            btExcluirTom.TabIndex = 9;
            btExcluirTom.Text = "Excluir Tom";
            btExcluirTom.UseVisualStyleBackColor = true;
            btExcluirTom.Click += btExcluirTom_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 168);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 10;
            label4.Text = "Tons:";
            // 
            // frmEditarMusica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 372);
            Controls.Add(label4);
            Controls.Add(btExcluirTom);
            Controls.Add(btNovoTom);
            Controls.Add(dgvTons);
            Controls.Add(btSalvar);
            Controls.Add(numIndice);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmEditarMusica";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Editar Música - ";
            ((System.ComponentModel.ISupportInitialize)numIndice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTons).EndInit();
            ((System.ComponentModel.ISupportInitialize)tomBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtNome;
        private TextBox txtTom;
        private NumericUpDown numIndice;
        private Button btSalvar;
        private DataGridView dgvTons;
        private BindingSource tomBindingSource;
        private Button btNovoTom;
        private Button btExcluirTom;
        private Label label4;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn tonalidadeDataGridViewTextBoxColumn;
    }
}