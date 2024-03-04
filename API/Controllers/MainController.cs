using API.Domain.Entities;
using API.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MainController : ControllerBase {
    private readonly AppDbContext _dbContext;
    private readonly Comment _comment1;
    private readonly Comment _comment2;

    public MainController(AppDbContext dbContext) {
        _dbContext = dbContext;
        
        _comment1 = new Comment() {
            Id = Guid.NewGuid(),
            Text = "This is the body of the comment 1",
            Signature = "signature"
        };
        _comment2 = new Comment() {
            Id = Guid.NewGuid(),
            Text = "This is the body of the comment 2",
            Signature = "signature2"
        };
    }

    [HttpPost("CreateBlog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AddBlog() {
        var blog = new Blog() {
            Id = Guid.NewGuid(),
            Comments = new () {
                _comment1,
                _comment2
            },
            Title = "TheGoodBlog",
            Content = "This is a good blog",
            PriceOfSubscription = 2
        };
        _dbContext.Blogs.Add(blog);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }
}
