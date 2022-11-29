using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyKingdom
{
    public static class UserInterface
    {
        private const int _MaxTextLineLength = 100;
        private const int _CountOfDefaultSybols = 6;

        public static void ShowText(string textForWrite, ConsoleColor consoleTextColor = ConsoleColor.White, bool separators = true, bool downSeparator = true, bool upSeparator = true)
        {
            if (separators && upSeparator)
            {
                Console.Write("\n");

                for (int i = 0; i < _MaxTextLineLength; i++)//Def separator
                    Console.Write('#');
            }

            string[] _tempStrSplited = textForWrite.Split(' ');

            for(int i = 0; i < _tempStrSplited.Length; i++)
            {
                Console.Write($"\n##");

                int _tempSumatorOfWords = 0;

                for (; i < _tempStrSplited.Length; i++)
                {
                    if ((_tempSumatorOfWords + _tempStrSplited[i].Length + 1) < _MaxTextLineLength - _CountOfDefaultSybols)
                    {
                        Console.ForegroundColor = consoleTextColor;
                        _tempSumatorOfWords += _tempStrSplited[i].Length + 1;//+1 - char of empty space
                        Console.Write($" {_tempStrSplited[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        i--;
                        break;
                    }
                }

                for (int j = _tempSumatorOfWords; j < _MaxTextLineLength - _CountOfDefaultSybols + 1; j++) // + 1 - we put ' ' before, but it's def cymbol
                    Console.Write(' ');

                Console.Write($" ##");
            }
            
            if (separators && downSeparator)
            {
                Console.Write("\n");

                for (int i = 0; i < _MaxTextLineLength; i++)//Def end
                    Console.Write('#');
            }
        }
        public static void ShowTextFromArray(string[] linesOfText, bool separators = true)
        {
            for(int i = 0; i < linesOfText.Length; i++)
            {
                if (separators)
                {
                    ShowText(linesOfText[i], ConsoleColor.White, separators);
                }
                else
                {
                    if ((i + 1) == linesOfText.Length)
                        ShowText(linesOfText[i]);
                    else
                        ShowText(linesOfText[i], ConsoleColor.White, true, false);
                }

            }
        }
        /// <summary>
        /// Returns the index of the selected element, if exit, returns -1.
        /// </summary>
        public static int GetSelectOfOne(string[] linesOfTextForChose, string descriptionOfChoice = "", bool isBack = true)
        {
            bool exit = false;
            int selectedLine = 0;

            while (!exit)
            {
                Console.Clear();

                if (descriptionOfChoice != "")
                    ShowText(descriptionOfChoice, ConsoleColor.Blue, true, false);

                for (int i = 0; i < linesOfTextForChose.Length; i++)
                {
                    if (selectedLine == i)
                        ShowText(linesOfTextForChose[i], ConsoleColor.Green, true, false);
                    else
                        ShowText(linesOfTextForChose[i], ConsoleColor.White, true, false);
                }

                if (isBack)
                {
                    if (selectedLine == linesOfTextForChose.Length)
                        ShowText("Выйти", ConsoleColor.Green);
                    else
                        ShowText("Выйти");
                }

                ConsoleKey inputKey = Console.ReadKey().Key;

                if ((inputKey == ConsoleKey.Enter) || (inputKey == ConsoleKey.E)) 
                {
                    if (selectedLine == linesOfTextForChose.Length)
                        return -1;
                    exit = true;
                } 
                else if((inputKey == ConsoleKey.DownArrow)||(inputKey== ConsoleKey.S))
                {
                    if (selectedLine < linesOfTextForChose.Length)
                        selectedLine++;
                }
                else if ((inputKey == ConsoleKey.UpArrow) || (inputKey == ConsoleKey.W))
                {
                    if (selectedLine > 0)
                        selectedLine--;
                }
            }
            return selectedLine;
        }
        public static int ShowAndGetSelectInMainMenu(float actualGameVersion)
        {
            ShowTextFromArray(new string[] { "Мы рады приветствовать вас в нашей игре.", $"Текущая версия игры {actualGameVersion}", "", "Надеемся, что вам хоть немножечко понравиться." });
            Thread.Sleep(3000);
            return GetSelectOfOne(new string[] { "Новая игра", "Загрузить", "Сохранить" }, "Для выбора используйте стелочки, или клавиши W | S");
        }
        public static int ShowAndGetSelectInGameMenu()
        {
            return GetSelectOfOne(new string[] { "Отправиться в подземелья", "Отправиться в город"}, $"Для выбора используйте стелочки, или клавиши W | S");
        }
    }
}
