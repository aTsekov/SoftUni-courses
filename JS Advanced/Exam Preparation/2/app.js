window.addEventListener("load", solve);

function solve() {
  let make = document.getElementById("make");
  let model = document.getElementById("model");
  let productionYear = document.getElementById("year");
  let fuelType = document.getElementById("fuel");
  let originalCost = document.getElementById("original-cost");
  let sellingPrice = document.getElementById("selling-price");

  document.getElementById("publish").addEventListener("click", publish);

  function publish(e) {
    e.preventDefault();
    if (make.value !== undefined && model.value !== undefined && Number(originalCost.value) !== undefined
      && Number(sellingPrice.value) !== undefined && Number(originalCost.value) < Number(sellingPrice.value)) {

      let tr = document.createElement("tr");
      tr.classList.add("row");
      tr.innerHTML = `<td>${make.value}</td>
                  <td>${model.value}</td>
                  <td>${productionYear.value}</td>
                  <td>${fuelType.value}</td>
                  <td>${originalCost.value}</td>
                  <td>${sellingPrice.value}</td>`;

                  let buttonsTD = document.createElement('td');
                 
                  let editButton = document.createElement('button');
                  editButton.classList.add('action-btn');
                  editButton.classList.add('edit');
                  editButton.innerText = `Edit`;

                  let sellButton = document.createElement('button');
                  sellButton.classList.add('action-btn');
                  sellButton.classList.add('sell');
                  sellButton.innerText = `Sell`;
                  buttonsTD.appendChild(editButton);
                  buttonsTD.appendChild(sellButton);
                  tr.appendChild(buttonsTD)
                  ;

      let tbody = document.getElementById("table-body");
      tbody.appendChild(tr);
      
      make.value = "";
      model.value = "";
      productionYear.value = "";
      fuelType.value = "";
      originalCost.value = "";
      sellingPrice.value = "";

    }

    document.getElementsByClassName("action-btn edit")[0].addEventListener("click", edit);

    function edit(e) {
      e.preventDefault();
      let table = document.getElementsByClassName("row")[0];

      make.value = table.children[0].innerText;
      model.value = table.children[1].innerText;
      productionYear.value = table.children[2].innerText;
      fuelType.value = table.children[3].innerText;
      originalCost.value = table.children[4].innerText;
      sellingPrice.value = table.children[5].innerText;

      e.target.parentElement.parentElement.remove()

    }
    document.getElementsByClassName("action-btn sell")[0].addEventListener("click",sell);
    document.getElementsByClassName("action-btn sell")[1].addEventListener("click",sell);

    
  }
  function sell(e) {
      

    let ulCarList = document.getElementById("cars-list");
    let li = document.createElement("li");
    li.classList.add("each-list");
    let span1 = document.createElement("span");
    let currTable = e.target.parentElement.parentElement;
    span1.innerText = `${currTable.children[0].textContent} ${currTable.children[1].textContent}`
    let span2 = document.createElement("span");
    span2.innerText = `${currTable.children[2].textContent}`;
    let span3 = document.createElement("span");
    let diff = Number(currTable.children[5].textContent) - Number(currTable.children[4].textContent)
    span3.innerText = `${diff}`
    li.appendChild(span1);
    li.appendChild(span2);
    li.appendChild(span3);
    ulCarList.appendChild(li);


    e.target.parentElement.parentElement.remove()
  }
}
