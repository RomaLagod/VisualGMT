using GMT_BLL.LogicInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMT_BLL
{
    public class FileManager : IFileManager
    {
        #region Properties

        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        #endregion

        #region Methods

        public bool IsExist(string filePath)
        {
            bool isExist = File.Exists(filePath);
            return isExist;
        }

        public string GetContent(string filePath)
        {
            return GetContent(filePath, _defaultEncoding);
        }

        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }

        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            int count = content.Length;
            return count;
        }

        #endregion

    }
}
