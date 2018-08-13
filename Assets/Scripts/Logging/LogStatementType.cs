using System;

namespace NoMansBlocks.Logging {
    /// <summary>
    /// The various types of log messages that can be
    /// printed out to the console / log file.
    /// </summary>
    [Serializable]
    public enum LogStatementType : byte {
        Debug   = 0,
        Warning = 1,
        Error   = 2,
    }
}