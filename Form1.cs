using System;
using System.Windows.Forms;

namespace formulariosencillo
{
    public partial class Form1 : Form
    {
        coneccion c = new coneccion();

        public Form1()
        {
            InitializeComponent();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            coneccion c = new coneccion();
            c.cargardatos(dgv);  
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TexNOMBRE_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextDUI_TextChanged(object sender, EventArgs e)
        {

        }

        private void TexEDAD_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (c.personaregistrada(Convert.ToInt32(textDUI.Text)) == 0)
            {

                MessageBox.Show(c.insertar(textDUI.Text, texNOMBRE.Text, Convert.ToInt32(texEDAD.Text)));
            }
            else {
                MessageBox.Show("ya existe");
                }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
