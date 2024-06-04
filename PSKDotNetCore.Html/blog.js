const tblBlog = "blogs";
let blogId = null;

getBlogTable();

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

function deleteBlog(id) {
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

// uuid function 
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
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
    Notiflix.Loading.pulse();
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
    setTimeout(function() {
        Notiflix.Loading.remove();
    }, 2000);
})

function successMessage(msg) {
    // alert(msg);
    Swal.fire({
        title: "Good job!",
        text: msg,
        icon: "success"
    });
}

function errorMessage(msg) {
    //alert(msg);
    Swal.fire({
        title: "Good job!",
        text: msg,
        icon: "error"
    });
}

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
        <button type="button" class="btn btn-primary" onclick="editBlog('${item.id}')">Edit</button>
        <button type="button" class="btn btn-danger" onclick="deleteBlog('${item.id}')">Delete</button>
        </td>
      </tr>
        `;
        htmlRows += htmlRow;
    });

    $('#tbody').html(htmlRows);
}