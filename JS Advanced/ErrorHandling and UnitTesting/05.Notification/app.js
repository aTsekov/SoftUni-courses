function notify(message) {
  let divContent = document.getElementById('notification');
  divContent.innerHTML = message;
  divContent.style.display = 'block';
  divContent.addEventListener('click', showHide);

  function showHide(e){
    e.target.style.display = 'none';
  }

}