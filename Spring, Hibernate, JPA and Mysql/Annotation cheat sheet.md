Annotations
	Core Spring Annotations
		@Autowired
			Injects dependencies automatically by type. Reduces manual wiring in configuration files. 
		@Bean
			Indicates that a method produces a bean managed by Spring. Used in @Configuration classes to define beans. 
		@Component
			Marks a class as a Spring-managed component. Enables auto-detection during component scanning. 
		@Configuration
			Marks a class as a source of bean definitions. Defines beans using @Bean-annotated methods.
		@Controller
			Marks a class as a Spring MVC controller. Handles HTTP requests and integrates with view resolvers.
		@Qualifier("${bean_name}")
			Resolves ambiguity when multiple beans of the same type exist. Specifies which bean to inject by name.
		@Repository
			Marks a class as a Data Access Object (DAO). Enables exception translation from JDBC to Spring's DataAccessException.
		@Service
			Marks a class as a service layer component. Indicates business logic or service layer.
		@Value
			Injects values from properties/files into fields. Supports SpEL for dynamic value resolution.
		@Target
			Specifies the kinds of program elements (e.g., classes, methods, fields) to which an annotation type is applicable. Defines where the annotation can be used. Common values include:
			ElementType.TYPE (class, interface, enum), ElementType.METHOD (methods), ElementType.FIELD (fields), ElementType.PARAMETER (method parameters), ElementType.ANNOTATION_TYPE (other annotations)
		@Retention
			Specifies how long an annotation is retained (e.g., source, class, runtime). Determines the lifecycle of the annotation. Common values include:
			RetentionPolicy.SOURCE (discarded during compilation), RetentionPolicy.CLASS (retained in bytecode but not at runtime), RetentionPolicy.RUNTIME (retained at runtime for reflection)
	Spring Boot Annotations
		@SpringBootApplication(scanBasePackages)
			Entry point for Spring Boot apps. Combines @Configuration, @EnableAutoConfiguration, and @ComponentScan.
	Spring MVC & REST Annotations
		@ControllerAdvice
			Global exception handler for controllers. Centralizes exception handling across multiple controllers.
		@DeleteMapping, @GetMapping, @PatchMapping, @PostMapping, @PutMapping
			Shortcuts for @RequestMapping with specific HTTP methods. Maps HTTP requests to handler methods.
		@ExceptionHandler
			Handles exceptions at the controller level. Customizes error responses for specific exceptions.
		@InitBinder
			Customizes data binding for request parameters. Registers property editors or validators.
		@ModelAttribute
			Binds a method parameter or return value to a model attribute. Exposes data to the view layer.
		@RequestBody
			Binds HTTP request body to a method parameter. Deserializes JSON/XML payloads into objects.
		@RepositoryRestResource
			Exposes JPA repositories as REST endpoints. Auto-generates CRUD APIs via Spring Data REST.
		@RequestMapping
			Maps HTTP requests to handler methods. Configures URL paths, methods, headers, etc.
		@RestController
			Combines @Controller and @ResponseBody. Simplifies RESTful web service development.
	Data Access & JPA Annotations
	  @Column(name="${column_name}")
			Maps a field to a database column. Customizes column name and properties (e.g., nullable, length).
	  @Entity
			Marks a class as a JPA entity. Maps the class to a database table.
		@GeneratedValue(strategy = GenerationType)
			Configures primary key generation strategy. Supports auto-increment, sequence, or UUID strategies.
		@Id
			Marks a field as the primary key. Identifies the unique identifier for an entity.
		@Table(name="${table_name}")
			Specifies the database table name for an entity. Overrides the default table name.
		@Transactional
			Defines transaction boundaries for methods/classes. Manages ACID properties for database operations.
		@JoinColumn(name=${column_name})
			Tells this column contains a foreign key. Hibernate will look at the declared class entity id to join this column with its pair
		@JoinTable(name=${table_name}, joinColumns=${column_name}, inverseJoinColumns=${column_name})
			Tells this property refers to a column in a join table (a many to many relation). 
			Name refers to the join table name in the database
			joinColumns refers to the join column in the database that matches this entity id	
			inverseJoinColumns refers to the join column in the database that matches the declared property entity id	
		@JoinColumn(name)
			Refers to a column inside a join table
		@OneToOne(cascade=CascadeType, mappedBy=${property}, fetch=FetchType)
			Tells Hibernate this property has a one to one relation with the declared entity, which means one of this class can be related to one of the declared property
			Cascade means that any operation applied to this entity will also happen to the related entities. By default in OneToOne, no operations are cascaded
			The mappedBy property tells Hibernate this object is reffered in the declared property class as the declared property
			The fetch property tells Hibernate to retrieve the property entity at the same time that this entity. The default fetch in OnToOne is FetchType.EAGER
		@OneToMany(cascade=CascadeType, mappedBy=${property}, fetch=FetchType)
			Tells Hibernate this property has a one to many relation with the declared entity, which means one of this class can be related to many of the declared property
			Cascade means that any operation applied to this entity will also happen to the related entities. By default in OneToMany, no operations are cascaded
			The mappedBy property tells Hibernate this entity is reffered in the declared property class as the declared property
			The fetch property tells Hibernate to retrieve the property entity at the same time that this entity. The default fetch in OneToMany is FetchType.LAZY
		@ManyToOne(cascade=CascadeType, fetch=FetchType)
			Tells Hibernate this property has a many to one relation with the declared entity, which means many of this class can be related to one of the declared property
			Cascade means that any operation applied to this entity will also happen to the related entities. By default in ManyToMany, no operations are cascaded
			The fetch property tells Hibernate to retrieve the property entity at the same time that this entity. The default fetch in OneToMany is FetchType.EAGER
		@ManyToMany(cascade=CascadeType, fetch=FetchType)
			Tells Hibernate this property has a many to many relation with the declared entity, which means many of this class can be related to many of the declared property
			Cascade means that any operation applied to this entity will also happen to the related entities. By default in ManyToMany, no operations are cascaded
			The fetch property tells Hibernate to retrieve the property entity at the same time that this entity. The default fetch in ManyToMany is FetchType.LAZY
	Validation Annotations
		@Future
			Validates that a date is in the future.
		@Max(value)
			Validates a number does not exceed the specified maximum.
		@Min(value)
			Validates a number is at least the specified minimum.
		@NotNull
			Validates a field is not null.
		@Past
			Validates that a date is in the past.
		@Pattern(regexp)
			Validates a string against a regex pattern.
		@Size(min, max)
			Validates collection/string size within bounds.
		@Valid
			Triggers validation on an object. Cascades validation to nested properties.
		@Constraint(validateBy)
			Marks an annotation as a custom constraint for validation. Links the annotation to a validator class that implements the validation logic. It is used in conjunction with the Bean Validation API (javax.validation). 
			validatedBy: Specifies the validator class(es) that implement the constraint.
	Bean Scoping & Lifecycle Annotations
		@Lazy
			Delays bean initialization until first use. Reduces startup time for rarely used beans.
		@PostConstruct
			Marks a method to execute after bean initialization. Used for setup tasks (e.g., opening resources).
		@PreDestroy
			Marks a method to execute before bean destruction. Used for cleanup tasks (e.g., closing resources).
		@Scope(ConfigurableBeanFactory)
			Configures bean scope (e.g., singleton, prototype). Controls bean lifecycle and instance creation.

Classes
	Spring MVC & Web Classes
		HttpServletRequest
			Represents an HTTP request (from javax.servlet). Provides access to request headers, parameters, and body in controllers.
		Model
			Interface for passing data between controllers and views. Stores attributes exposed to the view layer (e.g., Thymeleaf, JSP).
		ResponseEntity<T>
			Wraps an HTTP response with status code, headers, and body. Used in REST controllers to customize response details.
		StringTrimmerEditor
			Property editor to trim whitespace from strings. Automatically trims input fields during data binding (e.g., with @InitBinder).
		WebDataBinder
			Binds request parameters to Java objects. Validates and formats data, registers custom editors (e.g., StringTrimmerEditor).
		ConstraintValidator<Annotation, Value>
			Is an interface provided by the Bean Validation API (javax.validation) that defines the contract for implementing custom validation logic. 
			It is used in conjunction with the @Constraint annotation to create custom validation constraints in Spring applications.
	Spring Data JPA Classes
		EntityManager
			Interface for JPA operations (e.g., persisting, querying entities). Manages entity lifecycle and database interactions.
		JpaRepository<T, ID>
			Spring Data interface for CRUD operations on JPA entities. Simplifies database access with built-in methods (e.g., save, findAll).
		TypedQuery<T>
			JPA query with a defined result type. Executes type-safe JPQL or native SQL queries.
	Spring Security Classes
		HttpSecurity
			Configures HTTP security rules (e.g., authentication, authorization). Defines access control for endpoints, CSRF, and session management.
		InMemoryUserDetailsManager
			Stores user credentials in memory (for testing/demo). Implements UserDetailsManager for in-memory user management.
		JdbcUserDetailsManager
			Manages user authentication via JDBC (uses database). Extends UserDetailsManager to store/retrieve users from a DataSource.
		SecurityFilterChain
			Defines the order and configuration of security filters. Customizes request handling for authentication/authorization.
		User.builder
			Fluent builder for creating UserDetails objects. Simplifies user creation with roles, passwords, and status flags.
		UserDetails
			Interface representing core user information. Provides authentication details (username, password, roles).
		UserDetailsManager
			Extends UserDetailsService to support user management (create/update/delete). Manages user accounts in persistent storage.
	Data Source & JDBC Classes
		DataSource
			Factory for database connections (part of JDBC). Centralizes database configuration (URL, credentials, pooling).

Configurations
	application.properties
    	spring.jpa.hibernate.ddl-auto=update
	messages.properties
		typeMismatch.${model}.${property}