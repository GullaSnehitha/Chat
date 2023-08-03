using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Form2 : Form
    {
        private List<string> conversation = new List<string>();
        private Form1 form1;

        public Form2()
        {
            InitializeComponent();
        }

        public void AttachForm1(Form1 form1Ref)
        {
            form1 = form1Ref; // Initialize the reference to Form1
            form1.MessageSent += Form1_MessageSent; // Subscribe to the MessageSent event of Form1
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                conversation.Add("Form2: " + message);
                DisplayConversation();
                txtMessage.Text = "";

                // Raise the MessageSent event to notify Form1 about the message
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

        // Event handler for the MessageSent event of Form1 (Received message from Form1)
        private void Form1_MessageSent(object sender, string message)
        {
            // Check if the event sender is of type Form1
            if (sender is Form1)
            {
                conversation.Add("Form1: " + message);
                DisplayConversation();
            }
        }
    }
}
