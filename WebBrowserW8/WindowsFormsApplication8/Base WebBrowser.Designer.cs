namespace WindowsFormsApplication8
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.favoritosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HOME = new System.Windows.Forms.ToolStripButton();
            this.back = new System.Windows.Forms.ToolStripButton();
            this.forward = new System.Windows.Forms.ToolStripButton();
            this.refresh = new System.Windows.Forms.ToolStripButton();
            this.Cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.Navegador = new System.Windows.Forms.ToolStripComboBox();
            this.Go = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.Buscar = new System.Windows.Forms.ToolStripButton();
            this.newtab = new System.Windows.Forms.ToolStripButton();
            this.closeTap = new System.Windows.Forms.ToolStripButton();
            this.Navegador1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.HOME,
            this.back,
            this.forward,
            this.refresh,
            this.Cancelar,
            this.toolStripSeparator6,
            this.Navegador,
            this.Go,
            this.Buscar,
            this.toolStripSeparator7,
            this.newtab,
            this.closeTap});
            this.toolStrip1.Location = new System.Drawing.Point(0, 444);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1027, 29);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.favoritosToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(111, 26);
            this.toolStripDropDownButton1.Text = "Herramientas";
            // 
            // favoritosToolStripMenuItem1
            // 
            this.favoritosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.añadirToolStripMenuItem});
            this.favoritosToolStripMenuItem1.Name = "favoritosToolStripMenuItem1";
            this.favoritosToolStripMenuItem1.Size = new System.Drawing.Size(138, 24);
            this.favoritosToolStripMenuItem1.Text = "Favoritos";
            // 
            // añadirToolStripMenuItem
            // 
            this.añadirToolStripMenuItem.Name = "añadirToolStripMenuItem";
            this.añadirToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.añadirToolStripMenuItem.Text = "Añadir";
            // 
            // HOME
            // 
            this.HOME.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.HOME.Image = ((System.Drawing.Image)(resources.GetObject("HOME.Image")));
            this.HOME.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HOME.Name = "HOME";
            this.HOME.Size = new System.Drawing.Size(56, 26);
            this.HOME.Text = "HOME";
            this.HOME.Click += new System.EventHandler(this.HOME_Click);
            // 
            // back
            // 
            this.back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(23, 26);
            this.back.Text = "back";
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // forward
            // 
            this.forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forward.Image = ((System.Drawing.Image)(resources.GetObject("forward.Image")));
            this.forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(23, 26);
            this.forward.Text = "forward";
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // refresh
            // 
            this.refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(23, 26);
            this.refresh.Text = "refresh";
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Cancelar.Image = ((System.Drawing.Image)(resources.GetObject("Cancelar.Image")));
            this.Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(23, 26);
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // Navegador
            // 
            this.Navegador.AutoCompleteCustomSource.AddRange(new string[] {
            "1"});
            this.Navegador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Navegador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.Navegador.DropDownHeight = 300;
            this.Navegador.IntegralHeight = false;
            this.Navegador.Items.AddRange(new object[] {
            "http://www.google.es",
            "http://www.msn.es"});
            this.Navegador.Name = "Navegador";
            this.Navegador.Size = new System.Drawing.Size(375, 29);
            this.Navegador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Navegador_KeyPress);
            // 
            // Go
            // 
            this.Go.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Go.Image = ((System.Drawing.Image)(resources.GetObject("Go.Image")));
            this.Go.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(32, 26);
            this.Go.Text = "Go";
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Margin = new System.Windows.Forms.Padding(3);
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // Buscar
            // 
            this.Buscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Buscar.Image")));
            this.Buscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(56, 26);
            this.Buscar.Text = "Buscar";
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // newtab
            // 
            this.newtab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newtab.Image = ((System.Drawing.Image)(resources.GetObject("newtab.Image")));
            this.newtab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newtab.Name = "newtab";
            this.newtab.Size = new System.Drawing.Size(111, 26);
            this.newtab.Text = "añadir pestaña";
            this.newtab.Click += new System.EventHandler(this.newtab_Click);
            // 
            // closeTap
            // 
            this.closeTap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeTap.Image = ((System.Drawing.Image)(resources.GetObject("closeTap.Image")));
            this.closeTap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeTap.Name = "closeTap";
            this.closeTap.Size = new System.Drawing.Size(123, 26);
            this.closeTap.Text = "Eliminar pestaña";
            this.closeTap.Click += new System.EventHandler(this.closeTap_Click);
            // 
            // Navegador1
            // 
            this.Navegador1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Navegador1.Location = new System.Drawing.Point(0, 1);
            this.Navegador1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Navegador1.Name = "Navegador1";
            this.Navegador1.SelectedIndex = 0;
            this.Navegador1.Size = new System.Drawing.Size(1019, 436);
            this.Navegador1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 473);
            this.Controls.Add(this.Navegador1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem favoritosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem añadirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton Go;
        private System.Windows.Forms.ToolStripButton Buscar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton refresh;
        private System.Windows.Forms.ToolStripButton Cancelar;
        private System.Windows.Forms.ToolStripButton back;
        private System.Windows.Forms.ToolStripButton forward;
        private System.Windows.Forms.ToolStripButton HOME;
        private System.Windows.Forms.TabControl Navegador1;
        private System.Windows.Forms.ToolStripButton newtab;
        private System.Windows.Forms.ToolStripButton closeTap;
        private System.Windows.Forms.ToolStripComboBox Navegador;
    }
}

