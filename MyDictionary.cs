using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationTask_27._05._23
{
    [Serializable]
    public class MyDictionary
    {
        //public string DictionaryName { get; set; }
        public string Language { get;set; }
        public List<Word> WordList { get; set; }
        public MyDictionary(/*string name,*/ string language="english") 
        { 
            //DictionaryName = name;
            Language = language;
            WordList=new List<Word>();
        }

        //проверка, существует ли слово в словаре
        private bool CheckWordExist(string word)
        {
            var foundWord = WordList.FirstOrDefault(w => w.WordForTranslation == word);
            if (foundWord!=null)
            {
                return true;
            }
            return false;
        }
        //добавление слова в словарь с переводом
        public void AddWordToDictionary(Word word) 
        {
            if (CheckWordExist(word.WordForTranslation))
            {
                Console.WriteLine("\n\tЭто слово уже есть в словаре. Повторно добавить слово невозможно." +
                    "\n\tПри необходимости добавьте перевод для слова.");
            }
            else
            {
                WordList.Add(word);
            }
            
        }
        //метод для замены слова
        public void ChangeWord(string word) 
        { 
            foreach (var el in WordList)
            {
                if (word.Equals(el.WordForTranslation))
                {
                    el.WordForTranslation = word;
                    Console.WriteLine("\n\tСлово успешно заменено.");
                }
                else
                {
                    Console.WriteLine("\n\tВведенного Вами слова нет в словаре, попробуйте его добавить.");
                }
            }
        }

        //проверка существует ли перевод
        public bool TranslationExist(string translation)
        {
            foreach (var el in WordList)
            {
                foreach (var trans in el.Translations)
                {
                    if (trans.Equals(translation))
                    {
                         return true; 
                    }
                }
            }
            return false;
        }
        //метод для добавления перевода
        public void AddTranslation(string word, string translation)
        {
            var wordToUpdate = WordList.FirstOrDefault(w => w.WordForTranslation == word);
            if (wordToUpdate != null)
            {
                if (wordToUpdate.Translations.Contains(translation))
                {
                    Console.WriteLine($"\n\tТакой вариант перевода уже есть в словаре для слова {word}");
                }
                else
                {
                    wordToUpdate.Translations.Add(translation);
                    Console.WriteLine($"\n\tПеревод \"{translation}\" успешно добавлен для слова {word}.");
                }
            }
            else
            {
                Console.WriteLine("\n\tTакого слова нет в словаре. Перевод заменить невозможно." +
                    "\n\tПопробуйте сначала добавить слово в словарь.");
            }
        }

        public void ChangeTranslation(string word, string translationToDelete, string translation)
        {
            var wordToUpdate = WordList.FirstOrDefault(w => w.WordForTranslation == word);

            if (wordToUpdate != null)
            {
                if (wordToUpdate.Translations.Contains(translationToDelete))
                {
                    wordToUpdate.Translations.Remove(translationToDelete);
                    wordToUpdate.Translations.Add(translation);
                    Console.WriteLine($"\n\tПеревод для слова {word} успешно заменен на {translation}.");
                }
                else
                {
                    Console.WriteLine($"\n\tИскомый вариант перевода для слова {word} для замены не найден.");
                }
            }
            else
            {
                Console.WriteLine("\n\tТакого слова нет в словаре. Перевод заменить невозможно. Попробуйте сначала добавить слово.");
            }

        }

        //Метод для удаления слова из словаря вместе со всеми переводами
        public void DeleteWord(string word)
        {
            if (CheckWordExist(word))
            {
                WordList.RemoveAll(w => w.WordForTranslation == word);
                Console.WriteLine($"Слово \"{word}\" успешно удалено из словаря.");
            }
            else
                Console.WriteLine($"Слово \"{word}\" не найдено в словаре.") ;
        }

        //метод для удаления перевода (с учетом ограничения: последний перевод удалить нельзя
        public void DeleteTranslation(string word, string translation)
        {
            var wordToDelete=WordList.FirstOrDefault(w=>w.WordForTranslation== word);
            if(wordToDelete!=null)
            {
                if(wordToDelete.Translations.Count>1)
                {
                    wordToDelete.Translations.Remove(translation);
                    Console.WriteLine($"\n\tВариант перевода {translation} для слова {word} успешно удален.");
                }
                else { Console.WriteLine("\n\tНельзя удалить последний вариант перевода для слова."); }
            }
            else
                Console.WriteLine($"\n\tСлово {word} не найдено в словаре");
        }
        //метод для поиска слова в словаре
        public Word SearchWord(string word)
        {
            var wordToSeach=WordList.FirstOrDefault(w=>w.WordForTranslation == word);
            if(wordToSeach!=null) 
            {
                Console.WriteLine("\n\tПоиск успешен: "+ wordToSeach.ToString());
                return wordToSeach;
            }
            else
            {
                Console.WriteLine("\n\tСлово не найдено в словаре");
                return null;
            }
                
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Language: {Language}");

            foreach (var word in WordList)
            {
                sb.AppendLine($"Word: {word.WordForTranslation}");

                if (word.Translations.Count > 0)
                {
                    sb.AppendLine("Translations:");

                    foreach (var translation in word.Translations)
                    {
                        sb.AppendLine($"- {translation}");
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
