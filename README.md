# _Hair Salon database_

#### By _**Katlin Anderson**_

## Description

_A program program that data about stylist and clients, and organizes it in a helpful way._

## Setup/Installation Requirements

* _Clone from GitHub_
* _> CREATE DATABASE katlin_anderson;_
* _> USE katlin_anderson;_
* _> CREATE TABLE stylist (id serial PRIMARY KEY, name VARCHAR(255). daysAvailable DATE, );_
* _> CREATE TABLE client (id serial PRIMARY KEY, name VARCHAR(255), nextAppointment DATE, stylistId int);_
* _> CREATE TABLE specialties (id serial PRIMARY KEY, specialty VARCHAR(255));_
* _Start MAMP and click Open WebStart page in the MAMP window._
* _In the website you're taken to, select phpMyAdmin from the Tools dropdown._
* _Select the Import tab._
* _Select your database file, and click Go._
* _$ dotnet restore_
* _$ dotnet build_
* _$ dotnet run_

## Specs

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|
| The database will collect data about a hair salon | x | x |
| The database with collect data on stylists | x | x |
| The database will collect data on clients | x | x |
| The database will tore the client information that is specific to each stylist | x | x |
| The web application with display this information | x | x |


## Known Bugs

_No known bugs_

## Technologies Used

_C#_
_HTML_
_CSS_
_MYSQL_

### License

*This software is licensed under the GPL license.*

Copyright (c) 2019 **_Katlin Anderson_**
