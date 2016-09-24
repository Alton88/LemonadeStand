using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace LemonadeStand
{
    class FileReader
    {
        public FileReader() { }
        public string[] ReadFileToAttributes()
        {
            StreamReader streamReader = new StreamReader("SaveGame.txt");
            string[] savedData = streamReader.ReadToEnd().Split('+');
            streamReader.Close();

            return savedData;
        }
        
    }
    
}
