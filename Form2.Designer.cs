namespace ChatApplication
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxMessages = new System.Windows.Forms.RichTextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // textBoxMessages
            this.textBoxMessages.Location = new System.Drawing.Point(12, 12);
            this.textBoxMessages.Name = "textBoxMessages";
            this.textBoxMessages.ReadOnly = true;
            this.textBoxMessages.Size = new System.Drawing.Size(400, 200);
            this.textBoxMessages.TabIndex = 0;
            textBoxMessages.BackColor = System.Drawing.Color.Black; // Set the background color
            textBoxMessages.ForeColor = System.Drawing.Color.White; // Set the text colorr
            // textBoxMessage
            this.textBoxMessage.Location = new System.Drawing.Point(12, 228);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(400, 100);
            this.textBoxMessage.TabIndex = 1;
            // sendButton
            this.sendButton.Location = new System.Drawing.Point(12, 349);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            sendButton.BackColor = System.Drawing.Color.Green; // Set the background color
            // cancelButton
            this.cancelButton.Location = new System.Drawing.Point(93, 349);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            cancelButton.BackColor = System.Drawing.Color.Red;
            // clearButton
            this.clearButton.Location = new System.Drawing.Point(174, 349);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            clearButton.BackColor = System.Drawing.Color.SkyBlue;
            // Form2
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 384);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxMessages);
            this.Name = "Form2";
            this.Text = "Chat Application - Friend";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing); // Add this line to wire up the event handler to the FormClosing event.
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox textBoxMessages;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearButton;

        private void Form2_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveConversation(); // Save the conversation when the form is closing
        }
    }
}