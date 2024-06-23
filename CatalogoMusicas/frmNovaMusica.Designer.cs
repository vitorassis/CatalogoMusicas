namespace CatalogoMusicas
{
    partial class frmNovaMusica
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
            label2 = new Label();
            label3 = new Label();
            txtNome = new TextBox();
            txtTom = new TextBox();
            numIndice = new NumericUpDown();
            btCadastrar = new Button();
            ((System.ComponentModel.ISupportInitialize)numIndice).BeginInit();
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 97);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Tom:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 132);
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
            // txtTom
            // 
            txtTom.Location = new Point(145, 97);
            txtTom.Name = "txtTom";
            txtTom.Size = new Size(179, 23);
            txtTom.TabIndex = 4;
            // 
            // numIndice
            // 
            numIndice.Location = new Point(145, 130);
            numIndice.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numIndice.Name = "numIndice";
            numIndice.Size = new Size(179, 23);
            numIndice.TabIndex = 5;
            // 
            // btCadastrar
            // 
            btCadastrar.Location = new Point(169, 186);
            btCadastrar.Name = "btCadastrar";
            btCadastrar.Size = new Size(75, 23);
            btCadastrar.TabIndex = 6;
            btCadastrar.Text = "Cadastrar";
            btCadastrar.UseVisualStyleBackColor = true;
            btCadastrar.Click += btCadastrar_Click;
            // 
            // frmNovaMusica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 221);
            Controls.Add(btCadastrar);
            Controls.Add(numIndice);
            Controls.Add(txtTom);
            Controls.Add(txtNome);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmNovaMusica";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Cadastrar Música - ";
            ((System.ComponentModel.ISupportInitialize)numIndice).EndInit();
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
        private Button btCadastrar;
    }
}