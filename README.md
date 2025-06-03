# Dokumentacja aplikacji System Zarządzania Urządzeniami

---

## Opis aplikacji

System Zarządzania Urządzeniami to aplikacja desktopowa typu WinForms, która umożliwia zarządzanie pracownikami oraz przypisanymi do nich urządzeniami.  
Aplikacja pozwala na wykonywanie podstawowych operacji CRUD (Create, Read, Update, Delete) na tabelach `employee` oraz `device` w bazie PostgreSQL.  
Użytkownik może dodawać, edytować i usuwać pracowników oraz urządzenia, a także przypisywać urządzenia do konkretnych pracowników.

---

## Opis bazy danych

Aplikacja korzysta z relacyjnej bazy danych PostgreSQL z dwoma głównymi tabelami:

### Tabela `employee`

| Kolumna    | Typ danych | Opis                  |
|------------|------------|-----------------------|
| id         | integer    | Klucz główny, autoinkrementacja  |
| firstname  | varchar    | Imię pracownika       |
| lastname   | varchar    | Nazwisko pracownika   |
| department | varchar    | Dział, w którym pracuje|

### Tabela `device`

| Kolumna      | Typ danych | Opis                                         |
|--------------|------------|----------------------------------------------|
| id           | integer    | Klucz główny, autoinkrementacja              |
| name         | varchar    | Nazwa urządzenia                             |
| serialnumber | varchar    | Numer seryjny urządzenia                      |
| purchasedate | date       | Data zakupu urządzenia                        |
| employeeid   | integer    | Klucz obcy wskazujący na `employee.id`, nullable (urządzenie może nie być przypisane) |

---

## Konfiguracja aplikacji

### Wymagania wstępne

- Zainstalowany i działający serwer PostgreSQL (np. na `localhost` na porcie `5432`)
- Utworzona baza danych `urzadzenia`
- Utworzone tabele `employee` i `device` zgodnie ze schematem (przykładowe pliki ze strukturą tabel oraz danymi można załadować z dostępnych plików`.sql` przez przycisk "Załaduj bazę danych" w aplikacji)
- Język krótego użyto przy tworzeniu aplikacji: C# 7.3
- Platforma: .NET Framework 4.8

### Połączenie z bazą danych

Parametry połączenia są na stałe zapisane w klasie `DatabaseService` w polu:

```csharp
private readonly string connectionString = "Host=localhost;Port=5432;Database=urzadzenia;Username=postgres;Password=password";
