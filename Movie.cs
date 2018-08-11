using System;
namespace hellodotnetcore
{
    public class Movie
    {
        public string Id { get; }
        public string Title { get; }

        public Movie(string id, string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public override string ToString()
        {
            return "Id: " + this.Id + ", Title: " + this.Title;
        }
    }
}
