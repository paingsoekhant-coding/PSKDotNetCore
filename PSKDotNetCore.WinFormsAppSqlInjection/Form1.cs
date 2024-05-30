using PSKDotNetCore.Shared;

namespace PSKDotNetCore.WinFormsAppSqlInjection;

public partial class Form1 : Form
{
    private readonly DapperService _dapperService;
    public Form1()
    {
        InitializeComponent();
        _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        //this query can Injection
        //string query = $"select * from Tbl_User where email = '{txtEmail.Text.Trim()}' and password = '{txtPassword.Text.Trim()}'";

        //this query can't Injection
        string query = $"select * from tbl_User where email = @Email and password = @Password ";
        var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
        {
            Email = txtEmail.Text.Trim(),
            Password = txtPassword.Text.Trim()
        });
        if (model is null)
        {
            MessageBox.Show("User Does Not Exit.");
            return;
        }

        MessageBox.Show("Is Admin: " + model.Email);
    }
}

public class UserModel
{
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}
