namespace CatalogoMusicas
{
    partial class frmPastas
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
            dgvPastas = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pastaBindingSource = new BindingSource(components);
            btMusicas = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPastas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pastaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvPastas
            // 
            dgvPastas.AutoGenerateColumns = false;
            dgvPastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPastas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn });
            dgvPastas.DataSource = pastaBindingSource;
            dgvPastas.Location = new Point(12, 12);
            dgvPastas.Name = "dgvPastas";
            dgvPastas.Size = new Size(365, 376);
            dgvPastas.TabIndex = 0;
            dgvPastas.CellClick += dgvPastas_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // pastaBindingSource
            // 
            pastaBindingSource.DataSource = typeof(Models.Pasta);
            // 
            // btMusicas
            // 
            btMusicas.Enabled = false;
            btMusicas.Location = new Point(12, 403);
            btMusicas.Name = "btMusicas";
            btMusicas.Size = new Size(112, 23);
            btMusicas.TabIndex = 1;
            btMusicas.Text = "Acessar músicas";
            btMusicas.UseVisualStyleBackColor = true;
            btMusicas.Click += btMusicas_Click;
            // 
            // frmPastas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 436);
            Controls.Add(btMusicas);
            Controls.Add(dgvPastas);
            MaximizeBox = false;
            Name = "frmPastas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Pastas";
            ((System.ComponentModel.ISupportInitialize)dgvPastas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pastaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPastas;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private BindingSource pastaBindingSource;
        private Button btMusicas;
    }
}