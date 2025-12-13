# 🧁 Pastelería Creativa – FlowDocument + DataGrid (WPF)

![Banner Pastelería Creativa](https://github.com/mariarosete/pasteleria/blob/main/screenshots/pasteleria.png?raw=true)

Proyecto de interfaz desarrollado con **WPF (C#)** orientado al mundo de la **pastelería creativa**, compuesto por dos partes principales:

1) Un **FlowDocument** interactivo con secciones formateadas, imágenes y acciones (guardar, cargar e imprimir).  
2) Una aplicación de **Acceso a Datos** con **DataGrid**, conectada a una base de datos **Microsoft Access**, para gestionar postres mediante operaciones **CRUD**.

---

## ✨ Características principales

## 📄 FlowDocument – Pastelería Creativa

### 🧩 Estructura por secciones
- 3 secciones principales:
  - **Recetas** (base de los postres)
  - **Postres** (variedad destacada)
  - **Decoraciones** (personalidad de cada creación)
- Menú de navegación con botones: **Inicio**, **Recetas**, **Postres**, **Decoraciones**.

### 💾 Acciones del documento
- Botones: **Guardar**, **Cargar**, **Eliminar**, **Imprimir**.
- Permite guardar el documento, eliminarlo y volver a cargarlo.
- Opción de **impresión directa** del contenido del FlowDocument.

### 🎯 Interactividad y triggers
- **Trigger por propiedad**: al pasar el ratón por encima de un botón:
  - Aumenta su tamaño
  - Cambia la fuente a **negrita**
- Sección de **imágenes destacadas** organizada en columnas.
- **Trigger por evento**: al hacer clic sobre una imagen, esta cambia su tamaño.

### 🎨 Formato y diseño del contenido
- Texto organizado en **varias columnas** con línea divisoria.
- Diferentes estilos para párrafos:
  - Estilo con fondo claro
  - Estilo con borde
  - Estilo con color de texto específico
- Listas con viñetas en secciones destacadas.
- **Tabla** con combinación de celdas.
- Imágenes:
  - Imagen **flotante** con texto alrededor
  - Imagen **en línea** con el texto
  - Imagen en un **párrafo independiente**
- **Hipervínculo** para visitar una web externa.

---

## 📊 DataGrid – Acceso a Datos (CRUD)

### 🗃️ Información gestionada
La aplicación trabaja con una base de datos **Microsoft Access (`recetas.accdb`)**, que contiene registros con los siguientes campos:

- Id  
- Nombre  
- Chef  
- Tipo  
- Imagen  
- Tiempo de preparación  
- Dificultad  

### 🧭 Navegación por registros
- Desplazamiento por los registros mediante:
  - Menú de navegación
  - Botones
  - Menú contextual

### 🔎 Ver detalles
- Acceso al detalle del postre mediante:
  - Botón
  - Menú
  - Menú contextual

### ✏️ CRUD completo (Insertar / Modificar / Eliminar)
Disponible desde:
- Menú principal
- Botones
- Menú contextual

Incluye:
- Inserción de nuevos registros (aparecen seleccionados automáticamente).
- Modificación de registros existentes.
- Eliminación con **mensaje de confirmación**.

---

## 🎨 Estilos y animaciones (WPF)

- Estilo global de ventana aplicado a toda la aplicación.
- En botones:
  - **Trigger por propiedad**: cambia el color del texto y lo subraya al pasar el ratón.
  - **MultiTrigger**: cambia el color de la fuente y aumenta su tamaño.
  - **Animación**: efecto visual de aumento de tamaño del botón.

---

## 🛠️ Tecnologías utilizadas

![CSharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=windows&logoColor=white)
![FlowDocument](https://img.shields.io/badge/FlowDocument-WPF-blue?style=for-the-badge)
![Access](https://img.shields.io/badge/Microsoft%20Access-A4373A?style=for-the-badge&logo=microsoft-access&logoColor=white)

---

## 🚀 Objetivo del proyecto

- Practicar el diseño de documentos avanzados con **FlowDocument**.
- Aplicar estilos, columnas, tablas, imágenes y enlaces.
- Implementar **interacciones** mediante triggers y eventos en WPF.
- Desarrollar una aplicación de **acceso a datos** con **DataGrid** y **Microsoft Access**.
- Implementar operaciones **CRUD** completas con una interfaz consistente y usable.

---

## 💻 Cómo ejecutar el proyecto

1. Abre la solución en **Visual Studio**.
2. Asegúrate de tener instalado **.NET** y las herramientas de **WPF**.
3. Verifica la ruta de acceso a la base de datos **`recetas.accdb`** en la configuración del proyecto.
4. Ejecuta el proyecto desde Visual Studio.

---

## 📩 Contacto

<p align="center">
  <a href="mailto:marlarosete89@gmail.com">
    <img src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" />
  </a>
  <a href="https://linkedin.com/in/mariarosetesuarez">
    <img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>
  <a href="https://github.com/mariarosete">
    <img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white" />
  </a>
</p>

---

<p align="center">Desarrollado con ❤️ por <b>María Rosete Suárez</b></p>

