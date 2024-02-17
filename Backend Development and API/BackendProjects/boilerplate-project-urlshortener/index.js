require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();
const bodyParser = require("body-parser");
const dns = require('dns');

app.use(bodyParser.urlencoded({ extended: false }));

// Basic Configuration
const port = process.env.PORT || 3000;

app.use(cors());

app.use('/public', express.static(`${process.cwd()}/public`));

app.get('/', function(req, res) {
  res.sendFile(process.cwd() + '/views/index.html');
});

// Your first API endpoint
app.get('/api/hello', function(req, res) {
  res.json({ greeting: 'hello API' });
});

app.listen(port, function() {
  console.log(`Listening on port ${port}`);
});

app.post('/api/shorturl', (req, res) => {
  res.json(submitUrl(req.body.url));
})

let shortenedUrls = [];

function submitUrl(url) {
  let urlIndex = null;
  let validUrl;

  for (let i = 0; i < shortenedUrls.length; i++) {
    if (shortenedUrls[i] == url) {
      urlIndex = i;
    }
  }

  if (urlIndex == null) {
    dns.lookup(url, (err, address, family) => {
      validUrl = address;
    })
    console.log(validUrl);
    if (validUrl) {
      shortenedUrls.push(url);
      urlIndex = shortenedUrls.length - 1;
    } else {
      return { error: 'invalid url' };
    }
  }  
  
  return {
    "original_url": url,
    "short_url": urlIndex
  };
}