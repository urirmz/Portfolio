Node.js
Node is just a JavaScript environment. Like client side JavaScript, you can use the console to display useful debug information. On your local machine, you would see console output in a terminal

myApp.js
In the first two lines of the file myApp.js, you can see how easy it is to create an Express app object. This object has several methods, and you will learn many of them in these challenges.

app.listen()
One fundamental method is app.listen(port). It tells your server to listen on a given port, putting it in running state

In Express, routes takes the following structure: app.METHOD(PATH, HANDLER). METHOD is an http method in lowercase. PATH is a relative path on the server (it can be a string, or even a regular expression). HANDLER is a function that Express calls when the route is matched. Handlers take the form function(req, res) {...}, where req is the request object, and res is the response object. For example, the handler:
function(req, res) {
  res.send('Response String');
}
will serve the string 'Response String'.

Serve an HTML File
You can respond to requests with a file using the res.sendFile(path) method. You can put it inside the app.get('/', ...) route handler. Behind the scenes, this method will set the appropriate headers to instruct your browser on how to handle the file you want to send, according to its type. Then it will read and send the file. This method needs an absolute file path. We recommend you to use the Node global variable __dirname to calculate the path like this:
req.params: {userId: '546', bookId: '6754'}

Get Query Parameter Input from the Client
Another common way to get input from the client is by encoding the data after the route path, using a query string. The query string is delimited by a question mark (?), and includes field=value couples. Each couple is separated by an ampersand (&). Express can parse the data from the query string, and populate the object req.query. Some characters, like the percent (%), cannot be in URLs and have to be encoded in a different format before you can send them. If you use the API from JavaScript, you can use specific methods to encode/decode these characters.
route_path: '/library'
actual_request_URL: '/library?userId=546&bookId=6754'
req.query: {userId: '546', bookId: '6754'}

Use body-parser to Parse POST Requests
Besides GET, there is another common HTTP verb, it is POST. POST is the default method used to send client data with HTML forms. In REST convention, POST is used to send data to create new items in the database (a new user, or a new blog post). You don’t have a database in this project, but you are going to learn how to handle POST requests anyway.
In these kind of requests, the data doesn’t appear in the URL, it is hidden in the request body. The body is a part of the HTTP request, also called the payload. Even though the data is not visible in the URL, this does not mean that it is private. To see why, look at the raw content of an HTTP POST request:
POST /path/subpath HTTP/1.0
From: john@example.com
User-Agent: someBrowser/1.0
Content-Type: application/x-www-form-urlencoded
Content-Length: 20
name=John+Doe&age=25
As you can see, the body is encoded like the query string. This is the default format used by HTML forms. With Ajax, you can also use JSON to handle data having a more complex structure. There is also another type of encoding: multipart/form-data. This one is used to upload binary files. In this exercise, you will use a URL encoded body. To parse the data coming from POST requests, you must use the body-parser package. This package allows you to use a series of middleware, which can decode data in different formats.

Get Data from POST Requests
Mount a POST handler at the path /name. It’s the same path as before. We have prepared a form in the html frontpage. It will submit the same data of exercise 10 (Query string). If the body-parser is configured correctly, you should find the parameters in the object req.body. Have a look at the usual library example:
route: POST '/library'
urlencoded_body: userId=546&bookId=6754
req.body: {userId: '546', bookId: '6754'}
Respond with the same JSON object as before: {name: 'firstname lastname'}. Test if your endpoint works using the html form we provided in the app frontpage.
Tip: There are several other http methods other than GET and POST. And by convention there is a correspondence between the http verb, and the operation you are going to execute on the server. The conventional mapping is:
POST (sometimes PUT) - Create a new resource using the information sent with the request,
GET - Read an existing resource without modifying it,
PUT or PATCH (sometimes POST) - Update a resource using the data sent,
DELETE - Delete a resource.
There are also a couple of other methods which are used to negotiate a connection with the server. Except from GET, all the other methods listed above can have a payload (i.e. the data into the request body). The body-parser middleware works with these methods as well.

