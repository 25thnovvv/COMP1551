namespace DesktopInformationSystem
{
    partial class Admin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.admin_email = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.admin_status = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.admin_clearBtn = new System.Windows.Forms.Button();
            this.admin_deleteBtn = new System.Windows.Forms.Button();
            this.admin_updateBtn = new System.Windows.Forms.Button();
            this.admin_addBtn = new System.Windows.Forms.Button();
            this.admin_role = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.admin_phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.admin_gender = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.admin_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.admin_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.admin_worktype = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.admin_workinghours = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // admin_email
            // 
            this.admin_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_email.Location = new System.Drawing.Point(363, 36);
            this.admin_email.Multiline = true;
            this.admin_email.Name = "admin_email";
            this.admin_email.Size = new System.Drawing.Size(170, 23);
            this.admin_email.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(318, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Email:";
            // 
            // admin_status
            // 
            this.admin_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_status.FormattingEnabled = true;
            this.admin_status.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.admin_status.Location = new System.Drawing.Point(636, 92);
            this.admin_status.Name = "admin_status";
            this.admin_status.Size = new System.Drawing.Size(170, 23);
            this.admin_status.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(589, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Status:";
            // 
            // admin_clearBtn
            // 
            this.admin_clearBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.admin_clearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin_clearBtn.FlatAppearance.BorderSize = 0;
            this.admin_clearBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.admin_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_clearBtn.ForeColor = System.Drawing.Color.White;
            this.admin_clearBtn.Location = new System.Drawing.Point(579, 152);
            this.admin_clearBtn.Name = "admin_clearBtn";
            this.admin_clearBtn.Size = new System.Drawing.Size(113, 37);
            this.admin_clearBtn.TabIndex = 17;
            this.admin_clearBtn.Text = "Clear";
            this.admin_clearBtn.UseVisualStyleBackColor = false;
            this.admin_clearBtn.Click += new System.EventHandler(this.admin_clearBtn_Click);
            // 
            // admin_deleteBtn
            // 
            this.admin_deleteBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.admin_deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin_deleteBtn.FlatAppearance.BorderSize = 0;
            this.admin_deleteBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.admin_deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_deleteBtn.ForeColor = System.Drawing.Color.White;
            this.admin_deleteBtn.Location = new System.Drawing.Point(439, 152);
            this.admin_deleteBtn.Name = "admin_deleteBtn";
            this.admin_deleteBtn.Size = new System.Drawing.Size(113, 37);
            this.admin_deleteBtn.TabIndex = 16;
            this.admin_deleteBtn.Text = "Delete";
            this.admin_deleteBtn.UseVisualStyleBackColor = false;
            this.admin_deleteBtn.Click += new System.EventHandler(this.admin_deleteBtn_Click);
            // 
            // admin_updateBtn
            // 
            this.admin_updateBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.admin_updateBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin_updateBtn.FlatAppearance.BorderSize = 0;
            this.admin_updateBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.admin_updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_updateBtn.ForeColor = System.Drawing.Color.White;
            this.admin_updateBtn.Location = new System.Drawing.Point(298, 152);
            this.admin_updateBtn.Name = "admin_updateBtn";
            this.admin_updateBtn.Size = new System.Drawing.Size(113, 37);
            this.admin_updateBtn.TabIndex = 15;
            this.admin_updateBtn.Text = "Update";
            this.admin_updateBtn.UseVisualStyleBackColor = false;
            this.admin_updateBtn.Click += new System.EventHandler(this.admin_updateBtn_Click);
            // 
            // admin_addBtn
            // 
            this.admin_addBtn.BackColor = System.Drawing.Color.LightSlateGray;
            this.admin_addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin_addBtn.FlatAppearance.BorderSize = 0;
            this.admin_addBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.admin_addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin_addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_addBtn.ForeColor = System.Drawing.Color.White;
            this.admin_addBtn.Location = new System.Drawing.Point(160, 152);
            this.admin_addBtn.Name = "admin_addBtn";
            this.admin_addBtn.Size = new System.Drawing.Size(113, 37);
            this.admin_addBtn.TabIndex = 14;
            this.admin_addBtn.Text = "Add";
            this.admin_addBtn.UseVisualStyleBackColor = false;
            this.admin_addBtn.Click += new System.EventHandler(this.admin_addBtn_Click);
            // 
            // admin_role
            // 
            this.admin_role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_role.FormattingEnabled = true;
            this.admin_role.Items.AddRange(new object[] {
            "Admin"});
            this.admin_role.Location = new System.Drawing.Point(363, 94);
            this.admin_role.Name = "admin_role";
            this.admin_role.Size = new System.Drawing.Size(170, 23);
            this.admin_role.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(324, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Role:";
            // 
            // admin_phone
            // 
            this.admin_phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_phone.Location = new System.Drawing.Point(363, 65);
            this.admin_phone.Multiline = true;
            this.admin_phone.Name = "admin_phone";
            this.admin_phone.Size = new System.Drawing.Size(170, 23);
            this.admin_phone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone:";
            // 
            // admin_gender
            // 
            this.admin_gender.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_gender.FormattingEnabled = true;
            this.admin_gender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Others"});
            this.admin_gender.Location = new System.Drawing.Point(113, 94);
            this.admin_gender.Name = "admin_gender";
            this.admin_gender.Size = new System.Drawing.Size(170, 23);
            this.admin_gender.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gender:";
            // 
            // admin_name
            // 
            this.admin_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_name.Location = new System.Drawing.Point(113, 65);
            this.admin_name.Multiline = true;
            this.admin_name.Name = "admin_name";
            this.admin_name.Size = new System.Drawing.Size(170, 23);
            this.admin_name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Full Name:";
            // 
            // admin_id
            // 
            this.admin_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_id.Location = new System.Drawing.Point(113, 38);
            this.admin_id.Multiline = true;
            this.admin_id.Name = "admin_id";
            this.admin_id.Size = new System.Drawing.Size(170, 23);
            this.admin_id.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Admin ID:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Location = new System.Drawing.Point(0, 299);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(839, 226);
            this.panel4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(20, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(810, 225);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Admin\'s Data";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 299);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 226);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.admin_worktype);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.admin_workinghours);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.admin_email);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.admin_status);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.admin_clearBtn);
            this.panel3.Controls.Add(this.admin_deleteBtn);
            this.panel3.Controls.Add(this.admin_updateBtn);
            this.panel3.Controls.Add(this.admin_addBtn);
            this.panel3.Controls.Add(this.admin_role);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.admin_phone);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.admin_gender);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.admin_name);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.admin_id);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(12, 320);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 230);
            this.panel3.TabIndex = 4;
            // 
            // admin_worktype
            // 
            this.admin_worktype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_worktype.FormattingEnabled = true;
            this.admin_worktype.Items.AddRange(new object[] {
            "Full-Time",
            "Part-Time"});
            this.admin_worktype.Location = new System.Drawing.Point(636, 34);
            this.admin_worktype.Name = "admin_worktype";
            this.admin_worktype.Size = new System.Drawing.Size(170, 23);
            this.admin_worktype.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(566, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Work Type:";
            // 
            // admin_workinghours
            // 
            this.admin_workinghours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin_workinghours.Location = new System.Drawing.Point(636, 63);
            this.admin_workinghours.Multiline = true;
            this.admin_workinghours.Name = "admin_workinghours";
            this.admin_workinghours.Size = new System.Drawing.Size(170, 23);
            this.admin_workinghours.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(542, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Working Hours:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 290);
            this.panel1.TabIndex = 3;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Admin";
            this.Size = new System.Drawing.Size(875, 565);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox admin_email;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox admin_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button admin_clearBtn;
        private System.Windows.Forms.Button admin_deleteBtn;
        private System.Windows.Forms.Button admin_updateBtn;
        private System.Windows.Forms.Button admin_addBtn;
        private System.Windows.Forms.ComboBox admin_role;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox admin_phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox admin_gender;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox admin_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox admin_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox admin_workinghours;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox admin_worktype;
    }
}
