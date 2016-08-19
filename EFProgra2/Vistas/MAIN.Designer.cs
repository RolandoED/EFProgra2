namespace EFProgra2
{
    partial class MENU
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manProfesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manEstudianteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manProfesorToolStripMenuItem,
            this.manMateriaToolStripMenuItem,
            this.manEstudianteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manProfesorToolStripMenuItem
            // 
            this.manProfesorToolStripMenuItem.Name = "manProfesorToolStripMenuItem";
            this.manProfesorToolStripMenuItem.Size = new System.Drawing.Size(116, 25);
            this.manProfesorToolStripMenuItem.Text = "Man Profesor";
            this.manProfesorToolStripMenuItem.Click += new System.EventHandler(this.manProfesorToolStripMenuItem_Click);
            // 
            // manMateriaToolStripMenuItem
            // 
            this.manMateriaToolStripMenuItem.Name = "manMateriaToolStripMenuItem";
            this.manMateriaToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.manMateriaToolStripMenuItem.Text = "Man Materia";
            this.manMateriaToolStripMenuItem.Click += new System.EventHandler(this.manMateriaToolStripMenuItem_Click);
            // 
            // manEstudianteToolStripMenuItem
            // 
            this.manEstudianteToolStripMenuItem.Name = "manEstudianteToolStripMenuItem";
            this.manEstudianteToolStripMenuItem.Size = new System.Drawing.Size(129, 25);
            this.manEstudianteToolStripMenuItem.Text = "Man Estudiante";
            this.manEstudianteToolStripMenuItem.Click += new System.EventHandler(this.manEstudianteToolStripMenuItem_Click);
            // 
            // MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 476);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MENU";
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MENU_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manProfesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manEstudianteToolStripMenuItem;


    }
}