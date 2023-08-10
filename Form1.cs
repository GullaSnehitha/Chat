using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        private List<string> conversationHistory = new List<string>();
        private string filePath = "conversation.txt"; // File path for saving and loading the conversation
        private int indentation = 100; // Adjust the indentation for sent messages as needed

        public Form1()
        {
            InitializeComponent();
            form2 = new Form2(this);
            form2.Show();
            LoadConversation();
        }

        public void ReceiveMessage(string message)
        {
            conversationHistory.Add(message);
            textBoxMessages.Rtf = FormatConversation();
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
                ReceiveMessage($"Me1: {message}");
                form2.ReceiveMessage($"Friend: {message}");
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConversation();
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

        // Helper method to format the conversation for displaying in RichTextBox.
        private string FormatConversation()
        {
            string conversation = "{\\rtf1\\ansi";
            foreach (string message in conversationHistory)
            {
                string formattedMessage;
                if (message.StartsWith("Me1"))
                {
                    string sentMessage = message.Substring(4);
                    formattedMessage = $"\\b {sentMessage}\\b0";
                    formattedMessage = formattedMessage.Insert(0, $"\\b You\\cf2\\f1\\qr\\li{indentation} ");
                }
                else
                {
                    formattedMessage = $"{message}\\b0";
                    formattedMessage = formattedMessage.Insert(0, "\\cf1\\f0\\ql ");
                }

                conversation += "\\par " + formattedMessage;
            }
            conversation += "}";
            return conversation;
        }
    }
}