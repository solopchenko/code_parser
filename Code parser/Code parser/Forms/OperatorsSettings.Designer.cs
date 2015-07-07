namespace Code_parser
{
    partial class OperatorsSettings
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
            this.operators_grid = new System.Windows.Forms.DataGridView();
            this.saveOperatorsSettings_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.operators_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // operators_grid
            // 
            this.operators_grid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.operators_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operators_grid.Location = new System.Drawing.Point(12, 12);
            this.operators_grid.Name = "operators_grid";
            this.operators_grid.Size = new System.Drawing.Size(483, 315);
            this.operators_grid.TabIndex = 0;
            // 
            // saveOperatorsSettings_btn
            // 
            this.saveOperatorsSettings_btn.Location = new System.Drawing.Point(420, 333);
            this.saveOperatorsSettings_btn.Name = "saveOperatorsSettings_btn";
            this.saveOperatorsSettings_btn.Size = new System.Drawing.Size(75, 23);
            this.saveOperatorsSettings_btn.TabIndex = 1;
            this.saveOperatorsSettings_btn.Text = "Сохранить";
            this.saveOperatorsSettings_btn.UseVisualStyleBackColor = true;
            this.saveOperatorsSettings_btn.Click += new System.EventHandler(this.saveOperatorsSettings_btn_Click);
            // 
            // OperatorsSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 365);
            this.Controls.Add(this.saveOperatorsSettings_btn);
            this.Controls.Add(this.operators_grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OperatorsSettings";
            this.Text = "OperatorsSettings";
            ((System.ComponentModel.ISupportInitialize)(this.operators_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView operators_grid;
        private System.Windows.Forms.Button saveOperatorsSettings_btn;
    }
}