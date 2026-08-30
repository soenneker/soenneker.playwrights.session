[![](https://img.shields.io/nuget/v/soenneker.playwrights.session.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.playwrights.session/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.playwrights.session/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.playwrights.session/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.playwrights.session.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.playwrights.session/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.playwrights.session/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.playwrights.session/actions/workflows/codeql.yml)

# Soenneker.Playwrights.Session

An ownership-aware wrapper that keeps a Playwright browser context and its active page together behind `IBrowserSession`.

## Installation

```bash
dotnet add package Soenneker.Playwrights.Session
```

## Usage

Create a context and page, then return or pass them as one disposable session:

```csharp
using Microsoft.Playwright;
using Soenneker.Playwrights.Session;
using Soenneker.Playwrights.Session.Abstract;

IBrowserContext context = await browser.NewContextAsync();
IPage page = await context.NewPageAsync();

await using IBrowserSession session = new BrowserSession(context, page);

await session.Page.GotoAsync("https://example.com");
string title = await session.Page.TitleAsync();
```

By default the session owns both objects. Disposing it disposes the context, which closes its pages.

When a context is shared elsewhere, explicitly borrow it and choose whether the session owns only the page:

```csharp
await using IBrowserSession session = new BrowserSession(
    sharedContext,
    await sharedContext.NewPageAsync(),
    ownsContext: false,
    ownsPage: true);
```

Set both ownership flags to `false` when the caller manages both lifetimes. Disposing a session more than once is safe.
