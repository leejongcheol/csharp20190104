namespace ChatServer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>

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
    this.cmd_Start = new System.Windows.Forms.Button();
    this.lbl_Message = new System.Windows.Forms.Label();
    this.txt_Chat = new System.Windows.Forms.TextBox();
    this.SuspendLayout();
    //
    // cmd_Start
    //
    this.cmd_Start.Location = new System.Drawing.Point(29, 12);
    this.cmd_Start.Name = "cmd_Start";
    this.cmd_Start.Size = new System.Drawing.Size(139, 54);
    this.cmd_Start.TabIndex = 0;
    this.cmd_Start.Text = "Server Start";
    this.cmd_Start.UseVisualStyleBackColor = true;
    this.cmd_Start.Click += new
   System.EventHandler(this.cmd_Start_Click);
    //
    // lbl_Message
    //
    this.lbl_Message.AutoSize = true;
    this.lbl_Message.Font = new System.Drawing.Font("Gulim", 12F,
    System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
   ((byte)(129)));
    this.lbl_Message.Location = new System.Drawing.Point(174, 29);
    this.lbl_Message.Name = "lbl_Message";
    this.lbl_Message.Size = new System.Drawing.Size(186, 16);
    this.lbl_Message.TabIndex = 1;
    this.lbl_Message.Tag = "Stop";
    this.lbl_Message.Text = "Server 중지 상태 입니다.";
    //
    // txt_Chat
    //
    this.txt_Chat.Location = new System.Drawing.Point(29, 81);
    this.txt_Chat.Multiline = true;
    this.txt_Chat.Name = "txt_Chat";
    this.txt_Chat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
    this.txt_Chat.Size = new System.Drawing.Size(352, 175);
    this.txt_Chat.TabIndex = 2;
    //
    // Form1
    //
    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(419, 287);
    this.Controls.Add(this.txt_Chat);
    this.Controls.Add(this.lbl_Message);
    this.Controls.Add(this.cmd_Start);
    this.Name = "Form1";
    this.Text = "Form1";
    this.FormClosed += new
    System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
    this.ResumeLayout(false);
    this.PerformLayout();
}
#endregion
private System.Windows.Forms.Button cmd_Start;
private System.Windows.Forms.Label lbl_Message;
private System.Windows.Forms.TextBox txt_Chat;
 }
}