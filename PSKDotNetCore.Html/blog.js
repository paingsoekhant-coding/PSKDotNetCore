const tblBlog = "blogs";

//createBlog("new title", "new author", "new content");
readBlog();
//editBlog("f8043c69-1232-4bbd-a9cd-b0d93a1564d2");
//updateBlog("f8043c69-1232-4bbd-a9cd-b0d93a1564d2", "update1 title", "update2 author", "update3 content");
//deleteBlog("687ba841-3097-451e-87c4-f696d0f0cc5d");

function readBlog() {

    let lst = getBlogs();
    if (lst == 0) {
        console.log("No Data Found");
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
}

function editBlog(id) {
    const lst = getBlogs();
    console.log(lst);

    const items = lst.find(x => x.id === id);
    console.log(items);

    if (items == null) {
        console.log("No Data Found");
        return;
    }
}

function updateBlog(id, title, author, content) {
    let lst = getBlogs();

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
    let lst = getBlogs();

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

function getBlogs() {
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if (blogs !== null) {
        lst = JSON.parse(blogs);
    }
    return lst;
}