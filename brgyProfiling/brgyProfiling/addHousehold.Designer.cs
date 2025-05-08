namespace brgyProfiling
{
    partial class addHousehold
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
            this.rescount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.purok = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.householdID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(122, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "ADD HOUSEHOLD";
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Azure;
            this.cancelBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(116, 390);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(238, 43);
            this.cancelBtn.TabIndex = 59;
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
            this.addBtn.Location = new System.Drawing.Point(116, 325);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(238, 43);
            this.addBtn.TabIndex = 58;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 57;
            this.label5.Text = "Resident\'s Count";
            // 
            // rescount
            // 
            this.rescount.Location = new System.Drawing.Point(246, 253);
            this.rescount.Multiline = true;
            this.rescount.Name = "rescount";
            this.rescount.Size = new System.Drawing.Size(200, 31);
            this.rescount.TabIndex = 56;
            this.rescount.TextChanged += new System.EventHandler(this.rescount_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 55;
            this.label3.Text = "Purok";
            // 
            // purok
            // 
            this.purok.Location = new System.Drawing.Point(246, 204);
            this.purok.Multiline = true;
            this.purok.Name = "purok";
            this.purok.Size = new System.Drawing.Size(200, 31);
            this.purok.TabIndex = 54;
            this.purok.TextChanged += new System.EventHandler(this.purok_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 18);
            this.label1.TabIndex = 53;
            this.label1.Text = "Household Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(246, 156);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(200, 31);
            this.name.TabIndex = 52;
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "Household ID";
            // 
            // householdID
            // 
            this.householdID.Location = new System.Drawing.Point(246, 104);
            this.householdID.Multiline = true;
            this.householdID.Name = "householdID";
            this.householdID.Size = new System.Drawing.Size(200, 31);
            this.householdID.TabIndex = 50;
            this.householdID.TextChanged += new System.EventHandler(this.householdID_TextChanged);
            // 
            // addHousehold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 472);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rescount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.purok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.householdID);
            this.Controls.Add(this.label4);
            this.Name = "addHousehold";
            this.Text = "addHousehold";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rescount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox purok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox householdID;
    }
}