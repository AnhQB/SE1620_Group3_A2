
namespace SE1620_Group3_A2.GUI
{
    partial class ShowGUI
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
            this.btnAddNew = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbNumberShows = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.cbRoom = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateChoose = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(99, 201);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(149, 31);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add a new ...";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 289);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(887, 295);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // lbNumberShows
            // 
            this.lbNumberShows.AutoSize = true;
            this.lbNumberShows.Location = new System.Drawing.Point(34, 265);
            this.lbNumberShows.Name = "lbNumberShows";
            this.lbNumberShows.Size = new System.Drawing.Size(50, 20);
            this.lbNumberShows.TabIndex = 2;
            this.lbNumberShows.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Film";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Room";
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(110, 44);
            this.cbFilm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(203, 28);
            this.cbFilm.TabIndex = 6;
            // 
            // cbRoom
            // 
            this.cbRoom.FormattingEnabled = true;
            this.cbRoom.Location = new System.Drawing.Point(110, 132);
            this.cbRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbRoom.Name = "cbRoom";
            this.cbRoom.Size = new System.Drawing.Size(203, 28);
            this.cbRoom.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(360, 131);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateChoose
            // 
            this.dateChoose.CustomFormat = "dd/MM/yyyy";
            this.dateChoose.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChoose.Location = new System.Drawing.Point(110, 92);
            this.dateChoose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateChoose.Name = "dateChoose";
            this.dateChoose.Size = new System.Drawing.Size(203, 27);
            this.dateChoose.TabIndex = 10;
            // 
            // ShowGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.dateChoose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbRoom);
            this.Controls.Add(this.cbFilm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNumberShows);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddNew);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ShowGUI";
            this.Text = "ShowGUI";
            this.Load += new System.EventHandler(this.ShowGUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbNumberShows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.ComboBox cbRoom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateChoose;
    }
}