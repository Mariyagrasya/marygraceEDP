namespace brgyProfiling
{
    partial class forgotPass
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
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.forgot = new System.Windows.Forms.TextBox();
            this.frgtLgnBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(169, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "FORGOT PASSWORD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(102, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Security Question";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(102, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "Favorate Fruit";
            // 
            // forgot
            // 
            this.forgot.Location = new System.Drawing.Point(102, 232);
            this.forgot.Multiline = true;
            this.forgot.Name = "forgot";
            this.forgot.Size = new System.Drawing.Size(405, 31);
            this.forgot.TabIndex = 22;
            this.forgot.TextChanged += new System.EventHandler(this.frgtPass_TextChanged);
            // 
            // frgtLgnBtn
            // 
            this.frgtLgnBtn.BackColor = System.Drawing.Color.LightBlue;
            this.frgtLgnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frgtLgnBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.frgtLgnBtn.Location = new System.Drawing.Point(174, 293);
            this.frgtLgnBtn.Name = "frgtLgnBtn";
            this.frgtLgnBtn.Size = new System.Drawing.Size(238, 43);
            this.frgtLgnBtn.TabIndex = 25;
            this.frgtLgnBtn.Text = "Change Password";
            this.frgtLgnBtn.UseVisualStyleBackColor = false;
            this.frgtLgnBtn.Click += new System.EventHandler(this.frgtLgnBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(102, 161);
            this.username.Multiline = true;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(405, 31);
            this.username.TabIndex = 26;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // forgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.frgtLgnBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.forgot);
            this.Controls.Add(this.label4);
            this.Name = "forgotPass";
            this.Text = "forgotPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox forgot;
        private System.Windows.Forms.Button frgtLgnBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
    }
}