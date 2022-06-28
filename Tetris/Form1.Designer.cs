namespace Tetris
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonInstruction = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label1.Location = new System.Drawing.Point(573, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Score:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label2.Location = new System.Drawing.Point(580, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lines:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.7F);
            this.label3.Location = new System.Drawing.Point(310, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Level:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.7F);
            this.label4.Location = new System.Drawing.Point(565, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Speed:";
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.BackColor = System.Drawing.Color.IndianRed;
            this.labelPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F);
            this.labelPause.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelPause.Location = new System.Drawing.Point(159, 226);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(198, 67);
            this.labelPause.TabIndex = 4;
            this.labelPause.Text = "Пауза";
            this.labelPause.Visible = false;
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F);
            this.buttonPause.Location = new System.Drawing.Point(482, 276);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(187, 50);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.TabStop = false;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonPause_KeyPress);
            this.buttonPause.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            this.buttonPause.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttonPause_PreviewKeyDown);
            // 
            // buttonInstruction
            // 
            this.buttonInstruction.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonInstruction.FlatAppearance.BorderSize = 0;
            this.buttonInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.7F);
            this.buttonInstruction.Location = new System.Drawing.Point(482, 332);
            this.buttonInstruction.Name = "buttonInstruction";
            this.buttonInstruction.Size = new System.Drawing.Size(187, 50);
            this.buttonInstruction.TabIndex = 6;
            this.buttonInstruction.TabStop = false;
            this.buttonInstruction.Text = "Управление";
            this.buttonInstruction.UseVisualStyleBackColor = false;
            this.buttonInstruction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buttonInstruction_KeyPress);
            this.buttonInstruction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonInstruction_MouseClick);
            this.buttonInstruction.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.buttonInstruction_PreviewKeyDown);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(482, 388);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(187, 147);
            this.listView1.TabIndex = 7;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 1055);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonInstruction);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelPause);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonInstruction;
        private System.Windows.Forms.ListView listView1;
    }
}

