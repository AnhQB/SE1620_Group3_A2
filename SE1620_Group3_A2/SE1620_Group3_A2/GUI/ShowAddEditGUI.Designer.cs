
namespace SE1620_Group3_A2.GUI
{
    partial class ShowAddEditGUI
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
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.cbSlot = new System.Windows.Forms.ComboBox();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dateChoose = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbRoom
            // 
            this.cbRoom.Enabled = false;
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(159, 68);
            this.cbRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(182, 28);
            this.cbRoom.TabIndex = 0;
            // 
            // cbSlot
            // 
            this.cbSlot.FormattingEnabled = true;
            this.cbSlot.Location = new System.Drawing.Point(159, 185);
            this.cbSlot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSlot.Name = "cbSlot";
            this.cbSlot.Size = new System.Drawing.Size(182, 28);
            this.cbSlot.TabIndex = 1;
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(159, 241);
            this.cbFilm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(182, 28);
            this.cbFilm.TabIndex = 2;
            this.cbFilm.SelectedIndexChanged += new System.EventHandler(this.cbFilm_SelectedIndexChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(159, 300);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(182, 27);
            this.txtPrice.TabIndex = 3;
            // 
            // dateChoose
            // 
            this.dateChoose.CustomFormat = "dd/MM/yyyy";
            this.dateChoose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChoose.Location = new System.Drawing.Point(159, 123);
            this.dateChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateChoose.Name = "dateChoose";
            this.dateChoose.Size = new System.Drawing.Size(182, 27);
            this.dateChoose.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(94, 396);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 31);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(306, 396);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 31);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Room:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 131);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Slot:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Film:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Price:";
            // 
            // ShowAddEditGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 480);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dateChoose);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.cbFilm);
            this.Controls.Add(this.cbSlot);
            this.Controls.Add(this.cbRoom);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowAddEditGUI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.Text = "ShowAddEditGUI";
            this.Load += new System.EventHandler(this.ShowAddEditGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.ComboBox cbSlot;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dateChoose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}