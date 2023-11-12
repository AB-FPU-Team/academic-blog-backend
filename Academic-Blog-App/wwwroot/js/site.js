
$(function () {

    var reportCommentId;
    var selectedReason;
    var commentData;
    var Reportform = $("#reportModel");
    var newCommentForm = $("#formInputNewComment");

    $(document).on('submit', '[id^="editCommentForm"]', function (event) {
        event.preventDefault();
        var clickedButton = event.submitter;
        var editCommentId = $(clickedButton).data("edit-comment-id");
        var space = $(clickedButton).data("spadding-int");
        var content = $("#edit-input-" + editCommentId).val();
        var method = $(clickedButton).data("method");
        if (method === "Edit") {
            EditComment(editCommentId, content, space);
        } else {
           CancelComment(editCommentId, content, space);
        }
        return false;
    });


    $("#editOptions").click(function (event) {
        event.preventDefault();
        var commentId = $(this).data("comment-id");
        var space = $(this).data("space");
        EditOption(commentId, space);
        return false;
    });

    $("#deleteOptions").click(function (event) {
        event.preventDefault();
        var commentId = $(this).data("comment-id");
        DeleteOption(commentId);
        return false;
    });
    Reportform.submit(function (event) {
        event.preventDefault();
        reportCommentId = $("#reportModelCommentId", Reportform).val();
        selectedReason = $("#reasonSelected", Reportform).val();

        console.log("Report Comment Id Fetched: ", reportCommentId);
        console.log("Selected Reason: ", selectedReason);

        ReportComment(reportCommentId, selectedReason);
        return false;
    });
    newCommentForm.submit(function (event) {
        event.preventDefault();
        commentData = $("#inputComment", newCommentForm).val();
        console.log("New Comment : " + newCommentForm);
        CreateNewComment(commentData);
        return false;
    });
    $(document).on("click", ".feedback-btn", function () {
        var commentId = $(this).data("comment-id");
        var spaddingInt = $(this).data("spadding-int");
        console.log("Spadding Int Fetched: " + spaddingInt);
        console.log('Comment Id Fetched: ' + commentId);
        GetReplys(commentId, spaddingInt);
        return false;
    });

    $(document).on("click", ".submit-reply-btn", function () {
        var commentId = $(this).data("reply-comment-id");
        var spaddingInt = $(this).data("spadding-int");
        var currentFormReply = $('#replyContainer-' + commentId);
        if (currentFormReply.is(':visible')) {
            $('#replyContainer-' + commentId).hide();
        } 
        console.log("Spadding Int Fetched: " + spaddingInt);
        console.log('Comment Id Reply Fetched: ' + commentId);
        var replyComment = document.getElementById('inputReplyComment-' + commentId).value;
        console.log(replyComment);
        CreateReply(commentId, replyComment, spaddingInt);
        return false;
    });

    var connection = new signalR.HubConnectionBuilder().withUrl("/CenterHub").build();
    connection.start()
        .then(function () {
            console.log('Hub connection started');
        })
        .catch(function (err) {
            console.error('Error while starting Hub connection: ' + err.toString());
        });
    connection.on("TrackPost", function (blogId) {
        console.log("Post tracked : " + blogId);
        TrackPost(blogId);
    })
    connection.on("GetBlogId", function () {
        console.log("Get Blog Connected");
        GetBlogId();
    })
    GetBlogId();

    connection.on("ReportComment", function (reportCommentId) {
        console.log("Report Blog : " + reportCommentId);
        ReportComment(reportCommentId);
    })
    connection.on("GetReplys", function (commentId){
        console.log("Get Replys Connected");
        GetReplys(commentId);
    })
    connection.on("CreateReply", function (commentId, replyComment, spaddingInt) {
        console.log("Create Reply Connected");
        CreateReply(commentId, replyComment, spaddingInt);
    })

    connection.on("CreateNewComment", function (commentData) {
        console.log("Create new comment connected");
        CreateNewComment(commentData);
    })

    connection.on("EditOption", function (commentId, space) {
        console.log("Edit option connected");
        EditOption(commentId, space);
    })

    connection.on("EditComment", function (commentId, content, space) {
        console.log("Edit Comment connected");
        EditComment(commentId, content, space);
    })

    connection.on("CancelComment", function (commentId, content, space) {
        console.log("Cancel Comment connected");
        CancelComment(commentId, content, space);
    })

    connection.on("DeleteOption", function (commentId) {
        console.log("Delete option connected");
        DeleteOption(commentId);
    })

    function CancelComment(commentId, content, space) {
        console.log("Edit Options Inside: " + commentId);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=EditComment',
            method: 'GET',
            data: { commentId: commentId, content: content },
            success: function (result) {
                var account = result.account;
                var comment = result.comment;
                var login = result.login;
                console.log("Account: " + result.account);
                console.log("Comment: " + result.comment);

                var dayComment = getTimeDifference(new Date(comment.createTime));
                var commentorHtml =
                    ` <div class="value-comment-container" style="margin-left: ${space}px;"> 
                                <div class="col-lg-10 mx-auto border border-dark rounded" style="background-color: gainsboro; margin-top: 20px;">
                         <div class="row align-items-center">
                            <div class="col-sm-1 my-2 border-right border-dark">
                                   <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                             </div>
                                <div class="col-sm">
                                      <h4 class="m-0" style="font-weight: 600;">${account.name}</h4>
                                      <div style="font-weight: bold; color: red; font-size: 14px;"> ${dayComment} </div>
                                  </div>
                                </div>
                                    <div class="col border-top border-dark mt-1">
                                        <p style="color: black; opacity: 80%; padding: 0.5rem 0 0 2rem;">${content}</p>
                                </div>
                       </div>
                        <div class="form-group row py-sm-4 mb-0 align-items-center">
                            <div class="w-100"></div>
                            <div class="col-lg-10 mx-auto" style="color: black; opacity: 80%;">
                            <div class="row align-items-center pt-2">`;
                if (login === true) {
                    commentorHtml += `  <div class="col-2 text-center border-right border-secondary">
                                             <button type="button" id="report-${comment.id}" class="btn btn-outline-warning" data-toggle="modal" data-target="#reportModal" onclick="openReport('${comment.id}')">Report</button>                      
                                         </div>`;
                }
                commentorHtml += `
                            <div id="formReply-${comment.id}" class="col-2 text-center border-right border-secondary">
                                    <form method="get" class="m-0">
                                         <button  class="btn btn-outline-success feedback-btn" id="feedback-${comment.id}" data-comment-id="${comment.id}" data-spadding-int="${space}" data-feed-back="0" type="submit">0 FeedBack</button>
                                    </form>
                              </div>`;
                if (login === true) {
                    commentorHtml += `<div class="col-2 text-center border-right border-secondary">
                                           <button class="btn btn-outline-secondary" type="button" id="reply-${comment.id}" onclick="openReply('${comment.id}')">Reply</button>
                                     </div>`;
                }
                commentorHtml += `    
                       </div>
                              </div>
                                </div>
                                 <div id="replyContainer-${comment.id}" style="display: none; padding-left: 38px" class="col-lg-10 mx-auto pr-0">
                                    <form method="get" class="m-0">
                                        <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                            <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                            </div>
                                            <div class="col-sm-11 pr-0">
                                                <input class="form-control form-control-lg border border-dark" type="text" id="inputReplyComment-${comment.id}" name="inputReplyComment" required maxlength="200" pattern=".*[^ ].*" placeholder="Enter Comment" style="background-color: gainsboro;" />
                                            </div>
                                        </div>
                                        <div class="row justify-content-end">
                                            <button type="submit" class="btn btn-success px-5 submit-reply-btn" data-reply-comment-id="${comment.id}" data-spadding-int="${space}" style="font-size: 17px;">Submit</button>
                                        </div>
                                    </form>
                                </div>
                                </div>
                                <div class="comment-container" id="${comment.id}" style="">
                                </div> `;
                $("#value-comment-" + commentId).html(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    function EditComment(commentId, content, space) {
        console.log("Edit Options Inside: " + commentId);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=EditComment',
            method: 'GET',
            data: { commentId: commentId, content: content},
            success: function (result) {
                var account = result.account;
                var comment = result.comment;
                var login = result.login;
                console.log("Account: " + result.account);
                console.log("Comment: " + result.comment);

                var dayComment = getTimeDifference(new Date(comment.createTime));
                var commentorHtml =
                    ` <div class="value-comment-container" style="margin-left: ${space}px;"> 
                                <div class="col-lg-10 mx-auto border border-dark rounded" style="background-color: gainsboro; margin-top: 20px;">
                         <div class="row align-items-center">
                            <div class="col-sm-1 my-2 border-right border-dark">
                              <a href="/UserPage/StudentProfile?userId=${account.id}">
                                                    <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px; cursor: pointer;" />
                                </a>
                             </div>
                                <div class="col-sm">
                                 <a href="/UserPage/StudentProfile?userId=${account.id}" style="text-decoration: none; color: black; cursor: pointer;">
                                                    <h4 class="m-0" style="font-weight: 600;">${account.name}</h4>
                                   </a>
                                     
                                      <div style="font-weight: bold; color: red; font-size: 14px;"> ${dayComment} </div>
                                  </div>
                                </div>
                                    <div class="col border-top border-dark mt-1">
                                        <p style="color: black; opacity: 80%; padding: 0.5rem 0 0 2rem;">${content}</p>
                                </div>
                       </div>
                        <div class="form-group row py-sm-4 mb-0 align-items-center">
                            <div class="w-100"></div>
                            <div class="col-lg-10 mx-auto" style="color: black; opacity: 80%;">
                            <div class="row align-items-center pt-2">`;
                if (login === true) {
                    commentorHtml += `  <div class="col-2 text-center border-right border-secondary">
                                             <button type="button" id="report-${comment.id}" class="btn btn-outline-warning" data-toggle="modal" data-target="#reportModal" onclick="openReport('${comment.id}')">Report</button>                      
                                         </div>`;
                }
                commentorHtml += `
                            <div id="formReply-${comment.id}" class="col-2 text-center border-right border-secondary">
                                    <form method="get" class="m-0">
                                         <button  class="btn btn-outline-success feedback-btn" id="feedback-${comment.id}" data-comment-id="${comment.id}" data-spadding-int="${space}" data-feed-back="0" type="submit">0 FeedBack</button>
                                    </form>
                              </div>`;
                if (login === true) {
                    commentorHtml += `<div class="col-2 text-center border-right border-secondary">
                                           <button class="btn btn-outline-secondary" type="button" id="reply-${comment.id}" onclick="openReply('${comment.id}')">Reply</button>
                                     </div>`;
                }
                commentorHtml += `    
                       </div>
                              </div>
                                </div>
                                 <div id="replyContainer-${comment.id}" style="display: none; padding-left: 38px" class="col-lg-10 mx-auto pr-0">
                                    <form method="get" class="m-0">
                                        <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                            <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                            </div>
                                            <div class="col-sm-11 pr-0">
                                                <input class="form-control form-control-lg border border-dark" type="text" id="inputReplyComment-${comment.id}" name="inputReplyComment" required maxlength="200" pattern=".*[^ ].*" placeholder="Enter Comment" style="background-color: gainsboro;" />
                                            </div>
                                        </div>
                                        <div class="row justify-content-end">
                                            <button type="submit" class="btn btn-success px-5 submit-reply-btn" data-reply-comment-id="${comment.id}" data-spadding-int="${space}" style="font-size: 17px;">Submit</button>
                                        </div>
                                    </form>
                                </div>
                                </div>
                                <div class="comment-container" id="${comment.id}" style="">
                                </div> `;
                $("#value-comment-" + commentId).html(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    function EditOption(commentId, space) {
        console.log("Edit Options Inside: " + commentId);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=EditOption',
            method: 'GET',
            data: { commentId: commentId },
            success: function (result) {
                var account = result.account;
                var comment = result.comment;
                var login = result.login;
                console.log("Account: " + result.account);
                console.log("Comment: " + result.comment);

                $('#OtherOptionsModal').modal('hide');
                var commentorHtml =
                    `  <div id="edit-container-${comment.id}" style=" padding-left: ${space}px; margin-top: 20px;" class="col-lg-10 mx-auto pr-0">
                                        <form method="post" class="m-0" id="editCommentForm">
                                            <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                                <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                    <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                                </div>
                                                <div class="col-sm-11 pr-0">
                                                    <input class="form-control form-control-lg border border-dark" type="text" id="edit-input-${comment.id}" name="valueEdit" required maxlength="200" pattern=".*[^ ].*" value="${comment.content}" style="background-color: gainsboro;" />
                                                </div>
                                            </div>
                                            <div class="row justify-content-end">
                                                <button type="submit" class="btn btn-success px-5" data-edit-comment-id="${comment.id}" data-spadding-int="${space}" data-method="Edit" style="font-size: 17px;">Edit</button>
                                                <button type="submit" class="btn btn-success px-5" data-edit-comment-id="${comment.id}" data-spadding-int="${space}" data-method="Cancel" style="font-size: 17px;">Cancel</button>
                                            </div>
                                        </form>
                                    </div>`;
                $("#value-comment-" + commentId).html(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function DeleteOption(commentId) {
        console.log("Delete Options Inside: " + commentId);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=DeleteOption',
            method: 'GET',
            data: { commentId: commentId },
            success: function (result) {
                if (result.success)
                var commentorHtml =
                    `
                    `;
                $("#value-comment-" + commentId).html(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    function CreateNewComment(commentData) {
        console.log("Create New Comment Running Inside: " + commentData);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=CreateNewComment',
            method: 'GET',
            data: { commentData: commentData},
            success: function (result) {
                $('#commentBlog').modal('hide');
                var account = result.account;
                var comment = result.comment;
                var login = result.login;
                console.log("Account: " + result.account);
                console.log("Comment: " + result.comment);
                var dayComment = getTimeDifference(new Date(comment.createTime));
                var commentorHtml =
                    `     <div class="value-comment-container" id="value-comment-${comment.id}" style="margin-left: 0px;" onmousedown=openOthersOption('${comment.id}',0)> 
                    <div class="col-lg-10 mx-auto border border-dark rounded" style="background-color: gainsboro; margin-top: 20px;">
                         <div class="row align-items-center">
                            <div class="col-sm-1 my-2 border-right border-dark">
                              <a href="/UserPage/StudentProfile?userId=${account.id}">
                                      <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px; cursor: pointer;" />
                                </a>
                             </div>
                                <div class="col-sm">
                                 <a href="/UserPage/StudentProfile?userId=${account.id}" style="text-decoration: none; color: black; cursor: pointer;">
                                            <h4 class="m-0" style="font-weight: 600;">${account.name}</h4>
                                   </a>
                                      <div style="font-weight: bold; color: red; font-size: 14px;">${dayComment}</div>
                                  </div>
                                </div>
                                    <div class="col border-top border-dark mt-1">
                                        <p style="color: black; opacity: 80%; padding: 0.5rem 0 0 2rem;">${comment.content}</p>
                                </div>
                       </div>
                        <div class="form-group row py-sm-4 mb-0 align-items-center">
                            <div class="w-100"></div>
                            <div class="col-lg-10 mx-auto" style="color: black; opacity: 80%;">
                            <div class="row align-items-center pt-2">`;
                commentorHtml += `
                             <div id="formReply-${comment.id}" class="col-2 text-center border-right border-secondary">
                                    <form method="get" class="m-0">
                                         <button class="btn btn-outline-success feedback-btn" id="feedback-${comment.id}" data-comment-id="${comment.id}" data-spadding-int="0" data-feed-back="0" type="submit">0 FeedBack</button>
                                    </form>
                              </div>`;
                if (login === true) {
                    commentorHtml += `<div class="col-2 text-center border-right border-secondary">
                                           <button class="btn btn-outline-secondary" type="button" id="reply-${comment.id}" onclick="openReply('${comment.id}')">Reply</button>
                                     </div>`;
                }
                commentorHtml += `    
                         </div>
                              </div>
                                </div>
                                 <div id="replyContainer-${comment.id}" style="display: none; padding-left: 38px" class="col-lg-10 mx-auto pr-0">
                                    <form method="get" class="m-0">
                                        <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                            <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                            </div>
                                            <div class="col-sm-11 pr-0">
                                                <input class="form-control form-control-lg border border-dark" type="text" id="inputReplyComment-${comment.id}" name="inputReplyComment" required maxlength="200" pattern=".*[^ ].*" placeholder="Enter Comment" style="background-color: gainsboro;" />
                                            </div>
                                        </div>
                                        <div class="row justify-content-end">
                                            <button type="submit" class="btn btn-success px-5 submit-reply-btn" data-reply-comment-id="${comment.id}" data-spadding-int="38" style="font-size: 17px;">Submit</button>
                                        </div>
                                    </form>
                                </div>
                                </div>
                                  <div class="comment-container" id="${comment.id}" style="">
                                </div> `;
                $("#newComment").prepend(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
    function CreateReply(commentId, replyComment, spaddingInt) {
        console.log("Create Reply Running Inside: " + commentId);

        var currentCommentTag = document.getElementById("blogComment").textContent;
        var currentFeedBackTag = document.getElementById("feedback-" + commentId).textContent;

        var modifiedString = currentCommentTag.replace(new RegExp("Comments", "g"), "");
        var trimModifiedString = modifiedString.trim();

        var [feedBackNumber, feedBackText] = currentFeedBackTag.split(" ");

        var currentComment = parseInt(trimModifiedString);
        var currentFeedBack = parseInt(feedBackNumber);
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=CreateReply',
            method: 'GET',
            data: { commentId: commentId, replyComment: replyComment, spaddingInt: spaddingInt },
            success: function (result) {

                currentComment += 1;
                currentFeedBack += 1;
                $("#blogComment").text(currentComment + " Comments");
                $("#feedback-" + commentId).text(currentFeedBack + " " + feedBackText);

                var account = result.account;
                var comment = result.comment;
                var distance = result.distance;
                var login = result.login;
                console.log("Account: " + account.avatar);
                console.log("Comment: " + result.comment);
                console.log("Distances: " + result.distance);
                console.log("Login: " + result.login);
                var dayComment = getTimeDifference(new Date(comment.createTime));
                var commentorHtml =
                    `     <div class="value-comment-container" id="value-comment-${comment.id}" style="margin-left: ${distance}px;" onmousedown=openOthersOption('${comment.id}',${distance})> 
                                <div class="col-lg-10 mx-auto border border-dark rounded" style="background-color: gainsboro; margin-top: 20px;">
                         <div class="row align-items-center">
                            <div class="col-sm-1 my-2 border-right border-dark">
                             <a href="/UserPage/StudentProfile?userId=${account.id}">
                                      <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px; cursor: pointer;" />
                                </a>
                             </div>
                                <div class="col-sm">
                                 <a href="/UserPage/StudentProfile?userId=${account.id}" style="text-decoration: none; color: black; cursor: pointer;">
                                            <h4 class="m-0" style="font-weight: 600;">${account.name}</h4>
                                   </a>
                                      <div style="font-weight: bold; color: red; font-size: 14px;"> ${dayComment} </div>
                                  </div>
                                </div>
                                    <div class="col border-top border-dark mt-1">
                                        <p style="color: black; opacity: 80%; padding: 0.5rem 0 0 2rem;">${comment.content}</p>
                                </div>
                       </div>
                        <div class="form-group row py-sm-4 mb-0 align-items-center">
                            <div class="w-100"></div>
                            <div class="col-lg-10 mx-auto" style="color: black; opacity: 80%;">
                            <div class="row align-items-center pt-2">`;
                commentorHtml += `
                            <div id="formReply-${comment.id}" class="col-2 text-center border-right border-secondary">
                                    <form method="get" class="m-0">
                                         <button  class="btn btn-outline-success feedback-btn" id="feedback-${comment.id}" data-comment-id="${comment.id}" data-spadding-int="${distance}" data-feed-back="0" type="submit">0 FeedBack</button>
                                    </form>
                              </div>`;
                if (login === true) {
                    commentorHtml += `<div class="col-2 text-center border-right border-secondary">
                                           <button class="btn btn-outline-secondary" type="button" id="reply-${comment.id}" onclick="openReply('${comment.id}')">Reply</button>
                                     </div>`;
                }
                commentorHtml += `    
                       </div>
                              </div>
                                </div>
                                 <div id="replyContainer-${comment.id}" style="display: none; padding-left: 38px" class="col-lg-10 mx-auto pr-0">
                                    <form method="get" class="m-0">
                                        <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                            <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                <img class="rounded-circle shadow" src="/${account.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                            </div>
                                            <div class="col-sm-11 pr-0">
                                                <input class="form-control form-control-lg border border-dark" type="text" id="inputReplyComment-${comment.id}" name="inputReplyComment" required maxlength="200" pattern=".*[^ ].*" placeholder="Enter Comment" style="background-color: gainsboro;" />
                                            </div>
                                        </div>
                                        <div class="row justify-content-end">
                                            <button type="submit" class="btn btn-success px-5 submit-reply-btn" data-reply-comment-id="${comment.id}" data-spadding-int="${distance}" style="font-size: 17px;">Submit</button>
                                        </div>
                                    </form>
                                </div>                                                   
                                </div>
                                  <div class="comment-container" id="${comment.id}" style="">
                                </div>   `;
                $("#" + commentId).prepend(commentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function ReportComment(reportCommentId, selectedReason) {
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=Report',
            method: 'GET',
            data: { reportCommentId: reportCommentId, selectedReason: selectedReason},
            success: function (result) {
                if (result.success) {
                    alert("Report Success");
                } else {
                    alert("Report Failed Try Back Later");
                }
            },
            error: (error) => {
                console.log(error);
            }
        })
    }

    function GetReplys(commentId, spaddingInt) {
        console.log("Get Replys Running Inside: " + commentId);
        var nextCommentId = '';
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=Reply',
            method: 'GET',
            data: { commentId: commentId, distanceInt: spaddingInt },
            success: function (result) {
                var totalComentorHtml = '';
                var totalFeedBack = '0';
                var accountReplys = result.accountReplys;
                var replys = result.replys;
                var distance = result.distance;
                var feedBacks = result.feedBacks;
                var login = result.login;
                var currentAcc = result.currentAccount
                console.log("Account Replys: " + result.accountReplys);
                console.log("Replys: " + result.replys);
                console.log("Distances: " + result.distance);
                console.log("distanceForReply: " + result.distanceForReply);
                console.log("Login: " + result.login);
                $.each(replys, function (index, reply) {
                    $.each(feedBacks, function (index, feed) {
                        var [id, number] = feed.split(":");
                        if (id == reply.id) {
                            totalFeedBack = number;
                        }
                    });
                    $.each(accountReplys, function (index, acc) {
                        if (reply.commentorId === acc.id) {                                         
                                    nextCommentId = reply.id;
                            console.log("Next CommentId: " + nextCommentId);
                            var dayComment = getTimeDifference(new Date(reply.createTime));
                            var head = `<div class="value-comment-container" id="value-comment-${reply.id}" style="margin-left: ${distance}px;">`;
                            if (currentAcc != null) {
                                if (reply.commentorId == currentAcc.id) {
                                    head = `<div class="value-comment-container" id="value-comment-${reply.id}" style="margin-left: ${distance}px;" onmousedown="openOthersOption('${reply.id}', ${distance})">`;
                                }
                            }
                            var commentorHtml =
                                ` ${head}  
                                <div class="col-lg-10 mx-auto border border-dark rounded" style="background-color: gainsboro; margin-top: 20px;">
                         <div class="row align-items-center">
                            <div class="col-sm-1 my-2 border-right border-dark">
                             <a href="/UserPage/StudentProfile?userId=${acc.id}">
                                      <img class="rounded-circle shadow" src="/${acc.avatar}" alt="Avatar" style="width: 50px; height: 50px; cursor: pointer;" />
                                </a>
                             </div>
                                <div class="col-sm">
                                 <a href="/UserPage/StudentProfile?userId=${acc.id}" style="text-decoration: none; color: black; cursor: pointer;">
                                            <h4 class="m-0" style="font-weight: 600;">${acc.name}</h4>
                                   </a>
                                      <div style="font-weight: bold; color: red; font-size: 14px;">${dayComment}</div>
                                  </div>
                                </div>
                                    <div class="col border-top border-dark mt-1">
                                        <p style="color: black; opacity: 80%; padding: 0.5rem 0 0 2rem;">${reply.content}</p>
                                </div>
                       </div>
                        <div class="form-group row py-sm-4 mb-0 align-items-center">
                            <div class="w-100"></div>
                            <div class="col-lg-10 mx-auto" style="color: black; opacity: 80%;">
                            <div class="row align-items-center pt-2">`;
                            if (login === true) {
                                if (currentAcc.id !== reply.commentorId) {
                                commentorHtml += `<div class="col-2 text-center border-right border-secondary">
                                             <button type="button" id="report-${reply.id}" class="btn btn-outline-warning" data-toggle="modal" data-target="#reportModal" onclick="openReport('${reply.id}')">Report</button>                      
                                         </div>`;
                                }
                            }
                            commentorHtml += `                        
                             <div id="formReply-${reply.id}" class="col-2 text-center border-right border-secondary">
                                    <form method="get" class="m-0">
                                         <button class="btn btn-outline-success feedback-btn" id="feedback-${reply.id}" data-comment-id="${reply.id}" data-spadding-int="${distance}" data-feed-back="${totalFeedBack}" type="submit">${totalFeedBack} FeedBack</button>
                                    </form>
                              </div> `;
                            if (login === true) {
                                commentorHtml += ` <div class="col-2 text-center border-right border-secondary">
                                           <button class="btn btn-outline-secondary" type="button" id="reply-${reply.id}" onclick="openReply('${reply.id}')">Reply</button>
                                     </div>`;
                            }                      
                            commentorHtml += `                            
                         </div>
                              </div>
                                </div>`
                            if (currentAcc != null) {
                                commentorHtml += ` <div id="replyContainer-${reply.id}" style="display: none; padding-left: 38px" class="col-lg-10 mx-auto pr-0">
                                    <form method="get" class="m-0">
                                        <div class="form-group row pb-sm-1 mb-0 align-items-center">
                                            <div class="col-sm-1 p-0 text-center border-right border-dark" style="width: 50px; height: 50px;">
                                                <img class="rounded-circle shadow" src="/${currentAcc.avatar}" alt="Avatar" style="width: 50px; height: 50px;" />
                                            </div>
                                            <div class="col-sm-11 pr-0">
                                                <input class="form-control form-control-lg border border-dark" type="text" id="inputReplyComment-${reply.id}" name="inputReplyComment" required maxlength="200" pattern=".*[^ ].*" placeholder="Enter Comment" style="background-color: gainsboro;" />
                                            </div>
                                        </div>
                                        <div class="row justify-content-end">
                                            <button type="submit" class="btn btn-success px-5 submit-reply-btn" data-reply-comment-id="${reply.id}" data-spadding-int="${distance}" style="font-size: 17px;">Submit</button>
                                        </div>
                                    </form>
                                </div>`
                            }
                            commentorHtml += ` 
                               </div>
                                <div class="comment-container" id="${reply.id}" style="">
                                </div>`;
                        totalComentorHtml += commentorHtml;
                        }           
                    });
                });
                $("#" + commentId).html(totalComentorHtml);
            },
            error: function (error) {
                console.log(error);
            }
        });
    }

    function getTimeDifference(createTime) {
        var currentDate = new Date();
        var timeDifference = Math.floor((currentDate - createTime) / 1000); 

        var postFixTime = "";
        if (timeDifference < 60) {
            if (timeDifference === 0) {
                return "Just now";
            }
            postFixTime = "Seconds ago";
        } else if (timeDifference < 3600) {
            timeDifference = Math.floor(timeDifference / 60); 
            postFixTime = "Minutes ago";
        } else if (timeDifference < 86400) {
            timeDifference = Math.floor(timeDifference / 3600); 
            postFixTime = "Hours ago";
        } else {
            timeDifference = Math.floor(timeDifference / 86400);
            postFixTime = "Days ago";
        }

        var dayComment = timeDifference + " " + postFixTime;
        return dayComment;
    }


    function GetBlogId() {
        console.log("Get Blog Id Running Inside");
        $.ajax({
            url: '/AjaxPage/AjaxHandel?handler=BlogId',
            method: 'GET',
            success: function (result) {

                var blogId = result.blogId;
                console.log("Get Blog id return: " + blogId);
                TrackPost(blogId);
            },
            error: function (error) {
                console.log('Error occurred during GetBlogId request:', error);
            }
        })
    }
    function TrackPost(blogId) {
        console.log("Track Blog running inside : " + blogId);
        var currentViewTag = document.getElementById("blogView").textContent;
        var currentView = parseInt(currentViewTag);
        console.log("Current View: " + currentView);
        GenerateFingerprint(function (fingerprint) {
            console.log('Fingerprin: ' + fingerprint);
            console.log('Blog Id: ' + blogId)
            $.ajax({
                url: '/AjaxPage/AjaxHandel?handler=TrackBlog',
                type: 'GET',
                data: {
                    blogId: blogId,
                    fingerprint: fingerprint
                },
                success: function (result) {
                    if (result.success) {
                        console.log('View Counted');
   
                        currentView += 1;
                        var newBlogView = `<i class="fa fa-eye"  style="font-size:30px;color:black">${currentView}</i>`; 
                        $("#blogView").html(newBlogView);
                    } else {
                        console.log('View UnCounted');
                    }
                },
                error: function (error) {
                    console.log('Error occurred during tracking:', error);
                }
            });
        });
    }

    function GenerateFingerprint(callback) {
        Fingerprint2.get(function (components) {
            var values = components.map(function (component) { return component.value });
            var fingerprint = Fingerprint2.x64hash128(values.join(''), 31);
            callback(fingerprint);
        });
    }
});
