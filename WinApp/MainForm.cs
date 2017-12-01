using CoreLibrary;
using MorseCodeHelper.Lib.DataClasses;
using MorseCodeHelper.Lib.SqlDataManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var sdm = new SqlDataManager();
            this.listBox1.DataSource = sdm.GetAllAlphabets<Alphabet>();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sdm = new SqlDataManager();
            var alphabet = this.listBox1.SelectedItem as Alphabet;
            var charWhere = String.Format("AlphabetId = '{0}'", alphabet.AlphabetId);
            this.listBox2.DataSource = sdm.GetAllCharacters<Character>(charWhere).OrderBy(orderBy => orderBy.Name).ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sdm = new SqlDataManager();
            var alphabet = this.listBox1.SelectedItem as Alphabet;
            IEnumerable<Character> chars = this.listBox2.DataSource as IEnumerable<Character>;

            var standardChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-. ";

            foreach (var standardChar in standardChars)
            {
                if (!chars.Any(anyChar => anyChar.Symbol == standardChar.ToString())) {
                    var newChar = new Character()
                    {
                        AlphabetId = alphabet.AlphabetId,
                        Description = String.Format("{0} char {1}", alphabet.Name, standardChar),
                        Name = standardChar.ToString(),
                        Symbol = standardChar.ToString()
                    };

                    sdm.Insert(newChar);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MorseCodeMetaSnapshot.SaveNow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var telegraph = new Telegraph();
            telegraph.InputMessage = textBox1.Text;

            var alphabet = this.listBox1.SelectedItem as Alphabet;
            alphabet.PlayTelegraph(telegraph);
        }
    }
}
