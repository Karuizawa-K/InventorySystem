namespace InventorySystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label1 = new Label();
            BtnCle = new Button();
            TxtPas = new TextBox();
            BtnLog = new Button();
            label2 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            TxtUse = new TextBox();
            pictureBox2 = new PictureBox();
            ChkPass = new CheckBox();
            label5 = new Label();
            LblExt = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(397, 239);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 4;
            label1.Text = "Username";
            // 
            // BtnCle
            // 
            BtnCle.Cursor = Cursors.Hand;
            BtnCle.FlatAppearance.BorderSize = 0;
            BtnCle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnCle.Location = new Point(397, 460);
            BtnCle.Name = "BtnCle";
            BtnCle.Size = new Size(362, 47);
            BtnCle.TabIndex = 3;
            BtnCle.Text = "Clear";
            BtnCle.UseVisualStyleBackColor = true;
            BtnCle.Click += BtnCle_Click;
            // 
            // TxtPas
            // 
            TxtPas.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtPas.Location = new Point(397, 332);
            TxtPas.Name = "TxtPas";
            TxtPas.Size = new Size(362, 38);
            TxtPas.TabIndex = 1;
            TxtPas.UseSystemPasswordChar = true;
            TxtPas.TextChanged += TxtPas_TextChanged;
            // 
            // BtnLog
            // 
            BtnLog.BackColor = Color.MidnightBlue;
            BtnLog.Cursor = Cursors.Hand;
            BtnLog.FlatAppearance.BorderSize = 0;
            BtnLog.FlatStyle = FlatStyle.Flat;
            BtnLog.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnLog.ForeColor = Color.White;
            BtnLog.Location = new Point(397, 408);
            BtnLog.Name = "BtnLog";
            BtnLog.Size = new Size(362, 46);
            BtnLog.TabIndex = 2;
            BtnLog.Text = "Login";
            BtnLog.UseVisualStyleBackColor = false;
            BtnLog.Click += BtnLog_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(397, 304);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(354, 99);
            label3.Name = "label3";
            label3.Size = new Size(466, 82);
            label3.TabIndex = 7;
            label3.Text = "WELCOME BACK!";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(727, 337);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(24, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // TxtUse
            // 
            TxtUse.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtUse.Location = new Point(397, 267);
            TxtUse.Name = "TxtUse";
            TxtUse.Size = new Size(362, 38);
            TxtUse.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Window;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(726, 271);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 26);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // ChkPass
            // 
            ChkPass.AutoSize = true;
            ChkPass.Cursor = Cursors.Hand;
            ChkPass.Location = new Point(629, 378);
            ChkPass.Name = "ChkPass";
            ChkPass.Size = new Size(130, 24);
            ChkPass.TabIndex = 13;
            ChkPass.Text = "Showpassword";
            ChkPass.UseVisualStyleBackColor = true;
            ChkPass.CheckedChanged += ChkPass_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe Print", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(379, 170);
            label5.Name = "label5";
            label5.Size = new Size(420, 40);
            label5.TabIndex = 14;
            label5.Text = "Organize Today. Profit Tomorrow.";
            // 
            // LblExt
            // 
            LblExt.AutoSize = true;
            LblExt.Cursor = Cursors.Hand;
            LblExt.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblExt.ForeColor = Color.Red;
            LblExt.Location = new Point(1081, 603);
            LblExt.Name = "LblExt";
            LblExt.Size = new Size(61, 31);
            LblExt.TabIndex = 15;
            LblExt.Text = "EXIT";
            LblExt.TextAlign = ContentAlignment.MiddleCenter;
            LblExt.Click += LblExt_Click;
            LblExt.MouseEnter += LblExt_MouseEnter;
            LblExt.MouseLeave += LblExt_MouseLeave;
            LblExt.MouseHover += LblExt_MouseHover;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(995, 611);
            label4.Name = "label4";
            label4.Size = new Size(80, 22);
            label4.TabIndex = 16;
            label4.Text = "About us";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1154, 643);
            Controls.Add(label4);
            Controls.Add(LblExt);
            Controls.Add(label5);
            Controls.Add(ChkPass);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(TxtUse);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(TxtPas);
            Controls.Add(BtnCle);
            Controls.Add(BtnLog);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button BtnCle;
        private TextBox TxtPas;
        private Button BtnLog;
        private Label label2;
        private Label label3;
        private PictureBox pictureBox1;
        private TextBox TxtUse;
        private PictureBox pictureBox2;
        private CheckBox ChkPass;
        private Label label5;
        private Label LblExt;
        private Label label4;
    }
}
