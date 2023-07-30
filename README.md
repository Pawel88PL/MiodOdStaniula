# www.miododstaniula.pl

"Miód od Staniula" jest to projekt sklepu internetowego, napisany w techonologi ASP.NET Core MVC 6.0.
Do połączenia z bazą danych MS SQL Server wykorzystano narzędzie ORM Entity Framework Core.
<hr/>

Chronologia zmian:

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
<hr/>

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
<hr/>

Data 29.04.2023

1. Dodano możliwość rejestracji użytkownika.
2. Zabezpieczono kontroler ProductsController metodą autentykacji użytkownika.
3. Dostosowano wyświetlanie strony do urządzeń mobilnych.
4. Poprawiono stopkę.
<hr/>

Data 26.06.2023

1. Dodano klasę Cart.cs reprezentującą model koszyka zakupowego.
2. Zmieniono background dla listy produktów z szarego na białe.
3. Przyciski paska nawigacyjnego zmieniono na btn-outline, dodano ikony bootstrap icons.
<hr/>

Data 23.07.2023

1. Dodano nową klasę Category.cs reprezentującą kategorie danego produktu.
2. Poprawiono pola klasy Product.cs i dodano klucz obcy do tabeli Categories.
3. Przeprowadzono migrację 'newTable_Categories'.
4. Opublikowano wersję aplikacji 2.0.0.
5. Poprawiono wyświetlanie stopki.
6. ConnectionString do bazy danych przeniesiono do pliku appsettings.json, który wyłączono ze śledzenia w GitHub.
7. Utworzono kontroler 'AddNewProductController', klasę 'AddProductService.cs' z metodą 'AddNewProductAsync()'.
<hr/>

Data 24.07.2023

1. Utworzono kontroler 'WarehouseController', klasę 'WarehouseService.cs' z metodą 'GetAllProductsAsync()'.
2. Utworzono kontroler 'EditProductController', klasę 'EditProductService.cs' z metodami 'GetProductAsync()' i 'UpdateProductAsync()'.
<hr/>

Data 25.07.2023

1. W pliku 'Program.cs' skonfigurowano domyślny routing na stronę z produktami ('Store/Index').
2. Utworzono widok dzielony '_WelcomePage', który umieszczono na stronie głównej i na początku strony z produktami.
3. Poprawiono responsywność kart produktów na stronie z produktami.
4. Poprawiono wyświetlanie strony 'Details.cshtml' na urządzeniach mobilnych.
5. Kontroler 'StoreController' zmieniono na 'ProductController' i utworzono w nim medoty filtrowania i sortowania produktów
	według określonych warunków.
6. Na stronie z produktami dodano możliwość filtowania i sortowania produktów.
<hr/>

Data 27.07.2023

1. Dodano plik 'favicon.png' i odnośnik do ikony w tagu "head" pliku 'Layout.cshtml'.
2. Utworzono widok częściowy '_ProductList.cshtml' oraz metodę'GetProducts' w kontrolerze 'ProductsController', która jest odpowiedzialna za przekazywanie
	widoku częściowego do strony z produktami.
3. w pliku 'site.js' zastosowano żądanie AJAX w przypadku filtrowania produktów.
<hr/>

Data 28.07.2023

1. Dla karty produktu dodano przycisk 'Dodaj do koszyka' i efekt hover po najechaniu kursorem na kartę produktu.
2. Utworzono modal dla szczegółów produktu.
3. Zaimportowano czcionkę 'Playfair Display'.
<hr/>
Data 29.07.2023

1. Dodano model klienta 'Client.cs' i koszyka 'Cart.cs'.
2. Przeprowadzono migrację i update bazy danych.
<hr/>

Data 30.07.2023

1. Utworzono klasę 'DeleteServis.cs', interfejs 'IDeleteService.cs' i kontroler 'DeleteController.cs'.
2. Utworzono klasę 'FileUploadService.cs' i odpowiadający mu interfejs. Klasa ta odpowiada za dołączanie zdjęć
	produktów w trakcie dodawania nowego produktu.