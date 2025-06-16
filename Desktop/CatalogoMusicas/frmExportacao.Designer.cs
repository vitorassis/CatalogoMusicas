namespace CatalogoMusicas
{
    partial class frmExportacao
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
            label1 = new Label();
            btExportar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPastas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pastaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvPastas
            // 
            dgvPastas.AllowUserToAddRows = false;
            dgvPastas.AllowUserToDeleteRows = false;
            dgvPastas.AutoGenerateColumns = false;
            dgvPastas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPastas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn });
            dgvPastas.DataSource = pastaBindingSource;
            dgvPastas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPastas.Location = new Point(30, 56);
            dgvPastas.Name = "dgvPastas";
            dgvPastas.Size = new Size(387, 329);
            dgvPastas.TabIndex = 0;
            dgvPastas.CellClick += dataGridView1_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 28);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 1;
            label1.Text = "Selecione uma pasta:";
            // 
            // btExportar
            // 
            btExportar.Enabled = false;
            btExportar.Location = new Point(30, 415);
            btExportar.Name = "btExportar";
            btExportar.Size = new Size(387, 23);
            btExportar.TabIndex = 2;
            btExportar.Text = "Exportar PDF";
            btExportar.UseVisualStyleBackColor = true;
            btExportar.Click += btExportar_Click;
            // 
            // frmExportacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 450);
            Controls.Add(btExportar);
            Controls.Add(label1);
            Controls.Add(dgvPastas);
            MaximizeBox = false;
            Name = "frmExportacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Exportação de Índice";
            ((System.ComponentModel.ISupportInitialize)dgvPastas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pastaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPastas;
        private Label label1;
        private Button btExportar;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private BindingSource pastaBindingSource;
    }
}