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
                var item = new TreeViewItem()
                {
                    /// Set the header and path
                    Header = drive,
                    /// Set the Full Path
                    Tag = drive
                };

                /// Add a dummy item
                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                /// Add it to the main tree-view
                FolderView.Items.Add(item);                
            }            
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region InitialChecks
            var item = (TreeViewItem)sender;

            /// If the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null) return;

            /// Clear dummy data
            item.Items.Clear();

            /// Get folder name
            var fullPath = (string)item.Tag;
            #endregion

            #region GetDirectories
            /// Create a blank list for directories
            var directories = new List<string>();

            /// Try and get directories from the folder
            /// ignoring any issues doing so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0) directories.AddRange(dirs);
            }
            catch
            {
            }

            /// For each directory
            directories.ForEach(directoryPath =>
            {
                /// Create directory item
                var subItem = new TreeViewItem()
                {
                    /// Set header as folder name
                    Header = GetDirectoryName(directoryPath),
                    /// And tag as full path
                    Tag = directoryPath
                };

                /// Add dummy item so we can expand folder
                subItem.Items.Add(null);

                /// Handle expanding
                subItem.Expanded += Folder_Expanded;

                /// Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Files
            /// Create a blank list for files
            var files = new List<string>();

            /// Try and get directories from the files
            /// ignoring any issues doing so
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0) files.AddRange(fs);
            }
            catch
            {
            }

            /// For each directory
            files.ForEach(filePath =>
            {
                /// Create directory item
                var subItem = new TreeViewItem()
                {
                    /// Set header as folder name
                    Header = GetDirectoryName(filePath),
                    /// And tag as full path
                    Tag = filePath
                };

                /// Add this item to the parent
                item.Items.Add(subItem);
            });
            #endregion
        }
        #endregion

        #region FolderExpanded
        /// <summary>
        /// Find the file or folder name from a full path
        /// </summary>
        public static string GetDirectoryName(string path)
        {
            // C:\Something\a folder
            // C:\Something\a file.png
            // a file file.png

            /// If we have not path, return empty
            if (string.IsNullOrEmpty(path)) return string.Empty;

            /// Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            /// Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            /// If we don't find a backslash, return the path itself
            if (lastIndex <= 0) return path;

            /// Return the name after the last backslash
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
