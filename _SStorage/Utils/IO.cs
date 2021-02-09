using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SStorage.Utils
{
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
