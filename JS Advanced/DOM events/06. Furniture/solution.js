function solve() {


  let buttons = Array.from(document.getElementsByTagName("button"));
  let generateButton = buttons[0];
  let textAreas = Array.from(document.getElementsByTagName("textarea"));
  generateButton.addEventListener("click", generateProduct);
  let buyButton = buttons[1];
  buyButton.addEventListener("click", buy);


  function generateProduct() {

    let input = textAreas[0].value;
    let objects = JSON.parse(input)
    let tableBody = document.getElementsByTagName("tbody")[0];

    for (let item of objects) {
      let image = item["img"];
      let name = item["name"];
      let price = Number(item["price"]);
      let decFactor = Number(item["decFactor"]);
      let tableRow = document.createElement("tr");
      tableRow.innerHTML = `<td><img src="${image}"></td>
                          <td><p>${name}</p></td>
                          <td><p>${price}</p></td>
                          <td><p>${decFactor}</p></td>
                          <td><input type ="checkbox"></td>`;

      tableBody.appendChild(tableRow);
    }


  }

  function buy(event) {
    
    let res = [];
    let table = Array.from(document.querySelectorAll("tbody tr"));

    for (let row of table) {
      

      if (row.querySelector("input[type=checkbox]:checked")) {
        let tableData = Array.from(row.querySelectorAll("td"));

        let info = {
          name: tableData[1].children[0].textContent, // <td><p> where the name is stored
          price: tableData[2].children[0].textContent,
          decFactor: tableData[3].children[0].textContent
        }
        res.push(info);
      }

    }
    let furniturePieces = []
    let totalPrice = 0;
    let avgDecFactor = 0;
    for (let boughtProduct of res) {
      furniturePieces.push(boughtProduct.name)
      totalPrice += Number(boughtProduct.price);
      avgDecFactor += Number(boughtProduct.decFactor);

    }
    let totalFac = avgDecFactor / furniturePieces.length;
    let finalFurStr = furniturePieces.join(', ');
    let finalResult = `Bought furniture: ${finalFurStr}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${totalFac}`;
    textAreas[1].value = finalResult;

  }


}