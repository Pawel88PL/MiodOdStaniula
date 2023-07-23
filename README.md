Data 24.04.2023

1. Utworzono pierwszą migrację dla tabeli produkty.
2. Utworzono ProductsController odpowiedzialny za dodawanie, edytowanie i usuwanie produktów.
3. Utworzono StoreController do wyświetlania listy produktów.
4. Utworzono widoki dla powyższych kontrolerów.
5. Przeprowadzono update bazy danych.
6. Utworzono widok kart produktów.
7. Dodano kolumnę Photo w tabeli Products.
8. Utworzono link do szczegółów danego produktu klikając na kartę ze zdjęciem.
9. Utworzono przekierowanie do strony ProductsList z kontrolera Edit i Details.

Data 28.04.2023

1. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Magazyn.
2. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Dodaj nowy produkt.
3. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Edytuj produkt.
4. Dodano produkty do sklepu.
5. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Produkty.
6. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Szczegóły produktu.
7. Przeniesiono widok "Szczegóły produktu" do kontrolera StoreController.
8. W widoku "Edytuj produkt" dodano podgląd strony produktu.
9. Poprawiono wygląd, funkcjonalność i wyświetlanie strony Usuń produkt.

Data 29.04.2023

1. Dodano możliwość rejestracji użytkownika.
2. Zabezpieczono kontroler ProductsController metodą autentykacji użytkownika.
3. Dostosowano wyświetlanie strony do urządzeń mobilnych.
4. Poprawiono stopkę.

Data 26.06.2023

1. Dodano klasę Cart.cs reprezentującą model koszyka zakupowego.
2. Zmieniono background dla listy produktów z szarego na białe.
3. Przyciski paska nawigacyjnego zmieniono na btn-outline, dodano ikony bootstrap icons.

Data 23.07.2023

1. Dodano nową klasę Category.cs reprezentującą kategorie danego produktu.
2. Poprawiono pola klasy Product.cs i dodano klucz obcy do tabeli Categories.
3. Przeprowadzono migrację 'newTable_Categories'.
4. Opublikowano wersję aplikacji 2.0.0.
5. Poprawiono wyświetlanie stopki.
6. ConnectionString do bazy danych przeniesiono do pliku appsettings.json, który wyłączono ze śledzenia w GitHub.