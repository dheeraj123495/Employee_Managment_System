function userValid(element) {
    var EmailId = document.getElementById(element.id.replace("btnSubmit", "emailIdTxt")).value;
    var Pnumber = document.getElementById(element.id.replace("btnSubmit", "phoneNumberTxt")).value;

    if (element != null) {
        if (EmailId == null) {
            alert("Enter the Email");
            return false;
        }
        if (EmailId.indexOf('@') <= 0) {
            alert("Invalid Email");
            return false
        }
        if ((EmailId.charAt(EmailId.length - 4) != ".") && (EmailId.charAt(EmailId.length - 3) != '.')) {
            alert("Invalid Email");
            return false;
        }
        if (Pnumber.length != 10)
        {
            alert("Invalid Phone Number")
            return false;
        }
        else {
            alert("Registration Successfull");
            return true;
        }
    }
}
