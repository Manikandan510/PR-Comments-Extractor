using System.Windows.Forms;

namespace PR_Comments_Extractor
{
    partial class PRAnalyzer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            button2 = new Button();
            label4 = new Label();
            textBox2 = new TextBox();
            label5 = new Label();
            dataGridView1 = new DataGridView();
            label6 = new Label();
            button3 = new Button();
            label7 = new Label();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            textBox5 = new TextBox();
            button4 = new Button();
            button5 = new Button();
            progressBar1 = new ProgressBar();
            button1 = new Button();
            comboBox3 = new ComboBox();
            label1 = new Label();
            button6 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(255, 23);
            label2.Name = "label2";
            label2.Size = new Size(68, 22);
            label2.TabIndex = 3;
            label2.Text = "Project :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(600, 21);
            label3.Name = "label3";
            label3.Size = new Size(95, 22);
            label3.TabIndex = 4;
            label3.Text = "Repository :";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(329, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(247, 30);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(701, 18);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(270, 30);
            comboBox2.TabIndex = 6;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(946, 69);
            button2.Name = "button2";
            button2.Size = new Size(194, 30);
            button2.TabIndex = 7;
            button2.Text = "Get PRs by Repository";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(0, 64, 0);
            label4.Location = new Point(272, 213);
            label4.Name = "label4";
            label4.Size = new Size(0, 19);
            label4.TabIndex = 8;
            label4.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(255, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(247, 27);
            textBox2.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(147, 76);
            label5.Name = "label5";
            label5.Size = new Size(105, 22);
            label5.TabIndex = 10;
            label5.Text = "Associate ID :";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = SystemColors.AppWorkspace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 249);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1153, 601);
            dataGridView1.TabIndex = 11;
            dataGridView1.Visible = false;
            dataGridView1.DataBindingComplete += DataGridView1_DataBindingComplete;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(203, 162);
            label6.Name = "label6";
            label6.Size = new Size(98, 19);
            label6.TabIndex = 12;
            label6.Text = "Status: Idle";
            // 
            // button3
            // 
            button3.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(23, 201);
            button3.Name = "button3";
            button3.Size = new Size(197, 42);
            button3.TabIndex = 13;
            button3.Text = "Export report to Excel";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += button3_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(141, 112);
            label7.Name = "label7";
            label7.Size = new Size(111, 22);
            label7.TabIndex = 14;
            label7.Text = "Branch Name :";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(255, 110);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(247, 27);
            textBox3.TabIndex = 15;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(585, 73);
            dateTimePicker1.MaxDate = new DateTime(2023, 9, 14, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(128, 27);
            dateTimePicker1.TabIndex = 16;
            dateTimePicker1.Value = new DateTime(2023, 6, 14, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(753, 73);
            dateTimePicker2.MaxDate = new DateTime(2023, 9, 14, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(128, 27);
            dateTimePicker2.TabIndex = 17;
            dateTimePicker2.Value = new DateTime(2023, 9, 14, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.BackColor = Color.Black;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(-1, 184);
            label8.Name = "label8";
            label8.Size = new Size(1160, 2);
            label8.TabIndex = 18;
            // 
            // label9
            // 
            label9.BackColor = Color.Black;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Location = new Point(1155, -3);
            label9.Name = "label9";
            label9.Size = new Size(2, 190);
            label9.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 10.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label10.ForeColor = Color.SaddleBrown;
            label10.Location = new Point(17, 76);
            label10.Name = "label10";
            label10.Size = new Size(124, 19);
            label10.TabIndex = 20;
            label10.Text = "Optional filters";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(533, 76);
            label11.Name = "label11";
            label11.Size = new Size(55, 22);
            label11.TabIndex = 21;
            label11.Text = "From :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label12.Location = new Point(719, 77);
            label12.Name = "label12";
            label12.Size = new Size(37, 22);
            label12.TabIndex = 22;
            label12.Text = "To :";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(753, 216);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Commented By";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 25;
            textBox5.Visible = false;
            // 
            // button4
            // 
            button4.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(906, 216);
            button4.Name = "button4";
            button4.Size = new Size(105, 29);
            button4.TabIndex = 26;
            button4.Text = "Filter";
            button4.UseVisualStyleBackColor = true;
            button4.Visible = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(1034, 214);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 27;
            button5.Text = "Clear";
            button5.UseVisualStyleBackColor = true;
            button5.Visible = false;
            button5.Click += button5_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(16, 162);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(160, 19);
            progressBar1.TabIndex = 28;
            // 
            // button1
            // 
            button1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(946, 105);
            button1.Name = "button1";
            button1.Size = new Size(194, 29);
            button1.TabIndex = 29;
            button1.Text = "Get PRs by Project";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox3
            // 
            comboBox3.AutoCompleteMode = AutoCompleteMode.Append;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox3.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(634, 109);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(247, 30);
            comboBox3.TabIndex = 30;
            comboBox3.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(530, 115);
            label1.Name = "label1";
            label1.Size = new Size(98, 22);
            label1.TabIndex = 31;
            label1.Text = "Team Name :";
            label1.Visible = false;
            // 
            // button6
            // 
            button6.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(946, 140);
            button6.Name = "button6";
            button6.Size = new Size(194, 29);
            button6.TabIndex = 32;
            button6.Text = "Get Recent PRs of Team";
            button6.UseVisualStyleBackColor = true;
            button6.Visible = false;
            button6.Click += button6_Click;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(23, 12);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(154, 26);
            radioButton1.TabIndex = 33;
            radioButton1.TabStop = true;
            radioButton1.Text = "Associates report";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(23, 42);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(115, 26);
            radioButton2.TabIndex = 34;
            radioButton2.TabStop = true;
            radioButton2.Text = "Team report";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // PRAnalyzer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1171, 862);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button6);
            Controls.Add(label1);
            Controls.Add(comboBox3);
            Controls.Add(button1);
            Controls.Add(progressBar1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox5);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(dataGridView1);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "PRAnalyzer";
            Text = "Pull Request Report Generator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Button button2;
        private Label label4;
        private TextBox textBox2;
        private Label label5;
        private DataGridView dataGridView1;
        private Label label6;
        private Button button3;
        private Label label7;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Button button4;
        private TextBox textBox5;
        private Button button5;
        private ProgressBar progressBar1;
        private Button button1;
        private ComboBox comboBox3;
        private Label label1;
        private Button button6;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}