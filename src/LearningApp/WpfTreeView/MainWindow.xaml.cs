using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfTreeView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region OnLoaded
        /// <summary>
        /// When the application first opens
        /// </summary
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /// Get every logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                /// Create a new item for it
                var item = new TreeViewItem();

                /// Set the header and path
                item.Header = drive;
                item.Tag = drive;

                /// Add a dummy item
                item.Items.Add(null);

                /// Add it to the main tree-view
                FolderView.Items.Add(item);                
            }            
        }
        #endregion

    }
}
