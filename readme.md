# EF Core Study Notes (Intermediate Guide)

This guide is designed to take you from intermediate knowledge of C#/.NET and SQL to **mastery of EF Core**. It is written in a structured, reference-style format so you can learn and revisit without needing external docs.

---

## 1. Core Concepts

### What is EF Core?
- **Entity Framework Core (EF Core)** is an ORM (Object Relational Mapper).
- Translates **C# classes (entities)** into **database tables**.
- Eliminates most raw SQL, but still allows it when needed.
- Cross-platform, lightweight, and integrates with .NET Core/ASP.NET Core.

### Key Building Blocks
1. **DbContext** – The session with the database. Responsible for:
   - Querying
   - Saving
   - Change tracking
   - Configuring models
   
2. **DbSet<TEntity>** – Represents a table in the database.
   - Example: `DbSet<Student>` → `Students` table.

3. **Entities** – C# classes mapped to database tables.

4. **LINQ** – Language-Integrated Query used to write queries in C# that EF Core translates to SQL.

### Example: Minimal Setup
```csharp
public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=SchoolDb;Trusted_Connection=True;");
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
```

### DbContext Lifecycle
- Typically registered in **DI (Dependency Injection)** in ASP.NET Core.
- Scoped lifetime is most common: one `DbContext` per web request.

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

### Change Tracking
- EF Core keeps track of entity states:
  - `Added`
  - `Modified`
  - `Deleted`
  - `Unchanged`
- On `SaveChanges()`, EF Core generates the appropriate SQL.

```csharp
var student = new Student { Name = "Amr", Age = 22 };
context.Students.Add(student);
context.SaveChanges(); // INSERT
```

---

## 2. Database Models & Mappings

### Conventions
- EF Core uses **conventions by default**:
  - Class name → Table name
  - Property name → Column name
  - `Id` or `ClassNameId` → Primary Key

### Data Annotations
Decorators applied on properties to override defaults:
```csharp
public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Range(18, 60)]
    public int Age { get; set; }
}
```

### Fluent API
More advanced control via `OnModelCreating`:
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .HasKey(s => s.StudentId);

    modelBuilder.Entity<Student>()
        .Property(s => s.Name)
        .IsRequired()
        .HasMaxLength(50);
}
```

### Relationships
- **One-to-Many** (Student → Courses)
- **Many-to-Many** (Students ↔ Courses)
- **One-to-One** (Student ↔ Address)

Example:
```csharp
public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }

    public ICollection<Student> Students { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public ICollection<Course> Courses { get; set; }
}
```

---

## ✅ Quick Review Check
1. What does `DbSet<TEntity>` represent?
2. Which is better for advanced configurations: Data Annotations or Fluent API?
3. What happens when you call `SaveChanges()`?

---

👉 Next section will cover **Migrations & Schema Management**.
