public interface IComparable<T>
{
    int CompareTo(T other);
}

public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public int CompareTo(Student other)
    {
        if (other == null) return 0;

        int nameComparison = Name.CompareTo(other.Name);
        if (nameComparison == 0) return nameComparison;

        int ageComparison = Age.CompareTo(other.Age);
        if (ageComparison != 0) return ageComparison;
        
        return Grade.CompareTo(other.Grade);
    }
}
public class Book : IComparable<Book>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public int CompareTo(Book other)
    {
        if (other == null) return 0;

        int TitleComparison = Title.CompareTo(other.Title);
        if (TitleComparison == 0) return TitleComparison;

        int AuthorComparison = Author.CompareTo(other.Author);
        if (AuthorComparison != 0) return AuthorComparison;

        return Price.CompareTo(other.Price);
    }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Антон", 17, 94.0),
            new Student("Антон", 18, 93.0),
            new Student("Гоша", 18, 96.0),
            new Student("Коля", 16, 93.0)
        };

        BubbleSort(students);

         Console.WriteLine("Отсортированные студенты:");
         foreach (var student in students)
         {
             Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
         }


        List<Book> books = new List<Book>
                 {
                     new Book("Book-1", "Author-3", 25.0),
                     new Book("Book-2", "Author-2", 20.0),
                     new Book("Book-1", "Author-3", 30.0)
                 };

        BubbleSort(books);

        Console.WriteLine("\nОтсортированные книги:");
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Price: {book.Price}");
        }
    }
    public static void BubbleSort<T>(List<T> items) where T : IComparable<T>
    {
        int n = items.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
                if (items[j].CompareTo(items[j + 1]) > 0)
                {
                    T temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
        }
    }
}