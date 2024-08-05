namespace DesktopInformationSystem
{
    partial class TeacherForm
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
            this.logout_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.teacher1 = new DesktopInformationSystem.Teacher();
            this.salary1 = new DesktopInformationSystem.Salary();
            this.Teachers_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Teachersalary_btn = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logout_btn
            // 
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.Location = new System.Drawing.Point(12, 524);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(64, 29);
            this.logout_btn.TabIndex = 12;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(211, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Desktop Information System";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.teacher1);
            this.panel3.Controls.Add(this.salary1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(225, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 565);
            this.panel3.TabIndex = 5;
            // 
            // teacher1
            // 
            this.teacher1.Location = new System.Drawing.Point(0, 0);
            this.teacher1.Name = "teacher1";
            this.teacher1.Size = new System.Drawing.Size(875, 565);
            this.teacher1.TabIndex = 1;
            // 
            // salary1
            // 
            this.salary1.Location = new System.Drawing.Point(0, -1);
            this.salary1.Name = "salary1";
            this.salary1.Size = new System.Drawing.Size(875, 575);
            this.salary1.TabIndex = 0;
            // 
            // Teachers_btn
            // 
            this.Teachers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Teachers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Teachers_btn.ForeColor = System.Drawing.Color.White;
            this.Teachers_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Teachers_btn.Location = new System.Drawing.Point(12, 197);
            this.Teachers_btn.Name = "Teachers_btn";
            this.Teachers_btn.Size = new System.Drawing.Size(200, 40);
            this.Teachers_btn.TabIndex = 8;
            this.Teachers_btn.Text = "Teacher";
            this.Teachers_btn.UseVisualStyleBackColor = false;
            this.Teachers_btn.Click += new System.EventHandler(this.Teachers_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Teacher";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Teachers_btn);
            this.panel2.Controls.Add(this.Teachersalary_btn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(178)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 565);
            this.panel2.TabIndex = 4;
            // 
            // Teachersalary_btn
            // 
            this.Teachersalary_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Teachersalary_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Teachersalary_btn.ForeColor = System.Drawing.Color.White;
            this.Teachersalary_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Teachersalary_btn.Location = new System.Drawing.Point(12, 243);
            this.Teachersalary_btn.Name = "Teachersalary_btn";
            this.Teachersalary_btn.Size = new System.Drawing.Size(200, 40);
            this.Teachersalary_btn.TabIndex = 7;
            this.Teachersalary_btn.Text = "Teacher Salary";
            this.Teachersalary_btn.UseVisualStyleBackColor = false;
            this.Teachersalary_btn.Click += new System.EventHandler(this.Teachersalary_btn_Click);
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 565);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherForm";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logout_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private Teacher teacher1;
        private Salary salary1;
        private System.Windows.Forms.Button Teachers_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Teachersalary_btn;
    }
}