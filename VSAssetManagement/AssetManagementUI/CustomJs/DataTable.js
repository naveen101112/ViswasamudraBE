var tableFromJson = (jsonData) => {
    let tableData = [];
    if(jsonData){
        tableData = jsonData;
    }

    // Extract value from table header. 
    // ('Book ID', 'Book Name', 'Category' and 'Price')
    let col = [];
    for (let i = 0; i < tableData.length; i++) {
      for (let key in tableData[i]) {
        if (col.indexOf(key) === -1) {
          col.push(key);
        }
      }
    }

    // Create a table.
    const table = document.getElementById('demo-foo-filtering');

    var thead = table.createTHead();
    // Create table header row using the extracted headers above.
    var row = thead.insertRow(-1);

    for (let i = 0; i < col.length; i++) {
      let th = document.createElement("th");      // table header.
      th.innerHTML = col[i];
      row.appendChild(th);
    }


    let tbody = table.createTBody();  
    
    // add json data to the table as rows.
    for (let i = 0; i < tableData.length; i++) {
        console.log(tableData);
        let row = tbody.insertRow(-1);
        row.setAttribute('alt',tableData[i].id);
        row.setAttribute('name','dataRow');
      for (let j = 0; j < col.length; j++) {
        let tabCell = row.insertCell(-1);
        tabCell.innerHTML = tableData[i][col[j]];
      }
    }

    
    /*const divShowData = document.getElementById('showData');
    divShowData.innerHTML = "";
    divShowData.appendChild(table);*/
}

//$('dataRow').click(function(this){alert(this.alt)});