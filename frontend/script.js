// const menuBody = document.querySelector('#menu')
// document.addEventListener("click", menu)
// function menu(event){
//     if (event.target.closest('.menu_button')){
//         menuBody.classList.toggle('_active')
//     }
//     if (!event.target.closest('.menu_button')){
//         menuBody.classList.remove('_active')
//     }
// }


// ВАЛИДАЦИЯ (ТЕЛЕФОН)

function ValidPhone() {
    var re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    var myPhone = document.getElementsByClassName('phone').value;
    var valid = re.test(myPhone);
    if (valid) output = router.replace("./index.html");
    else output = null;
    return valid;
}  

function phonenumber(inputtxt)
{
  var phoneno = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
  if((inputtxt.value.match(phoneno))
        {
      return true;
        }
      else
        {
        alert("message");
        return false;
        }
}