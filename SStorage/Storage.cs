using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    //* Storage.Utils

    // Contains classes that provide utility functionality
    // that can help and assist in keeping code tidy & readable
    // while working with SStorage.

    namespace Utils
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

        public class HelperFactory
        {
            public static IStorage SStorageWithPath(string path) => new Storage(path);

            public static IStorage SStorage() => new Storage();

            public static IStorage SStorageDbg() => new Storage(true);

            public static IStorage SStorageWithPathDbg(string path) => new Storage(path, true);

            public static IStorage SStorageWithPathAndEncoding(string path, Encoding encoder) => new Storage(path, encoder);

            public static IStorage SStorageWithPathAndEncodingDbg(string path, Encoding encoder) => new Storage(path, encoder, true);
        }

        public class IO
        {
            #region Static

            public static void CreateFileInNewFolder(string folder, string file_name)
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                if (!File.Exists(folder + "\\" + file_name))
                {
                    FileStream temp = File.Create(folder + "\\" + file_name);
                    temp.Close();
                    temp.Dispose();
                }
            }

            #endregion
        }
    }

    // If we store the data's starting position in the dictionary,
    // we can set the streams context to there and read the value.
    // This could allow us to have binary data in a file that we can
    // index via string name. 

    // We will need to make it a template and work out what type of
    // data type they are reading.

    /// <summary>
    /// Main SStorage object.
    /// </summary>
    public class Storage : IDisposable, Utils.IStorage
    {
        public string FileName { get; set; }

        public IDictionary<string, long> PositionTable { get; set; }

        public long Position { get; set; }

        public bool Debug { get; set; }

        public Encoding StreamEncoder { get; set; }

        #region Utility

        public void CheckFileExistsOrCreate(string path)
        {
            if (!File.Exists(path))
            {
                FileStream temp = null;

                try
                {
                    temp = File.Create(path);
                }
                catch
                {
                    throw new IOException("You tried to set a data file to '" + path + "' does this directory exist?");
                }

                temp.Close();
                temp.Dispose();
            }
        }

        public void UpdateIndex()
        {
            long temp = 0;

            foreach (KeyValuePair<string, long> kv in PositionTable)
            {
                temp = kv.Value; // The dictionary is iterated upwards, so the final value will contain the Position we want
            }

            // Minus one because we save a one byte char as we save, now any new data will overwrite this value.

            // UPDATE: Inital thoughts were to take away one, but the character we add is literally NULL so it
            // Technically isn't actually there and messes things up, we now put a long there so we subtract 8
            // from the position.

            Position = temp - 8;
        }

        public void EraseAndFlush()
        {
            string[] names = { };

            foreach (KeyValuePair<string, long> kv in PositionTable)
            {
                names.Append(kv.Key);
            }

            foreach (string key in names)
            {
                PositionTable.Remove(key);
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open)))
            {
                writer.BaseStream.Position = Position;
                writer.Flush();
            }

            Position = 0;
        }

        public void Reset()
        {
            EraseAndFlush(); // Flush current stream & active data.

            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            CheckFileExistsOrCreate(FileName);
        }

        public void Dispose()
        {
            PositionTable.Clear();
        }

        public bool VarExists(string name) => PositionTable.ContainsKey(name);

        #endregion

        #region AsyncUtils

        public async Task CheckFileExistsOrCreateAsync(string Path)
        {
            await Task.Run(() =>
            {
                if (!File.Exists(Path))
                {
                    FileStream temp = null;

                    try
                    {
                        temp = File.Create(Path);
                    }
                    catch
                    {
                        throw new IOException("You tried to set a data file to '" + Path + "' does this directory exist?");
                    }

                    temp.Close();
                    temp.Dispose();
                }
            });
        }

        public Task EraseAndFlushAsync()
        {
            return Task.Run(() =>
            {
                string[] names = { };

                foreach (KeyValuePair<string, long> kv in PositionTable)
                {
                    names.Append(kv.Key);
                }

                foreach (string key in names)
                {
                    PositionTable.Remove(key);
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open)))
                {
                    writer.BaseStream.Position = Position;
                    writer.Flush();
                }

                Position = 0;
            });
        }

        public async Task ResetAsync()
        {
            await EraseAndFlushAsync(); // Flush current stream & active data.

            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            await CheckFileExistsOrCreateAsync(FileName);
        }

        public async Task<bool> VarExistsAsync(string name)
        {
            bool res = await Task.Run(() =>
            {
                return PositionTable.ContainsKey(name);
            });

            return res;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a storage instance with the default file name as 'storage.dat'
        /// </summary>
        /// <param name="debug">If true, Storage will throw exceptions on non-fatal errors for debugging. Otherwise, it will not.</param>
        public Storage(bool debug = false)
        {
            FileName = "storage.dat";
            CheckFileExistsOrCreate(FileName);

            StreamEncoder = Encoding.ASCII;
            PositionTable = new Dictionary<string, long>();
            Position = 0;
            Debug = debug;
        }

        /// <summary>
        /// Creates a storage instance with the specified file name.
        /// </summary>
        /// <param name="fileName">The file name to save the data into, can be a folder if it exists.</param>
        /// <param name="debug">If true, Storage will throw exceptions on non-fatal errors for debugging. Otherwise, it will not.</param>
        public Storage(string fileName, bool debug = false)
        {
            FileName = fileName;
            CheckFileExistsOrCreate(FileName);

            StreamEncoder = Encoding.ASCII;
            PositionTable = new Dictionary<string, long>();
            Position = 0;
            Debug = debug;
        }

        public Storage(string fileName, Encoding encoding, bool debug = false)
        {
            FileName = fileName;
            CheckFileExistsOrCreate(fileName);

            StreamEncoder = encoding;
            PositionTable = new Dictionary<string, long>();
            Position = 0;
            Debug = debug;
        }

        #endregion

        #region Write

        public bool Write(string Name, bool value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(bool);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, byte value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(byte);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, char value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(char);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, decimal value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(decimal);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, double value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(double);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, short value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(short);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, long value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(long);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, sbyte value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(sbyte);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, float value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(float);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, ushort value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(ushort);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, uint value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(uint);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        public bool Write(string Name, ulong value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(ulong);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }


        public bool Write(string Name, string value)
        {
            if (PositionTable.ContainsKey(Name))
            {
                if (Debug)
                {
                    throw new ArgumentException("The variable name '" + Name + "' already exists.");
                }

                return false;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = writer.BaseStream.Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += value.Length + 1; // 1 char = 1 byte, just the length.

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        #endregion

        #region WriteAsync

        public async Task<bool> WriteAsync(string Name, bool Value)
        {
            return await Task.Run(() =>
            {
                if (VarExists(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(bool);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, byte Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(byte);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, char Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(char);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, decimal Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(decimal);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, double Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(double);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, short Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(short);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, long Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(long);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, sbyte Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(sbyte);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, float Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(float);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, ushort Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(ushort);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, uint Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(uint);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, ulong Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += sizeof(ulong);

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        public async Task<bool> WriteAsync(string Name, string Value)
        {
            return await Task.Run(() =>
            {
                if (PositionTable.ContainsKey(Name))
                {
                    if (Debug)
                    {
                        throw new ArgumentException("The variable name '" + Name + "' already exists.");
                    }

                    return false;
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open), StreamEncoder)) // Closes the writer for us, much easier.
                {
                    writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                    var _temp = writer.BaseStream.Position; // Get the position before we write the value, so we can set it in the dictionary.
                    writer.Write(Value); // Write the value.

                    Position += Value.Length + 1; // 1 char = 1 byte, just the length.

                    PositionTable.Add(Name, _temp);
                }

                return PositionTable.ContainsKey(Name);
            });
        }

        #endregion

        #region Read


        public bool ReadBool(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            bool result = false;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadBoolean();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }


        public byte ReadByte(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadByte doesn't exist.");
            }

            byte result = 0x0;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadByte();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }


        public string ReadString(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadString doesn't exist.");
            }

            string result = string.Empty;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadString();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }


        public char ReadChar(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadChar doesn't exist.");
            }

            char result = char.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadChar();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }


        public decimal ReadDecimal(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadDecimal doesn't exist.");
            }

            decimal result = decimal.Zero;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadDecimal();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public double ReadDouble(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadDouble doesn't exist.");
            }

            double result = double.NaN;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadDouble();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }


        public short ReadShort(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadShort doesn't exist.");
            }

            short result = short.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadInt16();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public int ReadInt(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadInt doesn't exist.");
            }

            int result = int.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadInt32();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public long ReadLong(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadLong doesn't exist.");
            }

            long result = long.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadInt32();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public sbyte ReadSByte(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadSByte doesn't exist.");
            }

            sbyte result = sbyte.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadSByte();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public float ReadFloat(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadFloat doesn't exist.");
            }

            float result = float.NaN;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadSingle();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public ushort ReadUShort(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadUShort doesn't exist.");
            }

            ushort result = ushort.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadUInt16();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public uint ReadUInt(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadUInt doesn't exist.");
            }

            uint result = uint.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadUInt32();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        public ulong ReadULong(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadULong doesn't exist.");
            }

            ulong result = ulong.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
            {
                reader.BaseStream.Position = PositionTable[Name];

                try
                {
                    result = reader.ReadUInt64();
                }
                catch (EndOfStreamException)
                {
                    throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (ObjectDisposedException)
                {
                    throw new Exception("The reader object was disposed mid-operation. " +
                        " If you have this error, please contact https://github.com/DeetonRushy.");
                }
                catch (IOException err)
                {
                    throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                        FileName + "' still exist? Extra Info: " + err.Message);
                }
            }

            return result;
        }

        #endregion

        #region ReadAsync

        public async Task<bool> ReadBoolAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
                }

                bool result = false;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadBoolean();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<byte> ReadByteAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadByte doesn't exist.");
                }

                byte result = 0x0;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadByte();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<string> ReadStringAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadString doesn't exist.");
                }

                string result = string.Empty;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadString();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<char> ReadCharAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadChar doesn't exist.");
                }

                char result = char.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadChar();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<decimal> ReadDecimalAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadDecimal doesn't exist.");
                }

                decimal result = decimal.Zero;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadDecimal();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<double> ReadDoubleAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadDouble doesn't exist.");
                }

                double result = double.NaN;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadDouble();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<short> ReadShortAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadShort doesn't exist.");
                }

                short result = short.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadInt16();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<int> ReadIntAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadInt doesn't exist.");
                }

                int result = int.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadInt32();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<long> ReadLongAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadLong doesn't exist.");
                }

                long result = long.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadInt32();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<sbyte> ReadSByteAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadSByte doesn't exist.");
                }

                sbyte result = sbyte.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadSByte();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<float> ReadFloatAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadFloat doesn't exist.");
                }

                float result = float.NaN;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadSingle();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<ushort> ReadUShortAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadUShort doesn't exist.");
                }

                ushort result = ushort.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadUInt16();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<uint> ReadUIntAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadUInt doesn't exist.");
                }

                uint result = uint.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadUInt32();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        public async Task<ulong> ReadULongAsync(string Name)
        {
            return await Task.Run(async () =>
            {
                if (!await VarExistsAsync(Name))
                {
                    throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadULong doesn't exist.");
                }

                ulong result = ulong.MinValue;

                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open), StreamEncoder))
                {
                    reader.BaseStream.Position = PositionTable[Name];

                    try
                    {
                        result = reader.ReadUInt64();
                    }
                    catch (EndOfStreamException)
                    {
                        throw new Exception("There was an error reading the value '" + Name + "', we reached the end of the stream." +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (ObjectDisposedException)
                    {
                        throw new Exception("The reader object was disposed mid-operation. " +
                            " If you have this error, please contact https://github.com/DeetonRushy.");
                    }
                    catch (IOException err)
                    {
                        throw new IOException("While trying to read the value '" + Name + "' an IOException occured. Does the file '" +
                            FileName + "' still exist? Extra Info: " + err.Message);
                    }
                }

                return result;
            });
        }

        #endregion

        #region ImportExport

        public void Save(string path)
        {
            if (PositionTable.Count == 0)
                return; // No need to save.

            // Before saving we write in a null character which is 1 byte long, this is for
            // retreving the last known Position.

            long a = 100;
            Write("_LOAD_SAVE_PROTECTION", a);

            var serialized = JsonConvert.SerializeObject(PositionTable);

            if (!File.Exists(path))
            {
                if (path.Contains('.'))
                {
                    File.Create(path).Dispose();
                }
            }

            File.WriteAllText(path, serialized);
        }

        public async Task SaveAsync(string path)
        {
            if (PositionTable.Count == 0)
                return; // No need to save.

            // Before saving we write in a null character which is 1 byte long, this is for
            // retreving the last known Position.

            long a = 100;
            await WriteAsync("_LOAD_SAVE_PROTECTION", a);

            var serialized = JsonConvert.SerializeObject(PositionTable);

            if (!File.Exists(path))
            {
                if (path.Contains('.'))
                {
                    File.Create(path).Dispose();
                }
            }

            File.WriteAllText(path, serialized);
        }

        public void Load(string path)
        {
            EraseAndFlush(); // Make sure any current data we have isn't forgotten.

            if (!File.Exists(path))
            {
                // The passed file doesn't exist, not good so let them know with an exception. 
                // This could break the whole thing so we don't risk trying to handle.
                throw new ArgumentException($"The specified file doesn't exist. {path}");
            }


            var data = File.ReadAllText(path);

            PositionTable = JsonConvert.DeserializeObject<Dictionary<string, long>>(data);
            UpdateIndex();
        }

        public async Task LoadAsync(string path)
        {
            await EraseAndFlushAsync(); // Make sure any current data we have isn't forgotten.

            if (!File.Exists(path))
            {
                // The passed file doesn't exist, not good so let them know with an exception. 
                // This could break the whole thing so we don't risk trying to handle.
                throw new ArgumentException($"The specified file doesn't exist. {path}");
            }


            var data = File.ReadAllText(path);

            PositionTable = JsonConvert.DeserializeObject<Dictionary<string, long>>(data);
            UpdateIndex(); // Not an async version, when called here it's crucial the member is set.
        }

        #endregion
    }
}
