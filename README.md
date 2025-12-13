# 🧁 Pastelería Creativa – FlowDocument + DataGrid (WPF)

![Banner Pastelería Creativa](https://placehold.co/1200x400?text=Pasteleria+Creativa+-+FlowDocument+%2B+DataGrid)

Proyecto de interfaz desarrollado con **WPF** orientado al mundo de la **pastelería creativa**, compuesto por dos partes principales:

1) Un **FlowDocument** interactivo con secciones formateadas, imágenes y acciones (guardar/cargar/imprimir).  
2) Una aplicación de **Acceso a Datos** con **DataGrid** para gestionar posts/postres mediante operaciones **CRUD**.

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

### 🎯 Interactividad y triggers
- **Trigger por propiedad**: al pasar el ratón por encima de un botón:
  - Aumenta el tamaño del botón
  - Cambia la fuente a **negrita**
- Sección de **imágenes destacadas** organizada en columnas.
- **Trigger por evento**: al hacer clic sobre una imagen, cambia su tamaño.

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
La base de datos contiene registros con **7 campos**, incluyendo:
- Nombre
- Chef
- Tipo
- Imagen
- Tiempo de preparación
- Dificultad
*(y el campo restante según tu modelo)*

### 🧭 Navegación por registros
- Desplazamiento por registros mediante:
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
- Inserción de un nuevo registro (aparece seleccionado)
- Modificación de un registro existente
- Eliminación con **mensaje de confirmación**

---

## 🎨 Estilos y animaciones (WPF)

- Estilo global de ventana aplicado a toda la aplicación.
- En botones:
  - **Trigger por propiedad**: al pasar el ratón cambia el color del texto y lo subraya.
  - **MultiTrigger**: cambia el color de fuente y aumenta su tamaño.
  - **Animación**: efecto de aumento de tamaño del botón.

---

## 🛠️ Tecnologías utilizadas

![CSharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![XAML](https://img.shields.io/badge/XAML-0C54C2?style=for-the-badge&logo=windows&logoColor=white)
![FlowDocument](https://img.shields.io/badge/FlowDocument-WPF-blue?style=for-the-badge)
![DataGrid](https://img.shields.io/badge/DataGrid-WPF-purple?style=for-the-badge)

---

## 🚀 Objetivo del proyecto

- Practicar el diseño de documentos avanzados con **FlowDocument**.
- Aplicar estilos, columnas, tablas, imágenes y enlaces.
- Implementar **interacciones** con triggers y eventos.
- Desarrollar una aplicación de **acceso a datos** usando **DataGrid**.
- Implementar operaciones **CRUD** completas con una interfaz consistente.

---

## 💻 Cómo ejecutar el proyecto

1. Abre la solución en **Visual Studio**.
2. Asegúrate de tener instalado **.NET** y las herramientas de **WPF**.
3. Configura la conexión a la base de datos (si aplica).
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
