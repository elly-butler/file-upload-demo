namespace Nexul.Demo
{
    /// <summary>
    /// Types of files.  Not all are supported by this application.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// This file contains unknown data. (The default un-initialized value).
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Represents all the contained data in a string/text format.
        /// This type can be read and edited by any text based application.
        /// </summary>
        TextData = 1,
        /// <summary>
        /// Represents all the contained data in binary (non-text) format.
        /// This type requires a proprietary application to read or edit 
        /// the contents.
        /// </summary>
        Binary = 2,
        /// <summary>
        /// Represents photo binary data.
        /// </summary>
        Image = 3,
        /// <summary>
        /// Represents a video binary data format.
        /// </summary>
        Video = 4,
        /// <summary>
        /// Any file that can only be reviewed by downloading, at user request.
        /// </summary>
        Document = 5,
        /// <summary>
        /// This format of file does not contain data, but instead is an
        /// application that can be executed.
        /// </summary>
        Executeable = 6,
        /// <summary>
        /// This format of files does not contain data, but is a component
        /// that supports other components or executeables.
        /// </summary>
        Library = 7
    }
}