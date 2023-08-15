function showCheckoutAlert() {
  Swal.fire({
    title: '+48 570 436 579',
    text: 'Aktualnie, aby złożyć zamówienie zadzwoń do nas pod podany wyżej numer telefonu.',
    icon: 'info',
    footer: 'Za niedługo udostępnimy możliwość zamawiania bezpośrednio z naszej strony internetowej!'
  });
}

function showRegisterAlert() {
  Swal.fire({
    title: 'Funkcja w trakcie tworzenia!',
    text: 'Przepraszamy, możliwość rejestracji użytkowników jest w trakcie tworzenia.',
    icon: 'info'
  });
}

function showRegulationAlert() {
  Swal.fire({
    title: 'Strona w trakcie tworzenia!',
    text: 'Przepraszamy, aktualnie regulaminem sklepu internetowego jest w trakcie tworzenia.',
    icon: 'info'
  });
}

function confirmDeleteAlert(form){
    Swal.fire({
        title: 'Jesteś pewien?',
        text: "Tej operacji nie można cofnąć",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Tak, usuń',
        cancelButtonText: 'Nie, wróć na stronę'
    }).then((result) => {
        if (result.isConfirmed) {
            form.submit();
            Swal.fire(
            'Usunięto!',
            'Produkt został usunięty.',
            'success'
            )
        }
    })
}