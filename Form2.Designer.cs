namespace Storm_Spoofer_demo
{
    partial class frm_FiveMPathMissing
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
            this.txt_InputFivemPath = new System.Windows.Forms.TextBox();
            this.btn_FivemPathOK = new System.Windows.Forms.Button();
            this.btn_FivemPathCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(109, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter your FiveM path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_InputFivemPath
            // 
            this.txt_InputFivemPath.Location = new System.Drawing.Point(22, 83);
            this.txt_InputFivemPath.Name = "txt_InputFivemPath";
            this.txt_InputFivemPath.Size = new System.Drawing.Size(333, 23);
            this.txt_InputFivemPath.TabIndex = 1;
            this.txt_InputFivemPath.TextChanged += new System.EventHandler(this.txt_InputFivemPath_TextChanged);
            // 
            // btn_FivemPathOK
            // 
            this.btn_FivemPathOK.FlatAppearance.BorderSize = 0;
            this.btn_FivemPathOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FivemPathOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_FivemPathOK.ForeColor = System.Drawing.Color.White;
            this.btn_FivemPathOK.Location = new System.Drawing.Point(100, 121);
            this.btn_FivemPathOK.Name = "btn_FivemPathOK";
            this.btn_FivemPathOK.Size = new System.Drawing.Size(75, 23);
            this.btn_FivemPathOK.TabIndex = 2;
            this.btn_FivemPathOK.Text = "OK";
            this.btn_FivemPathOK.UseVisualStyleBackColor = true;
            this.btn_FivemPathOK.Click += new System.EventHandler(this.btn_FivemPathOK_Click);
            // 
            // btn_FivemPathCancel
            // 
            this.btn_FivemPathCancel.FlatAppearance.BorderSize = 0;
            this.btn_FivemPathCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FivemPathCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_FivemPathCancel.ForeColor = System.Drawing.Color.White;
            this.btn_FivemPathCancel.Location = new System.Drawing.Point(191, 121);
            this.btn_FivemPathCancel.Name = "btn_FivemPathCancel";
            this.btn_FivemPathCancel.Size = new System.Drawing.Size(75, 23);
            this.btn_FivemPathCancel.TabIndex = 3;
            this.btn_FivemPathCancel.Text = "Cancel";
            this.btn_FivemPathCancel.UseVisualStyleBackColor = true;
            this.btn_FivemPathCancel.Click += new System.EventHandler(this.btn_FivemPathCancel_Click);
            // 
            // frm_FiveMPathMissing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(379, 163);
            this.Controls.Add(this.btn_FivemPathCancel);
            this.Controls.Add(this.btn_FivemPathOK);
            this.Controls.Add(this.txt_InputFivemPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_FiveMPathMissing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.frm_FiveMPathMissing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txt_InputFivemPath;
        private Button btn_FivemPathOK;
        private Button btn_FivemPathCancel;
    }
}