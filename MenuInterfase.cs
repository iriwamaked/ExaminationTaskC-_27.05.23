using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationTask_27._05._23
{
    [Serializable]
    public abstract class MenuInterfase
    {
        public MyDictionary dict=new MyDictionary();
        public virtual void ShowMenu()
        {
            Console.WriteLine("\n\tВыберите действие со словарем: " +
                "\n\t 1 - Создать словарь" +
                "\n\t 2 - Добавить слово или перевод в уже существующий словарь" +
                "\n\t 3 - Заменить слово или перевод в словаре " +
                "\n\t 4 - Удалить слово или перевод из словаря " +
                "\n\t 5 - Искать перевод слова c возможностью экспортировать слово и варианты его перевода в файл" +
                "\n\t 6 - Cохранить словарь в файл");
        }

        public virtual MyDictionary CreateDictionary(string language)
        {
            MyDictionary dict=new MyDictionary(language);
            return dict;
        }

        public virtual void AddWordOrTranslaTion()
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы добавить слово," +
                    "\n\t2 - чтобы добавить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно добавить: ");
                        string wordToAdd = Console.ReadLine();
                        Word add = new Word(wordToAdd);
                        Console.WriteLine("\n\tДобавить перевод для нового слова:");
                        string translate = Console.ReadLine();
                        add.AddTranslation(translate);
                        dict.AddWordToDictionary(add);
                        Console.WriteLine("\n\tСлово успешно добавлено.");
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно добавить перевод: ");
                        string wordToTranslate = Console.ReadLine();
                        Console.WriteLine("\n\tВведите перевод для слова: ");
                        string translationToAdd = Console.ReadLine();
                        dict.AddTranslation(wordToTranslate, translationToAdd);
                        Console.WriteLine("\n\tПеревод успешно добавлен");
                        break;
                    default:
                        choice = 0;
                        break;
                }
            }
            while (choice != 0);
        }
        public virtual void AddWordOrTranslaTion(ref MyDictionary dictionary)
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы добавить слово," +
                    "\n\t2 - чтобы добавить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch(choice) 
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно добавить: ");
                        string wordToAdd=Console.ReadLine();
                        Word add=new Word(wordToAdd);
                        Console.WriteLine("\n\tДобавить перевод для нового слова:");
                        string translate=Console.ReadLine();
                        add.AddTranslation(translate);
                        dictionary.AddWordToDictionary(add);
                        Console.WriteLine("\n\tСлово успешно добавлено.");
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно добавить перевод: ");
                        string wordToTranslate = Console.ReadLine();
                        Console.WriteLine("\n\tВведите перевод для слова: ");
                        string translationToAdd=Console.ReadLine();
                        dictionary.AddTranslation(wordToTranslate, translationToAdd);
                        Console.WriteLine("\n\tПеревод успешно добавлен");
                        break;
                    default:
                        choice=0;
                        break;
                }
            }
            while (choice != 0);
        }
        
        public virtual void ChangeWordOrTranslarion(ref MyDictionary dictionary)
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы заменить слово," +
                    "\n\t2 - чтобы заменить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно заменить: ");
                        string wordToChange = Console.ReadLine();
                        dictionary.ChangeWord(wordToChange);
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно заменить перевод: ");
                        string wordToChangeTranslate = Console.ReadLine();
                        Console.Write("\n\tВведите перевод слова, который нужно заменить: ");
                        string translationToDelete = Console.ReadLine();
                        Console.Write("\n\tВведите правильный перевод слова: ");
                        string translationToChange = Console.ReadLine();
                        dictionary.ChangeTranslation(wordToChangeTranslate, translationToDelete, translationToChange);
                        Console.WriteLine("\n\tПеревод успешно добавлен");
                        break;
                    default:
                        choice = 0;
                        break;
                }
            }
            while (choice != 0);
        }

        public virtual void ChangeWordOrTranslarion()
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы заменить слово," +
                    "\n\t2 - чтобы заменить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно заменить: ");
                        string wordToChange = Console.ReadLine();
                        dict.ChangeWord(wordToChange);
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно заменить перевод: ");
                        string wordToChangeTranslate = Console.ReadLine();
                        Console.Write("\n\tВведите перевод слова, который нужно заменить: ");
                        string translationToDelete = Console.ReadLine();
                        Console.Write("\n\tВведите правильный перевод слова: ");
                        string translationToChange = Console.ReadLine();
                        dict.ChangeTranslation(wordToChangeTranslate, translationToDelete, translationToChange);
                        Console.WriteLine("\n\tПеревод успешно добавлен");
                        break;
                    default:
                        choice = 0;
                        break;
                }
            }
            while (choice != 0);
        }
        public virtual void DeleteWordOrTranslation()
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы удалить слово," +
                    "\n\t2 - чтобы удалить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно удалить: ");
                        string wordToDelete = Console.ReadLine();
                        dict.DeleteWord(wordToDelete);
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно удалить перевод: ");
                        string wordToDeleteTranslate = Console.ReadLine();
                        Console.Write("\n\tВведите перевод слова, который нужно удалить: ");
                        string translationToDelete = Console.ReadLine();
                        dict.DeleteTranslation(wordToDeleteTranslate, translationToDelete);
                        break;
                    default:
                        choice = 0;
                        break;
                }
            }
            while (choice != 0);
        }
        public virtual void DeleteWordOrTranslation(ref MyDictionary dictionary)
        {
            int choice = 0;
            do
            {
                Console.Write("\n\tНажмите 1, чтобы удалить слово," +
                    "\n\t2 - чтобы удалить перевод" +
                    "\n\t 0 - вернуться в главное меню");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("\n\tВведите слово, которое нужно удалить: ");
                        string wordToDelete = Console.ReadLine();
                        dictionary.DeleteWord(wordToDelete);
                        break;
                    case 2:
                        Console.Write("\n\tВведите слово, которому нужно удалить перевод: ");
                        string wordToDeleteTranslate = Console.ReadLine();
                        Console.Write("\n\tВведите перевод слова, который нужно удалить: ");
                        string translationToDelete = Console.ReadLine();
                        dictionary.DeleteTranslation(wordToDeleteTranslate, translationToDelete);
                        break;
                    default:
                        choice=0;
                        break;
                }
            }
            while (choice != 0);
        }
        
        public virtual Word SearchWord()
        {
            Console.WriteLine("\n\tВведите слово для поиска: ");
            string word = Console.ReadLine();
            Word tmp = dict.SearchWord(word);
            return tmp;
        }

        public virtual void ExportWordToFile(ref Word word)
        {
            //Word tmp=SearchWord();
            Console.WriteLine("\n\tВведите название файла для сохранения: ");
            string path = Console.ReadLine();
            using (FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(file, Encoding.UTF8))
            {
                writer.WriteLine(word);
            }
        }

        //public virtual void SaveDictionary(BinaryFile file)
        //{

        //}
    }
}
