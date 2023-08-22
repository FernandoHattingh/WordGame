using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordGame
{
    public partial class MainWindow : Window
    {
        List<string> wordList = new List<string>(){
        "Processor",
    "Compiler",
    "Array",
    "Counter",
    "Algorithm",
    "Memory",
    "Variable",
    "Function",
    "Interface",
    "Inheritance",
    "Constructor",
    "Destructor",
    "Debugging",
    "Exception",
    "LinkedList",
    "Recursion",
    "Enumeration",
    "Namespace",
    "Boolean",
    "Framework",
    "Operand",
    "Bytecode",
    "Framework",
    "Constructor"};

        Random wordSelector = new Random();
        int word = 0;
        int counter = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            btnCheck.IsEnabled = false;
        }

        public void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            lblScrambledWord.Content = (ScrambleWord(wordList[SelectWord()]).ToString());
            btnCheck.IsEnabled = true;
        }

        public int SelectWord()
        {
            word = wordSelector.Next(wordList.Count);

            return word;
        }

        public string ScrambleWord(string word)
        {
            char[] chars = new char[word.Length];
            Random rando = new Random(100);
            int index = 0;
            while (word.Length > 0)
            {
                int next = rando.Next(0, word.Length - 1);

                chars[index] = word[next];
                word = word.Substring(0, next) + word.Substring(next + 1);
                ++index;
            }
            return new String(chars);
        }

        public bool CheckMatch(string match)
        {
            string selectedWord = wordList[word].ToString();
            bool flag;
            if (match.Equals(selectedWord))
            {
                flag = true;
                counter++;
            }
            else
            {
                flag = false;
                counter--;
            }

            return flag;
        }


        public void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (lblScrambledWord.Content != null)
            {
                string userIn = txtbAnswer.Text;
                if (CheckMatch(userIn) == true)
                {

                    MessageBox.Show("Correct" + ", Your score is: " + counter);
                }
                else
                {

                    MessageBox.Show("Incorrect" + ", Your score is: " + counter);
                }
            }
            else
            {
                MessageBox.Show("Please click play first!");
            }
        }
    }
}
