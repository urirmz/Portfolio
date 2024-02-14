Mongo and Mongoose
You can connect to the database by calling the connect method within your myApp.js file by using the following syntax:
mongoose.connect(<Your URI>, { useNewUrlParser: true, useUnifiedTopology: true });

CRUD Part I - CREATE
First of all, we need a Schema. Each schema maps to a MongoDB collection. It defines the shape of the documents within that collection. Schemas are building blocks for Models. They can be nested to create complex models, but in this case, we'll keep things simple. A model allows you to create instances of your objects, called documents.
Replit is a real server, and in real servers, the interactions with the database happen in handler functions. These functions are executed when some event happens (e.g. someone hits an endpoint on your API). We’ll follow the same approach in these exercises. The done() function is a callback that tells us that we can proceed after completing an asynchronous operation such as inserting, searching, updating, or deleting. It's following the Node convention, and should be called as done(null, data) on success, or done(err) on error.
Warning - When interacting with remote services, errors may occur!
/* Example */
const someFunc = function(done) {
  //... do something (risky) ...
  if (error) return done(error);
  done(null, result);
};

Terminologies
Collections
Collections in Mongo are equivalent to tables in relational databases. They can hold multiple JSON documents.

Documents
Documents are equivalent to records or rows of data in SQL. While a SQL row can reference data in other tables, Mongo documents usually combine that in a document.

Fields
Fields, also known as properties or attributes, are similar to columns in a SQL table. In the image above, FirstName, LastName, Email, and Phone are all fields.

Schema
While Mongo is schema-less, SQL defines a schema via the table definition. A Mongoose schema is a document data structure (or shape of the document) that is enforced via the application layer.

SchemaTypes
While Mongoose schemas define the overall structure or shape of a document, SchemaTypes define the expected data type for individual fields (String, Number, Boolean, and so on).

You can also pass in useful options like required to make a field non-optional, default to set a default value for the field, and many more.

Models
Models are higher-order constructors that take a schema and create an instance of a document equivalent to records in a relational database.

Example
Here's a small code snippet to illustrate some of the terminology above:
const puppySchema = new mongoose.Schema({
  name: {
    type: String,
    required: true
  },
  age: Number
});

const Puppy = mongoose.model('Puppy', puppySchema);

In the code above, puppySchema defines the shape of the document which has two fields, name, and age.
The SchemaType for name is String and for age is Number. Note that you can define the SchemaType for a field by using an object with a type property like with name. Or you can apply a SchemaType directly to the field like with age.
Also, notice that the SchemaType for name has the option required set to true. To use options like required and lowercase for a field, you need to use an object to set the SchemaType.
At the bottom of the snippet, puppySchema is compiled into a model named Puppy, which can then be used to construct documents in an application.

mongodb+srv://urirmz:Uvasdemar123.@cluster0.hohuadm.mongodb.net/?retryWrites=true&w=majority