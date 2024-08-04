
namespace DesktopInformationSystem
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Adminsalary_btn = new System.Windows.Forms.Button();
            this.Admin_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Teachers_btn = new System.Windows.Forms.Button();
            this.Teachersalary_btn = new System.Windows.Forms.Button();
            this.Student_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.logout_btn = new System.Windows.Forms.Button();
            this.adminSalary1 = new DesktopInformationSystem.AdminSalary();
            this.salary1 = new DesktopInformationSystem.Salary();
            this.teacher1 = new DesktopInformationSystem.Teacher();
            this.student1 = new DesktopInformationSystem.Student();
            this.admin1 = new DesktopInformationSystem.Admin();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 25);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1080, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "X";
            this.label3.Click += new System.EventHandler(this.Exit_btn);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Desktop Information System | Main Form";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.logout_btn);
            this.panel2.Controls.Add(this.Adminsalary_btn);
            this.panel2.Controls.Add(this.Admin_btn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Teachers_btn);
            this.panel2.Controls.Add(this.Teachersalary_btn);
            this.panel2.Controls.Add(this.Student_btn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(178)))));
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 575);
            this.panel2.TabIndex = 1;
            // 
            // Adminsalary_btn
            // 
            this.Adminsalary_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Adminsalary_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Adminsalary_btn.ForeColor = System.Drawing.Color.White;
            this.Adminsalary_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Adminsalary_btn.Location = new System.Drawing.Point(12, 381);
            this.Adminsalary_btn.Name = "Adminsalary_btn";
            this.Adminsalary_btn.Size = new System.Drawing.Size(200, 40);
            this.Adminsalary_btn.TabIndex = 11;
            this.Adminsalary_btn.Text = "Admin Salary";
            this.Adminsalary_btn.UseVisualStyleBackColor = false;
            this.Adminsalary_btn.Click += new System.EventHandler(this.Adminsalary_btn_Click);
            // 
            // Admin_btn
            // 
            this.Admin_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Admin_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Admin_btn.ForeColor = System.Drawing.Color.White;
            this.Admin_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Admin_btn.Location = new System.Drawing.Point(12, 197);
            this.Admin_btn.Name = "Admin_btn";
            this.Admin_btn.Size = new System.Drawing.Size(200, 40);
            this.Admin_btn.TabIndex = 10;
            this.Admin_btn.Text = "Admin";
            this.Admin_btn.UseVisualStyleBackColor = false;
            this.Admin_btn.Click += new System.EventHandler(this.Admin_btn_Click);
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
            // Teachers_btn
            // 
            this.Teachers_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Teachers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Teachers_btn.ForeColor = System.Drawing.Color.White;
            this.Teachers_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Teachers_btn.Location = new System.Drawing.Point(12, 289);
            this.Teachers_btn.Name = "Teachers_btn";
            this.Teachers_btn.Size = new System.Drawing.Size(200, 40);
            this.Teachers_btn.TabIndex = 8;
            this.Teachers_btn.Text = "Teacher";
            this.Teachers_btn.UseVisualStyleBackColor = false;
            this.Teachers_btn.Click += new System.EventHandler(this.Teachers_btn_Click);
            // 
            // Teachersalary_btn
            // 
            this.Teachersalary_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Teachersalary_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Teachersalary_btn.ForeColor = System.Drawing.Color.White;
            this.Teachersalary_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Teachersalary_btn.Location = new System.Drawing.Point(12, 335);
            this.Teachersalary_btn.Name = "Teachersalary_btn";
            this.Teachersalary_btn.Size = new System.Drawing.Size(200, 40);
            this.Teachersalary_btn.TabIndex = 7;
            this.Teachersalary_btn.Text = "Teacher Salary";
            this.Teachersalary_btn.UseVisualStyleBackColor = false;
            this.Teachersalary_btn.Click += new System.EventHandler(this.Teachersalary_btn_Click);
            // 
            // Student_btn
            // 
            this.Student_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Student_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Student_btn.ForeColor = System.Drawing.Color.White;
            this.Student_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Student_btn.Location = new System.Drawing.Point(12, 243);
            this.Student_btn.Name = "Student_btn";
            this.Student_btn.Size = new System.Drawing.Size(200, 40);
            this.Student_btn.TabIndex = 3;
            this.Student_btn.Text = "Student";
            this.Student_btn.UseVisualStyleBackColor = false;
            this.Student_btn.Click += new System.EventHandler(this.Student_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome, Admin";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.admin1);
            this.panel3.Controls.Add(this.student1);
            this.panel3.Controls.Add(this.teacher1);
            this.panel3.Controls.Add(this.salary1);
            this.panel3.Controls.Add(this.adminSalary1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(225, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(875, 575);
            this.panel3.TabIndex = 2;
            // 
            // logout_btn
            // 
            this.logout_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout_btn.ForeColor = System.Drawing.Color.White;
            this.logout_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout_btn.Location = new System.Drawing.Point(12, 534);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.Size = new System.Drawing.Size(64, 29);
            this.logout_btn.TabIndex = 12;
            this.logout_btn.Text = "Logout";
            this.logout_btn.UseVisualStyleBackColor = false;
            this.logout_btn.Click += new System.EventHandler(this.logout_btn_Click);
            // 
            // adminSalary1
            // 
            this.adminSalary1.Location = new System.Drawing.Point(0, 0);
            this.adminSalary1.Name = "adminSalary1";
            this.adminSalary1.Size = new System.Drawing.Size(875, 575);
            this.adminSalary1.TabIndex = 0;
            // 
            // salary1
            // 
            this.salary1.Location = new System.Drawing.Point(0, 0);
            this.salary1.Name = "salary1";
            this.salary1.Size = new System.Drawing.Size(875, 575);
            this.salary1.TabIndex = 1;
            // 
            // teacher1
            // 
            this.teacher1.Location = new System.Drawing.Point(0, -1);
            this.teacher1.Name = "teacher1";
            this.teacher1.Size = new System.Drawing.Size(875, 576);
            this.teacher1.TabIndex = 2;
            // 
            // student1
            // 
            this.student1.Location = new System.Drawing.Point(0, 0);
            this.student1.Name = "student1";
            this.student1.Size = new System.Drawing.Size(875, 575);
            this.student1.TabIndex = 3;
            // 
            // admin1
            // 
            this.admin1.Location = new System.Drawing.Point(0, 0);
            this.admin1.Name = "admin1";
            this.admin1.Size = new System.Drawing.Size(875, 575);
            this.admin1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Student_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Teachersalary_btn;
        private System.Windows.Forms.Button Teachers_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Admin_btn;
        private System.Windows.Forms.Button Adminsalary_btn;
        private System.Windows.Forms.Button logout_btn;
        private Admin admin1;
        private Student student1;
        private Teacher teacher1;
        private Salary salary1;
        private AdminSalary adminSalary1;
    }
}