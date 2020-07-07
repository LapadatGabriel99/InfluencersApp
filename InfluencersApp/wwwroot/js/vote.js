$(document).ready(() => {
    let vote = 0;        

    $('#s1').click(() => {
        if ($("#s1").css("color") === 'rgb(255, 255, 0)') {
            vote = 1;
        }
        else {
            vote = 0;
        }
    });
    $('#s2').click(() => {
        if ($("#s2").css("color") === 'rgb(255, 255, 0)') {
            vote = 2;
        }
        else {
            if ($("#s1").css("color") === 'rgb(255, 255, 0)') {
                vote = 1;
            }
            else {
                vote = 0;
            }
        }
    });
    $('#s3').click(() => {
        if ($("#s3").css("color") === 'rgb(255, 255, 0)') {
            vote = 3;
        }
        else {
            if ($("#s2").css("color") === 'rgb(255, 255, 0)') {
                vote = 2;
            }
            else {
                if ($("#s1").css("color") === 'rgb(255, 255, 0)') {
                    vote = 1;
                }
                else {
                    vote = 0;
                }
            }
        }
    });
    $('#s4').click(() => {
        if ($("#s4").css("color") === 'rgb(255, 255, 0)') {
            vote = 4;
        }
        else {
            if ($("#s3").css("color") === 'rgb(255, 255, 0)') {
                vote = 3;
            }
            else {
                if ($("#s2").css("color") === 'rgb(255, 255, 0)') {
                    vote = 2;
                }
                else {
                    if ($("#s1").css("color") === 'rgb(255, 255, 0)') {
                        vote = 1;
                    }
                    else {
                        vote = 0;
                    }
                }
            }
        }
    });
    $('#s5').click(() => {
        let color = $("#s5").css("color");

        console.log(color);

        if ($("#s5").css("color") === 'rgb(255, 255, 0)') {
            vote = 5;
        }
        else {
            if ($("#s4").css("color") === 'rgb(255, 255, 0)') {
                vote = 4;
            }
            else {
                if ($("#s3").css("color") === 'rgb(255, 255, 0)') {
                    vote = 3;
                }
                else {
                    if ($("#s2").css("color") === 'rgb(255, 255, 0)') {
                        vote = 2;
                    }
                    else {
                        if ($("#s1").css("color") === 'rgb(255, 255, 0)') {
                            vote = 1;
                        }
                        else {
                            vote = 0;
                        }
                    }
                }
            }
        }
    });

    $("#vote").click(() => {                   

        let articleId = $("#article-id").html();
       
        if (typeof $.cookie(articleId) === 'undefined') {
            $.cookie(articleId, 0, { expires: 20 * 365, });
        }
        else {
            
        }
       
        if ($.cookie(articleId) == 0) {

            if (vote === 0) {
                $("#response").html("You must pick at least on star in order to vote...");

                return;
            }

            $.cookie(articleId, vote)
        }
        else {
            $("#response").html("Looks like you already voted this article!");

            return;
        }

        var data = {
            Score: vote,
            ArticleId: parseInt($("#article-id").html()),
            Succeded: false
        };

        console.log(JSON.stringify(data));

        $.ajax({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            type: "POST",
            url: "http://localhost:54096/ArticleApi/articleApi/sendVote",
            data: JSON.stringify(data),
            success: (response) => {              
                if (response.succeded === true) {
                    $("#response").html("Vote has been registered!");
                }
                else {
                    $("#response").html("Ops, something went wrong!");
                }                
            },            
            dataType: "json"
        });
    });    
});