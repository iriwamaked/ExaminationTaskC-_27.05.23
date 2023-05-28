using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace ExaminationTask_27._05._23
{
    public class BinaryFile: IStream
    {
        public void CreateDictionary(string path, ref MyDictionary dict)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dict);
            }
        }
        public void SaveDictionary(string path, ref MyDictionary dict)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, dict);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\tФайл не найден." + ex.Message);
            }
        }

        public bool LoadDictionary (string path, ref MyDictionary dict) 
        {
            bool isLoaded=false;
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    dict = (MyDictionary)bf.Deserialize(fs);
                }
                isLoaded = true;
               
            }
            else { Console.WriteLine("\n\tФайл не найден");}
            return isLoaded;
        }
    }
}
