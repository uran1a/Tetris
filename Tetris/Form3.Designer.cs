namespace Tetris
{
    partial class Form3
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelLevel = new System.Windows.Forms.Label();
            this.labelLines = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F);
            this.buttonReset.Location = new System.Drawing.Point(47, 370);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(168, 68);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "Сыграть заново";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label1.Location = new System.Drawing.Point(36, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ваш счёт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label2.Location = new System.Drawing.Point(40, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "LV: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label8.Location = new System.Drawing.Point(315, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 37);
            this.label8.TabIndex = 10;
            this.label8.Text = "Тетрис";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label9.Location = new System.Drawing.Point(36, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(273, 37);
            this.label9.TabIndex = 9;
            this.label9.Text = "Место в рейтинге:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label4.Location = new System.Drawing.Point(126, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 37);
            this.label4.TabIndex = 11;
            this.label4.Text = "Игрок ";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.SystemColors.Control;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.labelScore.Location = new System.Drawing.Point(197, 111);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(118, 37);
            this.labelScore.TabIndex = 14;
            this.labelScore.Text = "Тетрис";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.SystemColors.Control;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.labelName.Location = new System.Drawing.Point(225, 33);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(118, 37);
            this.labelName.TabIndex = 15;
            this.labelName.Text = "Тетрис";
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.BackColor = System.Drawing.SystemColors.Control;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.labelLevel.Location = new System.Drawing.Point(197, 167);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(118, 37);
            this.labelLevel.TabIndex = 16;
            this.labelLevel.Text = "Тетрис";
            // 
            // labelLines
            // 
            this.labelLines.AutoSize = true;
            this.labelLines.BackColor = System.Drawing.SystemColors.Control;
            this.labelLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.labelLines.Location = new System.Drawing.Point(197, 221);
            this.labelLines.Name = "labelLines";
            this.labelLines.Size = new System.Drawing.Size(118, 37);
            this.labelLines.TabIndex = 18;
            this.labelLines.Text = "Тетрис";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label3.Location = new System.Drawing.Point(36, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 37);
            this.label3.TabIndex = 17;
            this.label3.Text = "Линии:";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F);
            this.buttonExit.Location = new System.Drawing.Point(255, 370);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(168, 68);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(488, 450);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelLines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExit;
    }
}