using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Storage
{
    // If we store the data's starting position in the dictionary,
    // we can set the streams context to there and read the value.
    // This could allow us to have binary data in a file that we can
    // index via string name. 

    // We will need to make it a template and work out what type of
    // data type they are reading.

    class Storage
    {
        public string FileName { get; private set; }

        private IDictionary<string, long> PositionTable { get; set; }

        private long Position { get; set; }

        private bool Debug { get; set; }

        #region Utility

        private void CheckFileExistsOrCreate(string path)
        {
            if (!File.Exists(path))
            {
                FileStream temp = File.Create(path);
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

            PositionTable = new Dictionary<string, long>();
            Position = 0;
            Debug = debug;
        }

        #endregion

        #region Write

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(bool);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(byte);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(char);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(decimal);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(double);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(short);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(long);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(sbyte);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(float);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(ushort);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(uint);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
            {
                writer.BaseStream.Position = Position; // Set the position so we don't overwrite other data.

                var _temp = Position; // Get the position before we write the value, so we can set it in the dictionary.
                writer.Write(value); // Write the value.

                Position += sizeof(ulong);

                PositionTable.Add(Name, _temp);
            }

            return PositionTable.ContainsKey(Name);
        }

        /// <summary>
        /// Writes data into the file.
        /// </summary>
        /// <param name="Name">The name of which you want to be able to access this value.</param>
        /// <param name="value">The value to store.</param>
        /// <returns>True if all went well. Otherwise false.</returns>
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

            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Open))) // Closes the writer for us, much easier.
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

        #region Read

        /// <summary>
        /// Reads a boolean from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The boolean. If an error occurs, an exception will be thrown.</returns>
        public bool ReadBool(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            bool result = false;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a single byte from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The byte. Otherwise, an exception will be thrown.</returns>
        public byte ReadByte(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            byte result = 0x0;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a string from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The string. Otherwise, an exception will be thrown.</returns>
        public string ReadString(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            string result = string.Empty;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a single char from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The char. Otherwise, an exception will be thrown.</returns>
        public char ReadChar(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            char result = char.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a decimal value from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public decimal ReadDecimal(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            decimal result = decimal.Zero;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a double from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public double ReadDouble(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            double result = double.NaN;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a short from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public short ReadShort(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            short result = short.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads an integer value from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public int ReadInt(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            int result = int.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a 64bit integer value from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public long ReadLong(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            long result = long.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a signed byte from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public sbyte ReadSByte(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            sbyte result = sbyte.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads a floating point value from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public float ReadFloat(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            float result = float.NaN;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads an unsigned short from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public ushort ReadUShort(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            ushort result = ushort.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads an unsigned 32bit integer from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public uint ReadUInt(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            uint result = uint.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        /// <summary>
        /// Reads an unsigned 64bit integer from the data file.
        /// </summary>
        /// <param name="Name">The name which you assigned the variable to when writing it.</param>
        /// <returns>The decimal value. Otherwise, an exception will be thrown.</returns>
        public ulong ReadULong(string Name)
        {
            if (!PositionTable.ContainsKey(Name))
            {
                throw new ArgumentException("Specified identifier '" + Name + "' passed into ReadBool doesn't exist.");
            }

            ulong result = ulong.MinValue;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
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

        #region ImportExport

        /// <summary>
        /// Saves the current positions & data. This allows you to load the exact same data with the same names after the program has been restarted.
        /// </summary>
        /// <param name="path">The path to the file, if it doesn't already exist it will be created.</param>
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
                if (path.Contains("."))
                {
                    File.Create(path).Dispose();
                }
            }

            File.WriteAllText(path, serialized);
        }

        /// <summary>
        /// Loads the saved data from the Json file & imports it. This allows you to use data previously saved.
        /// </summary>
        /// <param name="path">The path you used with the Save method.</param>
        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                // The passed file doesn't exist, not good so let them know with an exception. 
                // This could break the whole thing so we don't risk trying to handle.
                throw new ArgumentException($"The specified file doesn't exist. {path}");
            }

            PositionTable = JsonConvert.DeserializeObject<Dictionary<string, long>>(File.ReadAllText(path));
            UpdateIndex();
        }

        #endregion
    }
}

