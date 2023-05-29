using DecoratorPattern;
using FluentAssertions;

namespace DecoratorPatternTests;

public class LoggerTests
{
    [Fact]
    public void SimpleLogger_logs_correctly()
    {
        var logger = new SimpleLogger();

        logger.Log("Hello").Should().Be("Information: Hello");
    }

    [Fact]
    public void TimestampingHashingLogger_logs_correctly()
    {
        var logger = new TimestampingLogger(new HashingLogger(new SimpleLogger()));

        //Assertion
    }

    [Fact]
    public void EncryptingTimestampingLogger_logs_correctly()
    {
        var logger = new EncryptingLogger(new TimestampingLogger(new SimpleLogger()));

        //Assertion
    }

    [Fact]
    public void EncryptingTimestampingHashingTimestampingLogger_logs_correctly()
    {
        var logger = new EncryptingLogger(new TimestampingLogger(new HashingLogger(new TimestampingLogger(new SimpleLogger()))));

        //Assertion
    }


    //[Fact]
    //public void Logger_logs_correctly()
    //{
    //    var logger = new Logger();

    //    logger.Log("Hello").Should().Be("Information: Hello");
    //}


    //[Fact]
    //public void TimestampingLogger_logs_correctly()
    //{
    //    var logger = new TimestampingLogger();

    //    logger.Log("Hello").Should().StartWith("2023"); //Do not hardcode dates in your tests like this ! Never !
    //    logger.Log("Hello").Should().EndWith("Information: Hello");
    //}

    //[Fact]
    //public void HashingLogger_logs_correctly()
    //{
    //    var logger = new HashingLogger();

    //    logger.Log("Hello").Should().NotStartWith("2023"); //Do not hardcode dates in your tests like this ! Never !
    //    logger.Log("Hello").Should().NotEndWith("Information: Hello");
    //}

    //[Fact]
    //public void EncryptingLogger_logs_correctly()
    //{
    //    var logger = new EncryptingLogger();

    //    logger.Log("Hello").Should().StartWith("Encrypted: ");
    //    logger.Log("Hello").Should().EndWith("Information: Hello");
    //}
}