function checkElement(isChecked, id) {
    console.log(id = id);
    if (isChecked == "True") {
        console.log("inside IF");
        document.getElementById(id).classList.add("checked");
    }
    else {
        console.log("inside ELSE");
        document.getElementById(id).classList.remove("checked");
    }
    
    console.log(isChecked);
}

function checkRange(ListNotes) {
    console.log(id = id);
    let counter = 1;
    ListNotes.forEach(element => {
        if (element.isChecked == "True") {
            console.log("inside IF");
            
        }
        else {
            console.log("inside ELSE");
            
        }
        counter += 1;
    });
    console.log(isChecked);
}