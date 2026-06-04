# RotsPapierSchaar API

Een REST API voor het spel Rots, Papier, Schaar gebouwd met ASP.NET Core .NET 10.

## Vereisten

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) of [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

## Draaien via Visual Studio

1. Open `RotsPapierSchaar.slnx` in Visual Studio 2022
2. Stel `RotsPapierSchaar.Api` in als startup project
3. Druk op **F5** of klik op **Run**

De API is bereikbaar op `http://localhost:5188`.

---

## Draaien via Docker Compose

1. Zorg dat Docker Desktop actief is
2. Open een terminal in de root van het project
3. Voer uit:

```bash
docker compose up --build
```

De API is bereikbaar op `http://localhost:5188`.

---

## HTTP bestand

In `RotsPapierSchaar.Api/RotsPapierSchaar.http` staan kant-en-klare verzoeken voor alle endpoints. Dit bestand kan direct worden uitgevoerd vanuit Visual Studio via de ingebouwde HTTP client.

---

Geldige waarden voor `spelerZet`: `Rots`, `Papier`, `Schaar`
