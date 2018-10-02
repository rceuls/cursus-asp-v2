using System.Collections.Generic;

namespace Blog
{
  public class BlogPost
  {
    public string Title { get; set; }
    public Blog Blog { get; set; }
    public Author Author { get; set; }
    public List<Comment> Comments { get; set; }
  }
}
