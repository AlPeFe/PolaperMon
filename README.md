# PolaperMon

Monitor ligero construido con .NET para tareas de supervisión y utilidades.

**Estado:** Código base inicial en el repositorio.

## Qué hace
PolaperMon es una aplicación escrita en C#/.NET diseñada para tareas de monitoreo y automatización relacionadas con infraestructura o procesos locales. Contiene la estructura base del proyecto y la configuración necesaria para compilar y ejecutar la aplicación en entornos compatibles con .NET.

## Tecnologías

- .NET 10 (net10.0)
- C#
- MSBuild / dotnet CLI

## Ejecutar localmente

1. Restaurar paquetes y compilar:

```bash
dotnet restore
dotnet build
```

2. Ejecutar la aplicación:

```bash
dotnet run --project PolaperMon/PolaperMon.csproj
```

3. Publicar (opcional):

```bash
dotnet publish -c Release -o publish
```

## Contribuir

- Abre un issue o crea un PR con cambios propuestos.
- Sigue las buenas prácticas de commits y pruebas.

---

Si quieres, puedo crear también una plantilla de `ISSUE_TEMPLATE` y `CONTRIBUTING.md`, o conectar el repo a GitHub y pushear los cambios por ti.