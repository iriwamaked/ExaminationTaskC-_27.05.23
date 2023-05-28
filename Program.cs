using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationTask_27._05._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuInterfase menu=new SimpleUserMenu();
            IStream fileBin=new BinaryFile();
            int choice = 0;
            do
            {
                menu.ShowMenu();
                Console.WriteLine("\n\tВаш выбор: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n\tУкажите тип словаря, например, англо-украинский");
                        string language = Console.ReadLine();
                        menu.CreateDictionary(language);
                        Console.WriteLine("\n\tСловарь успешно создан. Можно добавлять в него слова и переводы. " +
                            "\n\tНе забудьте сохранить словарь в файл!");
                        break;
                    case 2:
                        Console.WriteLine("\n\tВыберите язык словаря: 1 - англо-украинский; 2 - украино-русский" +
                            "\n\t3 - вновь созданный словарь, 4 - ввести путь к файлу с Вашим словарем.");
                        int langChoice = int.Parse(Console.ReadLine());
                        string path;
                        switch (langChoice)
                        {
                            case 1:
                                MyDictionary engDictionary = new MyDictionary();
                                path = "english";
                                IStream engBin = new BinaryFile();
                                //engBin.LoadDictionary(path, ref engDictionary);
                                if (engBin.LoadDictionary(path, ref engDictionary))
                                {
                                    menu.AddWordOrTranslaTion(ref engDictionary);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    menu.ShowMenu();
                                }
                                
                                break;
                            case 2:
                                MyDictionary ukrDictionary = new MyDictionary();
                                path = "ukrainian";
                                IStream ukrBin = new BinaryFile();
                                if (ukrBin.LoadDictionary(path, ref ukrDictionary))
                                {
                                    menu.AddWordOrTranslaTion(ref ukrDictionary);
                                }
                                else {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    menu.ShowMenu();
                                }
                                break;
                            case 3:
                                menu.AddWordOrTranslaTion();
                                break;
                            case 4:
                                Console.WriteLine("\n\tУкажите тип словаря, например, англо-украинский" +
                                    "\n\tназвание файла должно совпадать с языком для перевода, например, \"english\"");
                                string userPath = Console.ReadLine();
                                MyDictionary userDic = new MyDictionary();
                                if (File.Exists(userPath))
                                {
                                    using (FileStream fs = new FileStream(userPath, FileMode.Open))
                                    {
                                        BinaryFormatter bf = new BinaryFormatter();
                                        userDic = (MyDictionary)bf.Deserialize(fs);
                                    }
                                    menu.dict = userDic;
                                    menu.AddWordOrTranslaTion(ref userDic);
                                }
                                else { Console.WriteLine("\n\tФайл не найден"); }
                                break;
                        }

                        break;
                    case 3:
                        Console.WriteLine("\n\tВыберите язык словаря: 1 - англо-украинский; 2 - украино-русский" +
                            "\n\t3 - вновь созданный словарь, 4 - ввести путь к файлу с Вашим словарем.");
                        int langChoiceToChange = int.Parse(Console.ReadLine());
                        string pathToChange;
                        switch (langChoiceToChange)
                        {
                            case 1:
                                MyDictionary engDictionary = new MyDictionary();
                                pathToChange = "english";
                                IStream engBin = new BinaryFile();
                                //engBin.LoadDictionary(pathToChange, ref engDictionary);
                                if (engBin.LoadDictionary(pathToChange, ref engDictionary))
                                {
                                    menu.ChangeWordOrTranslarion(ref engDictionary);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    menu.ShowMenu();
                                }

                                break;
                            case 2:
                                MyDictionary ukrDictionary = new MyDictionary();
                                pathToChange = "ukrainian";
                                IStream ukrBin = new BinaryFile();
                                if (ukrBin.LoadDictionary(pathToChange, ref ukrDictionary))
                                {
                                    menu.ChangeWordOrTranslarion(ref ukrDictionary);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    menu.ShowMenu();
                                }
                                break;
                            case 3:
                                menu.AddWordOrTranslaTion();
                                break;
                            case 4:
                                Console.WriteLine("\n\tУкажите тип словаря, например, англо-украинский" +
                                    "\n\tназвание файла должно совпадать с языком для перевода, например, \"english\"");
                                string userPathToChange = Console.ReadLine();
                                MyDictionary userDic = new MyDictionary();
                                if (File.Exists(userPathToChange))
                                {
                                    using (FileStream fs = new FileStream(userPathToChange, FileMode.Open))
                                    {
                                        BinaryFormatter bf = new BinaryFormatter();
                                        userDic = (MyDictionary)bf.Deserialize(fs);
                                    }
                                    //menu.dict = userDic;
                                    menu.ChangeWordOrTranslarion(ref userDic);
                                }
                                else { Console.WriteLine("\n\tФайл не найден"); }
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("\n\tВыберите язык словаря: 1 - англо-украинский; 2 - украино-русский" +
                          "\n\t3 - вновь созданный словарь, 4 - ввести путь к файлу с Вашим словарем.");
                        int langChoiceToDelete = int.Parse(Console.ReadLine());
                        string pathToDelete;
                        switch (langChoiceToDelete)
                        {
                            case 1:
                                MyDictionary engDictionary = new MyDictionary();
                                pathToDelete = "english";
                                IStream engBin = new BinaryFile();
                                //engBin.LoadDictionary(pathToChange, ref engDictionary);
                                if (engBin.LoadDictionary(pathToDelete, ref engDictionary))
                                {
                                    menu.DeleteWordOrTranslation(ref engDictionary);
                                    engBin.SaveDictionary(pathToDelete, ref engDictionary);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    //menu.ShowMenu();
                                }

                                break;
                            case 2:
                                MyDictionary ukrDictionary = new MyDictionary();
                                pathToDelete = "ukrainian";
                                IStream ukrBin = new BinaryFile();
                                if (ukrBin.LoadDictionary(pathToDelete, ref ukrDictionary))
                                {
                                    menu.DeleteWordOrTranslation(ref ukrDictionary);
                                    ukrBin.SaveDictionary(pathToDelete, ref ukrDictionary);
                                }
                        
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                    //menu.ShowMenu();
                                }
                                break;
                            case 3:
                                menu.DeleteWordOrTranslation();
                                
                                break;
                            case 4:
                                Console.WriteLine("\n\tУкажите тип словаря, например, англо-украинский" +
                                    "\n\tназвание файла должно совпадать с языком для перевода, например, \"english\"");
                                string userPathToDelete = Console.ReadLine();
                                MyDictionary userDic = new MyDictionary();
                                IStream userBin = new BinaryFile();
                                if (userBin.LoadDictionary(userPathToDelete, ref userDic))
                                {
                                    menu.DeleteWordOrTranslation(ref userDic);
                                    userBin.SaveDictionary(userPathToDelete, ref userDic);
                                }
                               
                                else { Console.WriteLine("\n\tФайл не найден"); }
                                break;
                        }

                        break;
                    case 5:
                        Console.WriteLine("\n\tВыберите язык словаря: 1 - англо-украинский; 2 - украино-русский" +
                         "\n\t3 - вновь созданный словарь, 4 - ввести путь к файлу с Вашим словарем.");
                        int langChoiceToSearch = int.Parse(Console.ReadLine());
                        string pathToSearch;
                        switch (langChoiceToSearch)
                        {
                            case 1:
                                MyDictionary engDictionary = new MyDictionary();
                                pathToSearch = "english";
                                IStream engBin = new BinaryFile();
                                Console.WriteLine("\n\tВведите слово для поиска: ");
                                string wordToSearch = Console.ReadLine();
                                if (engBin.LoadDictionary(pathToSearch, ref engDictionary))
                                {
                                    engDictionary.SearchWord(wordToSearch);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                }
                                break;
                            case 2:
                                MyDictionary ukrDictionary = new MyDictionary();
                                pathToSearch = "ukrainian";
                                IStream ukrBin = new BinaryFile();
                                Console.WriteLine("\n\tВведите слово для поиска: ");
                                wordToSearch = Console.ReadLine();
                                if (ukrBin.LoadDictionary(pathToSearch, ref ukrDictionary))
                                {
                                    ukrDictionary.SearchWord(wordToSearch);
                                }
                                else
                                {
                                    Console.WriteLine("\n\tФайл со словарем не найден. Возвращаем в главное меню");
                                }
                                break;
                            case 3:
                                menu.SearchWord();
                                break;
                            case 4:
                                Console.WriteLine("\n\tУкажите тип словаря, например, англо-украинский" +
                                    "\n\tназвание файла должно совпадать с языком для перевода, например, \"english\"");
                                string userPathToSearch = Console.ReadLine();
                                MyDictionary userDic = new MyDictionary();
                                IStream userBin = new BinaryFile();
                                //BinaryFile userBin = new BinaryFile();
                                Console.WriteLine("\n\tВведите слово для поиска: ");
                                wordToSearch = Console.ReadLine();
                                Word tmp = new Word(wordToSearch);
                                if (userBin.LoadDictionary(userPathToSearch, ref userDic))
                                {
                                    
                                    tmp=userDic.SearchWord(wordToSearch);
                                }

                                else { Console.WriteLine("\n\tФайл не найден"); }
                                Console.WriteLine("\n\tСохранить результаты поиска в файл? 1- да, 0 - нет.");
                                int save = int.Parse(Console.ReadLine());
                                if (save == 1)
                                {
                                    menu.ExportWordToFile(ref tmp);
                                }
                                break;
                        }
                        break;
                    case 6:
                        Console.WriteLine("\n\tВведите название файла для сохранения словаря");
                        string pathToSaveDictionary = Console.ReadLine();
                        IStream dictSave = new BinaryFile();
                        dictSave.SaveDictionary(pathToSaveDictionary,ref menu.dict);

                        break;
                    case 7:
                        Console.WriteLine("\n\tСловарь: " + menu.dict.ToString());
                        break;
                }
            }
            while (choice != 0);

        }
    }
}
