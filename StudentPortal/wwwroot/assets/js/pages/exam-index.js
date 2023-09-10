loadTable();

$(document).on('click', '.filter_exams_btn', function(e) {
    e.preventDefault();

    loadTable();
});

function loadTable() {
    let fk_Exam = $('input[name=fk_Exam]').val();

    $.ajax({
        url: '/Exam/LoadTable',
        method: 'post',
        data: {fk_Exam: fk_Exam},
        beforeSend: function () {
            $('#cover-spin').show();
        },
        complete: function () {
            $('#cover-spin').hide();
        },
        success: function(data) {
            let rows = '';

            data.studentExams.forEach(studentExam => {
                rows += `<tr class="text-center">
                           <td>${studentExam.exam.name}</td> 
                           <td>${studentExam.questionCount}</td> 
                           <td>${studentExam.successCount}</td> 
                           <td>${studentExam.failedCount}</td> 
                           <td>${studentExam.createdAtString}</td>   
                         </tr>`;
            });

            if (rows) {
                $('.tbody-exams').html(rows);
            } else {
                $('.tbody-exams').html(`
                               <tr class="text-center"> 
                                   <td colspan="5">No Exam Result</td> 
                               </tr> 
                        `);
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}