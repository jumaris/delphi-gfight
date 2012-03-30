namespace GFightEditor {
  partial class frmGFightEditor {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing ) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.lsbAvailableItems = new System.Windows.Forms.ListBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add( this.tabPage1 );
      this.tabControl1.Controls.Add( this.tabPage2 );
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.ItemSize = new System.Drawing.Size( 150, 25 );
      this.tabControl1.Location = new System.Drawing.Point( 0, 0 );
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size( 584, 362 );
      this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add( this.lsbAvailableItems );
      this.tabPage1.Location = new System.Drawing.Point( 4, 29 );
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding( 3 );
      this.tabPage1.Size = new System.Drawing.Size( 576, 329 );
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Item Edit";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // lsbAvailableItems
      // 
      this.lsbAvailableItems.Dock = System.Windows.Forms.DockStyle.Left;
      this.lsbAvailableItems.FormattingEnabled = true;
      this.lsbAvailableItems.Location = new System.Drawing.Point( 3, 3 );
      this.lsbAvailableItems.Name = "lsbAvailableItems";
      this.lsbAvailableItems.Size = new System.Drawing.Size( 145, 323 );
      this.lsbAvailableItems.TabIndex = 0;
      this.lsbAvailableItems.CursorChanged += new System.EventHandler( this.lsbAvailableItems_CursorChanged );
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point( 4, 29 );
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding( 3 );
      this.tabPage2.Size = new System.Drawing.Size( 576, 329 );
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Mob Edit";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // frmGFightEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 584, 362 );
      this.Controls.Add( this.tabControl1 );
      this.Name = "frmGFightEditor";
      this.Text = "GFight Editor";
      this.tabControl1.ResumeLayout( false );
      this.tabPage1.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.ListBox lsbAvailableItems;
  }
}

