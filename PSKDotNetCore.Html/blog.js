const tblBlog = "blogs";
let blogId = null;

getBlogTable();
// testConfirmMessage2();

function testConfirmMessage() {
    let confirmMessage = new Promise(function(success, error) {

        const result = confirm('Are you sure want to delete?');
        if (result) {
            success();
        } else {
            error();
        }
    });


    confirmMessage.then(
        function(value) {
            /* code if successful */
            successMessage("Blog Deleted Successfully");
        },
        function(error) {
            /* code if some error */
            errorMessage("Blog Deletion Failed");
        }
    );
}

function testConfirmMessage2() {
    let confirmMessage = new Promise(function(success, error) {
        // "Producing Code" (May take some time)
        Swal.fire({
            title: "Confirm",
            text: "Are you sure want to delete?",
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes"
        }).then((result) => {
            if (result.isConfirmed) {
                success();
            } else {
                error();
            }

        });

    });

    // "Consuming Code" (Must wait for a fulfilled Promise)
    confirmMessage.then(
        function(value) {
            /* code if successful */
            successMessage("Blog Deleted Successfully");
        },
        function(error) {
            /* code if some error */
            errorMessage("Blog Deletion Failed");
        }
    );
}

//createBlog("new title", "new author", "new content");
//readBlog();
//editBlog("f8043c69-1232-4bbd-a9cd-b0d93a1564d2");
//updateBlog("f8043c69-1232-4bbd-a9cd-b0d93a1564d2", "update1 title", "update2 author", "update3 content");
//deleteBlog("687ba841-3097-451e-87c4-f696d0f0cc5d");

function readBlog() {

    let lst = getBlogs();
    if (lst == 0) {
        console.log("No Data Found");
        errorMessage("No Data Found");
        return;
    }
    console.log(lst);
    // document.write(blogs);
}

function createBlog(title, author, content) {
    let lst = getBlogs();

    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Blog Created Successfully");
    clearControls();
}

function editBlog(id) {
    const lst = getBlogs();
    console.log(lst);

    const items = lst.find(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        errorMessage("No Data Found");
        return;
    }
    // return items;
    blogId = items.id;
    $('#txtTitle').val(items.title);
    $('#txtAuthor').val(items.author);
    $('#txtContent').val(items.content);
    $('#txtTitle').focus();
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

    const items = lst.find(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        errorMessage("No Data Found");
        return;
    }

    items.title = title;
    items.author = author;
    items.content = content;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Blog Updated Successfully");
}

function deleteBlog2(id) {
    let result = confirm("Are you sure want to delete?");
    if (!result) return;

    let lst = getBlogs();

    const items = lst.filter(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        errorMessage("No Data Found");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    // console.log(lst);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Blog Deleted Successfully");
    getBlogTable();
}

function deleteBlog3(id) {
    Swal.fire({
        title: "Confirm",
        text: "Are you sure want to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes"
    }).then((result) => {
        if (!result.isConfirmed) return;
        let lst = getBlogs();

        const items = lst.filter(x => x.id === id);
        console.log(items);

        if (items == null) {
            console.log("No Data Found");
            errorMessage("No Data Found");
            return;
        }

        lst = lst.filter(x => x.id !== id);
        // console.log(lst);
        const jsonBlog = JSON.stringify(lst);
        localStorage.setItem(tblBlog, jsonBlog);

        successMessage("Blog Deleted Successfully");
        getBlogTable();

    });
}

function deleteBlog(id) {

    confirmMessage("Are you sure want to delete?").then(
        function(value) {
            let lst = getBlogs();

            const items = lst.filter(x => x.id === id);
            console.log(items);

            if (items == null) {
                console.log("No Data Found");
                errorMessage("No Data Found");
                return;
            }

            lst = lst.filter(x => x.id !== id);
            // console.log(lst);
            const jsonBlog = JSON.stringify(lst);
            localStorage.setItem(tblBlog, jsonBlog);

            successMessage("Blog Deleted Successfully");

            getBlogTable();
        }
    );
}

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}

$('#btnSave').click(function() {
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    if (blogId === null) {
        createBlog(title, author, content);
    } else {
        updateBlog(blogId, title, author, content);
        blogId = null;
    }

    getBlogTable();
})

function clearControls() {
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}

function getBlogTable() {
    const lst = getBlogs();
    let count = 0;
    let htmlRows = " ";
    lst.forEach(item => {
        const htmlRow = `
        <tr>
        <td>${++count}</td>
        <td>${item.title}</td>
        <td>${item.author}</td>
        <td>${item.content}</td>
        <td>
        <button type="button" class="btn btn-info" onclick="editBlog('${item.id}')">Edit</button>
        <button type="button" class="btn btn-warning" onclick="deleteBlog('${item.id}')">Delete</button>
        </td>
      </tr>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}