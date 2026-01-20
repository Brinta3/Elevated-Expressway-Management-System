using System.Data;
using Microsoft.Data.SqlClient;

namespace ELEMS
{
    public class Patrol
    {
        private Database _db = new Database();

        public int PatrolId { get; set; }
        public int ReportId { get; set; }
        public string PatrolNotes { get; set; } = "";


        // patrol logs
        public DataTable GetAllReportsWithPatrols()
        {
            string query = @"
                SELECT 
                    r.ReportId,
                    r.VehicleType,
                    r.Offence,
                    r.Location,
                    p.PatrolId,
                    p.Log AS PatrolNotes
                FROM Reports r
                LEFT JOIN PatrolLogs p ON r.ReportId = p.ReportId
            ";
            return _db.GetData(query);
        }

        // Insert patrol log
        public void Insert()
        {
            string query = "INSERT INTO PatrolLogs (ReportId, Log) VALUES (@ReportId, @Log)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReportId", ReportId),
                new SqlParameter("@Log", PatrolNotes)
            };
            _db.ExecuteQuery(query, parameters);
        }

        // Update patrol log
        public void Update()
        {
            string query = "UPDATE PatrolLogs SET Log=@Log WHERE PatrolId=@PatrolId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Log", PatrolNotes),
                new SqlParameter("@PatrolId", PatrolId)
            };
            _db.ExecuteQuery(query, parameters);
        }

        // Delete patrol log
        public void Delete()
        {
            string query = "DELETE FROM PatrolLogs WHERE PatrolId=@PatrolId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@PatrolId", PatrolId)
            };
            _db.ExecuteQuery(query, parameters);
        }

        // Get Patrol by ReportId
        public DataTable GetPatrolByReportId(int reportId)
        {
            string query = "SELECT * FROM PatrolLogs WHERE ReportId=@ReportId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReportId", reportId)
            };
            using (SqlConnection conn = new SqlConnection(_db.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddRange(parameters);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
