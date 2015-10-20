namespace SatoshiMines.UI.Forms
{
    partial class MainForm
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
                _provider.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbMines = new System.Windows.Forms.Label();
            this.cbMines = new System.Windows.Forms.ComboBox();
            this.lbBits = new System.Windows.Forms.Label();
            this.nudBits = new System.Windows.Forms.NumericUpDown();
            this.pOptions = new System.Windows.Forms.Panel();
            this.tbPlayerHash = new System.Windows.Forms.TextBox();
            this.cbPlayerHash = new System.Windows.Forms.CheckBox();
            this.smgMain = new SatoshiMines.UI.Controls.SatoshiMinesGrid();
            ((System.ComponentModel.ISupportInitialize)(this.nudBits)).BeginInit();
            this.pOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMines
            // 
            this.lbMines.AutoSize = true;
            this.lbMines.Location = new System.Drawing.Point(18, 205);
            this.lbMines.Name = "lbMines";
            this.lbMines.Size = new System.Drawing.Size(39, 13);
            this.lbMines.TabIndex = 2;
            this.lbMines.Text = "Mines";
            // 
            // cbMines
            // 
            this.cbMines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMines.FormattingEnabled = true;
            this.cbMines.Items.AddRange(new object[] {
            "One",
            "Three",
            "Five",
            "Twenty Four"});
            this.cbMines.Location = new System.Drawing.Point(21, 221);
            this.cbMines.Name = "cbMines";
            this.cbMines.Size = new System.Drawing.Size(178, 21);
            this.cbMines.TabIndex = 3;
            // 
            // lbBits
            // 
            this.lbBits.AutoSize = true;
            this.lbBits.Location = new System.Drawing.Point(18, 155);
            this.lbBits.Name = "lbBits";
            this.lbBits.Size = new System.Drawing.Size(28, 13);
            this.lbBits.TabIndex = 4;
            this.lbBits.Text = "Bits";
            // 
            // nudBits
            // 
            this.nudBits.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBits.Location = new System.Drawing.Point(21, 171);
            this.nudBits.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBits.Name = "nudBits";
            this.nudBits.Size = new System.Drawing.Size(178, 21);
            this.nudBits.TabIndex = 5;
            this.nudBits.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // pOptions
            // 
            this.pOptions.Controls.Add(this.cbPlayerHash);
            this.pOptions.Controls.Add(this.tbPlayerHash);
            this.pOptions.Controls.Add(this.lbBits);
            this.pOptions.Controls.Add(this.nudBits);
            this.pOptions.Controls.Add(this.lbMines);
            this.pOptions.Controls.Add(this.cbMines);
            this.pOptions.Location = new System.Drawing.Point(363, 12);
            this.pOptions.Name = "pOptions";
            this.pOptions.Size = new System.Drawing.Size(216, 344);
            this.pOptions.TabIndex = 6;
            // 
            // tbPlayerHash
            // 
            this.tbPlayerHash.Enabled = false;
            this.tbPlayerHash.Location = new System.Drawing.Point(21, 121);
            this.tbPlayerHash.Name = "tbPlayerHash";
            this.tbPlayerHash.Size = new System.Drawing.Size(178, 21);
            this.tbPlayerHash.TabIndex = 7;
            // 
            // cbPlayerHash
            // 
            this.cbPlayerHash.AutoSize = true;
            this.cbPlayerHash.Location = new System.Drawing.Point(21, 98);
            this.cbPlayerHash.Name = "cbPlayerHash";
            this.cbPlayerHash.Size = new System.Drawing.Size(94, 17);
            this.cbPlayerHash.TabIndex = 8;
            this.cbPlayerHash.Text = "Player Hash";
            this.cbPlayerHash.UseVisualStyleBackColor = true;
            this.cbPlayerHash.CheckedChanged += new System.EventHandler(this.cbPlayerHash_CheckedChanged);
            // 
            // smgMain
            // 
            this.smgMain.GameStarted = false;
            this.smgMain.Location = new System.Drawing.Point(12, 12);
            this.smgMain.Name = "smgMain";
            this.smgMain.Size = new System.Drawing.Size(345, 345);
            this.smgMain.TabIndex = 1;
            this.smgMain.Text = "smgMain";
            this.smgMain.OnGridClicked += new SatoshiMines.UI.Controls.SatoshiMinesGrid.OnGridClickedHandler(this.smgMain_OnGridClicked);
            this.smgMain.OnStartClicked += new System.EventHandler(this.smgMain_OnStartClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(591, 368);
            this.Controls.Add(this.pOptions);
            this.Controls.Add(this.smgMain);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudBits)).EndInit();
            this.pOptions.ResumeLayout(false);
            this.pOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.SatoshiMinesGrid smgMain;
        private System.Windows.Forms.Label lbMines;
        private System.Windows.Forms.ComboBox cbMines;
        private System.Windows.Forms.Label lbBits;
        private System.Windows.Forms.NumericUpDown nudBits;
        private System.Windows.Forms.Panel pOptions;
        private System.Windows.Forms.CheckBox cbPlayerHash;
        private System.Windows.Forms.TextBox tbPlayerHash;
    }
}