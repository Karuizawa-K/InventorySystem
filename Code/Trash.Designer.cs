namespace InventorySystem
{
    partial class Trash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trash));
            DgvTrash = new DataGridView();
            BtnRes = new Button();
            BtnDelPerma = new Button();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvTrash).BeginInit();
            SuspendLayout();
            // 
            // DgvTrash
            // 
            DgvTrash.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvTrash.Location = new Point(12, 12);
            DgvTrash.Name = "DgvTrash";
            DgvTrash.RowHeadersWidth = 51;
            DgvTrash.Size = new Size(718, 426);
            DgvTrash.TabIndex = 0;
            // 
            // BtnRes
            // 
            BtnRes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnRes.Image = Properties.Resources.recycle_symbol;
            BtnRes.Location = new Point(561, 444);
            BtnRes.Name = "BtnRes";
            BtnRes.Size = new Size(169, 44);
            BtnRes.TabIndex = 1;
            BtnRes.UseVisualStyleBackColor = true;
            BtnRes.Click += BtnRes_Click;
            BtnRes.MouseEnter += BtnRes_MouseEnter;
            BtnRes.MouseLeave += BtnRes_MouseLeave;
            // 
            // BtnDelPerma
            // 
            BtnDelPerma.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDelPerma.Image = Properties.Resources.delete;
            BtnDelPerma.Location = new Point(386, 444);
            BtnDelPerma.Name = "BtnDelPerma";
            BtnDelPerma.Size = new Size(169, 44);
            BtnDelPerma.TabIndex = 2;
            BtnDelPerma.UseVisualStyleBackColor = true;
            BtnDelPerma.Click += BtnDelPerma_Click;
            BtnDelPerma.MouseEnter += BtnDelPerma_MouseEnter;
            BtnDelPerma.MouseLeave += BtnDelPerma_MouseLeave;
            // 
            // BtnBack
            // 
            BtnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnBack.Image = Properties.Resources.back;
            BtnBack.Location = new Point(12, 444);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(169, 44);
            BtnBack.TabIndex = 3;
            BtnBack.UseVisualStyleBackColor = true;
            BtnBack.Click += BtnBack_Click;
            BtnBack.MouseEnter += BtnBack_MouseEnter;
            BtnBack.MouseLeave += BtnBack_MouseLeave;
            // 
            // Trash
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 495);
            Controls.Add(BtnBack);
            Controls.Add(BtnDelPerma);
            Controls.Add(BtnRes);
            Controls.Add(DgvTrash);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Trash";
            Text = " Deleted Records";
            Load += Trash_Load;
            ((System.ComponentModel.ISupportInitialize)DgvTrash).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvTrash;
        private Button BtnRes;
        private Button BtnDelPerma;
        private Button BtnBack;
    }
}