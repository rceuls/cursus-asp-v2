namespace Blog
{
  public class Comment
  {
    public string Commenter { get; set; }

    public BlogPost BlogPost { get; set; }
  }
}
