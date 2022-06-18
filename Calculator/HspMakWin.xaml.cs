using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace SimBT_Deneme
{
    public partial class HspMakWin : Window
    {
        public readonly char[] operators = { '+', '-', 'x', '÷' };
        public HspMakWin()
        {
            InitializeComponent();
            newOp.Content = "";
            oldOp.Content = "";
        }
        private void DivBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZeroIfNull();

            oldOp.Content += newOp.Content + " ÷ ";
            newOp.Content = "";
        }

        private void MultBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZeroIfNull();

            oldOp.Content += newOp.Content + " x ";
            newOp.Content = "";
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZeroIfNull();

            oldOp.Content += newOp.Content + " - ";
            newOp.Content = "";
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZeroIfNull();

            oldOp.Content += newOp.Content + " + ";
            newOp.Content = "";
        }

        private void AddZeroIfNull()
        {
            if (string.IsNullOrEmpty((string)newOp.Content))
                newOp.Content = "0";
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            oldOp.Content += (string)newOp.Content;
            string lst = Calculate((string)oldOp.Content);
            oldOp.Content = "";
            newOp.Content = lst;
        }

        private string Calculate(string content) 
        {
            string[] nums = content.Split(' '); // 25 + (2 - 9) -> 25,+,(,2-,9,)
            char op = ' '; // tekli sayılar hep işlem
            float output = float.Parse(nums[0]);

            for(int i = 1; i < nums.Length; i++)
            {
                if (IsContainOperator(nums[i]))
                {
                    op = nums[i][0];
                }
                else if(nums[i].Contains('(') || nums[i].Contains(')'))
                {
                    //...
                }
                else
                {
                    switch (op)
                    {
                        case '+': output += float.Parse(nums[i]); op = ' '; break;
                        case '-': output -= float.Parse(nums[i]); op = ' '; break;
                        case 'x': output *= float.Parse(nums[i]); op = ' '; break;
                        case '÷': output /= float.Parse(nums[i]); op = ' '; break;
                        default: break;
                    }
                }
                
            }
            return output.ToString();
        }

        private bool IsContainOperator(string val)
        {
            if (val.Contains(operators[0]) || val.Contains(operators[1]))
                return true;
            if (val.Contains(operators[2]) || val.Contains(operators[3]))
                return true;

            return false;
        }
        private void FactBtn_Click(object sender, RoutedEventArgs e)
        {
            AddZeroIfNull();

            if(!string.IsNullOrEmpty(oldOp.Content.ToString()))
                if (oldOp.Content.ToString().Contains(' '))
                {
                    MessageBox.Show("Make sure its only a number", "Factoriel error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            if (int.Parse(newOp.Content.ToString()) < 0)
            {
                newOp.Content = "1";
                return;
            }              

            uint output = 1;
            uint num = uint.Parse(newOp.Content.ToString());

            while (num > 1)
            {
                output *= num--;
            }

            newOp.Content = output.ToString();
        }
        private void CloseBrBtn_Click(object sender, RoutedEventArgs e)
        {
            if(oldOp.Content.ToString().Contains('('))
                newOp.Content += ")";
        }
        private void OpenBrBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "(";
        }
        private void FrictionBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void NineBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "9";
        }

        private void SixBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "6";
        }

        private void ThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "3";
        }

        private void EightBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "8";
        }

        private void SevenBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "7";
        }

        private void FourBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "4";
        }

        private void OneBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "1";
        }

        private void FiveBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "5";
        }

        private void TwoBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "2";
        }

        private void ZeroBtn_Click(object sender, RoutedEventArgs e)
        {
            newOp.Content += "0";
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            oldOp.Content = "";
            newOp.Content = "";
        }
    }
}
