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

namespace _56_ValidatesOnDataErrors
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Message = "Oli";
            this.VorName = "Gebert";
            this.textBox.ToolTip = "Oli";

            Task<string>.Run((Func<string>)Test2);
            Task.Run((Action)Test);
            // this.textBox

            this.DataContext = this;

        }


        public string Message { get; set; }

        string vorName;
        public string VorName
        {
            get { return vorName;}
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentException("Feld ist leer");

                vorName = value;
            }
        }

        public Func<int> FunctioN;
        void Test()
        { }

        string Test2()
        {
            return "";
        }
    }
}
