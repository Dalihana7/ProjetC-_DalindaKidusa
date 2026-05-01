# TaskFlow API

API REST de gestion de projets et de tâches, développée en ASP.NET Core 7 avec Entity Framework Core et SQLite.

## Membres du projet
- Dalinda Djelassi — Authentification, modèles, base de données
- Kidusa — Controllers, services, CRUD

## Technologies utilisées
- ASP.NET Core 7
- Entity Framework Core 7 (SQLite)
- JWT (JSON Web Token)
- BCrypt.Net
- Swagger / OpenAPI

## Installation

### Prérequis
- .NET SDK 7.0 ou supérieur

### Lancer le projet
```bash
git clone https://github.com/Dalihana7/ProjetC-_DalindaKidusa.git
cd TaskFlow.Api/TaskFlow.Api
dotnet restore
dotnet ef database update
dotnet run
```

Swagger disponible sur : http://localhost:5181

## Authentification JWT

### 1. Créer un compte
POST /api/users/register
```json
{
  "name": "Votre nom",
  "email": "email@example.com",
  "password": "motdepasse"
}
```

### 2. Se connecter
POST /api/users/login
```json
{
  "email": "email@example.com",
  "password": "motdepasse"
}
```

### 3. Utiliser le token
Cliquer sur **Authorize** dans Swagger et coller le token reçu.

## Endpoints

### Utilisateurs (publics)
| Méthode | Route | Description |
|---|---|---|
| POST | /api/users/register | Inscription |
| POST | /api/users/login | Connexion |

### Projets (JWT requis)
| Méthode | Route | Description |
|---|---|---|
| GET | /api/projects | Liste tous les projets |
| POST | /api/projects | Crée un projet |
| GET | /api/projects/{id} | Récupère un projet |
| PUT | /api/projects/{id} | Met à jour un projet |
| DELETE | /api/projects/{id} | Supprime un projet |

### Tâches (JWT requis)
| Méthode | Route | Description |
|---|---|---|
| GET | /api/tasks | Liste toutes les tâches |
| POST | /api/tasks | Crée une tâche |
| GET | /api/tasks/{id} | Récupère une tâche |
| PUT | /api/tasks/{id} | Met à jour une tâche |
| DELETE | /api/tasks/{id} | Supprime une tâche |

## Base de données
Générée via Entity Framework Core :
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Codes HTTP
| Code | Signification |
|---|---|
| 200 | Succès |
| 201 | Ressource créée |
| 204 | Suppression réussie |
| 400 | Données invalides |
| 401 | Non authentifié |
| 404 | Ressource introuvable |
| 409 | Conflit (email déjà utilisé) |