using System;
namespace Clase2.Sources
{
    public class SqlSource
    {
        public SqlSource()
        {
        }

        public Boolean Insert<T>(T item) where T : new()
        {
            return true;
        }

        public Boolean Update<T>(T item) where T : new()
        {
            return true;
        }
    }
}