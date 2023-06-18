using homework_30;
using System.Reflection;
using System.Text;

class MySerializer<T>
{
    private T obj;

    public MySerializer(T obj)

    {
        this.obj = obj;
    }

    public string Serialize()
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string serialized = "";

        foreach (PropertyInfo prop in properties)
        {
            MyPropertyInfoAttribute attribute = prop.GetCustomAttribute<MyPropertyInfoAttribute>();

            if (attribute != null)
            {
                string name = attribute.SerializationName;
                object value = prop.GetValue(obj);

                serialized += $"\n{name}: {value}";
            }
        }
        return serialized;
    }

    public string SerializedExtra()
    {
        TypeInfo type = typeof(T).GetTypeInfo();

        IEnumerable<PropertyInfo> pList = type.DeclaredProperties;

        StringBuilder sb = new StringBuilder();

        foreach (PropertyInfo p in pList)
        {
            sb.Append($"{p.Name} : {p.GetValue(obj)}\n");
        }
        return sb.ToString();
    }
}