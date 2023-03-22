using Questions.Interviews_CSharp.DesignPatterns.Creation;

namespace Questions.Interviews_CSharp.Test;

public class FactoryTest
{
    [Fact]
    public void Factory_ShouldCreatePeugeot_When_PeugeotAsked()
    {
        string expectedName = "Peugeot";
        var actual = Factory.CreateAuto(expectedName);
        Assert.Equal(expectedName, actual.Name);
    }

    [Fact]
    public void Factory_ShouldCreateRenault_When_RenaultAsked()
    {
        var expectedName = "Renault";
        var actual = Factory.CreateAuto(expectedName);
        Assert.Equal(expectedName, actual.Name);
    }
}