using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExaminationTask_27._05._23
{
    [Serializable]
    public class Word
    {
        public string WordForTranslation { get; set; }
        public List<string> Translations { get; set; }

        public Word(string word) 
        {
            WordForTranslation = word;
            Translations = new List<string>();
        }

         //метод для добавления нового варианта перевода
        public void AddTranslation(string translation) { Translations.Add(translation); }
        //метод для удаления варианта перевода
        public void RemoveTranslation(string translation) { Translations.Remove(translation); }
        public override string ToString()
        {
            return $"\n\tСлово: {WordForTranslation}, вариаты перевода: {Translations.ToString()}";
        }
    }
}
