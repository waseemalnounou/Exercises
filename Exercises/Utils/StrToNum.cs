namespace Exercises.Utils;

public class StringAsNumber {

    public static Boolean IsNum(char num){
        return Char.IsDigit(num);
    }

    public static int ConvertToNumber(string text){
        Boolean isNegative = false;
        string newText = text;
        int number = 0;
        
        if(text.Length > 0)
        {
            // handle positive/negative input
            if(text[0] == '-' || text[0] == '+'){
                if(text[0] == '-')
                isNegative = true;

                newText = text.Substring(1);
                if (newText == ""){
                    throw new Exception("Invalid Number");
                }
            }

            for (int i = 0; i< newText.Length; i++)
            {
                // subtract 48 from the ASCII value of the character will give the digit for the character
                if (IsNum(newText[i]))
                number = number * 10 + ((int)newText[i] - 48);
                else{
                    throw new Exception("Invalid Number");
                }
            }

        } else {
            throw new Exception("Input Length sould be greater than 0");
        }

        return isNegative ? number * -1 : number;
    }
}