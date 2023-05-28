using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationTask_27._05._23
{
    [Serializable]
    public class SimpleUserMenu:MenuInterfase
    {
        public override void ShowMenu()
        {
            base.ShowMenu();
        }

        public override MyDictionary CreateDictionary(string language)
        {
            return base.CreateDictionary(language);
        }

        public override void AddWordOrTranslaTion(ref MyDictionary dictionary)
        {
            base.AddWordOrTranslaTion(ref dictionary);
        }

        public override void ChangeWordOrTranslarion(ref MyDictionary dictionary)
        {
            base.ChangeWordOrTranslarion(ref dictionary);
        }

        public override void DeleteWordOrTranslation(ref MyDictionary dictionary)
        {
            base.DeleteWordOrTranslation(ref dictionary); 
        }

        public override Word SearchWord()
        {
            return base.SearchWord();
        }

        public override void ExportWordToFile(ref Word word)
        {
            base.ExportWordToFile(ref word);
        }

       
    }
}
