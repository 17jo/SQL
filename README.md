## Opis
Ovaj direktorijum se sastoji od jednostavnih konzolnih aplikacija napisanih u C# koji se povezuje sa Oracle bazom podataka.
**Napomena:** Upit direktno uključuje korisnički unos, što nije bezbedno. Preporučuje se korišćenje parametarskih upita kako bi se sprečila SQL injekcija.

## Funkcionalnosti

- Povezuje se sa Oracle bazom podataka koristeći `Oracle.ManagedDataAccess.Client` biblioteku.
- Traži od korisnika da unese tražene podatke.
- Izvršava SQL upit.
- Upravljanje mogućim greškama prilikom pristupa bazi podataka.

## Zahtevi

- .NET Framework (verzija 4.5 ili viša)
- Oracle.ManagedDataAccess.Client biblioteka
- Pristup Oracle bazi podataka sa odgovarajućom šemom

