using PSKDotNetCore.NLayer.DataAccess.Services;
using PSKDotNetCore.NLayer.DataAccess;

namespace PSKDotNetCore.NLayer.BusinessLogic.Services;

public class BL_Blog
{
    private readonly DA_Blog _daBlog;

    public BL_Blog()
    {
        _daBlog = new DA_Blog();
    }

    public List<BlogModel> GetBlogs()
    {
        var lst = _daBlog.GetBlogs();
        return lst;
    }

    public BlogModel GetBlog(int id)
    {
        var result = _daBlog.GetBlog(id);
        return result;
    }

    public int CreateBlog(BlogModel requestModel)
    {
        var result = _daBlog.CreateBlog(requestModel);
        return result;
    }

    public int UpdateBlog(int id, BlogModel requestModel)
    {
        var result = _daBlog.UpdateBlog(id, requestModel);
        return result;
    }

    public int DeleteBlog(int id)
    {
        var result = _daBlog.DeleteBlog(id);
        return result;
    }
}
