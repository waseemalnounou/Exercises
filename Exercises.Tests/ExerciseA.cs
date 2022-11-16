namespace Exercises.Utils;

public class TestConvertStingToNumber
{
    [Fact]
    public void Is_ConvertToNumber_Return_Valid_Number()
    {
        // Arrange
        string firstNum = "1234";
        string NegNum = "-1234";
        string PosNum = "+1234";
        string invalidNum1 = "+";
        string invalidNum2 = "12AA";

        int expectedNum = 1234;
        int expectedNegativeNum = -1234;
        string expectedLengthError = "Input Length sould be greater than 0";
        string expectedInvalidNumberError = "Invalid Number";

        StringAsNumber str1 = new StringAsNumber(firstNum);
        StringAsNumber str2 = new StringAsNumber(PosNum);
        StringAsNumber str3 = new StringAsNumber(NegNum);
        StringAsNumber str4 = new StringAsNumber("");
        StringAsNumber str5 = new StringAsNumber(invalidNum1);
        StringAsNumber str6 = new StringAsNumber(invalidNum2);

        // Act 
        var num1 = str1.ConvertToNumber();
        var num2 = str2.ConvertToNumber();
        var num3 = str3.ConvertToNumber();

        // Assert

        Assert.Equal(num1, expectedNum);
        Assert.Equal(num2, expectedNum);
        Assert.Equal(num3, expectedNegativeNum);

        var error1 = Assert.Throws<Exception>(()=> str4.ConvertToNumber());
        var error2 = Assert.Throws<Exception>(()=> str5.ConvertToNumber());
        var error3 = Assert.Throws<Exception>(()=> str5.ConvertToNumber());
        Assert.Equal(error1.Message, expectedLengthError);
        Assert.Equal(error2.Message, expectedInvalidNumberError);
        Assert.Equal(error3.Message, expectedInvalidNumberError);
    }
}
