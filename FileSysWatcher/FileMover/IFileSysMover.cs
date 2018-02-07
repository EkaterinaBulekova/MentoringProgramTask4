namespace FileSysMover.FileMover
{
    /// <summary>
    /// Provide moving files from watched directories according to the rules
    /// </summary>
    public interface IFileSysMover
    {
        /// <summary>
        /// Start process to watch directory and move file
        /// </summary>
        void FileSysMoveStart();
    }
}
