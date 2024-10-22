# Sistema de ABM de Médicos, Afiliados y Clínicas

## Descripción del Proyecto

Este proyecto es un sistema de gestión desarrollado en WinForms para facilitar el manejo de información de médicos, afiliados y clínicas. Permite realizar operaciones de Agregar, Buscar y Modificar (ABM) en cada una de estas entidades, mejorando la eficiencia en la gestión de datos.

## Tecnologías Utilizadas

- **Lenguaje**: C#
- **Framework**: .NET Framework
- **Base de Datos**: MySQL 
- **IDE**: Visual Studio

## Funcionalidades

El sistema incluye las siguientes funcionalidades:

### Inicio de Sesión
- Se inicia sesión con email y contraseña del administrador, cargada en la base de datos.

### Médicos
- Registro de nuevos médicos.
- Modificación de datos de médicos existentes.
- Visualización de la lista de médicos.

### Afiliados
- Registro de nuevos afiliados.
- Modificación de datos de afiliados existentes.
- Visualización de la lista de afiliados.

### Clínicas
- Registro de nuevas clínicas.
- Modificación de datos de clínicas existentes.
- Visualización de la lista de clínicas.

## Estructura del Proyecto

- **Capa de Datos**: Maneja la conexión a la base de datos y las operaciones CRUD.
- **Capa de Lógica**: Contiene la lógica de negocio y la validación de datos.
- **Capa de Entidades**: Contiene las clases que representan los objetos del dominio del sistema. Cada clase corresponde a una tabla en la base de datos y define las propiedades necesarias para gestionar los datos.
- **Capa de Presentación**: Interfaz de usuario y manejo de eventos.
