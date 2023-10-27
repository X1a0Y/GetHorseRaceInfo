namespace GetRaceInfo
{
    partial class Form1
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
            button_start = new Button();
            comboBox_trackid = new ComboBox();
            dateTimePicker_start = new DateTimePicker();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label1 = new Label();
            dateTimePicker_end = new DateTimePicker();
            button_init = new Button();
            checkBox_sort = new CheckBox();
            button_select = new Button();
            button_open_browser = new Button();
            groupBox3 = new GroupBox();
            button_save_path = new Button();
            textBox_save_path = new TextBox();
            groupBox4 = new GroupBox();
            checkBox_pool = new CheckBox();
            groupBox5 = new GroupBox();
            textBox_delay = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // button_start
            // 
            button_start.Location = new Point(190, 227);
            button_start.Margin = new Padding(2, 2, 2, 2);
            button_start.Name = "button_start";
            button_start.Size = new Size(308, 79);
            button_start.TabIndex = 0;
            button_start.Text = "Start";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // comboBox_trackid
            // 
            comboBox_trackid.FormattingEnabled = true;
            comboBox_trackid.Location = new Point(4, 21);
            comboBox_trackid.Margin = new Padding(2, 2, 2, 2);
            comboBox_trackid.Name = "comboBox_trackid";
            comboBox_trackid.Size = new Size(185, 25);
            comboBox_trackid.TabIndex = 1;
            comboBox_trackid.SelectedIndexChanged += comboBox_trackid_SelectedIndexChanged;
            // 
            // dateTimePicker_start
            // 
            dateTimePicker_start.Location = new Point(11, 22);
            dateTimePicker_start.Margin = new Padding(2, 2, 2, 2);
            dateTimePicker_start.Name = "dateTimePicker_start";
            dateTimePicker_start.Size = new Size(129, 23);
            dateTimePicker_start.TabIndex = 2;
            dateTimePicker_start.Leave += dateTimePicker_start_Leave;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox_trackid);
            groupBox1.Location = new Point(8, 84);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(202, 64);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Track";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dateTimePicker_end);
            groupBox2.Controls.Add(dateTimePicker_start);
            groupBox2.Location = new Point(213, 84);
            groupBox2.Margin = new Padding(2, 2, 2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 2, 2, 2);
            groupBox2.Size = new Size(288, 64);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Time";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(143, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(13, 17);
            label1.TabIndex = 5;
            label1.Text = "-";
            // 
            // dateTimePicker_end
            // 
            dateTimePicker_end.Location = new Point(157, 22);
            dateTimePicker_end.Margin = new Padding(2, 2, 2, 2);
            dateTimePicker_end.Name = "dateTimePicker_end";
            dateTimePicker_end.Size = new Size(129, 23);
            dateTimePicker_end.TabIndex = 3;
            // 
            // button_init
            // 
            button_init.Location = new Point(119, 152);
            button_init.Margin = new Padding(2, 2, 2, 2);
            button_init.Name = "button_init";
            button_init.Size = new Size(108, 63);
            button_init.TabIndex = 6;
            button_init.Text = "Init";
            button_init.UseVisualStyleBackColor = true;
            button_init.Click += button_init_Click;
            // 
            // checkBox_sort
            // 
            checkBox_sort.AutoSize = true;
            checkBox_sort.Location = new Point(4, 24);
            checkBox_sort.Margin = new Padding(2, 2, 2, 2);
            checkBox_sort.Name = "checkBox_sort";
            checkBox_sort.Size = new Size(51, 21);
            checkBox_sort.TabIndex = 7;
            checkBox_sort.Text = "Sort";
            checkBox_sort.UseVisualStyleBackColor = true;
            // 
            // button_select
            // 
            button_select.Location = new Point(230, 152);
            button_select.Margin = new Padding(2, 2, 2, 2);
            button_select.Name = "button_select";
            button_select.Size = new Size(108, 63);
            button_select.TabIndex = 8;
            button_select.Text = "Local File";
            button_select.UseVisualStyleBackColor = true;
            button_select.Click += button_select_Click;
            // 
            // button_open_browser
            // 
            button_open_browser.Location = new Point(8, 152);
            button_open_browser.Margin = new Padding(2, 2, 2, 2);
            button_open_browser.Name = "button_open_browser";
            button_open_browser.Size = new Size(108, 63);
            button_open_browser.TabIndex = 9;
            button_open_browser.Text = "Open Browser";
            button_open_browser.UseVisualStyleBackColor = true;
            button_open_browser.Click += button_open_browser_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button_save_path);
            groupBox3.Controls.Add(textBox_save_path);
            groupBox3.Location = new Point(8, 8);
            groupBox3.Margin = new Padding(2, 2, 2, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(2, 2, 2, 2);
            groupBox3.Size = new Size(494, 72);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Save Path";
            // 
            // button_save_path
            // 
            button_save_path.Location = new Point(456, 29);
            button_save_path.Margin = new Padding(2, 2, 2, 2);
            button_save_path.Name = "button_save_path";
            button_save_path.Size = new Size(34, 24);
            button_save_path.TabIndex = 1;
            button_save_path.Text = "...";
            button_save_path.UseVisualStyleBackColor = true;
            button_save_path.Click += button_save_path_Click;
            // 
            // textBox_save_path
            // 
            textBox_save_path.Location = new Point(6, 30);
            textBox_save_path.Margin = new Padding(2, 2, 2, 2);
            textBox_save_path.Name = "textBox_save_path";
            textBox_save_path.Size = new Size(445, 23);
            textBox_save_path.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBox_pool);
            groupBox4.Controls.Add(checkBox_sort);
            groupBox4.Location = new Point(342, 152);
            groupBox4.Margin = new Padding(2, 2, 2, 2);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(2, 2, 2, 2);
            groupBox4.Size = new Size(156, 63);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Options";
            // 
            // checkBox_pool
            // 
            checkBox_pool.AutoSize = true;
            checkBox_pool.Checked = true;
            checkBox_pool.CheckState = CheckState.Checked;
            checkBox_pool.Location = new Point(90, 24);
            checkBox_pool.Margin = new Padding(2, 2, 2, 2);
            checkBox_pool.Name = "checkBox_pool";
            checkBox_pool.Size = new Size(53, 21);
            checkBox_pool.TabIndex = 8;
            checkBox_pool.Text = "Pool";
            checkBox_pool.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(textBox_delay);
            groupBox5.Location = new Point(8, 227);
            groupBox5.Margin = new Padding(2, 2, 2, 2);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(2, 2, 2, 2);
            groupBox5.Size = new Size(178, 79);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Delay Time";
            // 
            // textBox_delay
            // 
            textBox_delay.Location = new Point(31, 36);
            textBox_delay.Margin = new Padding(2, 2, 2, 2);
            textBox_delay.Name = "textBox_delay";
            textBox_delay.Size = new Size(97, 23);
            textBox_delay.TabIndex = 0;
            textBox_delay.Text = "1000";
            textBox_delay.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 322);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(button_open_browser);
            Controls.Add(button_select);
            Controls.Add(button_init);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button_start);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button_start;
        private ComboBox comboBox_trackid;
        private DateTimePicker dateTimePicker_start;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private DateTimePicker dateTimePicker_end;
        private Button button_init;
        private CheckBox checkBox_sort;
        private Button button_select;
        private Button button_open_browser;
        private GroupBox groupBox3;
        private Button button_save_path;
        private TextBox textBox_save_path;
        private GroupBox groupBox4;
        private CheckBox checkBox_pool;
        private GroupBox groupBox5;
        private TextBox textBox_delay;
    }
}