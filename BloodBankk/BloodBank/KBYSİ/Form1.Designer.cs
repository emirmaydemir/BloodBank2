
namespace KBYSİ
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
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBar = new CircularProgressBar.CircularProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(140, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "KAN BANKASI YÖNETİM SİSTEMİ";
            // 
            // ProgressBar
            // 
            this.ProgressBar.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("ProgressBar.AnimationFunction")));
            this.ProgressBar.AnimationSpeed = 500;
            this.ProgressBar.BackColor = System.Drawing.Color.Snow;
            this.ProgressBar.Font = new System.Drawing.Font("Myanmar Text", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgressBar.ForeColor = System.Drawing.Color.Red;
            this.ProgressBar.InnerColor = System.Drawing.Color.Transparent;
            this.ProgressBar.InnerMargin = 2;
            this.ProgressBar.InnerWidth = -1;
            this.ProgressBar.Location = new System.Drawing.Point(217, 86);
            this.ProgressBar.MarqueeAnimationSpeed = 2000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.OuterColor = System.Drawing.Color.Black;
            this.ProgressBar.OuterMargin = -25;
            this.ProgressBar.OuterWidth = 26;
            this.ProgressBar.ProgressColor = System.Drawing.Color.Red;
            this.ProgressBar.ProgressWidth = 10;
            this.ProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.ProgressBar.Size = new System.Drawing.Size(169, 172);
            this.ProgressBar.StartAngle = 270;
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.ProgressBar.SubscriptText = ".23";
            this.ProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.ProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.ProgressBar.SuperscriptText = "°C";
            this.ProgressBar.TabIndex = 1;
            this.ProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.ProgressBar.Value = 68;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(250, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(244, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yükleniyor...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 336);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CircularProgressBar.CircularProgressBar ProgressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

