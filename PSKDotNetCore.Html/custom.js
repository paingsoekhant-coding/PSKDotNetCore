// uuid function
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
        (+c ^
            (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (+c / 4)))
        ).toString(16)
    );
}

function successMessage(msg) {
    // Swal.fire({
    //     title: "Good job!",
    //     text: msg,
    //     icon: "success"
    // });
    Notiflix.Report.success("Good job!", msg, "Ok");
}

function errorMessage(msg) {
    // Swal.fire({
    //     title: "Error",
    //     text: msg,
    //     icon: "error"
    // });
    Notiflix.Report.failure("Error", msg, "Ok");
}

function confirmMessage(msg) {
    let confirmMessageResult = new Promise(function(success, error) {
        //     Swal.fire({
        //         title: "Confirm",
        //         text: msg,
        //         icon: "warning",
        //         showCancelButton: true,
        //         confirmButtonText: "Yes"
        //     }).then((result) => {
        //         if (result.isConfirmed) {
        //             success();
        //         } else {
        //             error();
        //         }
        //     });
        // });
        Notiflix.Confirm.show(
            "Confirm",
            msg,
            "Yes",
            "No",
            function okCb() {
                success();
            },
            function cancelCb() {
                error();
            }
        );
    });
    return confirmMessageResult;
}