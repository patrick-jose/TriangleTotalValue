using Microsoft.Extensions.Logging;
using Moq;
using TriangleTotalValue.Controllers;
using TriangleTotalValue.Domain;

namespace TriangleTotalValue.Tests;

[TestClass]
public class UnitTests
{
    private ILogger<TriangleTotalValueController> _logger;
    private static string fileLocation = "../../../txtCases/";

    void Initialize()
    {
        var mockLogger = new Mock<ILogger<TriangleTotalValueController>>();
        this._logger = mockLogger.Object;
    }

    [TestMethod]
    [DataRow("example1", 13)]
    [DataRow("example2", 102)]
    [DataRow("example3", 203)]
    [DataRow("example4", 215)]
    [DataRow("example5", 1)]
    [DataRow("example6", 3)]
    [DataRow("example7", 29)]
    [DataRow("Triangle", 512790)]
    public void calculate_triange_total_value_ok(string testFile, int expected)
    {
        Initialize();

        var testStringValue = File.ReadAllText($"{fileLocation}{testFile}.txt");
        var triangle = new Triangle(testStringValue, this._logger);
        var actual = triangle.totalValue;

        Assert.AreEqual(expected, actual);
    }
}
