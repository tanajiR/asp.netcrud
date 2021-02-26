var pageindex = 1;
var pagesize = 5;
function ShowMoreRecords(_this) {
    $(_this).text("Loading...");

    $.ajax({
        url: "/user/getmorerecords",
        data: { pageindex, pagesize },
        success: function (response) {
            $(_this).text("Show Next 5 Records");
            //console.log(JSON.stringify(response.data));
            var counter = (pageindex * pagesize) + 1;
            var tr = "<tr>";
            $(response.data).each(function () {
                tr += "<td>" + counter + "</td>";
                tr += "<td>" + this.full_name + "</td>";
                tr += "<td>" + this.mno + "</td>";
                tr += "<td>" + this.email + "</td>";
                tr += "<td>" + this.password + "</td>";
                tr += "<td>" + this.addr + "</td>";
                tr += '<td><a href = "/user/edituser/' + this.id + '" class="btn btn-primary btn-xs" > Edit</a > <a onclick="return confirm(\"Are you sure?\")" href="/user/deleteuser/' + this.id + '" class="btn btn-danger btn-xs">Delete</a></td ><tr/>';
                counter++;
            });

            $("table").append(tr);

            pageindex++;
        }
    });
}
$("#HomeL").on("click", function () {
    $("li").removeClass("active");
    $(this).addClass("active");
});