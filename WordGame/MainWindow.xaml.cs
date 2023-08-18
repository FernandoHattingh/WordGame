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
        List<string> wordList = new List<string>();
        Random wordSelector = new Random();
        
        public MainWindow()
        {
            InitializeComponent();

        }

        public void btnPlay_Click(object sender, RoutedEventArgs e)
        {           
            wordList.Add("Processor");
            wordList.Add("Compiler");
            wordList.Add("Array");
            wordList.Add("Counter");
            

            lblScrambledWord.Content = (ScrambleWord(wordList[SelectWord()]).ToString());

        }

        public int SelectWord()
        {
            int word = wordSelector.Next(wordList.Count);

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
            string selectedWord = wordList[SelectWord()].ToString();
            bool flag;
            if (match.Equals(selectedWord))
            {
                flag = true;
                
            }
            else
            {
                flag = false;
               
            }

            return flag;
        }


        public void btnCheck_Click(object sender, RoutedEventArgs e)
        {
           string userIn = txtbAnswer.Text;
            int counter = 0;

            if (CheckMatch(userIn) == true)
            {
                counter++;
                MessageBox.Show("Corrcet" + ", Your score is:" + counter);
            }
            else
            {
                counter--;
                MessageBox.Show("Incorrcet" + ", Your score is:" + counter);
            }
        }
    }
}
