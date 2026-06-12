# Phonebook Console App (C#)

A simple console-based phonebook application built in C#, using a `Dictionary<string, string>` (key = phone number, value = name) as the in-memory data store.

## Features
- **Add contact** – validates the phone number with a regex (`^\+?[0-9]{8,}$`) before saving
- **Delete contact** – remove a contact by phone number
- **Search** – find a contact by name or phone number
- **List all** – display all saved contacts with a record count

## How it works
The app runs an interactive loop in the console:

```
Type "add"    - add a new contact
Type "delete" - delete a contact by number
Type "list"   - show all contacts
Type "exit"   - quit the app
(or just type a name/number to search for it)
```

## Technologies
- C# / .NET
- Collections (`Dictionary<string, string>`)
- Regular expressions for input validation
- LINQ (`Where`, `FirstOrDefault`)

## Possible improvements
- Persist data to a file or database (currently stored in memory only)
- Separate name/number into a proper `Contact` class
- Unit tests for validation and CRUD logic
