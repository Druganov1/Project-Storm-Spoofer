namespace Storm_Spoofer_demo
{
    partial class EnterKey
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
            this.txt_EnteredKey = new System.Windows.Forms.TextBox();
            this.btn_ActivateKey = new System.Windows.Forms.Button();
            this.lbl_EnterKeyHere = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_EnteredKey
            // 
            this.txt_EnteredKey.Location = new System.Drawing.Point(12, 40);
            this.txt_EnteredKey.Name = "txt_EnteredKey";
            this.txt_EnteredKey.Size = new System.Drawing.Size(311, 23);
            this.txt_EnteredKey.TabIndex = 0;
            // 
            // btn_ActivateKey
            // 
            this.btn_ActivateKey.Location = new System.Drawing.Point(126, 81);
            this.btn_ActivateKey.Name = "btn_ActivateKey";
            this.btn_ActivateKey.Size = new System.Drawing.Size(75, 23);
            this.btn_ActivateKey.TabIndex = 1;
            this.btn_ActivateKey.Text = "Activate";
            this.btn_ActivateKey.UseVisualStyleBackColor = true;
            this.btn_ActivateKey.Click += new System.EventHandler(this.btn_ActivateKey_Click);
            // 
            // lbl_EnterKeyHere
            // 
            this.lbl_EnterKeyHere.AutoSize = true;
            this.lbl_EnterKeyHere.Location = new System.Drawing.Point(113, 9);
            this.lbl_EnterKeyHere.Name = "lbl_EnterKeyHere";
            this.lbl_EnterKeyHere.Size = new System.Drawing.Size(108, 15);
            this.lbl_EnterKeyHere.TabIndex = 2;
            this.lbl_EnterKeyHere.Text = "Enter your key here";
            // 
            // EnterKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 116);
            this.Controls.Add(this.lbl_EnterKeyHere);
            this.Controls.Add(this.btn_ActivateKey);
            this.Controls.Add(this.txt_EnteredKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnterKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterKey";
            this.Load += new System.EventHandler(this.EnterKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txt_EnteredKey;
        private Button btn_ActivateKey;
        private Label lbl_EnterKeyHere;
    }
}