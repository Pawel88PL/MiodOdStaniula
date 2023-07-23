Data 24.04.2023

1. Utworzono pierwsz� migracj� dla tabeli produkty.
2. Utworzono ProductsController odpowiedzialny za dodawanie, edytowanie i usuwanie produkt�w.
3. Utworzono StoreController do wy�wietlania listy produkt�w.
4. Utworzono widoki dla powy�szych kontroler�w.
5. Przeprowadzono update bazy danych.
6. Utworzono widok kart produkt�w.
7. Dodano kolumn� Photo w tabeli Products.
8. Utworzono link do szczeg��w danego produktu klikaj�c na kart� ze zdj�ciem.
9. Utworzono przekierowanie do strony ProductsList z kontrolera Edit i Details.

Data 28.04.2023

1. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Magazyn.
2. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Dodaj nowy produkt.
3. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Edytuj produkt.
4. Dodano produkty do sklepu.
5. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Produkty.
6. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Szczeg�y produktu.
7. Przeniesiono widok "Szczeg�y produktu" do kontrolera StoreController.
8. W widoku "Edytuj produkt" dodano podgl�d strony produktu.
9. Poprawiono wygl�d, funkcjonalno�� i wy�wietlanie strony Usu� produkt.

Data 29.04.2023

1. Dodano mo�liwo�� rejestracji u�ytkownika.
2. Zabezpieczono kontroler ProductsController metod� autentykacji u�ytkownika.
3. Dostosowano wy�wietlanie strony do urz�dze� mobilnych.
4. Poprawiono stopk�.

Data 26.06.2023

1. Dodano klas� Cart.cs reprezentuj�c� model koszyka zakupowego.
2. Zmieniono background dla listy produkt�w z szarego na bia�e.
3. Przyciski paska nawigacyjnego zmieniono na btn-outline, dodano ikony bootstrap icons.

Data 23.07.2023

1. Dodano now� klas� Category.cs reprezentuj�c� kategorie danego produktu.
2. Poprawiono pola klasy Product.cs i dodano klucz obcy do tabeli Categories.
3. Przeprowadzono migracj� 'newTable_Categories'.
4. Opublikowano wersj� aplikacji 2.0.0.