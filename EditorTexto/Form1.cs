namespace EditorTexto
{
    public partial class Form1 : Form
    {
        String archivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Texto|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                archivo = openFile.FileName;

                using (StreamReader sr = new StreamReader(openFile.FileName))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
                Form1.ActiveForm.Text = archivo + "| Editor de texto"; 
            }

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Texto|*.txt";

            if (archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo)) 
                { 
                    sw.WriteLine(richTextBox1.Text); 
                }
            }
            else
            {
                if (saveFile.ShowDialog() == DialogResult.OK) 
                {
                    archivo = saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName)) 
                    { 
                        sw.WriteLine(richTextBox1.Text); 
                    }

                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            archivo = null;

            Form1.ActiveForm.Text = "Editor de texto";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}