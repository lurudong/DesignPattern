namespace _9_抽象工厂_更换数据库案例
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //更换数据库：SqlServer Mysql SQLite
            User user = new User();
            user.Name = "test";
            user.Id = 1;
            #region 1

            //SqlServerUser sqlServerUser = new SqlServerUser();
            //sqlServerUser.InsertUser(user);
            //sqlServerUser.GetUser(1);
            #endregion


            #region 使用工厂方法
            //IFactory factory = new MySqlFactoryUser();//new SqlServerFactoryUser();
            //var database = factory.GetDatabaseUser();
            //database.InsertUser(user);
            //database.GetUser(user.Id);
            #endregion

            #region 使用抽象工厂
            Department department = new Department();
            department.Name = "开发部门";
            department.Id = 1;
            IAbastractFactory abastractFactory = new SqlServerFactory();
            var databaseUser = abastractFactory.GetDatabaseUser();
            databaseUser.InsertUser(user);
            databaseUser.GetUser(user.Id);
            var databaseDepartment = abastractFactory.GetDatabaseDepartment();
            databaseDepartment.InsertDepartment(department);
            databaseDepartment.GetDepartment(department.Id);
            #endregion
            Console.ReadKey();
        }

    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public interface IDatabaseDepartment
    {
        void InsertDepartment(Department department);

        Department GetDepartment(int id);
    }
    public interface IDatabaseUser
    {

        void InsertUser(User user);

        User GetUser(int id);

    }
    public interface IFactory
    {
        IDatabaseUser GetDatabaseUser();
    }



    public class SqlServerUser : IDatabaseUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"SqlServer插入了{user.Name}");
        }

        public User GetUser(int id)
        {
            Console.WriteLine($"SqlServer获取了Id是{id}的用户");
            return new User { Id = id };
        }
    }

    public class MySqlUser : IDatabaseUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"MySql插入了{user.Name}");
        }

        public User GetUser(int id)
        {
            Console.WriteLine($"MySql获取了Id是{id}的用户");
            return new User { Id = id };
        }
    }

    public class SqlServerDepartment : IDatabaseDepartment
    {
        public void InsertDepartment(Department department)
        {
            Console.WriteLine($"SqlServer插入了{department.Name}的部门");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine($"SqlServer获取了Id是{id}的部门");
            return new Department { Id = id };
        }
    }
    public class MySqlDepartment : IDatabaseDepartment
    {
        public void InsertDepartment(Department department)
        {
            Console.WriteLine($"MySql插入了{department.Name}的部门");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine($"MySql获取了Id是{id}的部门");
            return new Department { Id = id };
        }
    }

    public class SQLiteDepartment : IDatabaseDepartment
    {
        public void InsertDepartment(Department department)
        {
            Console.WriteLine($"SQLite插入了{department.Name}的部门");
        }

        public Department GetDepartment(int id)
        {
            Console.WriteLine($"SQLite获取了Id是{id}的部门");
            return new Department { Id = id };
        }
    }

    public class SQLiteUser : IDatabaseUser
    {
        public void InsertUser(User user)
        {
            Console.WriteLine($"SQLite插入了{user.Name}");
        }

        public User GetUser(int id)
        {
            Console.WriteLine($"SQLite获取了Id是{id}的用户");
            return new User { Id = id };
        }
    }



    public class SqlServerFactoryUser : IFactory
    {
        public IDatabaseUser GetDatabaseUser()
        {
            return new SqlServerUser();
        }
    }

    public class MySqlFactoryUser : IFactory
    {
        public IDatabaseUser GetDatabaseUser()
        {
            return new MySqlUser();
        }
    }

    public class SQLiteFactoryUser : IFactory
    {
        public IDatabaseUser GetDatabaseUser()
        {
            return new SQLiteUser();
        }
    }

    public interface IAbastractFactory
    {

        IDatabaseUser GetDatabaseUser();
        IDatabaseDepartment GetDatabaseDepartment();

    }


    public class SqlServerFactory : IAbastractFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {

            return new SqlServerDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new SqlServerUser();
        }
    }

    public class MySqlFactory : IAbastractFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {

            return new MySqlDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new MySqlUser();
        }
    }


    public class SQLiteFactory : IAbastractFactory
    {
        public IDatabaseDepartment GetDatabaseDepartment()
        {

            return new SQLiteDepartment();
        }

        public IDatabaseUser GetDatabaseUser()
        {
            return new SQLiteUser();
        }
    }
}