$(document).ready(function () {
    $("#openFormModal").click(function () {
        $("#formAddModal").modal("show");
    });

    $(".close").click(function () {
        $("#formAddModal").modal("hide");
    });

    $("#saveFormBtn").click(function () {
        // Form alanlarını seçin
        var formName = $("#formName").val();
        var description = $("#description").val();

        // CreatedAt ve CreatedBy değerlerini alın
        var createdAt = new Date();
        var createdBy = "current user";

        // Form alanlarına CreatedAt, CreatedBy, FormName ve Description değerlerini ekleyin
        $("#createdAt").val(createdAt);
        $("#createdBy").val(createdBy);
        $("#formName").val(formName);
        $("#description").val(description);

        // Formu gönderin
        $("#AddForm").submit();
    });

    $('button[id^="openFieldModal-"]').click(function () {
        var formId = $(this).attr('id').replace('openFieldModal-', '');
        $('#FormId').val(formId);
        console.log(formId);
        $("#fieldAddModal").modal("show");
    });


    $(".close").click(function () {
        $("#fieldAddModal").modal("hide");
    });

    $('#saveField').click(function () {
        var formId = $('#FormId').val();
        var name = $('#Name').val();
        var dataType = $('#DataType').val();
        var required = $('#Required').is(':checked');

        $.ajax({
            type: 'POST',
            url: '/Form/AddFormField',
            data: { formId: formId, name: name, dataType: dataType, required: required },
            success: function () {
                $("#fieldAddModal").modal("hide");
                location.reload();
            },
            error: function () {
                alert('Hata oluştu!');
            }
        });
    });


});