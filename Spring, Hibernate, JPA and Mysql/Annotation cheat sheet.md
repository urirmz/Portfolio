Annotations:
    @SpringBootApplication(scanBasePackages = {"com.luv2code.springcoredemo","com.luv2code.util"})
    @PostConstruct:
    @PreDestroy:
    @Qualifier(${x}):
    @Configuration:
    @Component:
    @Controller
    @RESTController
    @RequestBody
    @InitBinder:
    @Autowired:
    @Value:
    @RequestMapping:
    @Lazy:
    @${HTTP Verb}Mapping: 
    @Scope(ConfigurableBeanFactory);
    @Entity
    @Table(name="${x}")
    @Id
    @GeneratedValue(strategy = GenerationType)
    @Column(name="${x}")
    @Repository
    @Transactional
    @Bean
    @ExceptionHandler
Classes:
    WebDataBinder 
    StringTrimmerEditor
    EntityManager
    TypedQuery<T>
    UserDetailsManager
    JdbcUserDetailsManager
    Datasource
    InMemoryUserDetailsManager
    UserDetails
    User.builder
    SecurityFilterChain
    HttpSecurity

Configurations:
    spring.jpa.hibernate.ddl-auto=update