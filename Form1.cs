using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Form1 : Form
    {
        private List<string> conversation = new List<string>();
        private Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        public void AttachForm2(Form2 form2Ref)
        {
            form2 = form2Ref;
            form2.MessageSent += Form2_MessageSent; // Subscribe to the MessageSent event of Form2
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                conversation.Add("Form1: " + message);
                DisplayConversation();
                txtMessage.Text = "";

                // Raise the MessageSent event to notify Form2 about the message
                OnMessageSent(message);
            }
        }

        // Custom event declaration
        public event EventHandler<string>? MessageSent;

        // Helper method to raise the MessageSent event
        protected virtual void OnMessageSent(string message)
        {
            MessageSent?.Invoke(this, message);
        }

        private void DisplayConversation()
        {
            listBoxConversation.Items.Clear();
            foreach (string message in conversation)
            {
                listBoxConversation.Items.Add(message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            conversation.Clear();
            DisplayConversation();
        }

        // Event handler for the MessageSent event of Form2 (Received message from Form2)
        private void Form2_MessageSent(object sender, string message)
        {
            // Check if the event sender is of type Form2
            if (sender is Form2)
            {
                conversation.Add("Form2: " + message);
                DisplayConversation();
            }
        }
    }
}
