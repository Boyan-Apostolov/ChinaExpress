using ChinaExpress.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CustomExtensions = ChinaExpress.Extensions.Extensions;
using ChinaExpress.Extensions;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DataAccess.ApplicationHelpers
{
    public class CategoriesDbHelper : BaseDbHelper, ICategoriesDbHelper
    {

        public List<Feature> GetCategoyFeatures(int categoryId)
        {
            var foundFeatures = new List<Feature>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT f.Id, f.Name, f.SerializedTags
FROM CategoryFeature as cf 
JOIN Feature as f 
ON f.Id = cf.FeatureId
WHERE cf.CategoryId = @CategoryId";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundFeatures.Add(new Feature(
                        (int)dr[0],
                        dr[1].ToString(),
                        dr[2].ToString()));
                }
            }

            return foundFeatures.ToList();
        }
        public Category[] GetAllCategories()
        {
            var foundCatgories = new List<Category>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT c.Id, c.Name, COUNT(*)
                        FROM Category as c
                        LEFT JOIN Product as p
                        ON p.CategoryId = c.Id
                        GROUP BY c.Id, c.Name";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundCatgories.Add(new Category(
                        (int)dr[0],
                        dr[1].ToString(),
                        (int)dr[2]));
                }

                foundCatgories.ForEach(fc => fc.SetFeatures(GetCategoyFeatures(fc.Id)));
            }

            return foundCatgories.ToArray();
        }

        public void CreateCategory(string catgoryText, List<int> features)
        {
            var conn = GetConnection();

            string sql = @"INSERT INTO Category (Name)
                            VALUES (@Name)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Name", catgoryText);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


            AddFeaturesToCategory(GetLastCreatedId(nameof(Category)), features);
        }

        private void AddFeaturesToCategory(int categoryId, List<int> features)
        {
            foreach (var featureId in features)
            {
                var conn = GetConnection();

                string sql = @"INSERT INTO CategoryFeature (CategoryId, FeatureId)
                            VALUES (@CategoryId, @FeatureId)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@FeatureId", featureId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }

        public void DeleteCategory(int foundCategoryId)
        {
            var conn = GetConnection();

            string sql = @"DELETE FROM Category WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", foundCategoryId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Feature[] GetAllFeatures()
        {
            var foundFeatures = new List<Feature>();

            var conn = GetConnection();
            using (conn)
            {
                string sql =
                    @"SELECT * FROM Feature";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    foundFeatures.Add(new Feature(
                        (int)dr[0],
                        dr[1].ToString(),
                        dr[2].ToString()));
                }
            }

            return foundFeatures.ToArray();
        }
    }
}
