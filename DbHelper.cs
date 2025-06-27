using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MainDataDashboard.Helpers
{
    public static class DbHelper
    {
        // 1) يبني Configuration من appsettings.json في مجلد التشغيل
        static readonly IConfigurationRoot Config = new ConfigurationBuilder()
          .SetBasePath(AppContext.BaseDirectory)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .Build();

        // 2) يستخرج سلسلة الاتصال
        static readonly string ConnStr = Config.GetConnectionString("FinanceDb")
          ?? throw new InvalidOperationException(
               "Could not find a connection string named 'FinanceDb' in appsettings.json");

        // 3) استخدام Microsoft.Data.SqlClient لتنفيذ الاستعلام
        public static DataTable ExecuteQuery(string sql)
        {
            using var conn = new SqlConnection(ConnStr);
            using var cmd = new SqlCommand(sql, conn);
            var dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }
    }
}
