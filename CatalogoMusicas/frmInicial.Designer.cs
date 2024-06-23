namespace CatalogoMusicas
{
    partial class frmInicial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btGerenciar = new Button();
            btExportar = new Button();
            SuspendLayout();
            // 
            // btGerenciar
            // 
            btGerenciar.Location = new Point(94, 34);
            btGerenciar.Name = "btGerenciar";
            btGerenciar.Size = new Size(147, 23);
            btGerenciar.TabIndex = 0;
            btGerenciar.Text = "Gerenciar músicas";
            btGerenciar.UseVisualStyleBackColor = true;
            btGerenciar.Click += btGerenciar_Click;
            // 
            // btExportar
            // 
            btExportar.Location = new Point(94, 77);
            btExportar.Name = "btExportar";
            btExportar.Size = new Size(147, 23);
            btExportar.TabIndex = 1;
            btExportar.Text = "Exportar Índice";
            btExportar.UseVisualStyleBackColor = true;
            btExportar.Click += btExportar_Click;
            // 
            // frmInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 117);
            Controls.Add(btExportar);
            Controls.Add(btGerenciar);
            MaximizeBox = false;
            Name = "frmInicial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Catálogo - Tela Inicial";
            ResumeLayout(false);
        }

        #endregion

        private Button btGerenciar;
        private Button btExportar;
    }
}
