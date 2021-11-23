
namespace Tp3_A21
{
    partial class FrmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerSousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tvHTML = new System.Windows.Forms.TreeView();
            this.lblTreeView = new System.Windows.Forms.Label();
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.lblContenu = new System.Windows.Forms.Label();
            this.btnSauvContenu = new System.Windows.Forms.Button();
            this.lbAttributs = new System.Windows.Forms.ListBox();
            this.lblAttributs = new System.Windows.Forms.Label();
            this.gbRechId = new System.Windows.Forms.GroupBox();
            this.btnRechParId = new System.Windows.Forms.Button();
            this.txtRechID = new System.Windows.Forms.TextBox();
            this.gbRechParTag = new System.Windows.Forms.GroupBox();
            this.lbRechParTag = new System.Windows.Forms.ListBox();
            this.btnRechParTags = new System.Windows.Forms.Button();
            this.txtRechTags = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnMonter = new System.Windows.Forms.Button();
            this.btnDescendre = new System.Windows.Forms.Button();
            this.menuPrincipal.SuspendLayout();
            this.gbRechId.SuspendLayout();
            this.gbRechParTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.elementToolStripMenuItem,
            this.attributsToolStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1257, 24);
            this.menuPrincipal.TabIndex = 0;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.ouvrirToolStripMenuItem,
            this.enregistrerToolStripMenuItem,
            this.enregistrerSousToolStripMenuItem,
            this.fermerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.nouveauToolStripMenuItem.Text = "Nouveau";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enregistrerToolStripMenuItem.Text = "Enregistrer";
            this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
            // 
            // enregistrerSousToolStripMenuItem
            // 
            this.enregistrerSousToolStripMenuItem.Name = "enregistrerSousToolStripMenuItem";
            this.enregistrerSousToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enregistrerSousToolStripMenuItem.Text = "Enregistrer sous";
            this.enregistrerSousToolStripMenuItem.Click += new System.EventHandler(this.enregistrerSousToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.fermerToolStripMenuItem.Text = "Fermer";
            this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
            // 
            // elementToolStripMenuItem
            // 
            this.elementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnElementToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.elementToolStripMenuItem.Name = "elementToolStripMenuItem";
            this.elementToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.elementToolStripMenuItem.Text = "Balise";
            // 
            // ajouterUnElementToolStripMenuItem
            // 
            this.ajouterUnElementToolStripMenuItem.Name = "ajouterUnElementToolStripMenuItem";
            this.ajouterUnElementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajouterUnElementToolStripMenuItem.Text = "Ajouter";
            this.ajouterUnElementToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnElementToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // attributsToolStripMenuItem
            // 
            this.attributsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.supprimerToolStripMenuItem1});
            this.attributsToolStripMenuItem.Name = "attributsToolStripMenuItem";
            this.attributsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.attributsToolStripMenuItem.Text = "Attributs";
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem1
            // 
            this.supprimerToolStripMenuItem1.Name = "supprimerToolStripMenuItem1";
            this.supprimerToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem1.Text = "Supprimer";
            this.supprimerToolStripMenuItem1.Click += new System.EventHandler(this.supprimerToolStripMenuItem1_Click);
            // 
            // tvHTML
            // 
            this.tvHTML.Location = new System.Drawing.Point(67, 72);
            this.tvHTML.Name = "tvHTML";
            this.tvHTML.Size = new System.Drawing.Size(337, 619);
            this.tvHTML.TabIndex = 1;
            this.tvHTML.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvHTML_AfterSelect);
            // 
            // lblTreeView
            // 
            this.lblTreeView.AutoSize = true;
            this.lblTreeView.Location = new System.Drawing.Point(185, 54);
            this.lblTreeView.Name = "lblTreeView";
            this.lblTreeView.Size = new System.Drawing.Size(143, 15);
            this.lblTreeView.TabIndex = 2;
            this.lblTreeView.Text = "Structure du fichier HTML";
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(438, 72);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(409, 304);
            this.txtContenu.TabIndex = 3;
            // 
            // lblContenu
            // 
            this.lblContenu.AutoSize = true;
            this.lblContenu.Location = new System.Drawing.Point(595, 54);
            this.lblContenu.Name = "lblContenu";
            this.lblContenu.Size = new System.Drawing.Size(53, 15);
            this.lblContenu.TabIndex = 4;
            this.lblContenu.Text = "Contenu";
            // 
            // btnSauvContenu
            // 
            this.btnSauvContenu.Location = new System.Drawing.Point(699, 382);
            this.btnSauvContenu.Name = "btnSauvContenu";
            this.btnSauvContenu.Size = new System.Drawing.Size(148, 23);
            this.btnSauvContenu.TabIndex = 5;
            this.btnSauvContenu.Text = "Sauvegarder le contenu";
            this.btnSauvContenu.UseVisualStyleBackColor = true;
            this.btnSauvContenu.Click += new System.EventHandler(this.btnSauvContenu_Click);
            // 
            // lbAttributs
            // 
            this.lbAttributs.FormattingEnabled = true;
            this.lbAttributs.ItemHeight = 15;
            this.lbAttributs.Location = new System.Drawing.Point(438, 447);
            this.lbAttributs.Name = "lbAttributs";
            this.lbAttributs.Size = new System.Drawing.Size(409, 244);
            this.lbAttributs.TabIndex = 6;
            // 
            // lblAttributs
            // 
            this.lblAttributs.AutoSize = true;
            this.lblAttributs.Location = new System.Drawing.Point(595, 429);
            this.lblAttributs.Name = "lblAttributs";
            this.lblAttributs.Size = new System.Drawing.Size(53, 15);
            this.lblAttributs.TabIndex = 7;
            this.lblAttributs.Text = "Attributs";
            // 
            // gbRechId
            // 
            this.gbRechId.Controls.Add(this.btnRechParId);
            this.gbRechId.Controls.Add(this.txtRechID);
            this.gbRechId.Location = new System.Drawing.Point(879, 72);
            this.gbRechId.Name = "gbRechId";
            this.gbRechId.Size = new System.Drawing.Size(362, 65);
            this.gbRechId.TabIndex = 8;
            this.gbRechId.TabStop = false;
            this.gbRechId.Text = "Recherche par id";
            // 
            // btnRechParId
            // 
            this.btnRechParId.Location = new System.Drawing.Point(217, 22);
            this.btnRechParId.Name = "btnRechParId";
            this.btnRechParId.Size = new System.Drawing.Size(138, 23);
            this.btnRechParId.TabIndex = 1;
            this.btnRechParId.Text = "Get element by Id";
            this.btnRechParId.UseVisualStyleBackColor = true;
            this.btnRechParId.Click += new System.EventHandler(this.btnRechParId_Click);
            // 
            // txtRechID
            // 
            this.txtRechID.Location = new System.Drawing.Point(6, 22);
            this.txtRechID.Name = "txtRechID";
            this.txtRechID.Size = new System.Drawing.Size(206, 23);
            this.txtRechID.TabIndex = 0;
            // 
            // gbRechParTag
            // 
            this.gbRechParTag.Controls.Add(this.lbRechParTag);
            this.gbRechParTag.Controls.Add(this.btnRechParTags);
            this.gbRechParTag.Controls.Add(this.txtRechTags);
            this.gbRechParTag.Location = new System.Drawing.Point(879, 172);
            this.gbRechParTag.Name = "gbRechParTag";
            this.gbRechParTag.Size = new System.Drawing.Size(362, 381);
            this.gbRechParTag.TabIndex = 9;
            this.gbRechParTag.TabStop = false;
            this.gbRechParTag.Text = "Recherche par tags";
            // 
            // lbRechParTag
            // 
            this.lbRechParTag.FormattingEnabled = true;
            this.lbRechParTag.ItemHeight = 15;
            this.lbRechParTag.Location = new System.Drawing.Point(6, 51);
            this.lbRechParTag.Name = "lbRechParTag";
            this.lbRechParTag.Size = new System.Drawing.Size(344, 319);
            this.lbRechParTag.TabIndex = 3;
            this.lbRechParTag.SelectedIndexChanged += new System.EventHandler(this.lbRechParTag_SelectedIndexChanged);
            // 
            // btnRechParTags
            // 
            this.btnRechParTags.Location = new System.Drawing.Point(217, 22);
            this.btnRechParTags.Name = "btnRechParTags";
            this.btnRechParTags.Size = new System.Drawing.Size(138, 23);
            this.btnRechParTags.TabIndex = 2;
            this.btnRechParTags.Text = "Get element by tags";
            this.btnRechParTags.UseVisualStyleBackColor = true;
            this.btnRechParTags.Click += new System.EventHandler(this.btnRechParTags_Click);
            // 
            // txtRechTags
            // 
            this.txtRechTags.Location = new System.Drawing.Point(6, 22);
            this.txtRechTags.Name = "txtRechTags";
            this.txtRechTags.Size = new System.Drawing.Size(206, 23);
            this.txtRechTags.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnMonter
            // 
            this.btnMonter.Location = new System.Drawing.Point(12, 316);
            this.btnMonter.Name = "btnMonter";
            this.btnMonter.Size = new System.Drawing.Size(49, 60);
            this.btnMonter.TabIndex = 10;
            this.btnMonter.UseVisualStyleBackColor = true;
            this.btnMonter.Click += new System.EventHandler(this.btnMonter_Click);
            // 
            // btnDescendre
            // 
            this.btnDescendre.Location = new System.Drawing.Point(12, 380);
            this.btnDescendre.Name = "btnDescendre";
            this.btnDescendre.Size = new System.Drawing.Size(49, 60);
            this.btnDescendre.TabIndex = 11;
            this.btnDescendre.UseVisualStyleBackColor = true;
            this.btnDescendre.Click += new System.EventHandler(this.btnDescendre_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 767);
            this.Controls.Add(this.btnDescendre);
            this.Controls.Add(this.btnMonter);
            this.Controls.Add(this.gbRechParTag);
            this.Controls.Add(this.gbRechId);
            this.Controls.Add(this.lblAttributs);
            this.Controls.Add(this.lbAttributs);
            this.Controls.Add(this.btnSauvContenu);
            this.Controls.Add(this.lblContenu);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.lblTreeView);
            this.Controls.Add(this.tvHTML);
            this.Controls.Add(this.menuPrincipal);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.Text = "frmPrincipal";
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.gbRechId.ResumeLayout(false);
            this.gbRechId.PerformLayout();
            this.gbRechParTag.ResumeLayout(false);
            this.gbRechParTag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerSousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem1;
        private System.Windows.Forms.TreeView tvHTML;
        private System.Windows.Forms.Label lblTreeView;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.Label lblContenu;
        private System.Windows.Forms.Button btnSauvContenu;
        private System.Windows.Forms.ListBox lbAttributs;
        private System.Windows.Forms.Label lblAttributs;
        private System.Windows.Forms.GroupBox gbRechId;
        private System.Windows.Forms.Button btnRechParId;
        private System.Windows.Forms.TextBox txtRechID;
        private System.Windows.Forms.GroupBox gbRechParTag;
        private System.Windows.Forms.ListBox lbRechParTag;
        private System.Windows.Forms.Button btnRechParTags;
        private System.Windows.Forms.TextBox txtRechTags;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnMonter;
        private System.Windows.Forms.Button btnDescendre;
    }
}