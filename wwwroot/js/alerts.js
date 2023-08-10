function showCheckoutAlert() {
  Swal.fire({
    title: 'Funkcja w trakcie tworzenia!',
    text: 'Przepraszamy, strona do przejścia do kasy jest w trakcie tworzenia.',
    icon: 'info'
  });
}

function showRegisterAlert() {
  Swal.fire({
    title: 'Funkcja w trakcie tworzenia!',
    text: 'Przepraszamy, możliwość rejestracji użytkowników jest w trakcie tworzenia.',
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