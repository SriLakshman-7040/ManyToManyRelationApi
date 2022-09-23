$.get("api/Employees", function (data, result) {
    let dynamictable = "";
    if (data) {
        for (let empdetail in data) {
            dynamictable += "<tr>"
            dynamictable += "<td>" + data[empdetail].employeeId + "<td>"
            dynamictable += "<td>" + data[empdetail].name + "<td>"
            dynamictable += "<td>" + data[empdetail].status + "<td>"
            dynamictable += "<td>" + data[empdetail].manager + "<td>"
            dynamictable += "<td>" + data[empdetail].wfm_Manager + "<td>"
            dynamictable += "<td>" + data[empdetail].email + "<td>"
            dynamictable += "<td>" + data[empdetail].lockStatus + "<td>"
            dynamictable += "<td>" + data[empdetail].experience + "<td>"
            dynamictable += "<td>" + data[empdetail].skills + "<td>"
            dynamictable += "</tr>"
        }
        $("#employeeDetailsBind").html(dynamictable);
    }
})