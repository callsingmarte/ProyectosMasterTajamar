// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#cmbCursos").on("change", function () {
        var valor = $(this).val();
        $.ajax({
            type: "GET",
            url: "/Student/DevuelveCapacidad/",
            data: { dato: valor },
            success: function (response) {
                $("#txtCapacity").val(response);
            },
            error: function (response) {
                alert(response.message);
            }
        })
    })

    $("#cmbCursoInstructor").on("change", function () {
        var valor = this.value;
        $.ajax({
            type: 'GET',
            url: '/Instructor/DevuelveMatriculas',
            data: { dato: valor },
            success: function (response) {
                $('#tableStudent').empty();  // Limpiar la tabla antes de agregar los nuevos datos
                $('#tableStudent').append('<tr><th>Student</th><th>Letter</th></tr>'); // Agregar encabezados de la tabla

                if (response.length > 0) {
                    // Mapeo de los valores numéricos de letterGrade a sus representaciones de texto
                    const gradeMap = {
                        0: 'A',
                        1: 'B',
                        2: 'C',
                        3: 'D',
                        4: 'F',
                        5: 'I',
                        6: 'W',
                        7: 'P'
                    };

                    for (var i = 0; i < response.length; i++) {
                        // Obtener el valor numérico de letterGrade y mapearlo a su representación de letra
                        var gradeAsString = gradeMap[response[i].letterGrade] || 'Unknown'; // Usa 'Unknown' si no se encuentra el valor
                        // Crear una nueva fila en la tabla
                        var row = $('<tr></tr>');
                        row.append('<td>' + response[i].student.studentName + '</td>');
                        row.append('<td class="text-right"><input type="text" id="txtGrade_' + response[i].student.studentId + '" value="' + gradeAsString + '"/></td>');

                        // Crear el botón para calificar con el data-student-id
                        var button = $('<input type="button" value="Post Grade" class="btn btn-success" />')
                            .data('student-id', response[i].student.studentId)
                            .on('click', function () {
                                var studentId = $(this).data('student-id');
                                calificar(studentId);
                            });

                        row.append($('<td></td>').append(button));
                        $('#tableStudent').append(row);  // Agregar la fila a la tabla
                    }
                }
                else {
                    var row = $('<tr></tr>');
                    row.append('<td colspan="2">Sin matriculas</td>');
                    $('#tableStudent').append(row);
                }
            }
        });
    });

    function calificar(studentId) {
        var grade = $('#txtGrade_' + studentId).val();

        $.ajax({
            type: "GET",
            url: '/Instructor/Califica',
            data: { dato: studentId, nota: grade },
            success: function (response) {
                alert('Registro actualizado');
            }
        })
    }
})