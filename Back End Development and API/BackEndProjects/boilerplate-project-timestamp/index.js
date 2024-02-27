// index.js
// where your node app starts

// init project
var express = require('express');
var app = express();

// enable CORS (https://en.wikipedia.org/wiki/Cross-origin_resource_sharing)
// so that your API is remotely testable by FCC 
var cors = require('cors');
app.use(cors({optionsSuccessStatus: 200}));  // some legacy browsers choke on 204

// http://expressjs.com/en/starter/static-files.html
app.use(express.static('public'));

// http://expressjs.com/en/starter/basic-routing.html
app.get("/", function (req, res) {
  res.sendFile(__dirname + '/views/index.html');
});


// your first API endpoint... 
app.get("/api/hello", function (req, res) {
  res.json({greeting: 'hello API'});
});

app.get("/api/", (req, res) => {
  res.json(getUnixUTCDate());
})

app.get("/api/:date", (req, res) => {
  res.json(getUnixUTCDate(req.params.date));
})


// Listen on port set in environment variable or default to 3000
var listener = app.listen(process.env.PORT || 3000, function () {
  console.log('Your app is listening on port ' + listener.address().port);
});


function getUnixUTCDate(date) {
  let utcDate;
  let unixDate;
 
  if (!date) {
    unixDate = Date.now();
    utcDate = new Date(unixDate).toUTCString();
  } else if (!isNaN(date)) {
    unixDate = parseInt(date);
    utcDate = new Date(unixDate).toUTCString();
  } else if (typeof date == "string" ) {
    utcDate = new Date(date).toUTCString();
    unixDate = Date.parse(utcDate);
  }

  if (utcDate == "Invalid Date") {
    return { "error" : "Invalid Date" };
  } else {
    return { "unix": unixDate, "utc": utcDate };
  }

}