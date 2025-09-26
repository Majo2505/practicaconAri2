🎬 Cinema API Challenge
🎯 Objetivo

Construir una API REST desde cero en ASP.NET Core que exponga CRUD para 2 recursos:

Movies

Tickets

y listados con:

Paginación (page, limit)

Ordenamiento (sort, order)

Respuesta estandarizada { data, meta }

⚠️ No se pide autenticación, CORS ni filtros avanzados.

👥 Organización y Git Flow

Rama de equipo:

git checkout -b cinema/teamXX


Subramas por feature:

cinema/teamXX-movies

cinema/teamXX-tickets

Merge de cada subrama → cinema/teamXX

Solo se revisará la rama principal del equipo.

📦 Modelos y DTOs esperados
Movie
Movie(
    Guid Id,
    string Title,
    string Genre,
    DateTime ReleaseDate,
    int DurationMinutes,
    bool Available
)

Ticket
Ticket(
    Guid Id,
    Guid MovieId,
    string BuyerName,
    DateTime PurchaseDate,
    decimal Price
)

📦 DTOs obligatorios

CreateMovieDto

UpdateMovieDto

CreateTicketDto

UpdateTicketDto

📌 Endpoints obligatorios
Movies

GET /api/v1/movies (lista con paginación y orden)

GET /api/v1/movies/{id}

POST /api/v1/movies

PUT /api/v1/movies/{id}

DELETE /api/v1/movies/{id}

Tickets

GET /api/v1/tickets (lista con paginación y orden)

GET /api/v1/tickets/{id}

POST /api/v1/tickets

PUT /api/v1/tickets/{id}

DELETE /api/v1/tickets/{id}

🔍 Query Params comunes

page (default 1, min 1)

limit (default 10, rango 1–100)

sort (campo permitido por recurso, ej: title, releaseDate, purchaseDate, price)

order (asc | desc, default asc)

📤 Respuesta estándar
{
  "data": [ /* items */ ],
  "meta": { "page": 1, "limit": 10, "total": 134 }
}

✅ Reglas HTTP

201 Created → al crear

200 OK → al leer/actualizar

204 No Content → al borrar

400 Bad Request → validación fallida

404 Not Found → recurso inexistente

Ejemplo error:

{ "error": "Movie not found", "status": 404 }

🧪 Ejemplos JSON
POST /api/v1/movies
{
  "title":"Inception",
  "genre":"Sci-Fi",
  "releaseDate":"2010-07-16T00:00:00Z",
  "durationMinutes":148,
  "available":true
}

POST /api/v1/tickets
{
  "movieId":"00000000-0000-0000-0000-000000000001",
  "buyerName":"Carlos Pérez",
  "purchaseDate":"2025-09-25T20:00:00Z",
  "price":7.50
}

🔗 Ejemplos de URLs
/api/v1/movies?page=1&limit=5&sort=title&order=asc
/api/v1/tickets?sort=purchaseDate&order=desc&page=2&limit=10

🧾 Planilla de Evaluación (100 pts)

1) Modelos & DTOs (25 pts)

(10) Modelos correctos (GUID, campos exactos)

(10) DTOs con DataAnnotations adecuados

(5) Defaults correctos (Available=true, PurchaseDate=DateTime.Now)

2) CRUD & HTTP (25 pts)

(10) Endpoints CRUD completos

(10) Códigos HTTP correctos (201/200/204/400/404)

(5) Errores sobrios en JSON

3) Listados (30 pts)

(15) Paginación (page, limit) con normalización

(15) Ordenamiento (sort, order) seguro

4) Respuesta estándar (10 pts)

(10) { data, meta } en todos los listados

5) Proceso & README (10 pts)

(5) Git flow correcto (subramas → merge)

(5) README con endpoints, ejemplos JSON y URLs de listados

✅ Aprobación mínima: 70 pts
