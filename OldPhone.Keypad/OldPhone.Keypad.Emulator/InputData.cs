namespace OldPhone.Keypad.Emulator
{
    /// <summary>
    /// Data model for OldPhone
    /// </summary>
    public class InputData
    {
        /// <summary>
        /// the lase processed input key
        /// </summary>
        public required string LastKey { get; set; }

        /// <summary>
        /// the current processed input key
        /// </summary>
        public required string CurrentKey { get; set; }

        /// <summary>
        /// the key modifier to identify the parsed value 
        /// </summary>
        public int KeyModifier { get; set; }

        /// <summary>
        /// the original processed input data
        /// </summary>
        public required string OriginInput { get; set; }

        /// <summary>
        /// the parsed process input data
        /// </summary>
        public required string ParsedInput { get; set; }
    }
}
