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
            this.buttonReset.Location = new System.Drawing.Point(24, 303);
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
            this.label1.Location = new System.Drawing.Point(55, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ваш счёт:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label2.Location = new System.Drawing.Point(59, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "LVL: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label4.Location = new System.Drawing.Point(83, 38);
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
            this.labelScore.Location = new System.Drawing.Point(231, 113);
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
            this.labelName.Location = new System.Drawing.Point(201, 38);
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
            this.labelLevel.Location = new System.Drawing.Point(231, 169);
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
            this.labelLines.Location = new System.Drawing.Point(231, 223);
            this.labelLines.Name = "labelLines";
            this.labelLines.Size = new System.Drawing.Size(118, 37);
            this.labelLines.TabIndex = 18;
            this.labelLines.Text = "Тетрис";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.7F);
            this.label3.Location = new System.Drawing.Point(55, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 37);
            this.label3.TabIndex = 17;
            this.label3.Text = "Линии:";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F);
            this.buttonExit.Location = new System.Drawing.Point(217, 303);
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
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(402, 383);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelLines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.Label labelLines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExit;
    }
}