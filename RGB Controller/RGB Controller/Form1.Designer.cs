
namespace RGB_Controller
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button_up = new System.Windows.Forms.Button();
            this.label_level = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_down = new System.Windows.Forms.Button();
            this.label_red = new System.Windows.Forms.Label();
            this.label_green = new System.Windows.Forms.Label();
            this.label_blue = new System.Windows.Forms.Label();
            this.button_left = new System.Windows.Forms.Button();
            this.button_right = new System.Windows.Forms.Button();
            this.label_anim = new System.Windows.Forms.Label();
            this.button_minimize = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM4";
            // 
            // button_up
            // 
            this.button_up.BackColor = System.Drawing.Color.Transparent;
            this.button_up.BackgroundImage = global::RGB_Controller.Properties.Resources.arrow_up;
            this.button_up.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_up.FlatAppearance.BorderSize = 0;
            this.button_up.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_up.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_up.Location = new System.Drawing.Point(650, 122);
            this.button_up.Name = "button_up";
            this.button_up.Size = new System.Drawing.Size(47, 56);
            this.button_up.TabIndex = 3;
            this.button_up.UseVisualStyleBackColor = false;
            this.button_up.Click += new System.EventHandler(this.button_up_Click);
            // 
            // label_level
            // 
            this.label_level.BackColor = System.Drawing.Color.Transparent;
            this.label_level.Font = new System.Drawing.Font("Monotype Corsiva", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_level.ForeColor = System.Drawing.Color.White;
            this.label_level.Location = new System.Drawing.Point(641, 195);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(65, 41);
            this.label_level.TabIndex = 5;
            this.label_level.Text = "1";
            this.label_level.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::RGB_Controller.Properties.Resources.color_wheel;
            this.pictureBox1.Location = new System.Drawing.Point(94, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 135);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button_close
            // 
            this.button_close.BackColor = System.Drawing.Color.Transparent;
            this.button_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_close.FlatAppearance.BorderSize = 0;
            this.button_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_close.Location = new System.Drawing.Point(663, 0);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(72, 36);
            this.button_close.TabIndex = 10;
            this.button_close.UseVisualStyleBackColor = false;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_down
            // 
            this.button_down.BackColor = System.Drawing.Color.Transparent;
            this.button_down.BackgroundImage = global::RGB_Controller.Properties.Resources.arrow_down;
            this.button_down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_down.FlatAppearance.BorderSize = 0;
            this.button_down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_down.Location = new System.Drawing.Point(650, 253);
            this.button_down.Name = "button_down";
            this.button_down.Size = new System.Drawing.Size(47, 56);
            this.button_down.TabIndex = 11;
            this.button_down.UseVisualStyleBackColor = false;
            this.button_down.Click += new System.EventHandler(this.button_down_Click);
            // 
            // label_red
            // 
            this.label_red.BackColor = System.Drawing.Color.Transparent;
            this.label_red.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_red.ForeColor = System.Drawing.Color.White;
            this.label_red.Location = new System.Drawing.Point(332, 167);
            this.label_red.Name = "label_red";
            this.label_red.Size = new System.Drawing.Size(65, 26);
            this.label_red.TabIndex = 12;
            this.label_red.Text = "---";
            this.label_red.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_green
            // 
            this.label_green.BackColor = System.Drawing.Color.Transparent;
            this.label_green.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_green.ForeColor = System.Drawing.Color.White;
            this.label_green.Location = new System.Drawing.Point(332, 214);
            this.label_green.Name = "label_green";
            this.label_green.Size = new System.Drawing.Size(65, 26);
            this.label_green.TabIndex = 13;
            this.label_green.Text = "---";
            this.label_green.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_blue
            // 
            this.label_blue.BackColor = System.Drawing.Color.Transparent;
            this.label_blue.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_blue.ForeColor = System.Drawing.Color.White;
            this.label_blue.Location = new System.Drawing.Point(332, 259);
            this.label_blue.Name = "label_blue";
            this.label_blue.Size = new System.Drawing.Size(65, 26);
            this.label_blue.TabIndex = 14;
            this.label_blue.Text = "---";
            this.label_blue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_left
            // 
            this.button_left.BackColor = System.Drawing.Color.Transparent;
            this.button_left.BackgroundImage = global::RGB_Controller.Properties.Resources.arrow_left;
            this.button_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_left.FlatAppearance.BorderSize = 0;
            this.button_left.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_left.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_left.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_left.Location = new System.Drawing.Point(449, 259);
            this.button_left.Name = "button_left";
            this.button_left.Size = new System.Drawing.Size(47, 56);
            this.button_left.TabIndex = 15;
            this.button_left.UseVisualStyleBackColor = false;
            this.button_left.Click += new System.EventHandler(this.button_left_Click);
            // 
            // button_right
            // 
            this.button_right.BackColor = System.Drawing.Color.Transparent;
            this.button_right.BackgroundImage = global::RGB_Controller.Properties.Resources.arrow_right;
            this.button_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_right.FlatAppearance.BorderSize = 0;
            this.button_right.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_right.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_right.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_right.Location = new System.Drawing.Point(546, 259);
            this.button_right.Name = "button_right";
            this.button_right.Size = new System.Drawing.Size(47, 56);
            this.button_right.TabIndex = 16;
            this.button_right.UseVisualStyleBackColor = false;
            this.button_right.Click += new System.EventHandler(this.button_right_Click);
            // 
            // label_anim
            // 
            this.label_anim.BackColor = System.Drawing.Color.Transparent;
            this.label_anim.Font = new System.Drawing.Font("Monotype Corsiva", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_anim.ForeColor = System.Drawing.Color.White;
            this.label_anim.Location = new System.Drawing.Point(449, 203);
            this.label_anim.Name = "label_anim";
            this.label_anim.Size = new System.Drawing.Size(144, 41);
            this.label_anim.TabIndex = 17;
            this.label_anim.Text = "Rainbow";
            this.label_anim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_anim.Click += new System.EventHandler(this.label_anim_Click);
            // 
            // button_minimize
            // 
            this.button_minimize.BackColor = System.Drawing.Color.Transparent;
            this.button_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_minimize.FlatAppearance.BorderSize = 0;
            this.button_minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_minimize.Location = new System.Drawing.Point(690, 383);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(46, 47);
            this.button_minimize.TabIndex = 18;
            this.button_minimize.UseVisualStyleBackColor = false;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RGB Controller";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(736, 431);
            this.Controls.Add(this.button_minimize);
            this.Controls.Add(this.label_anim);
            this.Controls.Add(this.button_right);
            this.Controls.Add(this.button_left);
            this.Controls.Add(this.label_blue);
            this.Controls.Add(this.label_green);
            this.Controls.Add(this.label_red);
            this.Controls.Add(this.button_down);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_level);
            this.Controls.Add(this.button_up);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RGB Controller";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button_up;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_down;
        private System.Windows.Forms.Label label_red;
        private System.Windows.Forms.Label label_green;
        private System.Windows.Forms.Label label_blue;
        private System.Windows.Forms.Button button_left;
        private System.Windows.Forms.Button button_right;
        private System.Windows.Forms.Label label_anim;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

