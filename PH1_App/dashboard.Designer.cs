
namespace PH1_App
{
    partial class dashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.toggleSidebarBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sidebar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản trị cơ sở dữ liệu";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(88, 185);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 71);
            this.button4.TabIndex = 14;
            this.button4.Text = "Danh sách vai trò";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.clickRole);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(318, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 71);
            this.button1.TabIndex = 15;
            this.button1.Text = "Danh sách người dùng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clickUser);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sidebar.Controls.Add(this.label3);
            this.sidebar.Controls.Add(this.label2);
            this.sidebar.Controls.Add(this.button8);
            this.sidebar.Controls.Add(this.button6);
            this.sidebar.Controls.Add(this.button5);
            this.sidebar.Controls.Add(this.label4);
            this.sidebar.Controls.Add(this.button2);
            this.sidebar.Controls.Add(this.button3);
            this.sidebar.Controls.Add(this.button10);
            this.sidebar.Controls.Add(this.button11);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(280, 753);
            this.sidebar.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(23, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giao diện";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(23, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thông tin khác";
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(0, 526);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(280, 54);
            this.button8.TabIndex = 8;
            this.button8.Text = "Khóa";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(0, 426);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(280, 55);
            this.button6.TabIndex = 6;
            this.button6.Text = "Nhật ký người dùng";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.clickAudit);
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(0, 371);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(280, 55);
            this.button5.TabIndex = 5;
            this.button5.Text = "Mã hóa dữ liệu";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Location = new System.Drawing.Point(23, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quản lý hệ thống";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(0, 155);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(280, 55);
            this.button2.TabIndex = 3;
            this.button2.Text = "Admin Dashboard";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(0, 316);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(280, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "Vai trò";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.clickRole);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button10.Location = new System.Drawing.Point(0, 261);
            this.button10.Name = "button10";
            this.button10.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button10.Size = new System.Drawing.Size(280, 55);
            this.button10.TabIndex = 1;
            this.button10.Text = "Người dùng";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.clickUser);
            // 
            // button11
            // 
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Inter Light", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button11.Location = new System.Drawing.Point(0, 100);
            this.button11.Name = "button11";
            this.button11.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.button11.Size = new System.Drawing.Size(280, 55);
            this.button11.TabIndex = 0;
            this.button11.Text = "Trang chủ";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.clickHomepage);
            // 
            // toggleSidebarBtn
            // 
            this.toggleSidebarBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toggleSidebarBtn.FlatAppearance.BorderSize = 0;
            this.toggleSidebarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleSidebarBtn.Font = new System.Drawing.Font("Inter Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSidebarBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toggleSidebarBtn.Location = new System.Drawing.Point(230, 12);
            this.toggleSidebarBtn.Name = "toggleSidebarBtn";
            this.toggleSidebarBtn.Size = new System.Drawing.Size(48, 45);
            this.toggleSidebarBtn.TabIndex = 12;
            this.toggleSidebarBtn.Text = "❮";
            this.toggleSidebarBtn.UseVisualStyleBackColor = false;
            this.toggleSidebarBtn.Click += new System.EventHandler(this.clickToggleSidebar);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(280, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 753);
            this.panel2.TabIndex = 3;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 753);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toggleSidebarBtn);
            this.Controls.Add(this.sidebar);
            this.Name = "dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Dashboard";
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button toggleSidebarBtn;
        private System.Windows.Forms.Panel panel2;
    }
}

