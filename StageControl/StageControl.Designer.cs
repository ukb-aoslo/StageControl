namespace StageControl
{
    partial class StageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageControl));
            this.VergenzwinkelButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.VergenzwinkelTextBox = new System.Windows.Forms.TextBox();
            this.VergenzwinkelLimitLabel = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.VergenzwinkelUpButton = new System.Windows.Forms.Button();
            this.VergenzwinkelDownButton = new System.Windows.Forms.Button();
            this.StagePosLabel = new System.Windows.Forms.Label();
            this.StagePosUp01Button = new System.Windows.Forms.Button();
            this.StagePosDown01Button = new System.Windows.Forms.Button();
            this.StagePosBeideTextBox = new System.Windows.Forms.TextBox();
            this.StagePosDown1Button = new System.Windows.Forms.Button();
            this.StagePosUp1Button = new System.Windows.Forms.Button();
            this.StagePosLimitLabel = new System.Windows.Forms.Label();
            this.StagePosHomeButton = new System.Windows.Forms.Button();
            this.StagePosLinksLabel = new System.Windows.Forms.Label();
            this.StagePosRechtsLabel = new System.Windows.Forms.Label();
            this.StagePosLinksTextBox = new System.Windows.Forms.TextBox();
            this.StagePosLinksDownButton = new System.Windows.Forms.Button();
            this.StagePosLinksUpButton = new System.Windows.Forms.Button();
            this.StagePosRechtsUpButton = new System.Windows.Forms.Button();
            this.StagePosRechtsDownButton = new System.Windows.Forms.Button();
            this.StagePosRechtsTextBox = new System.Windows.Forms.TextBox();
            this.PosKorrekturTextBox = new System.Windows.Forms.TextBox();
            this.PosKorrekturLabel = new System.Windows.Forms.Label();
            this.StagePosBeideLabel = new System.Windows.Forms.Label();
            this.AugenabstandTextBox = new System.Windows.Forms.TextBox();
            this.AugenabstandLabel = new System.Windows.Forms.Label();
            this.AugenabstandLimitLabel = new System.Windows.Forms.Label();
            this.AugenabstandUpButton = new System.Windows.Forms.Button();
            this.AugenabstandDownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VergenzwinkelButton
            // 
            this.VergenzwinkelButton.Location = new System.Drawing.Point(10, 334);
            this.VergenzwinkelButton.Name = "VergenzwinkelButton";
            this.VergenzwinkelButton.Size = new System.Drawing.Size(75, 23);
            this.VergenzwinkelButton.TabIndex = 4;
            this.VergenzwinkelButton.Text = "Home";
            this.VergenzwinkelButton.UseVisualStyleBackColor = true;
            this.VergenzwinkelButton.Click += new System.EventHandler(this.VergenzwinkelButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Vergenzwinkel";
            // 
            // VergenzwinkelTextBox
            // 
            this.VergenzwinkelTextBox.AcceptsReturn = true;
            this.VergenzwinkelTextBox.Location = new System.Drawing.Point(91, 336);
            this.VergenzwinkelTextBox.Name = "VergenzwinkelTextBox";
            this.VergenzwinkelTextBox.Size = new System.Drawing.Size(75, 20);
            this.VergenzwinkelTextBox.TabIndex = 8;
            this.VergenzwinkelTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VergenzwinkelTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VergenzwinkelTextBox_KeyPress);
            // 
            // VergenzwinkelLimitLabel
            // 
            this.VergenzwinkelLimitLabel.AutoSize = true;
            this.VergenzwinkelLimitLabel.Location = new System.Drawing.Point(172, 339);
            this.VergenzwinkelLimitLabel.Name = "VergenzwinkelLimitLabel";
            this.VergenzwinkelLimitLabel.Size = new System.Drawing.Size(32, 13);
            this.VergenzwinkelLimitLabel.TabIndex = 10;
            this.VergenzwinkelLimitLabel.Text = "0 - 5°";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            // 
            // VergenzwinkelUpButton
            // 
            this.VergenzwinkelUpButton.Location = new System.Drawing.Point(91, 307);
            this.VergenzwinkelUpButton.Name = "VergenzwinkelUpButton";
            this.VergenzwinkelUpButton.Size = new System.Drawing.Size(75, 23);
            this.VergenzwinkelUpButton.TabIndex = 15;
            this.VergenzwinkelUpButton.Text = "▲";
            this.VergenzwinkelUpButton.UseVisualStyleBackColor = true;
            this.VergenzwinkelUpButton.Click += new System.EventHandler(this.VergenzwinkelUpButton_Click);
            // 
            // VergenzwinkelDownButton
            // 
            this.VergenzwinkelDownButton.Location = new System.Drawing.Point(91, 362);
            this.VergenzwinkelDownButton.Name = "VergenzwinkelDownButton";
            this.VergenzwinkelDownButton.Size = new System.Drawing.Size(75, 23);
            this.VergenzwinkelDownButton.TabIndex = 16;
            this.VergenzwinkelDownButton.Text = "▼";
            this.VergenzwinkelDownButton.UseVisualStyleBackColor = true;
            this.VergenzwinkelDownButton.Click += new System.EventHandler(this.VergenzwinkelDownButton_Click);
            // 
            // StagePosLabel
            // 
            this.StagePosLabel.AutoSize = true;
            this.StagePosLabel.Location = new System.Drawing.Point(14, 174);
            this.StagePosLabel.Name = "StagePosLabel";
            this.StagePosLabel.Size = new System.Drawing.Size(71, 13);
            this.StagePosLabel.TabIndex = 17;
            this.StagePosLabel.Text = "Stageposition";
            // 
            // StagePosUp01Button
            // 
            this.StagePosUp01Button.Location = new System.Drawing.Point(137, 163);
            this.StagePosUp01Button.Name = "StagePosUp01Button";
            this.StagePosUp01Button.Size = new System.Drawing.Size(145, 23);
            this.StagePosUp01Button.TabIndex = 18;
            this.StagePosUp01Button.Text = "▲";
            this.StagePosUp01Button.UseVisualStyleBackColor = true;
            this.StagePosUp01Button.Click += new System.EventHandler(this.StagePosUp01Button_Click);
            // 
            // StagePosDown01Button
            // 
            this.StagePosDown01Button.Location = new System.Drawing.Point(137, 218);
            this.StagePosDown01Button.Name = "StagePosDown01Button";
            this.StagePosDown01Button.Size = new System.Drawing.Size(145, 23);
            this.StagePosDown01Button.TabIndex = 19;
            this.StagePosDown01Button.Text = "▼";
            this.StagePosDown01Button.UseVisualStyleBackColor = true;
            this.StagePosDown01Button.Click += new System.EventHandler(this.StagePosDown01Button_Click);
            // 
            // StagePosBeideTextBox
            // 
            this.StagePosBeideTextBox.AcceptsReturn = true;
            this.StagePosBeideTextBox.Location = new System.Drawing.Point(153, 192);
            this.StagePosBeideTextBox.Name = "StagePosBeideTextBox";
            this.StagePosBeideTextBox.Size = new System.Drawing.Size(113, 20);
            this.StagePosBeideTextBox.TabIndex = 20;
            this.StagePosBeideTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StagePosBeideTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StagePosBeideTextBox_KeyPress);
            // 
            // StagePosDown1Button
            // 
            this.StagePosDown1Button.Location = new System.Drawing.Point(91, 247);
            this.StagePosDown1Button.Name = "StagePosDown1Button";
            this.StagePosDown1Button.Size = new System.Drawing.Size(237, 23);
            this.StagePosDown1Button.TabIndex = 21;
            this.StagePosDown1Button.Text = "▽";
            this.StagePosDown1Button.UseVisualStyleBackColor = true;
            this.StagePosDown1Button.Click += new System.EventHandler(this.StagePosDown1Button_Click);
            // 
            // StagePosUp1Button
            // 
            this.StagePosUp1Button.Location = new System.Drawing.Point(91, 134);
            this.StagePosUp1Button.Name = "StagePosUp1Button";
            this.StagePosUp1Button.Size = new System.Drawing.Size(237, 23);
            this.StagePosUp1Button.TabIndex = 22;
            this.StagePosUp1Button.Text = "△";
            this.StagePosUp1Button.UseVisualStyleBackColor = true;
            this.StagePosUp1Button.Click += new System.EventHandler(this.StagePosUp1Button_Click);
            // 
            // StagePosLimitLabel
            // 
            this.StagePosLimitLabel.AutoSize = true;
            this.StagePosLimitLabel.Location = new System.Drawing.Point(334, 195);
            this.StagePosLimitLabel.Name = "StagePosLimitLabel";
            this.StagePosLimitLabel.Size = new System.Drawing.Size(56, 13);
            this.StagePosLimitLabel.TabIndex = 23;
            this.StagePosLimitLabel.Text = "-1 - 14 mm";
            // 
            // StagePosHomeButton
            // 
            this.StagePosHomeButton.Location = new System.Drawing.Point(10, 190);
            this.StagePosHomeButton.Name = "StagePosHomeButton";
            this.StagePosHomeButton.Size = new System.Drawing.Size(75, 23);
            this.StagePosHomeButton.TabIndex = 24;
            this.StagePosHomeButton.Text = "Home";
            this.StagePosHomeButton.UseVisualStyleBackColor = true;
            this.StagePosHomeButton.Click += new System.EventHandler(this.StagePosHomeButton_Click);
            // 
            // StagePosLinksLabel
            // 
            this.StagePosLinksLabel.AutoSize = true;
            this.StagePosLinksLabel.Location = new System.Drawing.Point(115, 118);
            this.StagePosLinksLabel.Name = "StagePosLinksLabel";
            this.StagePosLinksLabel.Size = new System.Drawing.Size(32, 13);
            this.StagePosLinksLabel.TabIndex = 25;
            this.StagePosLinksLabel.Text = "Links";
            // 
            // StagePosRechtsLabel
            // 
            this.StagePosRechtsLabel.AutoSize = true;
            this.StagePosRechtsLabel.Location = new System.Drawing.Point(269, 118);
            this.StagePosRechtsLabel.Name = "StagePosRechtsLabel";
            this.StagePosRechtsLabel.Size = new System.Drawing.Size(41, 13);
            this.StagePosRechtsLabel.TabIndex = 26;
            this.StagePosRechtsLabel.Text = "Rechts";
            // 
            // StagePosLinksTextBox
            // 
            this.StagePosLinksTextBox.AcceptsReturn = true;
            this.StagePosLinksTextBox.Location = new System.Drawing.Point(91, 192);
            this.StagePosLinksTextBox.Name = "StagePosLinksTextBox";
            this.StagePosLinksTextBox.Size = new System.Drawing.Size(56, 20);
            this.StagePosLinksTextBox.TabIndex = 27;
            this.StagePosLinksTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StagePosLinksTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StagePosLinksTextBox_KeyPress);
            // 
            // StagePosLinksDownButton
            // 
            this.StagePosLinksDownButton.Location = new System.Drawing.Point(91, 218);
            this.StagePosLinksDownButton.Name = "StagePosLinksDownButton";
            this.StagePosLinksDownButton.Size = new System.Drawing.Size(40, 23);
            this.StagePosLinksDownButton.TabIndex = 28;
            this.StagePosLinksDownButton.Text = "▼";
            this.StagePosLinksDownButton.UseVisualStyleBackColor = true;
            this.StagePosLinksDownButton.Click += new System.EventHandler(this.StagePosLinksDownButton_Click);
            // 
            // StagePosLinksUpButton
            // 
            this.StagePosLinksUpButton.Location = new System.Drawing.Point(91, 163);
            this.StagePosLinksUpButton.Name = "StagePosLinksUpButton";
            this.StagePosLinksUpButton.Size = new System.Drawing.Size(40, 23);
            this.StagePosLinksUpButton.TabIndex = 29;
            this.StagePosLinksUpButton.Text = "▲";
            this.StagePosLinksUpButton.UseVisualStyleBackColor = true;
            this.StagePosLinksUpButton.Click += new System.EventHandler(this.StagePosLinksUpButton_Click);
            // 
            // StagePosRechtsUpButton
            // 
            this.StagePosRechtsUpButton.Location = new System.Drawing.Point(288, 163);
            this.StagePosRechtsUpButton.Name = "StagePosRechtsUpButton";
            this.StagePosRechtsUpButton.Size = new System.Drawing.Size(40, 23);
            this.StagePosRechtsUpButton.TabIndex = 32;
            this.StagePosRechtsUpButton.Text = "▲";
            this.StagePosRechtsUpButton.UseVisualStyleBackColor = true;
            this.StagePosRechtsUpButton.Click += new System.EventHandler(this.StagePosRechtsUpButton_Click);
            // 
            // StagePosRechtsDownButton
            // 
            this.StagePosRechtsDownButton.Location = new System.Drawing.Point(288, 218);
            this.StagePosRechtsDownButton.Name = "StagePosRechtsDownButton";
            this.StagePosRechtsDownButton.Size = new System.Drawing.Size(40, 23);
            this.StagePosRechtsDownButton.TabIndex = 31;
            this.StagePosRechtsDownButton.Text = "▼";
            this.StagePosRechtsDownButton.UseVisualStyleBackColor = true;
            this.StagePosRechtsDownButton.Click += new System.EventHandler(this.StagePosRechtsDownButton_Click);
            // 
            // StagePosRechtsTextBox
            // 
            this.StagePosRechtsTextBox.AcceptsReturn = true;
            this.StagePosRechtsTextBox.Location = new System.Drawing.Point(272, 192);
            this.StagePosRechtsTextBox.Name = "StagePosRechtsTextBox";
            this.StagePosRechtsTextBox.Size = new System.Drawing.Size(56, 20);
            this.StagePosRechtsTextBox.TabIndex = 30;
            this.StagePosRechtsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StagePosRechtsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StagePosRechtsTextBox_KeyPress);
            // 
            // PosKorrekturTextBox
            // 
            this.PosKorrekturTextBox.AcceptsReturn = true;
            this.PosKorrekturTextBox.Location = new System.Drawing.Point(253, 336);
            this.PosKorrekturTextBox.MaxLength = 3;
            this.PosKorrekturTextBox.Name = "PosKorrekturTextBox";
            this.PosKorrekturTextBox.ReadOnly = true;
            this.PosKorrekturTextBox.Size = new System.Drawing.Size(75, 20);
            this.PosKorrekturTextBox.TabIndex = 33;
            this.PosKorrekturTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PosKorrekturLabel
            // 
            this.PosKorrekturLabel.AutoSize = true;
            this.PosKorrekturLabel.Location = new System.Drawing.Point(252, 317);
            this.PosKorrekturLabel.Name = "PosKorrekturLabel";
            this.PosKorrekturLabel.Size = new System.Drawing.Size(91, 13);
            this.PosKorrekturLabel.TabIndex = 34;
            this.PosKorrekturLabel.Text = "Positionskorrektur";
            // 
            // StagePosBeideLabel
            // 
            this.StagePosBeideLabel.AutoSize = true;
            this.StagePosBeideLabel.Location = new System.Drawing.Point(190, 118);
            this.StagePosBeideLabel.Name = "StagePosBeideLabel";
            this.StagePosBeideLabel.Size = new System.Drawing.Size(34, 13);
            this.StagePosBeideLabel.TabIndex = 35;
            this.StagePosBeideLabel.Text = "Beide";
            // 
            // AugenabstandTextBox
            // 
            this.AugenabstandTextBox.AcceptsReturn = true;
            this.AugenabstandTextBox.Location = new System.Drawing.Point(172, 39);
            this.AugenabstandTextBox.Name = "AugenabstandTextBox";
            this.AugenabstandTextBox.Size = new System.Drawing.Size(75, 20);
            this.AugenabstandTextBox.TabIndex = 36;
            this.AugenabstandTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AugenabstandTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AugenabstandTextBox_KeyPress);
            // 
            // AugenabstandLabel
            // 
            this.AugenabstandLabel.AutoSize = true;
            this.AugenabstandLabel.Location = new System.Drawing.Point(90, 42);
            this.AugenabstandLabel.Name = "AugenabstandLabel";
            this.AugenabstandLabel.Size = new System.Drawing.Size(76, 13);
            this.AugenabstandLabel.TabIndex = 37;
            this.AugenabstandLabel.Text = "Augenabstand";
            // 
            // AugenabstandLimitLabel
            // 
            this.AugenabstandLimitLabel.AutoSize = true;
            this.AugenabstandLimitLabel.Location = new System.Drawing.Point(253, 42);
            this.AugenabstandLimitLabel.Name = "AugenabstandLimitLabel";
            this.AugenabstandLimitLabel.Size = new System.Drawing.Size(59, 13);
            this.AugenabstandLimitLabel.TabIndex = 38;
            this.AugenabstandLimitLabel.Text = "41 - 71 mm";
            // 
            // AugenabstandUpButton
            // 
            this.AugenabstandUpButton.Location = new System.Drawing.Point(172, 10);
            this.AugenabstandUpButton.Name = "AugenabstandUpButton";
            this.AugenabstandUpButton.Size = new System.Drawing.Size(75, 23);
            this.AugenabstandUpButton.TabIndex = 39;
            this.AugenabstandUpButton.Text = "▲";
            this.AugenabstandUpButton.UseVisualStyleBackColor = true;
            this.AugenabstandUpButton.Click += new System.EventHandler(this.AugenabstandUpButton_Click);
            // 
            // AugenabstandDownButton
            // 
            this.AugenabstandDownButton.Location = new System.Drawing.Point(172, 65);
            this.AugenabstandDownButton.Name = "AugenabstandDownButton";
            this.AugenabstandDownButton.Size = new System.Drawing.Size(75, 23);
            this.AugenabstandDownButton.TabIndex = 40;
            this.AugenabstandDownButton.Text = "▼";
            this.AugenabstandDownButton.UseVisualStyleBackColor = true;
            this.AugenabstandDownButton.Click += new System.EventHandler(this.AugenabstandDownButton_Click);
            // 
            // StageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 402);
            this.Controls.Add(this.AugenabstandDownButton);
            this.Controls.Add(this.AugenabstandUpButton);
            this.Controls.Add(this.AugenabstandLimitLabel);
            this.Controls.Add(this.AugenabstandLabel);
            this.Controls.Add(this.AugenabstandTextBox);
            this.Controls.Add(this.StagePosBeideLabel);
            this.Controls.Add(this.PosKorrekturLabel);
            this.Controls.Add(this.PosKorrekturTextBox);
            this.Controls.Add(this.StagePosRechtsUpButton);
            this.Controls.Add(this.StagePosRechtsDownButton);
            this.Controls.Add(this.StagePosRechtsTextBox);
            this.Controls.Add(this.StagePosLinksUpButton);
            this.Controls.Add(this.StagePosLinksDownButton);
            this.Controls.Add(this.StagePosLinksTextBox);
            this.Controls.Add(this.StagePosRechtsLabel);
            this.Controls.Add(this.StagePosLinksLabel);
            this.Controls.Add(this.StagePosHomeButton);
            this.Controls.Add(this.StagePosLimitLabel);
            this.Controls.Add(this.StagePosUp1Button);
            this.Controls.Add(this.StagePosDown1Button);
            this.Controls.Add(this.StagePosBeideTextBox);
            this.Controls.Add(this.StagePosDown01Button);
            this.Controls.Add(this.StagePosUp01Button);
            this.Controls.Add(this.StagePosLabel);
            this.Controls.Add(this.VergenzwinkelDownButton);
            this.Controls.Add(this.VergenzwinkelUpButton);
            this.Controls.Add(this.VergenzwinkelLimitLabel);
            this.Controls.Add(this.VergenzwinkelTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VergenzwinkelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StageControl";
            this.RightToLeftLayout = true;
            this.Text = "StageControl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StageControl_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button VergenzwinkelButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VergenzwinkelTextBox;
        private System.Windows.Forms.Label VergenzwinkelLimitLabel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button VergenzwinkelUpButton;
        private System.Windows.Forms.Button VergenzwinkelDownButton;
        private System.Windows.Forms.Label StagePosLabel;
        private System.Windows.Forms.Button StagePosUp01Button;
        private System.Windows.Forms.Button StagePosDown01Button;
        private System.Windows.Forms.TextBox StagePosBeideTextBox;
        private System.Windows.Forms.Button StagePosDown1Button;
        private System.Windows.Forms.Button StagePosUp1Button;
        private System.Windows.Forms.Label StagePosLimitLabel;
        private System.Windows.Forms.Button StagePosHomeButton;
        private System.Windows.Forms.Label StagePosLinksLabel;
        private System.Windows.Forms.Label StagePosRechtsLabel;
        private System.Windows.Forms.TextBox StagePosLinksTextBox;
        private System.Windows.Forms.Button StagePosLinksDownButton;
        private System.Windows.Forms.Button StagePosLinksUpButton;
        private System.Windows.Forms.Button StagePosRechtsUpButton;
        private System.Windows.Forms.Button StagePosRechtsDownButton;
        private System.Windows.Forms.TextBox StagePosRechtsTextBox;
        private System.Windows.Forms.TextBox PosKorrekturTextBox;
        private System.Windows.Forms.Label PosKorrekturLabel;
        private System.Windows.Forms.Label StagePosBeideLabel;
        private System.Windows.Forms.TextBox AugenabstandTextBox;
        private System.Windows.Forms.Label AugenabstandLabel;
        private System.Windows.Forms.Label AugenabstandLimitLabel;
        private System.Windows.Forms.Button AugenabstandUpButton;
        private System.Windows.Forms.Button AugenabstandDownButton;
    }
}

