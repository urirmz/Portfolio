Reflection API
  Allows us to inspect or modify attributes of classes, interfaces, fields, and methods during runtime
  It's used by JUnit, Makita, Easy, Mock Power, Mock, Spring Framework and many others
  Common use cases include debugging, test tools, extensibility features and virtual development environments

java.lang.reflect package
  Provides classes and interfaces for obtaining reflective information about classes and objects
  Class class
    Instances of the class Class represent classes and interfaces in a running Java application
    Can be instantiated with the Object inherited method getClass()
    Main methods
      getName()
        Returns the name of the entity (class, interface, array class, primitive type, or void) represented by this Class object
      getFields()
        Returns an array containing Field objects reflecting all the accessible public fields
      getDeclaredFileds()
        Same as getFields(), but doesn't include inherited fields
      getGenericType()
        Returns a Type object that represents the declared type for the field represented by this Field object
      getPackageName()
        Returns the fully qualified package name as String
      getSuperclass()
        Returns the Class representing the direct superclass of the entity (class, interface, primitive type or void) 
          represented by this Class
      getInterfaces()
        Returns the interfaces directly implemented by the class or interface represented by this Class object
      forName()
        Returns the Class object associated with the class or interface with the given string name
      getDeclaredConstructors()
        Returns an array of Constructor objects reflecting all the constructors 
          implicitly or explicitly declared by the class represented by this Class object
      getMethods()
        Returns an array containing Method objects reflecting all the public methods of the class or interface 
          represented by this Class object, including those declared by the class or interface 
          and those inherited from superclasses and superinterfaces
      getDeclaredMethods()
        Same as getMethods(), but excluding inherited methods
  Field class
    Provides information about, and dynamic access to, a single field of a class or an interface
    May be a class (static) field or an instance field
    Main methods
      getModifier()
        Returns the Java language modifiers for the field represented by this Field object, as an integer
        The Modifier class should be used to decode the modifiers
      setAccesible(), checkCanSetAccessible(), getDeclaringClass(), getName(), getModifiers(), accessFlags(),
      isSynthetic(), getType(), getGenericType(), get(), set(), getAnnotation(), getAnnotationsByType(), getDeclaredAnnotations()
  Type interface
    Common superinterface for all types in the Java programming language
      Include raw types, parameterized types, array types, type variables and primitive types
    Defines the method getTypeName()
  Modifier class
    The Modifier class provides static methods and constants to decode class and member access modifiers
    Contains the static methods
      isPublic(), isPrivate(), isProtected(), isStatic(), isFinal(), isSynchronized(), isVolatile(), isTransient()
      isNative(), isInterface(), isAbstract(), isStrict(), toString(), isSynthetic(), isMandated()  
  Constructor class
    Provides information about, and access to, a single constructor for a class
    Extends executable
    Main methods
      getDeclaringClass(), getName(), getModifiers(), getTypeParameters(), getParameterCount(), 
      getGenericParameterTypes(), getExceptionTypes(), getGenericExceptionTypes(), newInstance(), 
      isVarArgs(), isSynthetic(), getAnnotation(), getDeclaredAnnotations(), getParameterAnnotations(),
      getAnnotatedReturnType(), getAnnotatedReceiverType()
  Method class
    Provides information about, and access to, a single method on a class or interface
    The reflected method may be a class method or an instance method (including an abstract method)
    Extends executable
      setAccessible(), getDeclaringClass(), getName(), getModifiers(), getTypeParameters(), getReturnType(),
      getGenericReturnType(), getParameterTypes(), getParameterCount(), getGenericParameterTypes(), 
      getExceptionTypes(), getGenericExceptionTypes(), isInvoke(), isVarArgs(), isSynthetic(), isDefault(),
      getDefaultValue(), getAnnotation(), getDeclaredAnnotations(), getParameterAnnotations(), getAnnotatedReturnType()
  AccesFlag enum
    Represents a JVM access or module-related flag on a runtime member, such as a class, field, or method
    Contains members
      PUBLIC, PRIVATE, PROTECTED, STATIC, FINAL, SUPER, OPEN, TRANSITIVE, SYNCHRONIZED, STATIC_PHASE, VOLATILE,
      BRIDGE, TRANSIENT, VARARGS, NATIVE, INTERFACE, ABSTRACT, STRICT, SYNTHETIC, ANNOTATION, ENUM, MANDATED, MODULE

Annotation
  Is a form of metadata that provides data about the program, but is not part of the program itself
    Annotations are nothing more than just information, logic is programmed in a separate place
  Can be annotated: types, classes and interfaces, fields, methods, parameters, constructors, 
    local variables, packages, modules, and even annotations itself
  Common uses cases include: information for the compiler, deployment time processing and runtime processing
  Each annotation is started with add sign followed by some meaningful name, 
    @Author
  Can include elements which can be named, and there are values for those elements
    @Author(name = "Michael Jackson")
  In case there is just one element associated with the annotation, element key can be substituted by just the value
    @SupressWarnings("rawtypes")
  It is also possible to use multiple annotations at once and from Java version eight there is even support
    of repeatable annotations
      @Override
	    @Author(name = "Vladymyr Vysotskiy")
	    @Author(name = "Konstantin Simonov")
	    public String toString()
  Annotations can be declared with the @interface keyword
    @Target(ElementType.METHOD) 
    @Retention(RetentionPolicy.RUNTIME)
    public @interface Test {
      Class<? extends Throwable> expected() default None.class;
	    String name() default "";
        /**
         * Default empty exception.
         */
        static class None extends Throwable {
            private None() {
            }
        }
    }
  Common annotations
    @Target
      Indicates the contexts in which an annotation interface is applicable
      Takes an array of ElementType enum
    @Retention
      Indicates how long annotations with the annotated interface are to be retained
      Takes a value of the RetentionPolicy enum
      If not present, the retention policy defaults to RetentionPolicy.CLASS
    @SupressWarnings
      It is used to inform the compiler to suppress specified compiler warnings
    @Override
      It is a marker annotation that can be used only on methods. A method annotated with @Override must override a method from a superclass
    @Deprecated
      It is a marker annotation. It indicates that a declaration is obsolete and has been replaced by a newer form
    @Repeatable
      It is used to indicate that the annotation interface whose declaration it (meta-) annotates is repeatable
    @Documented 
      Marker interface that tells the tool that the annotation should be documented
    @Inherited  
      Marker annotation that can be applied in another annotation declaration, 
      Only applies to annotations that will be used in class declarations
      Indicates that an annotation interface is automatically inherited
      Allows a super class annotation to be inherited in a subclass

