namespace CatalogoMusicas
{
    partial class frmNovoTom
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
            txtTom = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(161, 40);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Tom:";
            // 
            // btCadastrar
            // 
            btCadastrar.Location = new Point(191, 71);
            btCadastrar.Name = "btCadastrar";
            btCadastrar.Size = new Size(75, 23);
            btCadastrar.TabIndex = 1;
            btCadastrar.Text = "Cadastrar";
            btCadastrar.UseVisualStyleBackColor = true;
            btCadastrar.Click += btCadastrar_Click;
            // 
            // txtTom
            // 
            txtTom.Location = new Point(200, 37);
            txtTom.Name = "txtTom";
            txtTom.Size = new Size(118, 23);
            txtTom.TabIndex = 2;
            // 
            // frmNovoTom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(486, 106);
            Controls.Add(txtTom);
            Controls.Add(btCadastrar);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "frmNovoTom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Novo Tom - ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btCadastrar;
        private TextBox txtTom;
    }
}