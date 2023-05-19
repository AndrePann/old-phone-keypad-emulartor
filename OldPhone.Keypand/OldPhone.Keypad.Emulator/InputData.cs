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
        public string LastKey { get; set; }

        /// <summary>
        /// the current processed input key
        /// </summary>
        public string CurrentKey { get; set; }

        /// <summary>
        /// the key modifier to identify the parsed value 
        /// </summary>
        public int KeyModifier { get; set; }

        /// <summary>
        /// the original processed input data
        /// </summary>
        public string OriginInput { get; set; }

        /// <summary>
        /// the parsed process input data
        /// </summary>
        public string ParsedInput { get; set; }
    }
}
