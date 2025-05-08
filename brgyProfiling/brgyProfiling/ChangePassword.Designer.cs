namespace brgyProfiling
{
    partial class ChangePassword
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
            this.lgnBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.newpassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(160, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "CHANGE PASSWORD";
            // 
            // lgnBtn
            // 
            this.lgnBtn.BackColor = System.Drawing.Color.LightBlue;
            this.lgnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lgnBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lgnBtn.Location = new System.Drawing.Point(182, 308);
            this.lgnBtn.Name = "lgnBtn";
            this.lgnBtn.Size = new System.Drawing.Size(238, 43);
            this.lgnBtn.TabIndex = 28;
            this.lgnBtn.Text = "Log In";
            this.lgnBtn.UseVisualStyleBackColor = false;
            this.lgnBtn.Click += new System.EventHandler(this.lgnBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(103, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 18);
            this.label5.TabIndex = 27;
            this.label5.Text = "New Password";
            // 
            // newpassword
            // 
            this.newpassword.Location = new System.Drawing.Point(106, 226);
            this.newpassword.Multiline = true;
            this.newpassword.Name = "newpassword";
            this.newpassword.Size = new System.Drawing.Size(405, 31);
            this.newpassword.TabIndex = 26;
            this.newpassword.TextChanged += new System.EventHandler(this.newpassword_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Username";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(106, 145);
            this.username.Multiline = true;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(405, 31);
            this.username.TabIndex = 29;
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 390);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.username);
            this.Controls.Add(this.lgnBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newpassword);
            this.Controls.Add(this.label4);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button lgnBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox newpassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
    }
}