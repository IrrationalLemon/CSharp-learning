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

namespace Randomizer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {           
            if(int.TryParse(firstNum.Text, out int num1) && int.TryParse(secondNum.Text, out int num2))
            {
                if(CheckData(num1, num2))
                {
                    int firstNum = rand.Next(num1, num2);
                    int secondNum = rand.Next(num1, num2);

                    secondNum = firstNum == secondNum ? secondNum = rand.Next(num1, num2) : secondNum;

                    resultLabel.Content = "Ура! Номера " + firstNum + " и " + secondNum + " дежурные";
                }
                else
                {
                    MessageBox.Show("Первое число это начало диапазона, второе конец. Введи их правильно бля");
                }
            }
            else
            {
                MessageBox.Show("Ошибка. Зачем ты вводишь символы?");
            }
        }

        public bool CheckData(int num1, int num2)
        {
            bool flag = false;
            if(num1 >= 0 && num2 >= 0)
            {
                if (num1 < num2)
                {
                    flag = true;
                }
            }
            return flag;
        }

    }
}
