require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();
const bodyParser = require("body-parser");
const dns = require('dns');
const { doesNotMatch } = require('assert');
const { error } = require('console');
const res = require('express/lib/response');

const shortenedUrls = [];

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
  let errorMessage = { error: 'invalid url' };

  let urlObject; try {
    urlObject = new URL(req.body.url);
  } catch {
    return res.json(errorMessage);
  }
  
  let urlIndex = null;

  for (let i = 0; i < shortenedUrls.length; i++) {
    if (shortenedUrls[i] == urlObject.origin) {
      urlIndex = i;
    }
  }

  if (urlIndex == null) {
    let urlVerification = new Promise((resolve, reject) => {
      dns.lookup(urlObject.hostname, (error) => {
        if (error) reject(error);
        else resolve(true);
      });
    });
    urlVerification.then(() => {
      shortenedUrls.push(urlObject.origin);
      urlIndex = shortenedUrls.length - 1;
      res.json({ "original_url" : shortenedUrls[urlIndex], "short_url" : urlIndex});
    }).catch(() => {
      return res.json(errorMessage);
    });
  } else {
    return res.json({ "original_url" : shortenedUrls[urlIndex], "short_url" : urlIndex});
  }
})

app.get('/api/shorturl/:shortUrl', (req, res) => {
  return res.redirect(shortenedUrls[req.params.shortUrl]);
})


