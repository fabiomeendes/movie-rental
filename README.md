# Movie Rental

Movie Rental é uma API que simula a locação de um filme.

## Usage

bash
rebuild Visual Studio
run F5

## ASP.NET Core WebApi

- .NET CORE 2.1
- EntityFrameworkCore 2.1.1

## Notes

Usei conceitos do Clean Architecture para a estruturação do projeto.

Injeção de dependência para alcançar a IoC (Inversão de Controle) entre classes e suas dependências.

Poderia ter usado uma camada de Aplicação (Application) para controlar a lógica do negócio, no entanto fiz diretamente pelos Controladores.

Domain: Responsável pela modelagem das Entidades.
Api: Responsável pelas rotas e lógica do negócio.
Infra: Responsável por comunicar com o banco de dados e persistir as entidades.
