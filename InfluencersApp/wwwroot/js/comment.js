$(document).ready(() => {

    $("#send").click(() => {

        let articleId = $("#article-id").html();

        var data = {
            ArticleId: parseInt(articleId),
            Nickname: $("#nickname").html(),
            Content: $("#comment").html(),
            Succeded: false
        }

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            data: JSON.stringify(data),
            success: (response) => {
                if (response.succeded == true) {

                }
                else {
                    alert("Oops, unable to add article... please try again!");
                }
            }
        });
    });
});