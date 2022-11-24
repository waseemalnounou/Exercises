namespace Exercises.Utils;

public class TestConvertStingToNumber
{
    [Fact]
    public void Is_ConvertToNumber_Return_Valid_Number()
    {
        // Arrange
        string FirstNum = "1234";
        string NegNum = "-1234";
        string PosNum = "+1234";
        int expectedNum = 1234;
        int expectedNegativeNum = -1234;

        // Act 
        var num1 = StringAsNumber.ConvertToNumber(FirstNum);
        var num2 = StringAsNumber.ConvertToNumber(PosNum);
        var num3 = StringAsNumber.ConvertToNumber(NegNum);

        // Assert
        Assert.Equal(num1, expectedNum);
        Assert.Equal(num2, expectedNum);
        Assert.Equal(num3, expectedNegativeNum);
    }

    [Fact]
    public void ConvertToNumber_Throughing_Error()
    {
        // Arrange
        string InvalidNum1 = "+";
        string InvalidNum2 = "12AA";
        string expectedLengthError = "Input Length sould be greater than 0";
        string expectedInvalidNumberError = "Invalid Number";

        // Act 
        var error1 = Assert.Throws<Exception>(()=> StringAsNumber.ConvertToNumber(""));
        var error2 = Assert.Throws<Exception>(()=> StringAsNumber.ConvertToNumber(InvalidNum1));
        var error3 = Assert.Throws<Exception>(()=> StringAsNumber.ConvertToNumber(InvalidNum2));

        // Assert
        Assert.Equal(error1.Message, expectedLengthError);
        Assert.Equal(error2.Message, expectedInvalidNumberError);
        Assert.Equal(error3.Message, expectedInvalidNumberError);
    }
}
