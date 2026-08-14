# Tennis Kata - ASP.NET Core Implementation

A domain-driven C# implementation of the classic Tennis Kata built using Test-Driven Development (TDD) principles, xUnit, and exposed via an ASP.NET Core Web API with Swagger UI.

---

## Architecture & Project Structure

```text
TennisKata/
├── TennisKata.slnx          # XML Solution file
├── README.md                # Project documentation & instructions
├── src/
│   ├── TennisKata.Core/     # Domain model & tennis scoring logic
│   └── TennisKata.Api/      # ASP.NET Core Web API & Swagger UI
└── tests/
    └── TennisKata.Tests/    # xUnit unit test suite
```
---

## Prerequisites 

.NET SDK 8.0 or 0.9

---

## Getting Started

To clone the repository:
```bash
git clone https://github.com/vickykasou/TennisKata.git
```
To build the solution:
```bash
dotnet build
```

---

## Running the Tests

To run the complete test suite:
```bash
dotnet test
```

All unit and parametrized theory tests will execute, validating:
1. Standard point progressions (Love, 15, 30, 40)
2. Tied Scores (Love-All, Fifteen-All, Thirty-All)
3. Extended Deuce and Advantge cycles
4. Asymmetric and standard Win conditions

---

## Running the Web API & Swagger UI

To start the local ASP.NET Core Web API server:
```bash
dotnet run --project src/TennisKata.Api
```

Once started, open your browser and navigate to:
http://localhost:5124/swagger

Available Endpoints:
1. GET /api/tennis/score: Retrieves the current match score (e.g., {"score": "Love-All"}).
2. POST /api/tennis/point: Awards a point to a player by passing a JSON body (e.g., {"playerName": "Player 1"}).
3. POST /api/tennis/reset: Resets the match state back to 0-0 (Love-All).
