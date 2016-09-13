namespace webServerConcurrentTest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Test = new System.Windows.Forms.Button();
            this.txt_URL = new System.Windows.Forms.TextBox();
            this.txt_Parms = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_UnitNum = new System.Windows.Forms.TextBox();
            this.txt_ThreadNum = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Result = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(503, 178);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(75, 23);
            this.btn_Test.TabIndex = 0;
            this.btn_Test.Text = "测试";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // txt_URL
            // 
            this.txt_URL.Location = new System.Drawing.Point(12, 2);
            this.txt_URL.Name = "txt_URL";
            this.txt_URL.Size = new System.Drawing.Size(566, 21);
            this.txt_URL.TabIndex = 1;
            // 
            // txt_Parms
            // 
            this.txt_Parms.Location = new System.Drawing.Point(12, 29);
            this.txt_Parms.Multiline = true;
            this.txt_Parms.Name = "txt_Parms";
            this.txt_Parms.Size = new System.Drawing.Size(566, 143);
            this.txt_Parms.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_UnitNum);
            this.panel1.Controls.Add(this.txt_ThreadNum);
            this.panel1.Controls.Add(this.txt_Parms);
            this.panel1.Controls.Add(this.btn_Test);
            this.panel1.Controls.Add(this.txt_URL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 215);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "单线程循环次数";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "线程数";
            // 
            // txt_UnitNum
            // 
            this.txt_UnitNum.Location = new System.Drawing.Point(266, 178);
            this.txt_UnitNum.Name = "txt_UnitNum";
            this.txt_UnitNum.Size = new System.Drawing.Size(36, 21);
            this.txt_UnitNum.TabIndex = 2;
            this.txt_UnitNum.Text = "20";
            // 
            // txt_ThreadNum
            // 
            this.txt_ThreadNum.Location = new System.Drawing.Point(59, 178);
            this.txt_ThreadNum.Name = "txt_ThreadNum";
            this.txt_ThreadNum.Size = new System.Drawing.Size(51, 21);
            this.txt_ThreadNum.TabIndex = 2;
            this.txt_ThreadNum.Text = "100";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_Result);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 215);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 331);
            this.panel2.TabIndex = 3;
            // 
            // txt_Result
            // 
            this.txt_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Result.Location = new System.Drawing.Point(0, 0);
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txt_Result.Size = new System.Drawing.Size(608, 331);
            this.txt_Result.TabIndex = 2;
            this.txt_Result.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 546);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "服务器压力测试";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.TextBox txt_URL;
        private System.Windows.Forms.TextBox txt_Parms;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox txt_Result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_UnitNum;
        private System.Windows.Forms.TextBox txt_ThreadNum;
    }
}

