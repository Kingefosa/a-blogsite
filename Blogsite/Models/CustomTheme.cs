﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// This class represent a custom theme
/// </summary>
public class CustomTheme
{
    #region Variables

    public Int32 id;
    public string name;

    #endregion

    #region Constructors

    /// <summary>
    /// Create a new custom theme with default properties
    /// </summary>
    public CustomTheme()
    {
        // Set values for instance variables
        this.id = 0;
        this.name = "";

    } // End of the constructor

    /// <summary>
    /// Create a new custom theme from a reader
    /// </summary>
    /// <param name="reader"></param>
    public CustomTheme(SqlDataReader reader)
    {
        // Set values for instance variables
        this.id = Convert.ToInt32(reader["id"]);
        this.name = reader["name"].ToString();

    } // End of the constructor

    #endregion

    #region Insert methods

    /// <summary>
    /// Add one custom theme
    /// </summary>
    /// <param name="post">A reference to a custom theme post</param>
    public static long Add(CustomTheme post)
    {
        // Create the long to return
        long idOfInsert = 0;

        // Create the connection and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "INSERT INTO dbo.custom_themes (name) VALUES (@name);SELECT SCOPE_IDENTITY();";

        // The using block is used to call dispose automatically even if there are an exception.
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there are an exception.
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@name", post.name);

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases
                try
                {
                    // Open the connection
                    cn.Open();

                    // Execute the insert
                    idOfInsert = Convert.ToInt64(cmd.ExecuteScalar());

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Return the id of the inserted item
        return idOfInsert;

    } // End of the Add method

    /// <summary>
    /// Add custom theme templates
    /// </summary>
    /// <param name="id"></param>
    public static void AddCustomThemeTemplates(Int32 id)
    {
        // Get all the templates
        Dictionary<string, string> templates = CustomThemeTemplate.GetAllByCustomThemeId(id, "user_file_name", "ASC");
        
        // Add templates that does not exist
        if (templates.ContainsKey("front_category_menu.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_category_menu.cshtml", "/Views/shared_front/_category_menu.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_category_menu.cshtml"), "Creates the category menu with leveling."));
        }
        if (templates.ContainsKey("front_paging_menu.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_paging_menu.cshtml", "/Views/shared_front/_paging_menu.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_paging_menu.cshtml"), "Creates the paging menu that shows under listed items in many files."));
        }
        if (templates.ContainsKey("front_post_comments.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_post_comments.cshtml", "/Views/shared_front/_post_comments.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_post_comments.cshtml"), "Shows the comments for a post."));
        }
        if (templates.ContainsKey("front_post_files.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_post_files.cshtml", "/Views/shared_front/_post_files.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_post_files.cshtml"), "Show the files that can be downloaded for a post."));
        }
        if (templates.ContainsKey("front_shared_scripts.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_shared_scripts.cshtml", "/Views/shared_front/_shared_scripts.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_shared_scripts.cshtml"), "Common scripts for google analytics, google plus, facebook and more."));
        }
        if (templates.ContainsKey("front_standard_layout.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_standard_layout.cshtml", "/Views/shared_front/_standard_layout.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/shared_front/_standard_layout.cshtml"), "Standard layout file for a normal browser."));
        }
        if (templates.ContainsKey("author.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "author.cshtml", "/Views/home/author.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/author.cshtml"), "An information page about a author."));
        }
        if (templates.ContainsKey("category.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "category.cshtml", "/Views/home/category.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/category.cshtml"), "Displays a category with its categories and products."));
        }
        if (templates.ContainsKey("error.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "error.cshtml", "/Views/home/error.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/error.cshtml"), "The page that shows error messages."));
        }
        if (templates.ContainsKey("home.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "home.cshtml", "/Views/home/index.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/index.cshtml"), "The entry page for the website."));
        }
        if (templates.ContainsKey("information.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "information.cshtml", "/Views/home/information.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/information.cshtml"), "Displays the content of a static page."));
        }
        if (templates.ContainsKey("post.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "post.cshtml", "/Views/home/post.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/post.cshtml"), "Displays a post with files, rating and comments."));
        }
        if (templates.ContainsKey("search.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "search.cshtml", "/Views/home/search.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/home/search.cshtml"), "Displays a list of posts according to a search."));
        }
        if (templates.ContainsKey("user_menu.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "user_menu.cshtml", "/Views/user/_user_menu.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/_user_menu.cshtml"), "The menu for a signed in user."));
        }
        if (templates.ContainsKey("edit_user_details.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "edit_user_details.cshtml", "/Views/user/edit.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/edit.cshtml"), "The form where the user can edit his information."));
        }
        if (templates.ContainsKey("edit_user_comments.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "edit_user_comments.cshtml", "/Views/user/edit_comments.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/edit_comments.cshtml"), "A list form where the user can edit his comments."));
        }
        if (templates.ContainsKey("edit_user_ratings.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "edit_user_ratings.cshtml", "/Views/user/edit_ratings.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/edit_ratings.cshtml"), "A list form where the user can edit his ratings."));
        }
        if (templates.ContainsKey("forgot_password.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "forgot_password.cshtml", "/Views/user/forgot_password.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/forgot_password.cshtml"), "A form where a user can get his password."));
        }
        if (templates.ContainsKey("user_start_page.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "user_start_page.cshtml", "/Views/user/index.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/index.cshtml"), "The start page for the user."));
        }
        if (templates.ContainsKey("user_login.cshtml") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "user_login.cshtml", "/Views/user/login.cshtml",
                CustomThemeTemplate.GetMasterFileContent("/Views/user/login.cshtml"), "The form where a user can log in to his account."));
        }
        if (templates.ContainsKey("front_default_style.css") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_default_style.css", "/Content/annytab_css/front_default_style.css",
                CustomThemeTemplate.GetMasterFileContent("/Content/annytab_css/front_default_style.css"), "Css styling that is shared between layouts."));
        }
        if (templates.ContainsKey("front_medium_layout.css") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_medium_layout.css", "/Content/annytab_css/front_medium_layout.css",
                CustomThemeTemplate.GetMasterFileContent("/Content/annytab_css/front_medium_layout.css"), "Css styling for the medium layout."));
        }
        if (templates.ContainsKey("front_mobile_layout.css") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_mobile_layout.css", "/Content/annytab_css/front_mobile_layout.css",
                CustomThemeTemplate.GetMasterFileContent("/Content/annytab_css/front_mobile_layout.css"), "Css styling for the mobile layout."));
        }
        if (templates.ContainsKey("front_standard_layout.css") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "front_standard_layout.css", "/Content/annytab_css/front_standard_layout.css",
                CustomThemeTemplate.GetMasterFileContent("/Content/annytab_css/front_standard_layout.css"), "Css styling for the standard layout."));
        }
        if (templates.ContainsKey("rateit.css") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "rateit.css", "/Content/annytab_css/rateit.css",
                CustomThemeTemplate.GetMasterFileContent("/Content/annytab_css/rateit.css"), "The style for the rating component in posts."));
        }
        if (templates.ContainsKey("annytab.category-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.category-functions.js", "/Scripts/annytab_front/annytab.category-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.category-functions.js"), "Functions that apply to the category page, where a category is displayed."));
        }
        if (templates.ContainsKey("annytab.default-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.default-functions.js", "/Scripts/annytab_front/annytab.default-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.default-functions.js"), "Functions that apply to the entire website, both standard and mobile layouts."));
        }
        if (templates.ContainsKey("annytab.home-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.home-functions.js", "/Scripts/annytab_front/annytab.home-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.home-functions.js"), "Functions that apply to the index page of the website, the home page."));
        }
        if (templates.ContainsKey("annytab.post-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.post-functions.js", "/Scripts/annytab_front/annytab.post-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.post-functions.js"), "Functions that apply to the post page."));
        }
        if (templates.ContainsKey("annytab.standard-layout-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.standard-layout-functions.js", "/Scripts/annytab_front/annytab.standard-layout-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.standard-layout-functions.js"), "Functions that apply to the standard layout for the website."));
        }
        if (templates.ContainsKey("annytab.user-functions.js") == false)
        {
            CustomThemeTemplate.Add(new CustomThemeTemplate(id, "annytab.user-functions.js", "/Scripts/annytab_front/annytab.user-functions.js",
                CustomThemeTemplate.GetMasterFileContent("/Scripts/annytab_front/annytab.user-functions.js"), "Functions that apply to the edit user details page."));
        }

    } // End of the AddCustomThemeTemplates method

    /// <summary>
    /// Add a template
    /// </summary>
    /// <param name="template">A reference to a template</param>
    public static void AddTemplate(CustomThemeTemplate template)
    {
        // Add the template
        CustomThemeTemplate.Add(template);

        // Remove the cache
        RemoveThemeCache(template.custom_theme_id);

    } // End of the AddTemplate method

    #endregion

    #region Update methods

    /// <summary>
    /// Update a custom theme post
    /// </summary>
    /// <param name="post">A reference to a custom theme post</param>
    public static void Update(CustomTheme post)
    {
        // Create the connection and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "UPDATE dbo.custom_themes SET name = @name WHERE id = @id;";

        // The using block is used to call dispose automatically even if there are an exception.
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there are an exception.
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@id", post.id);
                cmd.Parameters.AddWithValue("@name", post.name);

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases.
                try
                {
                    // Open the connection.
                    cn.Open();

                    // Execute the update
                    cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

    } // End of the Update method

    /// <summary>
    /// Update a custom theme template
    /// </summary>
    /// <param name="template">A reference to a custom theme template</param>
    public static void UpdateTemplate(CustomThemeTemplate template)
    {
        // Update the the template
        CustomThemeTemplate.Update(template);

        // Remove the cache
        RemoveThemeCache(template.custom_theme_id);

    } // End of the UpdateTemplate method

    #endregion

    #region Count methods

    /// <summary>
    /// Count the number of custom themes by search keywords
    /// </summary>
    /// <param name="keywords">An array of keywords</param>
    /// <returns>The number of custom themes as an int</returns>
    public static Int32 GetCountBySearch(string[] keywords)
    {
        // Create the variable to return
        Int32 count = 0;

        // Create the connection string and the select statement
        string connection = Tools.GetConnectionString();
        string sql = "SELECT COUNT(id) AS count FROM dbo.custom_themes WHERE 1 = 1";

        // Append keywords to the sql string
        for (int i = 0; i < keywords.Length; i++)
        {
            sql += " AND (name LIKE @keyword_" + i.ToString() + ")";
        }

        // Add the final touch to the sql string
        sql += ";";

        // The using block is used to call dispose automatically even if there is a exception.
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there is a exception.
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add parameters for search keywords
                for (int i = 0; i < keywords.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@keyword_" + i.ToString(), "%" + keywords[i].ToString() + "%");
                }

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases.
                try
                {
                    // Open the connection
                    cn.Open();

                    // Execute the select statment
                    count = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Return the count
        return count;

    } // End of the GetCountBySearch method

    #endregion

    #region Get methods

    /// <summary>
    /// Check if a master post exists
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>A boolean that indicates if the post exists</returns>
    public static bool MasterPostExists(Int32 id)
    {
        // Create the boolean to return
        bool postExists = false;

        // Create the connection and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "SELECT COUNT(id) AS COUNT FROM dbo.custom_themes WHERE id = @id;";

        // The using block is used to call dispose automatically even if there is a exception.
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there is a exception.
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add a parameters
                cmd.Parameters.AddWithValue("@id", id);

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases.
                try
                {
                    // Open the connection.
                    cn.Open();

                    // Check if the post exist
                    postExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0 ? true : false;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Return the boolean
        return postExists;

    } // End of the MasterPostExists method

    /// <summary>
    /// Get one custom theme based on id
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>A reference to a custom theme post</returns>
    public static CustomTheme GetOneById(Int32 id)
    {
        // Create the post to return
        CustomTheme post = null;

        // Create the connection and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "SELECT * FROM dbo.custom_themes WHERE id = @id;";

        // The using block is used to call dispose automatically even if there is a exception.
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there is a exception.
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add a parameters
                cmd.Parameters.AddWithValue("@id", id);

                // Create a MySqlDataReader
                SqlDataReader reader = null;

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases.
                try
                {
                    // Open the connection.
                    cn.Open();

                    // Fill the reader with one row of data.
                    reader = cmd.ExecuteReader();

                    // Loop through the reader as long as there is something to read and add values
                    while (reader.Read())
                    {
                        post = new CustomTheme(reader);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    // Call Close when done reading to avoid memory leakage.
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        // Return the post
        return post;

    } // End of the GetOneById method

    /// <summary>
    /// Get all custom themes
    /// </summary>
    /// <param name="sortField">The field to sort on</param>
    /// <param name="sortOrder">The sort order</param>
    /// <returns>A list of custom theme posts</returns>
    public static List<CustomTheme> GetAll(string sortField, string sortOrder)
    {
        // Make sure that sort variables are valid
        sortField = GetValidSortField(sortField);
        sortOrder = GetValidSortOrder(sortOrder);

        // Create the list to return
        List<CustomTheme> posts = new List<CustomTheme>(10);

        // Create the connection string and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "SELECT * FROM dbo.custom_themes ORDER BY " + sortField + " " + sortOrder + ";";

        // The using block is used to call dispose automatically even if there is a exception
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there is a exception
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Create a reader
                SqlDataReader reader = null;

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases
                try
                {
                    // Open the connection.
                    cn.Open();

                    // Fill the reader with data from the select command.
                    reader = cmd.ExecuteReader();

                    // Loop through the reader as long as there is something to read
                    while (reader.Read())
                    {
                        posts.Add(new CustomTheme(reader));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    // Call Close when done reading to avoid memory leakage.
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        // Return the list of posts
        return posts;

    } // End of the GetAll method

    /// <summary>
    /// Get custom themes that contains search keywords
    /// </summary>
    /// <param name="keywords">An array of keywords</param>
    /// <param name="pageSize">The number of pages on one page</param>
    /// <param name="pageNumber">The page number of a page from 1 and above</param>
    /// <param name="sortField">The field to sort on</param>
    /// <param name="sortOrder">The sort order</param>
    /// <returns>A list of custom themes</returns>
    public static List<CustomTheme> GetBySearch(string[] keywords, Int32 pageSize, Int32 pageNumber, string sortField, string sortOrder)
    {
        // Make sure that sort variables are valid
        sortField = GetValidSortField(sortField);
        sortOrder = GetValidSortOrder(sortOrder);

        // Create the list to return
        List<CustomTheme> posts = new List<CustomTheme>(pageSize);

        // Create the connection string and the select statement
        string connection = Tools.GetConnectionString();
        string sql = "SELECT * FROM dbo.custom_themes WHERE 1 = 1";

        // Append keywords to the sql string
        for (int i = 0; i < keywords.Length; i++)
        {
            sql += " AND (name LIKE @keyword_" + i.ToString() + ")";
        }

        // Add the final touch to the select string
        sql += " ORDER BY " + sortField + " " + sortOrder + " OFFSET @pageNumber ROWS FETCH NEXT @pageSize ROWS ONLY;";

        // The using block is used to call dispose automatically even if there are an exception
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there are an exception
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@pageNumber", (pageNumber - 1) * pageSize);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);

                // Add parameters for search keywords
                for (int i = 0; i < keywords.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@keyword_" + i.ToString(), "%" + keywords[i].ToString() + "%");
                }

                // Create a reader
                SqlDataReader reader = null;

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application to crash in such cases
                try
                {
                    // Open the connection
                    cn.Open();

                    // Fill the reader with data from the select command
                    reader = cmd.ExecuteReader();

                    // Loop through the reader as long as there is something to read
                    while (reader.Read())
                    {
                        posts.Add(new CustomTheme(reader));
                    }

                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    // Call Close when done reading to avoid memory leakage.
                    if (reader != null)
                        reader.Close();
                }
            }
        }

        // Return the list of posts
        return posts;

    } // End of the GetBySearch method

    /// <summary>
    /// Get all the custom theme templates by custom theme id
    /// </summary>
    /// <param name="customThemeId">The custom theme id</param>
    /// <returns>A dictionary with custom theme templates</returns>
    public static Dictionary<string, string> GetAllTemplatesById(Int32 customThemeId)
    {
        // Get the templates from cache
        Dictionary<string, string> templates = CustomThemeTemplate.GetAllByCustomThemeId(customThemeId, "user_file_name", "ASC");

        // Return the templates
        return templates;

    } // End of the GetAllTemplatesById method

    #endregion

    #region Delete methods

    /// <summary>
    /// Delete a custom theme and all the templates for this theme
    /// </summary>
    /// <param name="id">The id</param>
    /// <returns>An error code</returns>
    public static Int32 DeleteOnId(Int32 id)
    {
        // Get all the domains
        List<Domain> domains = Domain.GetAll("id", "ASC");

        // Loop the domains
        for (int i = 0; i < domains.Count; i++)
        {
            // Check if the theme is used by the domain
            if (domains[i].custom_theme_id == id)
            {
                return 5;
            }
        }

        // Create the connection and the sql statement
        string connection = Tools.GetConnectionString();
        string sql = "DELETE FROM dbo.custom_themes_templates WHERE custom_theme_id = @id;DELETE FROM dbo.custom_themes WHERE id = @id;";

        // The using block is used to call dispose automatically even if there is a exception
        using (SqlConnection cn = new SqlConnection(connection))
        {
            // The using block is used to call dispose automatically even if there is a exception
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                // Add parameters
                cmd.Parameters.AddWithValue("@id", id);

                // The Try/Catch/Finally statement is used to handle unusual exceptions in the code to
                // avoid having our application crash in such cases
                try
                {
                    // Open the connection.
                    cn.Open();

                    // Execute the update
                    cmd.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    // Check for a foreign key constraint error
                    if (e.Number == 547)
                    {
                        return 5;
                    }
                    else
                    {
                        throw e;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        // Return the code for success
        return 0;

    } // End of the DeleteOnId method

    /// <summary>
    /// Delete all the templates for a custom theme id
    /// </summary>
    /// <param name="customThemeId"></param>
    public static void DeleteTemplatesOnId(Int32 customThemeId)
    {
        // Delete templates
        CustomThemeTemplate.DeleteOnId(customThemeId);

        // Remove the cache
        RemoveThemeCache(customThemeId);

    } // End of the DeleteTemplatesOnId method

    /// <summary>
    /// Delete a template on id
    /// </summary>
    /// <param name="customThemeId">The custom theme id</param>
    /// <param name="userFileName">The file name</param>
    public static void DeleteTemplateOnId(Int32 customThemeId, string userFileName)
    {
        // Delete the template
        CustomThemeTemplate.DeleteOnId(customThemeId, userFileName);

        // Remove the theme cache
        RemoveThemeCache(customThemeId);

    } // End of the DeleteTemplateOnId method

    #endregion

    #region Cache

    /// <summary>
    /// Remove the cache
    /// </summary>
    /// <param name="customThemeId">The custom theme id</param>
    public static void RemoveThemeCache(Int32 customThemeId)
    {
        // Create the theme id
        string themeId = "Theme_" + customThemeId.ToString();

        // Remove the key from cache
        Tools.RemoveKeyFromCache(themeId);

    } // End of the RemoveThemeCache method

    #endregion

    #region Validation

    /// <summary>
    /// Get a valid sort field
    /// </summary>
    /// <param name="sortField">The sort field</param>
    /// <returns>A valid sort field as a string</returns>
    public static string GetValidSortField(string sortField)
    {
        // Make sure that the sort field is valid
        if (sortField != "id" && sortField != "name")
        {
            sortField = "id";
        }

        // Return the string
        return sortField;

    } // End of the GetValidSortField method

    /// <summary>
    /// Get a valid sort order
    /// </summary>
    /// <param name="sortOrder">The sort order</param>
    /// <returns>A valid sort order as a string</returns>
    public static string GetValidSortOrder(string sortOrder)
    {
        // Make sure that the sort order is valid
        if (sortOrder != "ASC" && sortOrder != "DESC")
        {
            sortOrder = "ASC";
        }

        // Return the string
        return sortOrder;

    } // End of the GetValidSortOrder method

    #endregion

} // End of the class