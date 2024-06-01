const tblBlog = "blogs";

//createBlog();
readBlog();
//editBlog("29ca2d98-c1ae-43f1-832b-6189b9970d0f");
//updateBlog("04396ffb-a8c9-4cca-b556-891245197bc6", "update title", "update author", "update content");
//deleteBlog("6a64e7de-6e8b-4bea-851d-54bc51c1ba02");

function readBlog() {

    const blogs = localStorage.getItem(tblBlog);
    if (blogs == null) {
        console.log("No Data Found");
        return;
    }
    console.log(blogs);
    // document.write(blogs);
}

function createBlog() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const requestModel = {
        id: uuidv4(),
        title: "test title",
        author: "test author",
        content: "test content"
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function editBlog(id) {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const items = lst.find(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        return;
    }
}

function updateBlog(id, title, author, content) {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const items = lst.find(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        return;
    }

    items.title = title;
    items.author = author;
    items.content = content;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function deleteBlog(id) {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }

    const items = lst.filter(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        return;
    }

    lst = lst.filter(x => x.id !== id);
    // console.log(lst);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

// uuid function 
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}