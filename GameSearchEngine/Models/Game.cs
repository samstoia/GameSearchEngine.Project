// using System.Collections.Generic;
// using MySql.Data.MySqlClient;
// using System;

// namespace GameSearchEngine
// {
//     public class Game
//     {
//         public string _title;
//         public string _description;
//         public string _genre;
//         public string _platforms;
//         public string _year_released;
//         public int _rating;
//         public string _image_large;
//         public string _thumbnail_image;
//         private int _id;

//         public Game(string title, string description, string genre, string platforms, string yearReleased, int rating, string imageLarge, string thumbnailImage, int id = 0)
//         {
//             _title = title;
//             _description = description;
//             _genre = genre;
//             _platforms = platforms;
//             _year_released = yearReleased;
//             _rating = rating;
//             _image_large = imageLarge;
//             _thumbnail_image = thumbnailImage;
//             _id = _id;
//         }

//         public string GetTitle()
//         {
//             return _title;
//         }

//         public string GetDescription()
//         {
//             return _description;
//         }

//         public string GetGenre()
//         {
//             return _genre;
//         }

//         public string GetPlatforms()
//         {
//             return _platforms;
//         }

//         public string GetYear()
//         {
//             return _year_released;
//         }

//         public int GetRating()
//         {
//             return _rating;
//         }

//         public string GetImage()
//         {
//             return _image_large;
//         }

//         public string GetThumb()
//         {
//             return _thumbnail_image;
//         }

//         public int GetId()
//         {
//             return _id;
//         }

//         public static List<Game> GetAll(bool rating_sort = false)
//         {
//             List<Game> allGames = new List<Game> { };
//             MySqlConnection conn = DB.Connection();
//             conn.Open();
//             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//             if (!rating_sort)
//             {
//             cmd.CommandText = @"SELECT * FROM games;";
//             } else 
//             {
//                 cmd.CommandText = @"SELECT * FROM games ORDER BY rating;";
//             }
//             MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//             while (rdr.Read())
//             {
//                 int GameId = rdr.GetInt32(0);
//                 string GameTitle = rdr.GetString(1);
//                 string GameDescription = rdr.GetString(2);
//                 string GameGenre = rdr.GetString(3);
//                 string GamePlatforms = rdr.GetString(4);
//                 string GameYear = rdr.GetString(5);
//                 int GameRating = rdr.GetInt32(6);
//                 string GameImage = rdr.GetString(7);
//                 string GameThumb = rdr.GetString(8);
//                 Game newGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
//                 allGames.Add(newGame);
//             }
//             conn.Close();
//             if (conn != null)
//             {
//                 conn.Dispose();
//             }
//             return allGames;
//         }

//         public static List<Game> GetSelected(string userInput, string platform, string year, string genre)
//         {
//             List<Game> selectedGames = new List<Game> { };
//             MySqlConnection conn = DB.Connection();
//             conn.Open();
//             MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
//             cmd.CommandText = @"SELECT * FROM games WHERE (platforms = '" platform  "') OR (year_released = '" + year + "') OR (genre = '" + genre + "') OR (title LIKE '%" + userInput + "%') OR (description LIKE '%" + userInput + "%');";
//             MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
//             while (rdr.Read())
//             {
//                 int GameId = rdr.GetInt32(0);
//                 string GameTitle = rdr.GetString(1);
//                 string GameDescription = rdr.GetString(2);
//                 string GameGenre = rdr.GetString(3);
//                 string GamePlatforms = rdr.GetString(4);
//                 string GameYear = rdr.GetString(5);
//                 int GameRating = rdr.GetInt32(6);
//                 string GameImage = rdr.GetString(7);
//                 string GameThumb = rdr.GetString(8);
//                 Game selectedGame = new Game(GameTitle, GameDescription, GameGenre, GamePlatforms, GameYear, GameRating, GameImage, GameThumb, GameId);
//                 selectedGames.Add(newGame);
//             }
//             conn.Close();
//             if (conn != null)
//             {
//                 conn.Dispose();
//             }
//             return selectedGames;
//         }


//         // WORKING SQL SEARCH
//         //SELECT * FROM games WHERE (platforms = 'Xbox One') OR (genre = 'Strategy/Tactics') AND (title LIKE '%Halo%');

//     }

// }