using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.KnuthMorrisPratt
{
    public class KnuthMorrisPratt
    {
        public static List<int> KMPSearch(string text, string searchWord)
        {
            var result = new List<int>();
            var txtLength = text.Length;
            var wordLength = searchWord.Length;

            int[] prefixPattren = new int[wordLength];
            LongestPrefixPattren(searchWord, prefixPattren);

            int wordIterator = 0;
            int textIterator = 0;
            while (textIterator<txtLength)
            {
                if (searchWord[wordIterator] == text[textIterator])
                {
                    textIterator++;
                    wordIterator++;
                }

                if (wordIterator == wordLength)
                {
                    result.Add(textIterator - wordIterator);
                    wordIterator = prefixPattren[wordIterator - 1];
                }
                else if (textIterator < txtLength && searchWord[wordIterator] != text[textIterator])
                {
                    if (wordIterator != 0)
                    {
                        wordIterator = prefixPattren[wordIterator - 1];
                    }
                    else
                    {
                        textIterator++;
                    }
                }
            }

            return result;
        }

        private static void LongestPrefixPattren(string searchWord, int[] prefixPattren)
        {
            var len = 0;
            var i = 1;
            prefixPattren[0] = 0;
            var searchWordLength = searchWord.Length;


            while (i< searchWordLength)
            {
                if (searchWord[i] == searchWord[len])
                {
                    len++;
                    prefixPattren[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = prefixPattren[len - 1];
                    }
                    else
                    {
                        prefixPattren[i] = len;
                        i++;
                    }
                }
            }
        }
    }
}
