using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfTreeView
{
    public class Class1 : INotifyPropertyChanged
    {
        private string _test;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test
        {
            get
            {
                return _test;
            }
            set
            {
                if (_test == value) return;
                _test = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
            }
        }

        public Class1()
        {
            Task.Run(async () =>
            {
                int i = 0;

                while (true)
                {
                    await Task.Delay(20);
                    Test = (i++).ToString();
                }
            });
        }

        public override string ToString()
        {
            return "Hello Wawi";
        }
    }
}
