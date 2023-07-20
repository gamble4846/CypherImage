using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherImage.Utility
{
    public static class CommonFunctions
    {
        public static int GetMovesCountByKey(string Key)
        {
            int MovesCounts = 5;
            if(!String.IsNullOrEmpty(Key))
            {
                MovesCounts = 0;
                foreach(var character in Key)
                {
                    MovesCounts += GetCharacterInNumber(character);
                }
            }
            return MovesCounts;
        }

        private static int GetCharacterInNumber(char character)
        {
            char[] CharacterList = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '`', '~', '[', '{', '}', ']', ';', '"', ':', ',', '<', '>', '.', '?', '/', '|'};
            return CharacterList.ToList().FindIndex(x => x == character) + 1;
        }
    }
}
