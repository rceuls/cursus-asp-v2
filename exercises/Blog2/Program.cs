using System;
using System.Collections.Generic;

namespace Blog
{
  public class Program
  {
    static void Main(string[] args)
    {
      var blog = new Blog();
      blog.Name = "My new blog";

      var blogPost = new BlogPost();
      blogPost.Title = "my first blogpost";
      blog.BlogPosts = new List<BlogPost>();
      blog.BlogPosts.Add(blogPost);

      blogPost.Blog = blog;

      Console.WriteLine($"Naam van mijn blog: {blogPost.Blog.Name}");
      Console.WriteLine($"Naam van mijn blogpost: {blogPost.Title}");
    }
    /*
      Blog, Blogpost, Author, Category, Comment
      Blog heeft meerdere blogposts, blogpost heeft één blog
      Blogpost heeft één auteur, auteur heeft meerdere blogposts
      Blogpost heeft meerdere categorieën, category heeft meerdere blogposts
      Blogpost heeft meerdere comments, comment heeft één Blogpost 
     */
  }
}
