using System.Text;

namespace BuilderPattern.Core.InitialProposition;
public interface IDocumentBuilder
{
    IDocumentBuilder Reset();
    IDocumentBuilder WriteTitle(string text);
    IDocumentBuilder WriteParagraph(string text);

    string Build();
}

public class HtmlDocumentBuilder : IDocumentBuilder
{
    StringBuilder _sb = new StringBuilder();
    public IDocumentBuilder Reset()
    {
        _sb.Clear();
        return this;
    }

    public IDocumentBuilder WriteTitle(string text)
    {
        _sb.Append("<h1>");
        _sb.Append(text);
        _sb.Append("</h1>");
        return this;
    }

    public IDocumentBuilder WriteParagraph(string text)
    {
        _sb.Append("<p>");
        _sb.Append(text);
        _sb.Append("</p>");
        return this;
    }


    public string Build() => _sb.ToString();

}


public class MarkDownDocumentBuilder : IDocumentBuilder
{
    private StringBuilder _sb = new();

    public IDocumentBuilder Reset()
    {
        _sb.Clear();
        return this;
    }

    public IDocumentBuilder WriteTitle(string text)
    {
        _sb.Append("\n#");
        _sb.Append(text);
        return this;
    }

     public IDocumentBuilder WriteParagraph(string text)
    {
        _sb.Append("\n");
        _sb.Append(text);
        return this;
    }

    public string Build() => _sb.ToString();
}


class Director 
{
    public void BuildWelcomePage(IDocumentBuilder builder)
    {
        builder
            .Reset()
            .WriteTitle("Welcome")
            .WriteParagraph("This is the welcome page.");
    }

    public void BuildGoodbyePage(IDocumentBuilder builder)
    {
        builder
            .Reset()
            .WriteTitle("Goodbye")
            .WriteParagraph("This is the goodbye page");
    }
}


//Fere Liskov
class CompositeBuilder : IDocumentBuilder
{
    public readonly List<IDocumentBuilder> Leafs = new();
    public IDocumentBuilder Reset()
    {
        Leafs.ForEach(b => b.Reset());
        return this;
    }

    public IDocumentBuilder WriteTitle(string text)
    {
        Leafs.ForEach(b => b.WriteTitle(text));
        return this;
    }
    public IDocumentBuilder WriteParagraph(string text)
    {
        Leafs.ForEach(b => b.WriteParagraph(text));
        return this;
    }

    public string Build()
    {
        throw new NotSupportedException();
    }

}


// Usar a composição sem ferir Liskov - Segregation Interface Principle (I - SOLID) Segregação por interface

interface IDocumentWriter
{
    IDocumentWriter Reset();
    IDocumentWriter WriteTitle(string text);
    IDocumentWriter WriteParagraph(string text);
}

interface IDocumentBuilder2 : IDocumentWriter
{
    string Build();
}