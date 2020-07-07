$(document).ready(() => {

    $("#send").click(() => {

        let articleId = $("#article-id").html();

        var data = {
            ArticleId: parseInt(articleId),
            Nickname: $("#nickname").val(),
            Content: $("#comment").val(),
            Succeded: false
        }

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: "http://localhost:54096/ArticleApi/articleApi/sendComment",
            data: JSON.stringify(data),
            success: (response) => {
                if (response.succeded == true) {
                    $("#comments-block").append
                        ('<div class="row justify-content-center"><div class="col-sm-12 col-md-6"><div class="media-body pt-3 pb-3 pr-4 d-block comment"><h5 class="media-heading">' + response.nickname + '</h5><p>' + response.content + '</p></div></div></div>')
                }
                else {
                    alert("Oops, unable to add article... please try again!");
                }
            },
            dataType: "json"
        });
    });
});