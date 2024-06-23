namespace CatalogoMusicas
{
    partial class frmNovaPasta
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
            label1 = new Label();
            btCadastrar = new Button();
            txtNome = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 43);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // btCadastrar
            // 
            btCadastrar.Location = new Point(168, 87);
            btCadastrar.Name = "btCadastrar";
            btCadastrar.Size = new Size(105, 23);
            btCadastrar.TabIndex = 1;
            btCadastrar.Text = "Cadastrar Pasta";
            btCadastrar.UseVisualStyleBackColor = true;
            btCadastrar.Click += btCadastrar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(113, 40);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(276, 23);
            txtNome.TabIndex = 2;
            // 
            // frmNovaPasta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 139);
            Controls.Add(txtNome);
            Controls.Add(btCadastrar);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmNovaPasta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Cadastrar Pasta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btCadastrar;
        private TextBox txtNome;
    }
}