namespace ELEMS
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private PictureBox pictureBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(163, 23);
            label1.TabIndex = 0;
            label1.Text = "Welcome patrol team";
            // 
            // label2
            // 
            label2.Location = new Point(413, 86);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 1;
            label2.Text = "Pid";
            // 
            // label3
            // 
            label3.Location = new Point(413, 144);
            label3.Name = "label3";
            label3.Size = new Size(54, 23);
            label3.TabIndex = 2;
            label3.Text = "Log";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.Location = new Point(288, 236);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(650, 188);
            dataGridView1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(955, 261);
            button2.Name = "button2";
            button2.Size = new Size(75, 28);
            button2.TabIndex = 7;
            button2.Text = "Delete";
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(955, 360);
            button3.Name = "button3";
            button3.Size = new Size(75, 30);
            button3.TabIndex = 8;
            button3.Text = "Update";
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(965, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 31);
            button4.TabIndex = 9;
            button4.Text = "Log Out";
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(785, 86);
            button5.Name = "button5";
            button5.Size = new Size(75, 27);
            button5.TabIndex = 10;
            button5.Text = "Clear";
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(785, 144);
            button6.Name = "button6";
            button6.Size = new Size(75, 30);
            button6.TabIndex = 11;
            button6.Text = "Insert";
            button6.Click += button6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(491, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(228, 27);
            textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(491, 141);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(228, 27);
            textBox2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Screenshot_2026_01_19_180944;
            pictureBox2.Location = new Point(0, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(1285, 453);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // Form5
            // 
            ClientSize = new Size(1282, 450);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(pictureBox2);
            Name = "Form5";
            Text = "Patrol Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pictureBox2;
    }
}
