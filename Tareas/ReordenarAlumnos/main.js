class Student {
    constructor(place, name, image, colorClass){
        this.place = place,
        this.name = name,    
        this.image = image
        //Indica la pareja de alumnos bajo una misma clase
        this.colorClass = colorClass
    }
}

let isCoveringCard = true;
let isComparing = false;
let studentsOrigin = [];

let students = [
    new Student(1, "David", "Avatar1.jpg", "group1"),   
    new Student(2, "Raul", "Avatar2.jpg", "group1"),   
    new Student(3, "Daniel", "Avatar3.jpg", "group2"),   
    new Student(4, "Robert", "Avatar4.jpg", "group2"),   
    new Student(5, "Daniel Salas", "Avatar5.jpg", "group3"),   
    new Student(6, "Ruben", "Avatar6.jpg", "group3"),   
    new Student(7, "Angel", "Avatar7.jpg", "group4"),   
    new Student(8, "Jorge", "Avatar8.jpg", "group4"),   
    new Student(9, "Nick", "Avatar9.jpg", "group5"),   
    new Student(10, "Martin", "Avatar10.jpg", "group5"),   
];

let studentsColleaguesOrigin = [
    { student: students[0], colleague: students[1] },
    { student: students[1], colleague: students[0] },
    { student: students[2], colleague: students[3] },
    { student: students[3], colleague: students[2] },
    { student: students[4], colleague: students[5] },
    { student: students[5], colleague: students[4] },
    { student: students[6], colleague: students[7] },
    { student: students[7], colleague: students[6] },
    { student: students[8], colleague: students[9] },
    { student: students[9], colleague: students[8] }
]

$(function (){
    console.log("cargando estudiantes...");
    LoadStudentsOrigin();
    DisplayStudents();
    $("#switchCoverCard").on("change", ToggleCoverCards)
    //La ordenacion es igual a la original en la primera carga
    //no tiene sentido ver la comparativa    
    $("#btnCompare").prop("disabled", true);
    $("#fileInput").on("change", LoadFromFile);
});

function DisplayStudents(){
    $("#studentsContainer").empty(); // Limpiar contenedor
    let row;
    for(let contador = 0; contador < students.length; contador++){
        if(contador+1 == 1 ||contador + 1 == 5 || contador + 1 == 9 ){
            row = $("<div></div>").addClass("row mb-3");
            $("#studentsContainer").append(row);
        }
        row.append(`
            <div class='col-3'>
                <div class="card shadow position-relative" style="width: 18rem;">
                    <img src="./images/${students[contador].image}" class="card-img-top"/>
                    <div class="card-body ${students[contador].colorClass}">                
                        <h5 class="card-title">${students[contador].name}</h5>
                    </div>
                </div>
            </div>
        `);
    }
}

function ReorderStudents() {
    let places = [...Array(students.length).keys()].map(i => i + 1); // Array [1, 2, ..., 10]
    places = places.sort(() => Math.random() - 0.5); // Mezclar lugares aleatoriamente
    console.log("places", places);
    students.forEach((student, index) => {
        student.place = places[index];
    });   

    // Reordenar estudiantes por su atributo 'place'
    students.sort((a, b) => a.place - b.place);
    console.log(students);    

    let repetirReordenacion = false;
   //Comprobar si el studiante y el compañero son el mismo que antes
    studentsColleaguesOrigin.forEach((studentColleage, index) => {
        let studentFoundIndex = students.findIndex( student => student.name === studentColleage.student.name);

        if(studentFoundIndex !== -1){                        
            //Comprobar si el compañero es el mismo al reordenar
            if(studentFoundIndex % 2 == 1 && studentFoundIndex != 0){
                if(students[studentFoundIndex-1].name === studentColleage.colleague.name){
                    repetirReordenacion = true;
                }
            }else if (students[studentFoundIndex + 1].name === studentColleage.colleague.name){
                repetirReordenacion = true;
            }else if (studentFoundIndex == 0 && students[studentFoundIndex + 1].name === studentColleage.colleague.name){
                repetirReordenacion = true;
            }
        }
    })

    if(repetirReordenacion){
        ReorderStudents();
    }

    //Cambio los grupos de color
    students.forEach((student, index) => {
        switch (true) {
            case (index === 0 || index === 1):
                student.colorClass = "group1";
                break;
            case (index === 2 || index === 3):
                student.colorClass = "group2";
                break;
            case (index === 4 || index === 5):
                student.colorClass = "group3";
                break;
            case (index === 6 || index === 7):
                student.colorClass = "group4";
                break;
            case (index === 8 || index === 9):
                student.colorClass = "group5";
                break;
        }
        isComparing = false;
        ChangeCompareBtnText();
    })

    //Al haber un cambio de orden se puede comparar
    $("#btnCompare").prop("disabled", false);
    DisplayStudents();

    if(isCoveringCard){
        CoverCards();   
    }else {
        UnCoverCards();
    }
}    

function SaveOrderStudents() {
    students.forEach((student, index) => {        
        if(index == 0){
            studentsColleaguesOrigin[index].student = student;
            studentsColleaguesOrigin[index].colleague = students[index+1];
        }else if(index % 2 == 1){
            studentsColleaguesOrigin[index].student = student;
            studentsColleaguesOrigin[index].colleague = students[index-1];
        }else{
            studentsColleaguesOrigin[index].student = student;
            studentsColleaguesOrigin[index].colleague = students[index+1];
        }
    })
    console.log("new students origin: ", studentsColleaguesOrigin)
    LoadStudentsOrigin();
    SaveToFile();
    if(isComparing){
        DisplayStudents();
    }
    //Al guardar una nueva ordenacion esta coincide con la ordenacion actual
    //por ello no se debe poder comparar
    $("#btnCompare").prop("disabled", true);
    isComparing = false;
    ChangeCompareBtnText();    
}

function SaveToFile() {
    // Convertir el array a JSON
    const data = JSON.stringify(studentsColleaguesOrigin, null, 2);

    // Crear un blob con los datos
    const blob = new Blob([data], { type: "text/plain" });

    // Crear un enlace para la descarga
    //Solo aceptamos un enlace el ultimo creado
    $("#downloadLinkContainer").empty();
    $("#downloadLinkContainer").append(
        `<a id="downloadLink" href="${URL.createObjectURL(blob)}" download="OrdenacionEstudiantes.txt">
        Descargar ordenacion estudiantes
        <\a>`
    );

    // Simular clic en el enlace    
    $("#downloadLink")[0].click();

    console.log("Archivo guardado.");
}

function LoadFromFile(event) {
    const file = event.target.files[0]; // Obtener el archivo seleccionado

    if (file) {
        const reader = new FileReader();
        reader.onload = function(e) {
            try {
                // Parsear los datos del archivo como JSON
                const data = JSON.parse(e.target.result);

                // Actualizar el array original
                studentsColleaguesOrigin = data.map(item => ({
                    student: new Student(item.student.place, item.student.name, item.student.image, item.student.colorClass),
                    colleague: new Student(item.colleague.place, item.colleague.name, item.colleague.image, item.student.colorClass)
                }));            
                console.log("Datos cargados:", studentsColleaguesOrigin);

                //Carga el listado de alumnos a comparar
                LoadStudentsOrigin();

                //Actualiza el listado de alumnos
                studentsColleaguesOrigin.forEach((studentColleague, index)=> {
                    students[index] = studentColleague.student;
                })

                isComparing = false;
                ChangeCompareBtnText();
                DisplayStudents();
                //Al cargar una nueva ordenacion esta coincide con la actual por ello no tiene sentido comparar
                $("#btnCompare").prop("disabled", true);
            } catch (error) {
                console.error("Error al leer el archivo:", error);
            }
        };
        reader.readAsText(file);
    }
}

function LoadStudentsOrigin(){    
    studentsColleaguesOrigin.forEach((studentColleague, index)=> {
        if(studentsOrigin.length == 0){
            studentsOrigin.push(studentColleague.student);
        }else{
            studentsOrigin[index] = studentColleague.student;
        }
    })
}

function CompareStudentsOrder(){
    if(isComparing){
        DisplayStudents();
        $("#btnCompare").text("Comparar");
        isComparing = false;
    }else{
        $("#studentsContainer").empty(); // Limpiar contenedor
        $("#studentsContainer").append(`<div class="row">
            <div id="studentsCompare" class="col-6" style="border-right: 3px solid #000000">
                <h2>Ordenación Original</h2>
            </div>
            <div id="students0rder" class="col-6">
                <h2>Nueva Ordenación</h2>
            </div>
        </div>`);
        DisplayStudentsComparison("studentsCompare", studentsOrigin);
        DisplayStudentsComparison("students0rder", students);
        isComparing = true;
        $("#btnCompare").text("Listar estudiantes");    
    }
}

function ChangeCompareBtnText(){
    if(isComparing){
        $("#btnCompare").text("Listar estudiantes");    
    }else{
        $("#btnCompare").text("Comparar");
    }
}

function DisplayStudentsComparison(labelId, list){
    let row;
    for(let contador = 0; contador < list.length; contador++){
        if(contador+1 == 1 ||contador + 1 == 5 || contador + 1 == 9 ){
            row = $("<div></div>").addClass("row mb-3");
            $(`#${labelId}`).append(row);
        }
        row.append(`
            <div class='col-3'>
                <div class="card shadow" style="width: 9rem;">
                    <img src="./images/${list[contador].image}" class="card-img-top"/>
                    <div class="card-body ${list[contador].colorClass}">                
                        <h5 class="card-title">${list[contador].name}</h5>
                    </div>
                </div>
            </div>
        `);
    }
}

function ToggleCoverCards() {
    isCoveringCard = !isCoveringCard;
    if(!isComparing){
        if(isCoveringCard){
            CoverCards();   
        }else {
            UnCoverCards();
        }    
    }
}

function UnCoverCards(){
    $(".coverOverlay").each(function() {
        $(this).remove();
    })
}

function CoverCards(){
    $(".card").each(function (){
        $(this).append(`
            <div class="coverOverlay position-absolute top-0 start-0 w-100 h-100 rounded" onclick="CardReveal(event)">
                <img src='./images/CardCover.jpg' class='coverImg img-fluid rounded w-100 h-100' />
            </div>
        `);
    });
}

function CardReveal(event){    
    $(event.target).removeClass("coverImg");
    $(event.target).addClass("cardReveal");
    
    setTimeout(function(){
        $(event.target).remove();
    }, 3000);
}
