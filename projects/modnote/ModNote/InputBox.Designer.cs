namespace ModNote
{
    partial class InputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBox));
            this.btnInputOK = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnInputCancel = new System.Windows.Forms.Button();
            this.CbInput1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnInputOK
            // 
            this.btnInputOK.Location = new System.Drawing.Point(177, 57);
            this.btnInputOK.Name = "btnInputOK";
            this.btnInputOK.Size = new System.Drawing.Size(75, 23);
            this.btnInputOK.TabIndex = 0;
            this.btnInputOK.Text = "OK";
            this.btnInputOK.UseVisualStyleBackColor = true;
            this.btnInputOK.Click += new System.EventHandler(this.btnInputOK_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(13, 13);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(144, 13);
            this.lblInput.TabIndex = 2;
            this.lblInput.Text = "What module is this note for?";
            // 
            // btnInputCancel
            // 
            this.btnInputCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnInputCancel.Location = new System.Drawing.Point(12, 57);
            this.btnInputCancel.Name = "btnInputCancel";
            this.btnInputCancel.Size = new System.Drawing.Size(75, 23);
            this.btnInputCancel.TabIndex = 3;
            this.btnInputCancel.Text = "Cancel";
            this.btnInputCancel.UseVisualStyleBackColor = true;
            this.btnInputCancel.Click += new System.EventHandler(this.btnInputCancel_Click);
            // 
            // CbInput1
            // 
            this.CbInput1.FormattingEnabled = true;
            this.CbInput1.Location = new System.Drawing.Point(13, 30);
            this.CbInput1.Name = "CbInput1";
            this.CbInput1.Size = new System.Drawing.Size(144, 21);
            this.CbInput1.TabIndex = 4;
            // 
            // InputBox
            // 
            this.AcceptButton = this.btnInputOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnInputCancel;
            this.ClientSize = new System.Drawing.Size(264, 89);
            this.ControlBox = false;
            this.Controls.Add(this.CbInput1);
            this.Controls.Add(this.btnInputCancel);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnInputOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "InputBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Module Select";
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInputOK;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnInputCancel;
        private System.Windows.Forms.ComboBox CbInput1;
    }
}