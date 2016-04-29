
$(function () {
    $("#btnCreate").click(function () {
        $("#mymodal input").val("");
        $(".modal-title").html("新增工作");
        $("form").attr("action", "/Home/CreateWork");
    });
});



function Update(workId, workName, description, workMark) {
    $("#WorkId").val(workId);
    $("#WorkName").val(workName);
    $("#Description").val(description);
    $("#WorkMark").val(workMark);
    $("form").attr("action", "/Home/UpdateWork");
    $(".modal-title").html("更新工作");
    $("#mymodal").modal("toggle");
}

function FinishWork(workId) {
    $("#finishModal").modal("toggle");
    $("#btnFinish").click(function () {
        $.ajax({
            url: "/Home/FinishWork",
            type: "post",
            data: { workId: workId },
            success: function (result) {
                if (result === 1) {
                    location.reload();
                }
            }
        });
    });
}
function DeleteWork(workId) {
    $("#deleteModal").modal("toggle");
    $("#btnDelete").click(function () {
        $.ajax({
            url: "/Home/DeleteWork",
            type: "post",
            data: { workId: workId },
            success: function (result) {
                if (result === 1) {
                    location.reload();
                }
            }
        });
    });
}