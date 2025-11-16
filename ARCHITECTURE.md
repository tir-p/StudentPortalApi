# Student Portal API - Architecture Documentation

## Overview
This API follows a clean architecture pattern with clear separation of concerns across multiple layers.

## Architecture Flow
```
Controller → Service → Repository → DbContext → Database
```

## Layer Responsibilities

### 1. Controllers (`Controllers/`)
- **Purpose**: Handle HTTP requests and responses
- **Responsibilities**:
  - Route HTTP requests to appropriate service methods
  - Validate model state
  - Return appropriate HTTP status codes
  - Apply API attributes (Routing, Model Binding, Action Results)

**Example**: `StudentController.cs
- Uses `[Route]`, `[ApiController]`, `[HttpGet]`, `[HttpPost]`, etc.
- Returns `ActionResult<T>` for proper type safety
- Uses `[ProducesResponseType]` for Swagger documentation

### 2. Services (`Services/`)
- **Purpose**: Business logic layer
- **Responsibilities**:
  - Implement business rules and validation
  - Orchestrate repository calls
  - Handle business-specific operations
  - Coordinate between multiple repositories if needed

**Benefits of Service Layer**:
- Separation of concerns (business logic separate from data access)
- Testability (can mock repositories)
- Reusability (services can be used by multiple controllers)
- Centralized business logic

**Example**: `StudentService.cs`
- Validates business rules (e.g., ID > 0)
- Can add complex business logic (e.g., check email uniqueness)

### 3. Repositories (`Repositories/`)
- **Purpose**: Data access layer
- **Responsibilities**:
  - Interact with Entity Framework
  - Perform CRUD operations
  - Handle database queries using LINQ
  - Map between Domain Models and DTOs

**Benefits of Repository Pattern**:
- Abstraction of data access
- Testability (can mock repositories)
- Single Responsibility Principle
- Easy to swap data sources

**Example**: `StudentRepository.cs`
- Uses async/await for all database operations
- Uses LINQ for querying
- Uses AutoMapper for DTO mapping

### 4. Data Layer (`Data/`)
- **Purpose**: Entity Framework configuration
- **Components**:
  - `DbContext`: Manages database connections and entity tracking
  - Entity configurations (Fluent API in `OnModelCreating`)
  - Migrations

## Key Patterns & Practices

### Dependency Injection
All dependencies are injected through constructors and registered in `Program.cs`:
```csharp
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
```

**Benefits**:
- Loose coupling
- Testability (easy to mock)
- Single Responsibility
- Inversion of Control

### DTOs (Data Transfer Objects)
Located in `DTOs/` folder.

**Why Use DTOs?**
1. **Security**: Control what data is exposed to API consumers
2. **Over-posting Prevention**: Prevent malicious data injection
3. **Decoupling**: API contracts independent of database schema
4. **Performance**: Exclude unnecessary navigation properties
5. **Versioning**: Version APIs without changing domain models

**Example**: `StudentDTO` only exposes necessary fields, not internal navigation properties.

### Mapping (AutoMapper)
Located in `Mappings/MappingProfile.cs`.

- Maps between Domain Models (`Models/`) and DTOs (`DTOs/`)
- Reduces boilerplate code
- Centralized mapping configuration

### Extension Methods
Located in `Extensions/QueryExtensions.cs`.

**Purpose**: Follow DRY (Don't Repeat Yourself) principle by creating reusable query operations.

**Example**: `IncludeRelatedEntities()` extension method reduces code duplication when querying students with related data.

### Async/Await
All database operations use async/await.

**Why?**
1. **Non-blocking**: Prevents thread blocking during I/O operations
2. **Scalability**: Allows threads to handle other requests while waiting
3. **Resource Utilization**: Better use of server resources
4. **Performance**: Improves application throughput

### Entity Framework Configuration

#### Data Annotations
Used in `Models/` for simple configurations:
- `[Key]`: Primary key
- `[Required]`: Required field
- `[MaxLength]`: String length constraint
- `[EmailAddress]`: Email validation
- `[Range]`: Numeric range validation

#### Fluent API
Used in `DbContext.OnModelCreating()` for complex configurations:
- Relationships (one-to-one, one-to-many, many-to-many)
- Foreign keys
- Delete behaviors (Cascade, Restrict)
- Indexes
- Composite keys

**When to use Data Annotations vs Fluent API?**
- **Data Annotations**: Simple, attribute-based configurations directly on models
- **Fluent API**: Complex relationships, advanced configurations, or when you want to keep models clean

### Migrations
Located in `Migrations/` folder.

**What are Migrations?**
- Version control for database schema
- Track changes to database structure over time
- Enable database updates without manual SQL scripts

**Why Use Migrations?**
1. **Version Control**: Track all database changes
2. **Team Collaboration**: Share database schema changes
3. **Deployment**: Apply changes consistently across environments
4. **Rollback**: Revert to previous schema versions if needed

### Enums
Located in `Enums/` folder.

**Purpose**: Replace magic numbers/strings with type-safe constants.

**Examples**:
- `AttendanceStatus`: Good, Warning, Critical
- `LetterGrade`: A, B, C, D, F
- `CourseStatus`: Active, Inactive, Completed

**Benefits**:
- Type safety
- IntelliSense support
- Prevents typos
- Self-documenting code

### LINQ
Used extensively in repositories for querying and data transformations.

**Examples**:
- `.Where()`: Filtering
- `.Select()`: Projections
- `.Include()`: Eager loading
- `.FirstOrDefaultAsync()`: Single item queries
- `.ToListAsync()`: Materialize queries

## SOLID Principles Applied

1. **Single Responsibility**: Each class has one reason to change
   - Controllers handle HTTP
   - Services handle business logic
   - Repositories handle data access

2. **Open/Closed**: Open for extension, closed for modification
   - Extension methods extend functionality without modifying existing code

3. **Liskov Substitution**: Interfaces can be substituted with implementations
   - `IStudentService` can be replaced with `StudentService` or mock implementations

4. **Interface Segregation**: Clients shouldn't depend on interfaces they don't use
   - Separate interfaces for different concerns (`IStudentService`, `IStudentRepository`)

5. **Dependency Inversion**: Depend on abstractions, not concretions
   - Controllers depend on `IStudentService`, not `StudentService`
   - Services depend on `IStudentRepository`, not `StudentRepository`

## Project Structure
```
StudentPortalApi/
├── Controllers/          # API endpoints
├── Services/            # Business logic
├── Repositories/        # Data access
├── Interfaces/          # Contracts (interfaces)
├── Models/             # Domain entities
├── DTOs/               # Data Transfer Objects
├── Mappings/           # AutoMapper profiles
├── Data/               # DbContext and EF configuration
├── Extensions/         # Extension methods
├── Enums/              # Enum definitions
└── Migrations/         # EF Migrations
```

## API Attributes Used

### Routing
- `[Route("api/[controller]")]`: Base route for controller
- `[HttpGet("{id:int}")]`: Route parameter with type constraint

### Model Binding
- `[FromBody]`: Bind from request body
- `[FromRoute]`: Bind from route parameters
- `[FromQuery]`: Bind from query string

### Action Results
- `ActionResult<T>`: Type-safe return type
- `Ok()`: 200 OK
- `CreatedAtAction()`: 201 Created
- `NotFound()`: 404 Not Found
- `BadRequest()`: 400 Bad Request
- `NoContent()`: 204 No Content

### Documentation
- `[ProducesResponseType]`: Swagger documentation
- XML comments: API documentation

## Validation

### Model Validation
- Data Annotations on DTOs (`[Required]`, `[EmailAddress]`, etc.)
- `ModelState.IsValid` check in controllers
- Automatic validation by ASP.NET Core

### Business Validation
- Performed in Service layer
- Example: ID validation, business rule checks

## Error Handling
- Controllers return appropriate HTTP status codes
- Error messages in response body
- Model validation errors returned as BadRequest

## Testing Considerations
- Interfaces enable easy mocking
- Service layer can be tested independently
- Repository can be tested with in-memory database
- Controllers can be tested with mocked services

