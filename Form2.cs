using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Form2 : Form
    {
        private Form1 otherForm;
        private List<string> conversationHistory = new List<string>();
        private string filePath = "conversation2.txt"; // File path for saving and loading the conversation

        public Form2(Form1 form1)
        {
            InitializeComponent();
            otherForm = form1;
            LoadConversation();
        }

        public void ReceiveMessage(string message)
        {
            conversationHistory.Add(message);
            textBoxMessages.Rtf = FormatConversation();
            SaveConversation(); // Save the conversation after receiving a new message
        }

        public void ClearConversation()
        {
            conversationHistory.Clear();
            textBoxMessages.Clear();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string message = textBoxMessage.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                ReceiveMessage($"You: {message}");
                otherForm.ReceiveMessage($"Friend: {message}");
                SaveConversation(); // Save the conversation when a new message is sent
                textBoxMessage.Clear();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBoxMessage.Clear();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearConversation();
            SaveConversation(); // Save the conversation when the "Clear" button is clicked
        }

        private void SaveConversation()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (string message in conversationHistory)
                    {
                        writer.WriteLine(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving the conversation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConversation()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    conversationHistory.Clear();
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            conversationHistory.Add(line);
                        }
                    }
                    textBoxMessages.Rtf = FormatConversation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading the conversation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          private string FormatConversation()
        {
            string conversation = "{\\rtf1\\ansi";
            foreach (string message in conversationHistory)
            {
                string formattedMessage;
                if (message.StartsWith("You"))
                {
                    string sentMessage = message.Substring(4);
                    int indentation = 45; // Adjust the indentation as needed to move messages to the right
                    formattedMessage = "\\b " + sentMessage + "\\b0";
                    formattedMessage = formattedMessage.Insert(0, $"\\b You:\\cf2\\f1\\qr\\li{indentation} ");
                }
                else
                {
                    formattedMessage = "" + message + "\\b0";
                    formattedMessage = formattedMessage.Insert(0, "\\cf1\\f0\\ql ");
                }

                conversation += "\\par " + formattedMessage;
            }
            conversation += "}";
            return conversation;
        }
   
    }
}