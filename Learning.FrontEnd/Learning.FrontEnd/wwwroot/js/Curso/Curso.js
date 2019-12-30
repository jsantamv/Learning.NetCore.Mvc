function () {
    $('.edit-mode').hide();
    $('.edit-user, .cancel-user').on('click', function () {
        var tr = $(this).parents('tr:first');
        tr.find('.edit-mode, .display-mode').toggle();
    });

    $('.save-user').on('click', function () {
        var tr = $(this).parents('tr:first');
        var Name = tr.find("#Name").val();        
        var UserID = tr.find("#UserID").html();
        tr.find("#lblName").text(Name);        
        tr.find('.edit-mode, .display-mode').toggle();
        var UserModel =
        {
            "ID": UserID,
            "Name": Name
        };
        $.ajax({
            url: '/Curso/Create/',
            data: JSON.stringify(UserModel),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert(data);
            }
        });

    });
}