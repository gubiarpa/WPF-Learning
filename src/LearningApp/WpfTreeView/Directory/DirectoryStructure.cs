using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTreeView.Directory.Data;

namespace WpfTreeView.Directory
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Get all logical drives on the computer
        /// </summary>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            /// Get every logical drive on the machine
            return System.IO.Directory.GetLogicalDrives().Select(
                drive => new DirectoryItem()
                {
                    FullPath = drive,
                    Type = DirectoryItemType.Drive
                }
            ).ToList();
        }

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            /// Create an empty list
            var items = new List<DirectoryItem>();

            #region GetDirectories
            /// Create a blank list for directories
            var directories = new List<string>();

            /// Try and get directories from the folder
            /// ignoring any issues doing so
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0) items.AddRange(dirs.Select(
                    dir => new DirectoryItem()
                    {
                        FullPath = dir,
                        Type = DirectoryItemType.Folder
                    }
                ));
            }
            catch
            {
            }
            #endregion

            #region Files
            /// Try and get directories from the files
            /// ignoring any issues doing so
            try
            {
                var files = System.IO.Directory.GetFiles(fullPath);

                if (files.Length > 0) items.AddRange(files.Select(
                    file => new DirectoryItem()
                    {
                        FullPath = file,
                        Type = DirectoryItemType.File
                    }
                ));
            }
            catch
            {
            }
            #endregion

            return items;
        }

        #region Helpers
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
