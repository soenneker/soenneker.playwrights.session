[![](https://img.shields.io/nuget/v/soenneker.playwrights.session.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.playwrights.session/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.playwrights.session/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.playwrights.session/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.playwrights.session.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.playwrights.session/)

# Soenneker.Playwrights.Session

Represents a Playwright browser session, including a browser context and an active page, with support for asynchronous disposal.

## Install

```bash
dotnet add package Soenneker.Playwrights.Session
```

## What you get

- `IBrowserSession` — Represents a Playwright browser session, including a browser context and an active page, with support for asynchronous disposal.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IBrowserSession.Page` | Gets the active `IPage` associated with the browser session. | Gets the active `IPage` associated with the browser session. |
| `IBrowserSession.Context` | Gets the underlying `IBrowserContext` for advanced scenarios. | Gets the underlying `IBrowserContext` for advanced scenarios. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
