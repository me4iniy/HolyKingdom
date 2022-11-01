﻿using System;
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
        
        public static void ShowText(string textForWrite, ConsoleColor consoleTextColor = ConsoleColor.White, bool separators = true)
        {
            if (separators)
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
            Console.Write("\n");
            if (separators)
            {
                for (int i = 0; i < _MaxTextLineLength; i++)//Def end
                    Console.Write('#');
            }
        }

        /// <summary>
        /// Returns the index of the selected element, if exit, returns -1.
        /// </summary>
        
        public static int GetSelectOfOne(string[] linesOfTextForChose)
        {
            bool exit = false;
            int selectedLine = 0;

            while (!exit)
            {
                Console.Clear();

                for (int i = 0; i < linesOfTextForChose.Length; i++)
                    if (selectedLine == i)
                        ShowText(linesOfTextForChose[i], ConsoleColor.Green);
                    else
                        ShowText(linesOfTextForChose[i]);

                if (selectedLine == linesOfTextForChose.Length)
                    ShowText("Выйти", ConsoleColor.Green);
                else
                    ShowText("Выйти");

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
        public static void ShowTextFromArray(string[] linesOfText)
        {
            foreach (string lineOfText in linesOfText)
                ShowText(lineOfText, ConsoleColor.White, false);
        }
    }
}
