
$(function () {
    var connection = new signalR.HubConnectionBuilder().withUrl("/CenterHub").build();
    connection.start();

    connection.on("TrackPost", function () {
        TrackPost();
    })

    function TrackPost(postId) {
        GenerateFingerprint(function (fingerprint) {
            $.ajax({
                url: '/AjaxPage/AjaxHandel?handler=TrackPost',
                method: 'POST',
                data: {
                    postId: postId,
                    fingerprint: fingerprint
                },
                success: function (result) {
                    if (result.success) {
                        console.log('View Counted');
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
