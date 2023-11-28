// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function is_valid_email(email) {
        const emailPattern = /^[\w.-]+@[a-zA-Z\d.-]+\.[a-zA-Z]{2,}$/;
    return emailPattern.test(email);
      }

    function is_strong_password(password) {
        return (
          password.length >= 8 && /[A-Z]/.test(password) && /\d/.test(password)
    );
      }

    function showAlert(message) {
        const customAlert = document.getElementById("customAlert");
    customAlert.innerText = message;
    customAlert.style.display = "block";

        // Cacher l'alerte après quelques secondes
        setTimeout(() => {
        customAlert.style.display = "none";
        }, 3000);
      }

    function validateForm() {
        const emailInput = document.getElementById("email");
    const passwordInput = document.getElementById("password");

    const email = emailInput.value;
    const password = passwordInput.value;

    if (!is_valid_email(email)) {
        showAlert(`L'adresse e-mail ${email} n'est pas valide.`);
    return false;
        }

    if (!is_strong_password(password)) {
        showAlert("Le mot de passe n'est pas suffisamment fort.");
    return false;
        }

    // Ajoutez ici le code pour soumettre le formulaire si toutes les vérifications réussissent
    // Par exemple, vous pouvez utiliser AJAX pour envoyer les données au serveur.

    return true; // Retourne true pour soumettre le formulaire, false pour l'empêcher.
      }
