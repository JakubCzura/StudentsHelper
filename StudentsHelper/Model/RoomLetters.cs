using System.Collections.Generic;

namespace StudentsHelper.Model
{
    public class RoomLetters
    {
        private List<string> letters = new List<string>() {
        " " , "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "U", "P", "R", "S", "T", "U", "W", "Y", "Z", "X" };

        public List<string> Letters
        {
            get { return letters; }
            set { letters = value; }
        }
    }
}