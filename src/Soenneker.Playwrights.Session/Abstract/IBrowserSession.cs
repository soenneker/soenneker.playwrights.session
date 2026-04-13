using System;
using Microsoft.Playwright;

namespace Soenneker.Playwrights.Session.Abstract;

/// <summary>
/// Represents a Playwright browser session, including a browser context and an active page,
/// with support for asynchronous disposal.
/// </summary>
public interface IBrowserSession : IAsyncDisposable
{
    /// <summary>
    /// Gets the active <see cref="IPage"/> associated with the browser session.
    /// </summary>
    IPage Page { get; }

    /// <summary>
    /// Gets the underlying <see cref="IBrowserContext"/> for advanced scenarios.
    /// </summary>
    IBrowserContext Context { get; }
}