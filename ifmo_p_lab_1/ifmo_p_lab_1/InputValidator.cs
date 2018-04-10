using System;
using System.Text.RegularExpressions;

namespace Petar.IFMO.sem_2.programming.lab_1
    {
    static class InputValidator
        {

        #region Fields

        private static Regex ISBNChecker = new Regex(@"^978-\d-\d{5}-\d{3}-\d$");
        private static Regex DateChecker = new Regex(@"^\d{2}\.\d{2}\.\d{4}$");

        #endregion

        #region Methods

        internal static Boolean CheckMenuAction(String input)
            {
            if (input != "1" && input != "2" && input != "3" && input != "4")
                {
                return false;
                }
            return true;
            }

        internal static Boolean CheckCharacteristicInput(String characteristic, String input)
            {
            switch (characteristic)
                {
                case "name":
                    // 1. Check length
                    if (input.Length < 1 || input.Length > 256)
                        {
                        return false;
                        }
                    // 2. Check whitespaces in the beginning and in the end of the input
                    if (input[0] == ' ' || input[input.Length - 1] == ' ')
                        {
                        return false;
                        }
                    break;
                case "author":
                    // 1. Check length
                    if (input.Length < 1 || input.Length > 256)
                        {
                        return false;
                        }
                    // 2. Check whitespaces in the beginning and in the end of the input
                    if (input[0] == ' ' || input[input.Length - 1] == ' ')
                        {
                        return false;
                        }
                    // 3. Check if there are two or more whitespaces next to each other
                    for (Int32 i = 1; i < input.Length; i++)
                        {
                        if (input[i] == ' ' && input[i - 1] == ' ')
                            {
                            return false;
                            }
                        }
                    break;
                case "annotation":
                    // 1. Check length
                    if (input.Length > 256)
                        {
                        return false;
                        }
                    break;
                case "ISBN":
                    // 1. Check if regular expressions for ISBN matches the input
                    if (ISBNChecker.IsMatch(input) == false)
                        {
                        return false;
                        }
                    break;
                case "publicationDate":
                    // 1. Check if regular expressions for date matches the input
                    if (DateChecker.IsMatch(input) == false)
                        {
                        return false;
                        }
                    break;
                }
            return true;
            }

        #endregion

        }
    }
