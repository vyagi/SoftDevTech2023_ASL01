using FluentAssertions;

namespace SingletonPattern.Tests;

public class SingletonTests
{
    [Fact]
    public void Instance_can_be_created_and_the_date_of_creation_is_correct()
    {
        var s = Singleton.GetInstance();

        s.Should().NotBeNull();
        s.CreatedAt.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(100));
    }

    [Fact]
    public void There_should_be_only_one_instance_of_singleton()
    {
        var s1 = Singleton.GetInstance();
        var s2 = Singleton.GetInstance();

        ReferenceEquals(s1, s2).Should().BeTrue();
        s1.CreatedAt.Should().Be(s2.CreatedAt);
    }

    [Fact]
    public void There_should_be_only_one_instance_of_singleton_in_multithreaded_application()
    {
        Singleton s1 = null;
        Singleton s2 = null;

        Task task1 = Task.Factory.StartNew(() => s1 = Singleton.GetInstance());
        Task task2 = Task.Factory.StartNew(() => s2 = Singleton.GetInstance());

        Task.WaitAll(task1, task2);

        ReferenceEquals(s1, s2).Should().BeTrue();
        s1.CreatedAt.Should().Be(s2.CreatedAt);
    }
}