using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace GameSearchEngine.Models
{
    public class Game
    {
        public string _title;
        public string _description;
        public string _genre;
        public string _platforms;
        public string _year_released;
        public int _rating;
        public string _image_large;
        public string _thumbnail_image;
        private int _id;

        public Game(string title, string description, string genre, string platforms, string yearReleased, int rating, string imageLarge, string thumbnailImage, int id = 0)
        {
            _title = title;
            _description = description;
            _genre = genre;
            _platforms = platforms;
            _year_released = yearReleased;
            _rating = rating;
            _image_large = imageLarge;
            _thumbnail_image = thumbnailImage;
            _id = id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetGenre()
        {
            return _genre;
        }

        public string GetPlatforms()
        {
            return _platforms;
        }

        public string GetYear()
        {
            return _year_released;
        }

        public int GetRating()
        {
            return _rating;
        }

        public string GetImage()
        {
            return _image_large;
        }

        public string GetThumb()
        {
            return _thumbnail_image;
        }

        public int GetId()
        {
            return _id;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO game (title, description, genre, platforms, yearReleased, rating) VALUES (@title, @description, @genre, @platforms, @yearReleased, @rating);";
            MySqlParameter title = new MySqlParameter();
            MySqlParameter description = new MySqlParameter();
            MySqlParameter genre = new MySqlParameter();
            MySqlParameter platforms = new MySqlParameter();
            MySqlParameter yearReleased = new MySqlParameter();
            MySqlParameter rating = new MySqlParameter();
            title.ParameterName = "@title";
            title.Value = this.GetTitle();
            description.ParameterName = "@description";
            description.Value = this.GetDescription();
            genre.ParameterName = "@genre";
            genre.Value = this.GetGenre();
            platforms.ParameterName = "@platforms";
            platforms.Value = this.GetPlatforms();
            yearReleased.ParameterName = "@yearReleased";
            yearReleased.Value = this.GetYear();
            rating.ParameterName = "@rating";
            rating.Value = this.GetRating();
            cmd.Parameters.Add(title);
            cmd.Parameters.Add(description);
            cmd.Parameters.Add(genre);
            cmd.Parameters.Add(platforms);
            cmd.Parameters.Add(yearReleased);
            cmd.Parameters.Add(rating);
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Game> GetAll(bool rating_sort = false)
        {
            List<Game> allGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            if (!rating_sort)
            {
                cmd.CommandText = @"SELECT * FROM games;";
            }
            else
            {
                cmd.CommandText = @"SELECT * FROM games ORDER BY rating;";
            }
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game newGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                allGames.Add(newGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allGames;
        }

        //@"SELECT * FROM games WHERE (genre = '%" + genre + "%') AND (platforms LIKE '%" + platform + "%') AND (year_released = '%" + yearStart + "%') OR (title LIKE '%" + userInput + "%') ORDER BY games.title;";

        public static List<Game> GetSelected(string genre, string platform, string yearStart, string userInput)
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            if (genre == "any" && platform == "any" && yearStart == "any")
            {
            cmd.CommandText = @"SELECT * FROM games WHERE (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else if (genre == "any" && platform == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (year_released LIKE '%" + yearStart + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else if (genre == "any" && yearStart == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (platforms LIKE '%" + platform + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else if (platform == "any" && yearStart == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (genre LIKE '%" + genre + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            } 
            else if (platform == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (genre LIKE '%" + genre + "%') AND (year_released LIKE '%" + yearStart + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else if (yearStart == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (genre LIKE '%" + genre + "%') AND (platforms LIKE '%" + platform + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else if (genre == "any")
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (year_released LIKE '%" + yearStart + "%') AND (platforms LIKE '%" + platform + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            else
            {
                cmd.CommandText = @"SELECT * FROM games WHERE (genre = '%" + genre + "%') AND (platforms LIKE '%" + platform + "%') AND (year_released = '%" + yearStart + "%') AND (title LIKE '%" + userInput + "%') ORDER BY games.title;";
            }
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                selectedGames.Add(selectedGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return selectedGames;
        }

        public static List<Game> GetGenre(string genreName)
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE (genre LIKE '%" + genreName + "%');";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                selectedGames.Add(selectedGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return selectedGames;
        }

        public static List<Game> GetPlatform(string platformName)
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE (platforms LIKE '%" + platformName + "%');";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                selectedGames.Add(selectedGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return selectedGames;
        }

        public static List<Game> GetYearOrdered()
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE year_released ORDER BY games.year_released;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                selectedGames.Add(selectedGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return selectedGames;
        }

        public static List<Game> GetRatingOrdered()
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE rating ORDER BY games.rating DESC;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int GameId = rdr.GetInt32(0);
                string GameTitle = rdr.GetString(1);
                string GameDescription = rdr.GetString(2);
                string GameGenre = rdr.GetString(3);
                string GamePlatforms = rdr.GetString(4);
                string GameYear = rdr.GetString(5);
                int GameRating = rdr.GetInt32(6);
                string GameImage = rdr.GetString(7);
                string GameThumb = rdr.GetString(8);
                Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
                selectedGames.Add(selectedGame);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return selectedGames;
        }


        // WORKING SQL SEARCH
        //SELECT * FROM games WHERE (platforms = 'Xbox One') OR (genre = 'Strategy/Tactics') AND (title LIKE '%Halo%');

        public static Game Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int GameId = 0;
            string GameTitle = "";
            string GameDescription = "";
            string GameGenre = "";
            string GamePlatforms = "";
            string GameYear = "";
            int GameRating = 0;
            string GameImage = "";
            string GameThumb = "";
            while (rdr.Read())
            {
                GameId = rdr.GetInt32(0);
                GameTitle = rdr.GetString(1);
                GameDescription = rdr.GetString(2);
                GameGenre = rdr.GetString(3);
                GamePlatforms = rdr.GetString(4);
                GameYear = rdr.GetString(5);
                GameRating = rdr.GetInt32(6);
                GameImage = rdr.GetString(7);
                GameThumb = rdr.GetString(8);
            }
            Game newGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newGame;
        }
    }

}
