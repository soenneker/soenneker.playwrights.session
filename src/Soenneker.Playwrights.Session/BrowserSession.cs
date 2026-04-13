using System.Threading.Tasks;
using Microsoft.Playwright;
using Soenneker.Playwrights.Session.Abstract;

namespace Soenneker.Playwrights.Session;

///<inheritdoc cref="IBrowserSession"/>
public sealed class BrowserSession : IBrowserSession
{
    public IBrowserContext Context { get; }

    public IPage Page { get; }

    public BrowserSession(IBrowserContext context, IPage page)
    {
        Context = context;
        Page = page;
    }

    public ValueTask DisposeAsync()
    {
        return Context.DisposeAsync();
    }
}