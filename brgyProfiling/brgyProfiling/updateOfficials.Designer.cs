namespace brgyProfiling
{
    partial class updateOfficials
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.role = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.staffID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Azure;
            this.cancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(114, 390);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(238, 43);
            this.cancelBtn.TabIndex = 68;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click_1);
            // 
            // updateBtn
            // 
            this.updateBtn.BackColor = System.Drawing.Color.LightBlue;
            this.updateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.updateBtn.Location = new System.Drawing.Point(114, 325);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(238, 43);
            this.updateBtn.TabIndex = 67;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 18);
            this.label3.TabIndex = 66;
            this.label3.Text = "Role ID";
            // 
            // role
            // 
            this.role.Location = new System.Drawing.Point(244, 227);
            this.role.Multiline = true;
            this.role.Name = "role";
            this.role.Size = new System.Drawing.Size(200, 31);
            this.role.TabIndex = 65;
            this.role.TextChanged += new System.EventHandler(this.roleID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 64;
            this.label1.Text = "Staff Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(244, 179);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(200, 31);
            this.name.TabIndex = 63;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "Staff ID";
            // 
            // staffID
            // 
            this.staffID.Location = new System.Drawing.Point(244, 127);
            this.staffID.Multiline = true;
            this.staffID.Name = "staffID";
            this.staffID.Size = new System.Drawing.Size(200, 31);
            this.staffID.TabIndex = 61;
            this.staffID.TextChanged += new System.EventHandler(this.staffID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(84, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 29);
            this.label4.TabIndex = 60;
            this.label4.Text = "UPDATE BRGY OFFICIALS";
            // 
            // updateOfficials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 472);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.role);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.staffID);
            this.Controls.Add(this.label4);
            this.Name = "updateOfficials";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "updateOfficials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox role;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox staffID;
        private System.Windows.Forms.Label label4;
    }
}