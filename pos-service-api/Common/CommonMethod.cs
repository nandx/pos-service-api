using System.Data;

namespace pos_service_api.Common
{
    public static class CommonMethod
    {
        public static List<T> ConvertToList<T>(DataTable dt)
        {
            Console.WriteLine("CommonMethod - ConvertToList ---> " + DateTime.Now);
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return [.. dt.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                return objT;
            })];
        }
    }
}
