using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SStorage.Utils
{
    public interface IStorage
    {
        /// <summary>
        /// The name of the file holding the data.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// The dictionary that contains variable name and stream positions.
        /// </summary>
        IDictionary<string, long> PositionTable { get; set; }

        /// <summary>
        /// The current end position in the stream.
        /// </summary>
        long Position { get; set; }

        /// <summary>
        /// Whether the class is running in debug mode.
        /// </summary>
        bool Debug { get; set; }

        /// <summary>
        /// The current encoding being use for read&write.
        /// </summary>
        Encoding StreamEncoder { get; set; }

        /// <summary>
        /// Deletes the current data file and creates a new file with the same name.
        /// </summary>
        void Reset();
        Task ResetAsync();

        /// <summary>
        /// Creates a file if it doesn't already exist.
        /// </summary>
        /// <param name="path">The path to the file you want to be made.</param>
        void CheckFileExistsOrCreate(string path);
        Task CheckFileExistsOrCreateAsync(string path);

        /// <summary>
        /// Updates the Position variable to the most recent position. EXPENSIVE.
        /// </summary>
        void UpdateIndex();

        /// <summary>
        /// Resets the position, all dictionary data. EXPENSIVE.
        /// </summary>
        void EraseAndFlush();
        Task EraseAndFlushAsync();

        /// <summary>
        /// Allows you to see if a variable exists in the current context.
        /// </summary>
        /// <param name="name">The variable name.</param>
        /// <returns>True if it exists. Otherwise false.</returns>
        bool VarExists(string name);
        Task<bool> VarExistsAsync(string name);

        #region Write

        /// <summary>
        /// Writes a boolean value to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. True or False.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, bool value);
        Task<bool> WriteAsync(string Name, bool value);

        /// <summary>
        /// Writes a byte to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. 0-255.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, byte value);
        Task<bool> WriteAsync(string Name, byte value);

        /// <summary>
        /// Writes a single char to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. Any value surrounded by ''.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, char value);
        Task<bool> WriteAsync(string Name, char value);

        /// <summary>
        /// Writes a decimal value to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, decimal value);
        Task<bool> WriteAsync(string Name, decimal value);

        /// <summary>
        /// Writes a single double to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, double value);
        Task<bool> WriteAsync(string Name, double value);

        /// <summary>
        /// Writes a single short to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. -32767 through 32767</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, short value);
        Task<bool> WriteAsync(string Name, short value);

        /// <summary>
        /// Writes a long to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, long value);
        Task<bool> WriteAsync(string Name, long value);

        /// <summary>
        /// Writes a single signed short to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, sbyte value);
        Task<bool> WriteAsync(string Name, sbyte value);

        /// <summary>
        /// Writes a single floating point number to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, float value);
        Task<bool> WriteAsync(string Name, float value);

        /// <summary>
        /// Writes an unsigned short to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. 0 through 65535</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, ushort value);
        Task<bool> WriteAsync(string Name, ushort value);

        /// <summary>
        /// Writes an unsigned integer to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, uint value);
        Task<bool> WriteAsync(string Name, uint value);

        /// <summary>
        /// Writes an unsigned long to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, ulong value);
        Task<bool> WriteAsync(string Name, ulong value);

        /// <summary>
        /// Writes a string to the data file in binary format.
        /// </summary>
        /// <param name="Name">The name you want to assign the value.</param>
        /// <param name="value">The value itself. Any sized string.</param>
        /// <returns>True if the operation completed successfully. False otherwise.</returns>
        bool Write(string Name, string value);
        Task<bool> WriteAsync(string Name, string value);

        #endregion

        #region Read

        /// <summary>
        /// Reads a Boolean value from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The boolean. Otherwise, an exception.</returns>
        bool ReadBool(string Name);
        Task<bool> ReadBoolAsync(string Name);

        /// <summary>
        /// Reads a Byte from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The byte. Otherwise, an exception.</returns>
        byte ReadByte(string Name);
        Task<byte> ReadByteAsync(string Name);

        /// <summary>
        /// Reads a string from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The boolean. Otherwise, an exception.</returns>
        string ReadString(string Name);
        Task<string> ReadStringAsync(string Name);

        /// <summary>
        /// Reads a char from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The char. Otherwise, an exception.</returns>
        char ReadChar(string Name);
        Task<char> ReadCharAsync(string Name);

        /// <summary>
        /// Reads a decimal value from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The decimal. Otherwise, an exception.</returns>
        decimal ReadDecimal(string Name);
        Task<decimal> ReadDecimalAsync(string Name);

        /// <summary>
        /// Reads a double from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The double. Otherwise, an exception.</returns>
        double ReadDouble(string Name);
        Task<double> ReadDoubleAsync(string Name);

        /// <summary>
        /// Reads a short from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The short. Otherwise, an exception.</returns>
        short ReadShort(string Name);
        Task<short> ReadShortAsync(string Name);

        /// <summary>
        /// Reads an integer value from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The integer. Otherwise, an exception.</returns>
        int ReadInt(string Name);
        Task<int> ReadIntAsync(string Name);

        /// <summary>
        /// Reads a long from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The long. Otherwise, an exception.</returns>
        long ReadLong(string Name);
        Task<long> ReadLongAsync(string Name);

        /// <summary>
        /// Reads a signed byte from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The sbyte. Otherwise, an exception.</returns>
        sbyte ReadSByte(string Name);
        Task<sbyte> ReadSByteAsync(string Name);

        /// <summary>
        /// Reads a floating point value from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The float. Otherwise, an exception.</returns>
        float ReadFloat(string Name);
        Task<float> ReadFloatAsync(string Name);

        /// <summary>
        /// Reads an unsigned short from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The ushort. Otherwise, an exception.</returns>
        ushort ReadUShort(string Name);
        Task<ushort> ReadUShortAsync(string Name);

        /// <summary>
        /// Reads an unsigned integer from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The uint. Otherwise, an exception.</returns>
        uint ReadUInt(string Name);
        Task<uint> ReadUIntAsync(string Name);

        /// <summary>
        /// Reads an unsigned long from storage.
        /// </summary>
        /// <param name="Name">The name you assigned said value.</param>
        /// <returns>The boolean. Otherwise, an exception.</returns>
        ulong ReadULong(string Name);
        Task<ulong> ReadULongAsync(string Name);

        #endregion

        /// <summary>
        /// Saves all session data into Json format. This can be re-loaded if the dat file & json are available.
        /// </summary>
        /// <param name="path">The path to the file we will save the data to. If it doesn't exist, it will be created.</param>
        void Save(string path);
        Task SaveAsync(string path);

        /// <summary>
        /// Loads previous data in to SStorage allowing the .dat file to be readable.
        /// </summary>
        /// <param name="path">The path to the file with the data. The file also passed as a parameter to Save.</param>
        void Load(string path);
        Task LoadAsync(string path);
    }
}
