using System.Threading.Tasks;
using Microsoft.Playwright;
using Soenneker.Playwrights.Session.Abstract;

namespace Soenneker.Playwrights.Session;

///<inheritdoc cref="IBrowserSession"/>
public sealed class BrowserSession : IBrowserSession
{
    private readonly bool _ownsContext;
    private readonly bool _ownsPage;

    public IBrowserContext Context { get; }

    public IPage Page { get; }

    public BrowserSession(IBrowserContext context, IPage page, bool ownsContext = true, bool ownsPage = true)
    {
        Context = context;
        Page = page;
        _ownsContext = ownsContext;
        _ownsPage = ownsPage;
    }

    public async ValueTask DisposeAsync()
    {
        if (_ownsPage && !Page.IsClosed)
            await Page.CloseAsync();

        if (_ownsContext)
            await Context.DisposeAsync();
    }
}