# Kuantum
Postulación

Implementación de la API

API: Al descargar o clonar el proyecto se debe solo ejecutar en Visual Studio 2019 - Swagger implementado (Si se desea levantar una base de datos local, se debe leer el
siguiente paso).

Base de datos: 
La base de datos se encuentra alojada en la cloud de Microsoft "Azure" especificamente en Azure Database for MySQL flexible server, en el caso de querer levantar la base
localmente se debe:<br/>
- Instalar Xampp<br/>
- Levantar los servicios de MySQL<br/>
- Crear la base de datos llamada kuantum<br/>
- Ejecutar las siguientes instrucciones SQL<br/>
  
CREATE TABLE document (
  id int(11) NOT NULL,
  name varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  description varchar(1000) COLLATE utf8_spanish2_ci NOT NULL,
  author_full_name varchar(300) COLLATE utf8_spanish2_ci NOT NULL,
  author_email varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  serial_code varchar(16) COLLATE utf8_spanish2_ci NOT NULL,
  created_at timestamp NULL DEFAULT NULL,
  updated_at timestamp NULL DEFAULT NULL,
  deleted_at timestamp NULL DEFAULT NULL
) <br/>
ALTER TABLE document
  ADD PRIMARY KEY (id);<br/>
ALTER TABLE document
  MODIFY id int(11) NOT NULL AUTO_INCREMENT;
COMMIT;<br/><br/>

CREATE TABLE document_page_index (
  id int(11) NOT NULL,
  document_id int(11) NOT NULL,
  name varchar(100) COLLATE utf8_spanish2_ci NOT NULL,
  page int(11) NOT NULL,
  created_at timestamp NULL DEFAULT NULL
) <br/>
ALTER TABLE document_page_index
  ADD PRIMARY KEY (id),
  ADD KEY FK_DocumentPage (document_id);
<br/>
ALTER TABLE document_page_index
  MODIFY id int(11) NOT NULL AUTO_INCREMENT;
<br/>
ALTER TABLE document_page_index
  ADD CONSTRAINT FK_DocumentPage FOREIGN KEY (document_id) REFERENCES document (id);
COMMIT;<br/>
- Modificar en el proyecto la cadena de conexión en el archivo appsettings.json en el campo KuantumAPIConnection.<br/>
- Modificar en el proyecto la cadena de conexión en el archivo kuantumContext.cs dentro de la carpeta Models

