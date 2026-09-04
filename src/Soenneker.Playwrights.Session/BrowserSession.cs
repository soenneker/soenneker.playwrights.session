using System.Threading.Tasks;
using System.Threading;
using Microsoft.Playwright;
using Soenneker.Playwrights.Session.Abstract;

namespace Soenneker.Playwrights.Session;

/// <inheritdoc cref="IBrowserSession" />
public sealed class BrowserSession : IBrowserSession
{
    private readonly bool _ownsContext;
    private readonly bool _ownsPage;
    private int _disposed;

    public IBrowserContext Context { get; }

    public IPage Page { get; }

    /// <summary>
    /// Creates a session around an existing Playwright context and page.
    /// </summary>
    /// <param name="context">Context exposed by the session.</param>
    /// <param name="page">Active page exposed by the session.</param>
    /// <param name="ownsContext">Whether disposing the session also disposes the context and its pages.</param>
    /// <param name="ownsPage">Whether disposing the session closes the page when the context is borrowed.</param>
    public BrowserSession(IBrowserContext context, IPage page, bool ownsContext = true, bool ownsPage = true)
    {
        Context = context;
        Page = page;
        _ownsContext = ownsContext;
        _ownsPage = ownsPage;
    }

    public async ValueTask DisposeAsync()
    {
        if (Interlocked.Exchange(ref _disposed, 1) != 0)
            return;

        if (_ownsContext)
        {
            await Context.DisposeAsync();
            return;
        }

        if (_ownsPage && !Page.IsClosed)
            await Page.CloseAsync();
    }
}
