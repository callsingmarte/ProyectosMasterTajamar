class Student {
    constructor(place, name){
        this.place = place,
        this.name = name   
    }
}

let students = [
    new Student(1, "David"),   
    new Student(2, "Raul"),   
    new Student(3, "Daniel"),   
    new Student(4, "Robert"),   
    new Student(5, "Daniel Salas"),   
    new Student(6, "Ruben"),   
    new Student(7, "Angel"),   
    new Student(8, "Jorge"),   
    new Student(9, "Nick"),   
    new Student(10, "Martin"),   
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
    DisplayStudents();
    console.log("cargando estudiantes...");
});

function DisplayStudents(){
    $("#studentsContainer").empty(); // Limpiar contenedor
    let row;
    for(let contador = 0; contador < students.length; contador++){
        if(contador+1 == 1 ||contador + 1 == 5 || contador + 1 == 9 ){
            row = $("<div></div>").addClass("row");
            $("#studentsContainer").append(row);
        }
        row.append(`
            <div class='col-3'>
                <p>${students[contador].name}</p>
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
            console.log("studentColleague primary to compare", studentColleage.student.name);
            console.log("studentIndex", studentFoundIndex);
            console.log("studentFound", students[studentFoundIndex]);
            console.log("original colleague", studentColleage.colleague.name);    
            //Comprobar si el compañero es el mismo al reordenar
            if(studentFoundIndex % 2 == 1 && studentFoundIndex != 0){
                console.log("new colleague", students[studentFoundIndex-1].name);    
                if(students[studentFoundIndex-1].name === studentColleage.colleague.name){
                    console.log("Repeated Colleague");
                    repetirReordenacion = true;
                }
            }else if (students[studentFoundIndex + 1].name === studentColleage.colleague.name){
                console.log("new colleague", students[studentFoundIndex+1].name);    
                console.log("Repeated Colleague");
                repetirReordenacion = true;
            }else if (studentFoundIndex == 0 && students[studentFoundIndex + 1].name === studentColleage.colleague.name){
                console.log("new colleague", students[studentFoundIndex+1].name);    
                console.log("Repeated Colleague");
                repetirReordenacion = true;
            }
        }else{
            console.log("Student not found:", studentColleague.student.name);
        }
    })

    if(repetirReordenacion){
        ReorderStudents();
    }

    DisplayStudents();
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
    SaveToFile();
}

function SaveToFile() {
    // Convertir el array a JSON
    const data = JSON.stringify(studentsColleaguesOrigin, null, 2);

    // Crear un blob con los datos
    const blob = new Blob([data], { type: "text/plain" });

    // Crear un enlace para la descarga
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = "studentsColleaguesOrigin.txt";

    // Simular clic en el enlace
    link.click();

    console.log("Archivo guardado.");
}