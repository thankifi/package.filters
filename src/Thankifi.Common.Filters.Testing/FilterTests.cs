using Thankifi.Common.Filters.Abstractions;

namespace Thankifi.Common.Filters.Testing;

public class FilterTests
{
    private IFilterService _service = null!;

    [SetUp]
    public void Setup()
    {
        _service = new FilterService(new IFilter[]
        {
            new BinaryFilter(),
            // new BottomifyFilter(),
            new LeetFilter(),
            new MockFilter(),
            new ShoutingFilter()
        });
    }

    [Test]
    public async Task CanDoBinary()
    {
        var text = await _service.Apply("binary", "This is a Test");
        
        Assert.That(text, Is.EqualTo("10101001101000110100111100111000001101001111001110000011000011000001010100110010111100111110100"));
    }

    // [Test]
    // public async Task CanDoBottomify()
    // {
    //     var text = await _service.Apply("bottomify", "This is a Test");
    //     
    //     Assert.That(text, Is.EqualTo(""));
    // }

    [Test]
    public async Task CanDoLeet()
    {
        var text = await _service.Apply("leet", "This is a Test");
        
        Assert.That(text, Is.EqualTo("7h15 15 4 7357"));
    }

    [Test]
    public async Task CanDoMock()
    {
        var text = await _service.Apply("mock", "This is a Test");
        
        Assert.That(text, Is.EqualTo("tHiS iS a TeSt"));
    }

    [Test]
    public async Task CanDoShouting()
    {
        var text = await _service.Apply("shouting", "This is a Test");
        
        Assert.That(text, Is.EqualTo("THIS IS A TEST"));
    }
}