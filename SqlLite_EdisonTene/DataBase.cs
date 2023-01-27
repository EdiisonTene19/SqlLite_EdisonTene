using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SqlLite_EdisonTene
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();

    }
}
