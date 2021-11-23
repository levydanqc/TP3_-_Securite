
namespace Tp3_A21
{
    partial class FrmBalise
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
            this.components = new System.ComponentModel.Container();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAttributs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSuppAttribut = new System.Windows.Forms.Button();
            this.btnAjoutAttribut = new System.Windows.Forms.Button();
            this.btnAjoutBalise = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(117, 12);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(361, 23);
            this.txtNom.TabIndex = 1;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(10, 15);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(101, 15);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom de la balise :";
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(117, 41);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(361, 182);
            this.txtContenu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contenu :";
            // 
            // lbAttributs
            // 
            this.lbAttributs.FormattingEnabled = true;
            this.lbAttributs.ItemHeight = 15;
            this.lbAttributs.Location = new System.Drawing.Point(117, 275);
            this.lbAttributs.Name = "lbAttributs";
            this.lbAttributs.Size = new System.Drawing.Size(361, 214);
            this.lbAttributs.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attributs :";
            // 
            // btnSuppAttribut
            // 
            this.btnSuppAttribut.Location = new System.Drawing.Point(117, 243);
            this.btnSuppAttribut.Name = "btnSuppAttribut";
            this.btnSuppAttribut.Size = new System.Drawing.Size(173, 23);
            this.btnSuppAttribut.TabIndex = 4;
            this.btnSuppAttribut.Text = "Supprimer l\'attribut";
            this.btnSuppAttribut.UseVisualStyleBackColor = true;
            this.btnSuppAttribut.Click += new System.EventHandler(this.btnSuppAttribut_Click);
            // 
            // btnAjoutAttribut
            // 
            this.btnAjoutAttribut.Location = new System.Drawing.Point(305, 243);
            this.btnAjoutAttribut.Name = "btnAjoutAttribut";
            this.btnAjoutAttribut.Size = new System.Drawing.Size(173, 23);
            this.btnAjoutAttribut.TabIndex = 5;
            this.btnAjoutAttribut.Text = "Ajouter l\'attribut";
            this.btnAjoutAttribut.UseVisualStyleBackColor = true;
            this.btnAjoutAttribut.Click += new System.EventHandler(this.btnAjoutAttribut_Click);
            // 
            // btnAjoutBalise
            // 
            this.btnAjoutBalise.Location = new System.Drawing.Point(117, 495);
            this.btnAjoutBalise.Name = "btnAjoutBalise";
            this.btnAjoutBalise.Size = new System.Drawing.Size(361, 23);
            this.btnAjoutBalise.TabIndex = 3;
            this.btnAjoutBalise.Text = "Ajouter la balise";
            this.btnAjoutBalise.UseVisualStyleBackColor = true;
            this.btnAjoutBalise.Click += new System.EventHandler(this.btnAjoutBalise_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frmBalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 557);
            this.Controls.Add(this.btnAjoutBalise);
            this.Controls.Add(this.btnAjoutAttribut);
            this.Controls.Add(this.btnSuppAttribut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAttributs);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.Name = "FrmBalise";
            this.Text = "Ajout d\'une balise";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbAttributs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSuppAttribut;
        private System.Windows.Forms.Button btnAjoutAttribut;
        private System.Windows.Forms.Button btnAjoutBalise;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}