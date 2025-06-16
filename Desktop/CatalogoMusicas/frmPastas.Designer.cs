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
            btNova = new Button();
            btEditar = new Button();
            btExcluir = new Button();
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
            dgvPastas.Location = new Point(12, 12);
            dgvPastas.Name = "dgvPastas";
            dgvPastas.Size = new Size(434, 376);
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
            // btNova
            // 
            btNova.Location = new Point(174, 403);
            btNova.Name = "btNova";
            btNova.Size = new Size(75, 23);
            btNova.TabIndex = 2;
            btNova.Text = "Nova Pasta";
            btNova.UseVisualStyleBackColor = true;
            btNova.Click += btNova_Click;
            // 
            // btEditar
            // 
            btEditar.Enabled = false;
            btEditar.Location = new Point(255, 403);
            btEditar.Name = "btEditar";
            btEditar.Size = new Size(87, 23);
            btEditar.TabIndex = 3;
            btEditar.Text = "Editar Pasta";
            btEditar.UseVisualStyleBackColor = true;
            btEditar.Click += btEditar_Click;
            // 
            // btExcluir
            // 
            btExcluir.Enabled = false;
            btExcluir.Location = new Point(348, 403);
            btExcluir.Name = "btExcluir";
            btExcluir.Size = new Size(98, 23);
            btExcluir.TabIndex = 4;
            btExcluir.Text = "Excluir Pasta";
            btExcluir.UseVisualStyleBackColor = true;
            btExcluir.Click += btExcluir_Click;
            // 
            // frmPastas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 436);
            Controls.Add(btExcluir);
            Controls.Add(btEditar);
            Controls.Add(btNova);
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
        private Button btNova;
        private Button btEditar;
        private Button btExcluir;
    }
}