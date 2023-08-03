using System;
using System.Windows.Forms;

namespace ChatApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form1 = new Form1();
            Form2 form2 = new Form2();

            form1.AttachForm2(form2); // Set Form2 reference in Form1
            form2.AttachForm1(form1); // Set Form1 reference in Form2

            form1.Show();
            form2.Show();

            Application.Run();
        }
    }
}
