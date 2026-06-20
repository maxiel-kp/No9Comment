using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace No9Comment.Pages;

public class IndexModel : PageModel
{
    private static readonly List<Comment> CommentStorage = new();

    public List<Comment> Comments { get; set; } = new();

    [BindProperty]
    public string? CommentText { get; set; }

    public void OnGet()
    {
        Comments = CommentStorage;
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrWhiteSpace(CommentText))
        {
            CommentStorage.Add(new Comment
            {
                UserName = "Blend 285",
                Text = CommentText.Trim(),
                CreatedAt = DateTime.Now
            });
        }

        return RedirectToPage();
    }
}

public class Comment
{
    public string UserName { get; set; } = "";
    public string Text { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}