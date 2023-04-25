CREATE DATABASE Domino

USE Domino

CREATE TABLE CadenaDomino
(
	IdCadena INT Primary Key Identity(1, 1),
	Cadena varchar(800),
	Fecha datetime
)