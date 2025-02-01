# Gym & Fitness Guide - Backend

## 📌 Descripción
Este es el backend del proyecto **Gym & Fitness Guide**, desarrollado en **.NET 8**, que proporciona endpoints para gestionar usuarios, preguntas, respuestas y recomendaciones.

## 🚀 Tecnologías utilizadas
- 💻 **.NET 8** (C#)
- 🏠 **ASP.NET Core Web API**
- 🛢 **Entity Framework Core** (ORM)
- 🗄 **MySQL** (Base de datos)
- 🔥 **Swagger** (Documentación de API)
- 🔄 **Automapper** (Mapear DTOs con Entidades)

## 📂 Estructura del proyecto
```
backend/
│── GymFitnessGuide.API/
│   ├── Controllers/         # Controladores de la API
│   ├── Program.cs           # Configuración de la API
│   ├── appsettings.json     # Configuración del proyecto
│   ├── ErrorHandler.cs      # Middleware para capturar errores.
│── GymFitnessGuide.Application/
│   ├── DTOs/                # Dtos (objeto de transferencia de datos)
│   ├── Interfaces/          # Interfaces de los servicios
│   ├── Mappings/            # Configuracion de automapper
│   ├── Services/            # Servicios
│── GymFitnessGuide.Infraestructure/
│   ├── Data/                # Contexto
│   ├── Migrations/          # Migraciones de base de datos
│   ├── Entities/            # Entidades
│   ├── Repositories/        # Repositorios
│   │   ├── Interfaces/      # Interfaces de los repositorios
│── GymFitnessGuide.sln      # Solución del proyecto
```

## 🔧 Instalación y configuración
### 1️⃣ Clonar el repositorio
```sh
git clone https://github.com/abrahamraies/GymFitnessGuide.git
cd GymFitnessGuide
```

### 2️⃣ Configurar la base de datos
Asegúrate de tener **MySQL** instalado y crea una base de datos llamada `gymfitnessguide`. Luego, configura el archivo `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=gymfitnessguide;user=root;password=tu_contraseña"
}
```

### 3️⃣ Aplicar migraciones
```sh
dotnet ef database update
```

### 4️⃣ Ejecutar el servidor
```sh
dotnet run
```

La API estará disponible en `http://localhost:5000/api`

## 📌 Funcionalidades principales
- ✅ Creación y gestión de usuarios.
- ✅ Generación de preguntas y almacenamiento de respuestas.
- ✅ Cálculo de la mejor categoría de entrenamiento según las respuestas del test.
- ✅ Consulta de recomendaciones para cada categoría.
- ✅ Documentación automática con Swagger.

## 📄 Licencia
Este proyecto está bajo la licencia **MIT**. ¡Siéntete libre de contribuir! 🎉
