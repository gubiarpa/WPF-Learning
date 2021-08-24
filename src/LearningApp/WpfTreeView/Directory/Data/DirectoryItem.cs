namespace WpfTreeView.Directory.Data
{
    /// <summary>
    /// Information about a directory item such a drive, file of folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The absolute path to this item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>
        public string Name => Type.Equals(DirectoryItemType.Drive) ? FullPath : DirectoryStructure.GetDirectoryName(FullPath);
    }
}
