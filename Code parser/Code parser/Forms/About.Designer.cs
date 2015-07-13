﻿namespace Code_parser.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.developer_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.student_label = new System.Windows.Forms.Label();
            this.university_1_label = new System.Windows.Forms.Label();
            this.university_2_label = new System.Windows.Forms.Label();
            this.icLogo_pictureBox = new System.Windows.Forms.PictureBox();
            this.company_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.icLogo_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // developer_label
            // 
            this.developer_label.AutoSize = true;
            this.developer_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.developer_label.Location = new System.Drawing.Point(133, 12);
            this.developer_label.Name = "developer_label";
            this.developer_label.Size = new System.Drawing.Size(103, 18);
            this.developer_label.TabIndex = 1;
            this.developer_label.Text = "Разработчик:";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.name_label.Location = new System.Drawing.Point(242, 14);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(179, 18);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "Солопченко Святослав,";
            // 
            // student_label
            // 
            this.student_label.AutoSize = true;
            this.student_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.student_label.Location = new System.Drawing.Point(242, 32);
            this.student_label.Name = "student_label";
            this.student_label.Size = new System.Drawing.Size(231, 18);
            this.student_label.TabIndex = 3;
            this.student_label.Text = "студент Института Кибернетики";
            // 
            // university_1_label
            // 
            this.university_1_label.AutoSize = true;
            this.university_1_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.university_1_label.Location = new System.Drawing.Point(242, 50);
            this.university_1_label.Name = "university_1_label";
            this.university_1_label.Size = new System.Drawing.Size(268, 18);
            this.university_1_label.TabIndex = 4;
            this.university_1_label.Text = "Национального исследовательского";
            // 
            // university_2_label
            // 
            this.university_2_label.AutoSize = true;
            this.university_2_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.university_2_label.Location = new System.Drawing.Point(242, 68);
            this.university_2_label.Name = "university_2_label";
            this.university_2_label.Size = new System.Drawing.Size(306, 18);
            this.university_2_label.TabIndex = 5;
            this.university_2_label.Text = "Томского политехнического университета";
            // 
            // icLogo_pictureBox
            // 
            this.icLogo_pictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("icLogo_pictureBox.BackgroundImage")));
            this.icLogo_pictureBox.InitialImage = null;
            this.icLogo_pictureBox.Location = new System.Drawing.Point(12, 12);
            this.icLogo_pictureBox.Name = "icLogo_pictureBox";
            this.icLogo_pictureBox.Size = new System.Drawing.Size(96, 96);
            this.icLogo_pictureBox.TabIndex = 0;
            this.icLogo_pictureBox.TabStop = false;
            // 
            // company_label
            // 
            this.company_label.AutoSize = true;
            this.company_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.company_label.Location = new System.Drawing.Point(70, 133);
            this.company_label.Name = "company_label";
            this.company_label.Size = new System.Drawing.Size(440, 18);
            this.company_label.TabIndex = 6;
            this.company_label.Text = "По заданию ФГУП НПО им. С.А. Лавочкина, г. о. Химки, 2015";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(560, 171);
            this.Controls.Add(this.company_label);
            this.Controls.Add(this.university_2_label);
            this.Controls.Add(this.university_1_label);
            this.Controls.Add(this.student_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.developer_label);
            this.Controls.Add(this.icLogo_pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icLogo_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox icLogo_pictureBox;
        private System.Windows.Forms.Label developer_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label student_label;
        private System.Windows.Forms.Label university_1_label;
        private System.Windows.Forms.Label university_2_label;
        private System.Windows.Forms.Label company_label;
    }
}