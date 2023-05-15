namespace SingletonPattern;

//Perfect, thread safe, low boilerplate, performant and lazy
public class Singleton
{
    private Singleton() => CreatedAt = DateTime.Now;

    public DateTime CreatedAt { get; }

    private static readonly Lazy<Singleton> Lazy = new (() => new Singleton());

    public static Singleton GetInstance() => Lazy.Value;

    public static string Name => "Marcin";
}

//Almost perfect, but it is not lazy
//public class Singleton
//{
//    private static readonly Singleton Instance = new();

//    private Singleton() => CreatedAt = DateTime.Now;

//    public DateTime CreatedAt { get; }

//    public static Singleton GetInstance() => Instance;

//    public static string Name => "Marcin";
//}

//too much boilerplate ... it sucks
//public class Singleton
//{
//    private static readonly object PadLock = new();

//    private static volatile Singleton _instance;

//    private Singleton() => CreatedAt = DateTime.Now;

//    public DateTime CreatedAt { get; }

//    public static Singleton GetInstance()
//    {
//        if (_instance != null)
//            return _instance;

//        lock (PadLock)
//        {
//            if (_instance == null)
//            {
//                _instance = new Singleton();
//            }
//        }

//        return _instance;
//    }
//}

// poor performance
// public class Singleton
// {
//     private static readonly object _padLock = new();
//
//     private static Singleton _instance;
//
//     private Singleton() => CreatedAt = DateTime.Now;
//
//     public DateTime CreatedAt { get; }
//
//     public static Singleton GetInstance()
//     {
//         lock (_padLock)
//         {
//             if (_instance == null)
//             {
//                 _instance = new Singleton();
//             }
//         } 
//
//         return _instance;
//     }
// }


//This simple approach is not thread-safe, so don't use it in multithreaded application
//public class Singleton
//{
//    private static Singleton _instance;

//    private Singleton() => CreatedAt = DateTime.Now;

//    public DateTime CreatedAt { get; }

//    public static Singleton GetInstance()
//    {
//        //not thread safe 
//        if (_instance == null)
//        {
//            _instance = new Singleton();
//        }

//        return _instance;
//    }
//}