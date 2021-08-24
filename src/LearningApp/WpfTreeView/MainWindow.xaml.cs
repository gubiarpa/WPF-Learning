using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        #region FolderExpanded
        /// <summary>
        /// whe a folder is expanded, find the sub folders/files
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
           
        }
        #endregion
    }
}
