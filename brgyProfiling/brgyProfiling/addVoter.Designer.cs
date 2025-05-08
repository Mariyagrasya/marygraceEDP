namespace brgyProfiling
{
    partial class addVoter
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.precinctnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.residentID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.voterID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(77, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "ADD REGISTERED VOTER";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Azure;
            this.cancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(114, 408);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(238, 43);
            this.cancelBtn.TabIndex = 69;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.LightBlue;
            this.addBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addBtn.Location = new System.Drawing.Point(114, 343);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(238, 43);
            this.addBtn.TabIndex = 68;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 18);
            this.label5.TabIndex = 67;
            this.label5.Text = "Precinct Number";
            // 
            // precinctnum
            // 
            this.precinctnum.Location = new System.Drawing.Point(244, 271);
            this.precinctnum.Multiline = true;
            this.precinctnum.Name = "precinctnum";
            this.precinctnum.Size = new System.Drawing.Size(200, 31);
            this.precinctnum.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 18);
            this.label3.TabIndex = 65;
            this.label3.Text = "Registration Date";
            // 
            // registration
            // 
            this.registration.Location = new System.Drawing.Point(244, 222);
            this.registration.Multiline = true;
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(200, 31);
            this.registration.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 63;
            this.label1.Text = "Resident";
            // 
            // residentID
            // 
            this.residentID.Location = new System.Drawing.Point(244, 174);
            this.residentID.Multiline = true;
            this.residentID.Name = "residentID";
            this.residentID.Size = new System.Drawing.Size(200, 31);
            this.residentID.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 61;
            this.label2.Text = "Voter ID";
            // 
            // voterID
            // 
            this.voterID.Location = new System.Drawing.Point(244, 122);
            this.voterID.Multiline = true;
            this.voterID.Name = "voterID";
            this.voterID.Size = new System.Drawing.Size(200, 31);
            this.voterID.TabIndex = 60;
            // 
            // addVoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 507);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.precinctnum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.residentID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voterID);
            this.Controls.Add(this.label4);
            this.Name = "addVoter";
            this.Text = "addVoter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox precinctnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox registration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox residentID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox voterID;
    }
}