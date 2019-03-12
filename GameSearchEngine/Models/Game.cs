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

        // SELECT * FROM games WHERE (platforms LIKE '%Xbox 360%') AND (year_released BETWEEN '1990' AND '2010') AND (genre = 'Action') AND (title LIKE '%Attack on Earth%') OR (description LIKE '%Attack on Earth%');

        public static List<Game> GetSelected(string userInput, string platform, string yearStart, string yearEnd, string genre)
        {
            List<Game> selectedGames = new List<Game> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM games WHERE (platforms LIKE '%" + platform + "%') AND (year_released BETWEEN '" + yearStart + "' AND '" + yearEnd + "') AND (genre = '" + genre + "') AND (title LIKE '%" + userInput + "%') OR (description LIKE '%" + userInput + "%');";
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