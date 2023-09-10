jQuery.noConflict();

let questionsWithAnswers = [];

$(document).on('click', '.next_to_question', function(e) {
    e.preventDefault();
    
    let questionNumber = $(this).data('question-number');
    
    let fk_Answer = $(`input[name=Fk_Answer_${questionNumber}]:checked`).val();
    
    if (fk_Answer) {
    
        let questionAnswer = {
            Fk_Question: parseInt(questionNumber),
            Fk_Answer: parseInt(fk_Answer),
        };
        
        // Check if the questionsWithAnswers array contains an object with the same Fk_Question
        let index = questionsWithAnswers.findIndex(item => item.Fk_Question === questionAnswer.Fk_Question);
    
        if (index !== -1) {
            // Update the existing object's Fk_Answer
            questionsWithAnswers[index].Fk_Answer = questionAnswer.Fk_Answer;
        } else {
            // Push the new questionAnswer object to the array
            questionsWithAnswers.push(questionAnswer);
        }
    
        $(this).parents('.test-step').next().addClass('active');
        $(this).parents('.test-step').removeClass('active');
        
    } else {
        Toast.fire({
            icon: 'error',
            title: 'Answer is Required',
        });
    }
});

$(document).on('click', '.submit_form', function(e) {
    e.preventDefault();

    let lastQuestionNumber = $(this).data('question-number');

    let LastAnswer = $(`input[name=Fk_Answer_${lastQuestionNumber}]:checked`).val();

    if (LastAnswer) {

        let questionAnswer = {
            Fk_Question: parseInt(lastQuestionNumber),
            Fk_Answer: parseInt(LastAnswer),
        };
    
        questionsWithAnswers.push(questionAnswer);
    
        $(this).parents('.test-step').next().addClass('active');
        $(this).parents('.test-step').removeClass('active');
    
    } else {
        Toast.fire({
            icon: 'error',
            title: 'Answer is Required',
        });
    }

    jQuery.ajax({
        url: '/Exam/SubmitExam',
        method: 'post',
        data: {
            Id: $('input[name=Id]').val(),
            Questions: questionsWithAnswers
        },
        success: function(data) {
    
            $('.exam_degree').html(`You Got ${data.successCount} of ${data.questionCount}`);
        
        },
        // beforeSend: function () {
        //     $('#cover-spin').show();
        // },
        // complete: function () {
        //     $('#cover-spin').hide();
        // },
        error: function(err) {
            Toast.fire({
                icon: 'error',
                title: 'Something went Wrong!',
            });
        }
    });
});

$(document).on('click', '.test-step .prev-btn', function(e) {
    e.preventDefault();

    $(this).parents('.test-step').prev().addClass('active');
    $(this).parents('.test-step').removeClass('active');
});