using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationTask_27._05._23
{
    public interface IStream
    {
       
        void CreateDictionary(string path, ref MyDictionary dict);
        void SaveDictionary(string path, ref MyDictionary dict);
        bool LoadDictionary(string path, ref MyDictionary dict);
    }
}
