using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMT_BLL.LogicInterface
{
    public interface IFileManager
    {
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string content, string filePath);
        void SaveContent(string content, string filePath, Encoding encoding);
        int GetSymbolCount(string content);
        bool IsExist(string filePath);
    }
}
