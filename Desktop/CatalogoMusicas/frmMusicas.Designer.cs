namespace CatalogoMusicas
{
    partial class frmMusicas
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
            txtBuscar = new TextBox();
            btBuscar = new Button();
            dgvMusicas = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            indiceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            musicaBindingSource = new BindingSource(components);
            btNova = new Button();
            btEditar = new Button();
            btExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMusicas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)musicaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome: ";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(75, 17);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(570, 23);
            txtBuscar.TabIndex = 1;
            // 
            // btBuscar
            // 
            btBuscar.Location = new Point(671, 17);
            btBuscar.Name = "btBuscar";
            btBuscar.Size = new Size(117, 23);
            btBuscar.TabIndex = 2;
            btBuscar.Text = "Buscar";
            btBuscar.UseVisualStyleBackColor = true;
            btBuscar.Click += btBuscar_Click;
            // 
            // dgvMusicas
            // 
            dgvMusicas.AllowUserToAddRows = false;
            dgvMusicas.AllowUserToDeleteRows = false;
            dgvMusicas.AutoGenerateColumns = false;
            dgvMusicas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMusicas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, indiceDataGridViewTextBoxColumn });
            dgvMusicas.DataSource = musicaBindingSource;
            dgvMusicas.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvMusicas.Location = new Point(23, 57);
            dgvMusicas.Name = "dgvMusicas";
            dgvMusicas.Size = new Size(765, 343);
            dgvMusicas.TabIndex = 3;
            dgvMusicas.CellClick += dgvMusicas_CellClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nameDataGridViewTextBoxColumn.HeaderText = "Nome";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // indiceDataGridViewTextBoxColumn
            // 
            indiceDataGridViewTextBoxColumn.DataPropertyName = "Indice";
            indiceDataGridViewTextBoxColumn.HeaderText = "Índice";
            indiceDataGridViewTextBoxColumn.Name = "indiceDataGridViewTextBoxColumn";
            // 
            // musicaBindingSource
            // 
            musicaBindingSource.DataSource = typeof(Models.Musica);
            // 
            // btNova
            // 
            btNova.Location = new Point(33, 415);
            btNova.Name = "btNova";
            btNova.Size = new Size(121, 23);
            btNova.TabIndex = 4;
            btNova.Text = "Nova Música";
            btNova.UseVisualStyleBackColor = true;
            btNova.Click += btNova_Click;
            // 
            // btEditar
            // 
            btEditar.Enabled = false;
            btEditar.Location = new Point(160, 415);
            btEditar.Name = "btEditar";
            btEditar.Size = new Size(126, 23);
            btEditar.TabIndex = 5;
            btEditar.Text = "Editar Música";
            btEditar.UseVisualStyleBackColor = true;
            btEditar.Click += btEditar_Click;
            // 
            // btExcluir
            // 
            btExcluir.Enabled = false;
            btExcluir.Location = new Point(661, 417);
            btExcluir.Name = "btExcluir";
            btExcluir.Size = new Size(127, 23);
            btExcluir.TabIndex = 6;
            btExcluir.Text = "Excluir Música";
            btExcluir.UseVisualStyleBackColor = true;
            btExcluir.Click += btExcluir_Click;
            // 
            // frmMusicas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btExcluir);
            Controls.Add(btEditar);
            Controls.Add(btNova);
            Controls.Add(dgvMusicas);
            Controls.Add(btBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmMusicas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Músicas - ";
            ((System.ComponentModel.ISupportInitialize)dgvMusicas).EndInit();
            ((System.ComponentModel.ISupportInitialize)musicaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btBuscar;
        private DataGridView dgvMusicas;
        private BindingSource musicaBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn indiceDataGridViewTextBoxColumn;
        private Button btNova;
        private Button btEditar;
        private Button btExcluir;
    }
}