namespace CMHKAssignment3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btPanel = new System.Windows.Forms.Panel();
            this.GenerateBt = new System.Windows.Forms.Button();
            this.LoadBt = new System.Windows.Forms.Button();
            this.SaveBt = new System.Windows.Forms.Button();
            this.RowsTxt = new System.Windows.Forms.TextBox();
            this.ColumnsTxt = new System.Windows.Forms.TextBox();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(158, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rows :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(119, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columns : ";
            // 
            // btPanel
            // 
            this.btPanel.BackColor = System.Drawing.Color.Transparent;
            this.btPanel.Location = new System.Drawing.Point(108, 163);
            this.btPanel.Name = "btPanel";
            this.btPanel.Size = new System.Drawing.Size(450, 450);
            this.btPanel.TabIndex = 2;
            // 
            // GenerateBt
            // 
            this.GenerateBt.BackColor = System.Drawing.SystemColors.Control;
            this.GenerateBt.Location = new System.Drawing.Point(464, 34);
            this.GenerateBt.Name = "GenerateBt";
            this.GenerateBt.Size = new System.Drawing.Size(167, 23);
            this.GenerateBt.TabIndex = 3;
            this.GenerateBt.Text = "Generate";
            this.GenerateBt.UseVisualStyleBackColor = false;
            this.GenerateBt.Click += new System.EventHandler(this.GenerateBt_Click);
            // 
            // LoadBt
            // 
            this.LoadBt.Location = new System.Drawing.Point(464, 92);
            this.LoadBt.Name = "LoadBt";
            this.LoadBt.Size = new System.Drawing.Size(167, 23);
            this.LoadBt.TabIndex = 1;
            this.LoadBt.Text = "Load";
            this.LoadBt.UseVisualStyleBackColor = true;
            this.LoadBt.Click += new System.EventHandler(this.LoadBt_Click);
            // 
            // SaveBt
            // 
            this.SaveBt.Location = new System.Drawing.Point(464, 63);
            this.SaveBt.Name = "SaveBt";
            this.SaveBt.Size = new System.Drawing.Size(167, 23);
            this.SaveBt.TabIndex = 2;
            this.SaveBt.Text = "Save";
            this.SaveBt.UseVisualStyleBackColor = true;
            this.SaveBt.Click += new System.EventHandler(this.SaveBt_Click);
            // 
            // RowsTxt
            // 
            this.RowsTxt.Location = new System.Drawing.Point(240, 50);
            this.RowsTxt.Name = "RowsTxt";
            this.RowsTxt.Size = new System.Drawing.Size(180, 21);
            this.RowsTxt.TabIndex = 0;
            // 
            // ColumnsTxt
            // 
            this.ColumnsTxt.Location = new System.Drawing.Point(240, 79);
            this.ColumnsTxt.Name = "ColumnsTxt";
            this.ColumnsTxt.Size = new System.Drawing.Size(180, 21);
            this.ColumnsTxt.TabIndex = 4;
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "txt";
            this.dlgSave.FileName = "Puzzle";
            this.dlgSave.InitialDirectory = "C:\\";
            // 
            // dlgOpen
            // 
            this.dlgOpen.FileName = "Puzzle";
            this.dlgOpen.InitialDirectory = "C:\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(669, 663);
            this.Controls.Add(this.ColumnsTxt);
            this.Controls.Add(this.RowsTxt);
            this.Controls.Add(this.GenerateBt);
            this.Controls.Add(this.LoadBt);
            this.Controls.Add(this.SaveBt);
            this.Controls.Add(this.btPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "n-Puzzle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel btPanel;
        private System.Windows.Forms.Button GenerateBt;
        private System.Windows.Forms.Button LoadBt;
        private System.Windows.Forms.Button SaveBt;
        private System.Windows.Forms.TextBox RowsTxt;
        private System.Windows.Forms.TextBox ColumnsTxt;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
    }
}

