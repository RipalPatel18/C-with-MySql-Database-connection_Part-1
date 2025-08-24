using blogdb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;


namespace blogdb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleAPIController : ControllerBase
    {
        //access to the blog object
        private BlogDbContext Blog = new BlogDbContext();

        [HttpGet(template: "ListArticleNames")]
        public string ListArticleNames()
        {
            //create empty list of strings
            List<string> ArticleTitles = new List<string>();

            //open the connection to the database
            MySqlConnection connection = Blog.AccessDatabase();

            //open connection
            connection.Open();

            //Sql query to select all articles
            string query = "SELECT * from articles";

            //Create Command
            MySqlCommand command = connection.CreateCommand();

            //create a command to execute the query
            command.CommandText = query;

            // Execute the command and retrieve the result set
            MySqlDataReader resultSet = command.ExecuteReader();

            // Process the result set
            while (resultSet.Read())
            {
                String ArticleTitle = resultSet["articletitle"].ToString();
                ArticleTitles.Add(ArticleTitle);
                //another way 
                //ArticleTitles.Add(resultSet.GetString("title")); // Assuming "title" is the column name
            }

            resultSet.Close();
            connection.Close();

            // Return the list of article titles as a comma-separated string
            return string.Join(", ", ArticleTitles);
        }
    }
}
