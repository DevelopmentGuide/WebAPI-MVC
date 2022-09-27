var x = document.getElementById("PassWord");
var y = document.getElementById("PassWordIcon");

y.addEventListener("click", ShowPassWord);

function ShowPassWord() {
  x.type = "text";
  y.style.filter = "brightness(1.5)";

  setTimeout(function () {
    x.type = "password";
    y.style.filter = "brightness(1)";
  }, 1000);
}
